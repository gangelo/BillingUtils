using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BillingUtils.Code {

	public class MonthlyTimesheets : IEnumerable, IEnumerator, IXmlable<TimesheetMonth> {
		// Fields
		// --------------------------------------------------------------------------
		#region Fields
		static private object m_synchRoot = new object();
		private bool m_suspendChangedEvent;
		protected Collection<Timesheet> m_collection;
		protected virtual int EnumeratorIndex { get; set; }
		public EventHandler<MonthlyTimesheetChangedEventArgs> MonthlyTimesheetChangedEvent { get; set; }
		public virtual TimesheetMonth TimesheetMonth { get; protected set; }
		public virtual int? InvoiceNumber { get; set; }
		public string FileName { get; protected set; }		
		#endregion	// Fields

		// Construction/Initialization
		// --------------------------------------------------------------------------
		#region Construction/Initialization
		public MonthlyTimesheets(TimesheetMonth timesheetMonth, XElement element) {
			this.FromXml(timesheetMonth, element);
		}

		public MonthlyTimesheets(TimesheetMonth timesheetMonth) {
			this.Initialize();
			this.LoadMonthlyTimesheets(timesheetMonth);			
		}

		protected virtual void Initialize() {
			this.EnumeratorIndex = 0;
			this.Timesheets = new Collection<Timesheet>();
		} 
		#endregion	// Construction/Initialization

		// Properties
		// --------------------------------------------------------------------------
		#region Properties
		static protected string MonthlyTimesheetFileNameFormatString{
			get { return "Monthly Timesheets {0}-{1:00}.xml"; }
		}

		public bool HasInvoiceNumber {
			get { return (this.InvoiceNumber.GetValueOrDefault(0) > 0); }
		} 
		#endregion	// Properties

		protected virtual void LoadMonthlyTimesheets(TimesheetMonth timesheetMonth) {
			this.SuspendChangedEvent(true);

			this.Clear();

			this.TimesheetMonth = timesheetMonth;

			string fileName = string.Format(MonthlyTimesheets.MonthlyTimesheetFileNameFormatString, this.TimesheetMonth.Year, this.TimesheetMonth.Month);
			this.FileName = Path.Combine(new string[] { Configuration.Configuration.Instance.UserDataFolder, fileName });
			if (!File.Exists(this.FileName)) {
				CreateXmlDocument(this.FileName);
			} else {
				LoadXmlDocument(this.FileName);
			}

			this.SuspendChangedEvent(false);
		}

		protected void CreateXmlDocument(string fileName) {
			int year = this.TimesheetMonth.Year;
			int month = this.TimesheetMonth.Month;			

			DateTime startDate = new DateTime(year, month, 1);
			DateTime endDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));

			TimesheetMonth timesheetMonth = new TimesheetMonth(startDate.Year, startDate.Month);

			// Get our invoice number to use.			
			int invoiceNumber = MonthlyTimesheets.GetPreviousInvoiceNumberOrDefault(new DateTime(year, month, 1).AddMonths(-1));
			this.InvoiceNumber = ++invoiceNumber;

			// Capture the day of week...
			DayOfWeek dayOfWeek = startDate.DayOfWeek;

			// If the day of week is not a Monday, we need to calculate backwards or
			// forwards to get to the Monday we want...
			if (dayOfWeek != DayOfWeek.Monday) {
				double daysToAdd = 0;

				if (dayOfWeek < DayOfWeek.Monday) {
					daysToAdd = Convert.ToDouble(DayOfWeek.Monday - dayOfWeek);
				} else if (startDate.DayOfWeek > DayOfWeek.Monday) {
					daysToAdd = -Convert.ToDouble(dayOfWeek - DayOfWeek.Monday);
				}

				startDate = startDate.AddDays(daysToAdd);
			}
						
			DateTime monday = startDate;
			for (int i = 0; monday <= endDate; i++) {
				DateTime mondayPlus6 = monday.AddDays(6);

				if (!Timesheet.WouldTimesheetSplit(timesheetMonth, monday, mondayPlus6)) {
					this.Add(monday, mondayPlus6, i);
				} else {
					this.Add(monday, mondayPlus6, i, 0);
					this.Add(monday, mondayPlus6, i, 1);
				}

				monday = monday.AddDays(7);	// see if we can get the next Monday...
			}			

			// Save the changes.
			XElement root = new XElement(this.ToXml());
			root.Save(fileName);
		}		

		protected void LoadXmlDocument(string fileName) {
			XElement root = XElement.Load(fileName);
			
			// Note: No need to perform the below.  this.TimesheetMonth is
			// updated prior to calling this member.
			//int year = Convert.ToInt32(root.Attribute("timesheetYear").Value);
			//int month = Convert.ToInt32(root.Attribute("timesheetMonth").Value);
			//this.TimesheetMonth = new TimesheetMonth(year, month);
			// _PRIORITY_: This is new 2011-02-15!!!
			int invoiceNumber = Convert.ToInt32(root.Attribute("invoiceNumber").Value);

			if (invoiceNumber == 0) {
				// Get our invoice number to use.				
				invoiceNumber = MonthlyTimesheets.GetPreviousInvoiceNumberOrDefault(new DateTime(this.TimesheetMonth.Year, this.TimesheetMonth.Month, 1).AddMonths(-1));
				++invoiceNumber;
			}
			this.InvoiceNumber = invoiceNumber;

			foreach (XElement timesheetElement in root.XPathSelectElements("./timesheet")) {
				Timesheet timesheet = new Timesheet(this, timesheetElement);
				this.Add(timesheet);
			}
		}

		public virtual void Save() {
			string fileName = this.FileName;
			XElement root = this.ToXml();
			root.Save(fileName);
		}

		// Add Members
		// --------------------------------------------------------------------------
		#region Add Members
		protected virtual void Add(DateTime startDate, DateTime endDate, int weekIndex) {
			this.Add(new Timesheet(this, startDate, endDate, weekIndex));
		}

		protected virtual void Add(DateTime startDate, DateTime endDate, int weekIndex, int splitIndex) {
			this.Add(new Timesheet(this, startDate, endDate, weekIndex, splitIndex));
		}

		protected virtual void Add(Timesheet timesheet) {
			this.Timesheets.Add(timesheet);
			this.AttachChangedEvent(timesheet);

			// If suspend changed event is not set, notify anyone who needs to know that
			// this monthly timesheet has changed...
			if (!this.IsSuspendChangedEvent && this.MonthlyTimesheetChangedEvent != null) {
				this.MonthlyTimesheetChangedEvent(this, new MonthlyTimesheetChangedEventArgs(this));
			}
		} 
		#endregion	// Add Members

		// Properties
		// --------------------------------------------------------------------------
		#region Properties
		public virtual bool IsSuspendChangedEvent {
			get { return m_suspendChangedEvent; }
			protected set { m_suspendChangedEvent = value; }
		}

		/// <summary>
		/// Returns all Timesheets that have been sent.
		/// </summary>
		public virtual Timesheet[] SentTimesheets {
			get { return this.Timesheets.Where(p => p.TimesheetSent).ToArray(); }
		}

		/// <summary>
		/// Returns the count of Timesheets that have been sent.
		/// </summary>
		public virtual int SentTimesheetCount {
			get { return this.Timesheets.Count(p => p.TimesheetSent); }
		}

		/// <summary>
		/// Returns all Timesheets that have NOT been sent.
		/// </summary>
		public virtual Timesheet[] UnSentTimesheets {
			get { return this.Timesheets.Where(p => !p.TimesheetSent).ToArray(); }
		}

		/// <summary>
		/// Returns the count of Timesheets that have NOT been sent.
		/// </summary>
		public virtual int UnSentTimesheetCount {
			get { return this.Timesheets.Count(p => !p.TimesheetSent); }
		}
		#endregion	// Properties

		public virtual void SuspendChangedEvent(bool suspend) {
			this.IsSuspendChangedEvent = suspend;
		}

		public virtual decimal GetBillableHours() {
			if (this.Timesheets.Count == 0) {
				return 0m;
			} else {
				return this.Timesheets.Sum(p => p.GetBillableHours());
			}
		}

		public virtual decimal GetInvoiceAmount() {
			if (this.Timesheets.Count == 0) {
				return 0m;
			} else {
				return this.Timesheets.Sum(p => p.GetInvoiceAmount());
			}
		}

		public virtual string GetFormattedInvoiceAmount() {
			return this.GetInvoiceAmount().ToString("C");
		}

		public virtual string GetFileName() {
			const string fileNameFormatString = "Invoice {0}-{1:00}.xlsx";
			int timesheetYear = this.TimesheetMonth.Year;
			int timesheetMonth = this.TimesheetMonth.Month;
			return string.Format(fileNameFormatString, timesheetYear, timesheetMonth);
		}

		/// <summary>
		/// Removes all Timesheets from the collection and resets the Enumerator position.
		/// </summary>
		public virtual void Clear() {
			this.Initialize();
		}

		public virtual int Count {
			get { return this.Timesheets.Count(); }
		}

		public virtual Timesheet this[int index] {
			get { return this.Timesheets[index]; }
		}

		public virtual Collection<Timesheet> Timesheets {
			get { return m_collection; }
			set {
				m_collection = value;

				foreach (Timesheet timesheet in m_collection) {
					this.AttachChangedEvent(timesheet);
				}

				// If suspend changed event is not set, notify anyone who needs to know that
				// this monthly timesheet has changed...
				if (!this.IsSuspendChangedEvent && this.MonthlyTimesheetChangedEvent != null) {
					this.MonthlyTimesheetChangedEvent(this, new MonthlyTimesheetChangedEventArgs(this));
				}
			}
		}

		#region IEnumerable Members
		IEnumerator IEnumerable.GetEnumerator() {
			return this.Timesheets.GetEnumerator();
		}
		#endregion	// IEnumerable Members

		#region IEnumerator Members
		public virtual object Current {
			get {
				try {
					try {
						return this.Timesheets[this.EnumeratorIndex];
					} catch (IndexOutOfRangeException) {
						throw new InvalidOperationException();
					}
				} finally {
				}
			}
		}

		public virtual bool MoveNext() {
			this.EnumeratorIndex++;
			return (this.EnumeratorIndex < this.Timesheets.Count);
		}

		public virtual void Reset() {
			this.EnumeratorIndex = -1;
		}
		#endregion // IEnumerator Members

		protected virtual void AttachChangedEvent(Timesheet timesheet) {
			timesheet.TimesheetChangedEvent += new EventHandler<TimesheetChangedEventArgs>(
				delegate(object sender, TimesheetChangedEventArgs e) {
					// If suspend changed event is not set, notify anyone who needs to know that
					// this monthly timesheet has changed...
					if (!this.IsSuspendChangedEvent && this.MonthlyTimesheetChangedEvent != null) {
						this.MonthlyTimesheetChangedEvent(this, new MonthlyTimesheetChangedEventArgs(this));
					}
				});
		}

		// IXmlable Members
		// --------------------------------------------------------------------------
		#region IXmlable Members
		public void FromXml(TimesheetMonth timesheetMonth, XElement element) {
			this.TimesheetMonth = timesheetMonth;
			// Load invoiceNumber here...
			// Add timesheets here...
			this.Initialize();
			throw new NotImplementedException();
		}

		public XElement ToXml() {
			XElement element = new XElement("root",
				new XAttribute("timesheetYear", this.TimesheetMonth.Year),
				new XAttribute("timesheetMonth", this.TimesheetMonth.Month),
				new XAttribute("invoiceNumber", this.InvoiceNumber ?? 0)
				);

			foreach (Timesheet timesheet in this.Timesheets) {
				element.Add(timesheet.ToXml());
			}

			return element;
		}
		#endregion	// IXmlable Members		

		// Calculations
		// --------------------------------------------------------------------------
		#region Calculations
		public int GetDayTypeCount(DayType dayType) {
			int count = 0;

			// Calculate only VALID TimesheetDates!			
			foreach (Timesheet timesheet in this.Timesheets) {
				count += timesheet.GetDayTypeCount(dayType);				
			}

			return count;
		}

		/// <summary>
		/// Returns the Weekday count for all Timesheets, that is, the number of TimesheetDate objects in 
		/// each Timesheet object that are marked IsWeenday == true.
		/// </summary>		
		/// <returns>The total number of TimesheetDate objects in each Timesheet objects where IsValidDate == true and IsWeekday == true.</returns>
		/// <remarks>If TimesheetDate.IsValidDate return false, that date is not included in the final count.</remarks>
		public int GetWeekdayCount() {
			return this.Timesheets.Sum(p => p.GetWeekdayCount());
		}

		/// <summary>
		/// Returns the Weekend count for all Timesheets, that is, the number of TimesheetDate objects in 
		/// each Timesheet object that are marked IsWeenday == true.
		/// </summary>		
		/// <returns>The total number of TimesheetDate objects in each Timesheet objects where IsValidDate == true and IsWeekend == true.</returns>
		/// <remarks>If TimesheetDate.IsValidDate return false, that date is not included in the final count.</remarks>
		public int GetWeekendCount() {
			return this.Timesheets.Sum(p => p.GetWeekendCount());
		}
		#endregion	// Calculations

		// Helper Members
		// --------------------------------------------------------------------------
		#region Helper Members
		/// <summary>
		/// Returns the previous Invoice number user, or, the default invoice number provided.
		/// </summary>
		/// <param name="startDate">The year/month to start the search.</param>		
		/// <param name="defaultInvoiceNumber">The default invoice number to return if no previous invoice number is found.</param>
		/// <returns>The previous invoice number used, or, the default provided by the defaultInvoiceNumber parameter.</returns>
		static public int GetPreviousInvoiceNumberOrDefault(DateTime startDateTime, int defaultInvoiceNumber = 0) {
			lock (m_synchRoot) {
				int startYear = startDateTime.Year;
				int startMonth = startDateTime.Month;

				DateTime dateTime = new DateTime(startYear, startMonth, 1);
				string fileName = Path.Combine(
					new string[] { 
						Configuration.Configuration.Instance.UserDataFolder, 
						string.Format(MonthlyTimesheets.MonthlyTimesheetFileNameFormatString, dateTime.Year, dateTime.Month) 
					}
				);

				if (File.Exists(fileName)) {
					XElement root = XElement.Load(fileName);					
					int invoiceNumber;
					if (Int32.TryParse(root.Attribute("invoiceNumber").Value, out invoiceNumber)) {
						defaultInvoiceNumber = (invoiceNumber == 0) ? defaultInvoiceNumber : invoiceNumber;
					}
				}
				return defaultInvoiceNumber;
			}
		}
		#endregion	// Helper Members
	};
};
