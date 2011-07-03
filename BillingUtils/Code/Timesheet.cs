using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

using BillingUtils.Code.Enums;
using BillingUtils.Code.Helpers;
using BillingUtils.Code.Configuration;

namespace BillingUtils.Code {

	public class Timesheet : IEnumerable, IEnumerator, IXmlable<MonthlyTimesheets> {
		// Fields
		// --------------------------------------------------------------------------
		#region Fields
		public enum ImageListIndexes : int {
			Locked
		};

		static private object m_syncRoot = new object();

		protected virtual int EnumeratorIndex { get; set; }
		public virtual int WeekIndex { get; protected set; }
		public virtual int SplitIndex { get; protected set; }
		public virtual bool TimesheetSent { get; set; }
		protected Collection<TimesheetDate> m_collection;
		
		public EventHandler<TimesheetChangedEventArgs> TimesheetChangedEvent { get; set; }
		#endregion	// Fields

		// Construction
		// --------------------------------------------------------------------------
		#region Construction
		public Timesheet(MonthlyTimesheets monthlyTimesheets, XElement element) {			
			this.FromXml(monthlyTimesheets, element);			
		}	

		public Timesheet(MonthlyTimesheets monthlyTimesheets, DateTime startDate, DateTime endDate, int weekIndex)
			: this(monthlyTimesheets, startDate, endDate, weekIndex, -1) {
		}

		public Timesheet(MonthlyTimesheets monthlyTimesheets, DateTime startDate, DateTime endDate, int weekIndex, int splitIndex) {
			this.MonthlyTimesheets = monthlyTimesheets;
			this.Initialize(startDate, endDate, weekIndex, splitIndex, false);
		}

		protected virtual	void Initialize(DateTime startDate, DateTime endDate, int weekIndex, int splitIndex, bool timesheetSent) {
			if (startDate.Date.DayOfWeek != DayOfWeek.Monday) {
				throw new ArgumentException("Timesheet startDate must be Monday.");
			} else {
				this.Initialize();

				//this.TimesheetMonth = timesheetMonth;
				this.WeekIndex = weekIndex;
				this.SplitIndex = splitIndex;
				this.LoadDates(startDate, endDate);
				this.TimesheetSent = timesheetSent;

				if (this.IsSplitTimesheet && (this.SplitIndex < 0 || this.SplitIndex > 1)) {
					// splitIndex must be > -1 for split timesheets...
					throw new ArgumentException("splitIndex cannot be < 0 or > 1 for split timesheets. Please specify splitIndex >= 0 and <= 1 for split timesheets.");
				} else if (!this.IsSplitTimesheet && this.SplitIndex > -1) {
					// splitIndex cannot be > -1 for NON-split timesheets...
					throw new ArgumentException("splitIndex cannot be >= 0 for NON-split timesheets. Please specify splitIndex == -1 (or omit this parameter) for NON-split timesheets.");
				}

				// Note: we need set this.SplitIndex and call this.LoadDates(...) prior to calling this method because
				// initialization of TimesheetDate values is dependent on verified split timesheet settings for this
				// timesheet...
				InitializeTimesheetDateValues();
			}
		}

		protected virtual void Initialize() {
			this.EnumeratorIndex = 0;
			this.Dates = new Collection<TimesheetDate>();
		}
		#endregion	// Construction
			
		// Properties
		// --------------------------------------------------------------------------
		#region Properties
		public MonthlyTimesheets MonthlyTimesheets { get; protected set; }

		public virtual TimesheetDate StartDate {
			get { return this.Dates.First(); }
		}

		public virtual TimesheetDate EndDate {
			get { return this.Dates.Last(); }
		}

		public virtual int WeekNumber {
			get { return this.WeekIndex + 1; }
		}

		/// <summary>
		/// Returns true if the timesheet's start and end dates contain the 15th of the month,
		/// and, the 15th of the month DOES NOT fall on a weekend.
		/// </summary>
		public virtual bool IsSplitTimesheet {
			get {
				TimesheetMonth timesheetMonth = this.MonthlyTimesheets.TimesheetMonth;
				DateTime fifteenthOfMonth = new DateTime(timesheetMonth.Year, timesheetMonth.Month, 15);
				if (this.Dates.Count(p => p.Date.Day == 15) > 0) {
					if (fifteenthOfMonth.DayOfWeek == DayOfWeek.Saturday || fifteenthOfMonth.DayOfWeek == DayOfWeek.Sunday) {
						return false;
					} else {
						return true;
					}
				} else {
					// If the 15th does not fall within this timesheet, it is not a split timesheet.
					return false;
				}
			}
		}

		/// <summary>
		/// Returns true if this Timesheet's TimesheetDate's do not have the same Rate (e.g. a Rate increase/decrease occurred).
		/// </summary>
		/// <returns>true if this Timesheet has TimesheetDate's with different Rates.</returns>
		public bool IsSplitRate() {			
			var rateCount = (from u in this.Dates
						  select new {
							  u.RatePerHour
						  }).Distinct().Count();
			return rateCount > 1;			
		}
		#endregion	// Properties			

		// Collection Methods
		// --------------------------------------------------------------------------
		#region Collection Methods
		protected virtual void AddRange(IEnumerator<TimesheetDate> dates) {
			while (dates.MoveNext()) {
				this.Dates.Add(dates.Current);
			}
		}

		/// <summary>
		/// Removes all Timesheets from the collection and resets the Enumerator position.
		/// </summary>
		public virtual void Clear() {
			this.Initialize();

			// This is taken care of when this.Date is set in Initialize()...
			//if (this.TimesheetChangedEvent != null) {
			//   this.TimesheetChangedEvent(this, new TimesheetChangedEventArgs(this));
			//}
		}

		public virtual TimesheetDate this[int index] {
			get { return this.Dates[index]; }
		}

		public virtual Collection<TimesheetDate> Dates {
			get { return m_collection; }
			protected set { 
				m_collection = value;

				if (this.TimesheetChangedEvent != null) {
					this.TimesheetChangedEvent(this, new TimesheetChangedEventArgs(this));
				}
			}
		} 
		#endregion	// Collection Methods

		#region IEnumerable Members
		IEnumerator IEnumerable.GetEnumerator() {
			return this.Dates.GetEnumerator();
		}
		#endregion	// IEnumerable Members

		#region IEnumerator Members
		public virtual object Current {
			get {
				try {
					try {
						return this.Dates[this.EnumeratorIndex];
					} catch (IndexOutOfRangeException) {
						throw new InvalidOperationException();
					}
				} finally {
				}
			}
		}

		public virtual bool MoveNext() {
			this.EnumeratorIndex++;
			return (this.EnumeratorIndex < this.Dates.Count);
		}

		public virtual void Reset() {
			this.EnumeratorIndex = -1;
		}
		#endregion // IEnumerator Members

		// General Methods
		// --------------------------------------------------------------------------
		#region General Methods
		protected virtual void LoadDates(DateTime startDate, DateTime endDate) {
			DateTime date = startDate;

			while (date <= endDate) {
				TimesheetDate timesheetDate = new TimesheetDate(this, date);
				this.Dates.Add(timesheetDate);
				date = date.AddDays(1);
			}

			// Note: DO NOT kick off the timesheet changed event because the timesheet
			// values have not been initialized. It is the programmer's responsibility
			// to call this event upon initializing the timeseet date values...

			//if (this.TimesheetChangedEvent != null) {
			//   this.TimesheetChangedEvent(this, new TimesheetChangedEventArgs(this));
			//}
		}

		protected virtual void InitializeTimesheetDateValues() {
			foreach (TimesheetDate date in this.Dates) {
				decimal defaultBillableHours = Timesheet.GetBillableHoursDefault(this, date.Date);
				date.BillableHours = defaultBillableHours;				

				// Attach to the TimesheetDateChangedEvent for the TimesheetDate. If it changes
				// from this point on, we need to inform anyone who needs to know that this timesheet
				// has changed...
				date.TimesheetDateChangedEvent += new EventHandler<TimesheetDateChangedEventArgs>(
					delegate(object sender, TimesheetDateChangedEventArgs e) {
						if (this.TimesheetChangedEvent != null) {
							this.TimesheetChangedEvent(this, new TimesheetChangedEventArgs(this));
						}
					});
			}

			if (this.TimesheetChangedEvent != null) {
				this.TimesheetChangedEvent(this, new TimesheetChangedEventArgs(this));
			}
		}

		/// <summary>
		/// Returns the total billable hours for this timesheet.
		/// </summary>
		/// <returns>The billable hours for this timesheet</returns>
		public virtual decimal GetBillableHours() {
			if (this.Dates.Count == 0) {
				return 0m;
			} else {
				decimal billableHours = this.Dates.Sum(p => p.BillableHours);
				return billableHours;
			}
		}

		/// <summary>
		/// Returns the invoice amout for this timesheet based on billable hours, and, dollars/hour
		/// specified in the configuration.
		/// </summary>
		/// <returns>The invlice amout for this timesheet</returns>
		public virtual decimal GetInvoiceAmount() {
			if (this.Dates.Count == 0) {
				return 0m;
			} else {
				return this.Dates.Sum(p => p.InvoiceAmount);
			}
		}		

		public virtual string GetFormattedInvoiceAmount() {
			return this.GetInvoiceAmount().ToString("C");
		}

		public virtual string GetFormattedRatesPerHour() {
			IEnumerable<Rate> rates = Rates.GetRates(this);

			StringBuilder formattedRates = new StringBuilder();
			for (int i = 0; i < rates.Count(); i++) {
				Rate rate = rates.ElementAt(i);
				if (i > 0) {
					formattedRates.Append(" | ");
				}
				formattedRates.Append(rate.ToString());
			}

			return formattedRates.ToString();
		}

		/// <summary>
		/// Returns the proposed file name based on the timesheet year, month, unique indicator e.g.
		/// Timesheet 2011-03 Week 1 (02-28-2011 Through 03-06-2011)
		/// </summary>
		/// <returns>The proposed file name for this timesheet e.g.	Timesheet 2010-05 A.xlsx</returns>
		public virtual string GetFileName() {
			TimesheetMonth timesheetMonth = this.MonthlyTimesheets.TimesheetMonth;

			int year = timesheetMonth.Year;
			int month = timesheetMonth.Month;
			string shortMonthName = timesheetMonth.SortName;

			string fromDate = Helpers.Dates.GetMMDDYYYY(this.StartDate.Date, '-');
			string toDate = Helpers.Dates.GetMMDDYYYY(this.EndDate.Date, '-');


			const string fileNameFormatString = "Timesheet {0}-{1:00} Week {2} ({3} Through {4}";

			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.AppendFormat(fileNameFormatString, year, month, this.WeekNumber.ToString(), fromDate, toDate);

			if (this.IsSplitTimesheet) {
				if (this.SplitIndex < 0 || this.SplitIndex > 1) {
					throw new Exception("SplitIndex for split timesheet was out of range (must be 0 or 1).");					
				} else {
					stringBuilder.Append(", ");
					stringBuilder.AppendFormat("{0} of 2", this.SplitIndex + 1);
				}
			}

			stringBuilder.Append(")");
			stringBuilder.Append(".xlsx");

			return stringBuilder.ToString();
		}		
		#endregion	// General Methods
		
		// Static Members
		// --------------------------------------------------------------------------
		#region Static Members
		static public string GetTimesheetWeekString(Timesheet timesheet) {
			lock (m_syncRoot) {
				TimesheetMonth timesheetMonth = timesheet.MonthlyTimesheets.TimesheetMonth;

				string fromDate = Helpers.Dates.GetMMDDYYYY(timesheet.StartDate.Date, '-');
				string toDate = Helpers.Dates.GetMMDDYYYY(timesheet.EndDate.Date, '-');

				const string formatString = "Week {0} ({1} Through {2})";
				return string.Format(formatString, timesheet.WeekNumber.ToString(), fromDate, toDate);
			}
		}

		/// <summary>
		/// Returns the default billable hours for the date.
		/// </summary>
		/// <param name="timesheet">The timesheet that the date falls under.</param>
		/// <param name="date">The date whose default billable hours are to be returned.</param>
		/// <returns>The default billable hours.</returns>
		static protected decimal GetBillableHoursDefault(Timesheet timesheet, DateTime date) {
			lock (m_syncRoot) {
				int year = timesheet.MonthlyTimesheets.TimesheetMonth.Year;
				int month = timesheet.MonthlyTimesheets.TimesheetMonth.Month;
				if (date.Year != year || date.Month != month) {
					// If the date to check does not fall within the timesheet, do not count hours for that day.
					return 0m;
				} else if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) {
					// If the date falls on a weekend, do not count hours for that day.
					return 0m;
				} else {
					decimal defaultWorkDayHours = Configuration.Configuration.Instance.MiscellaneousConfiguration.DefaultWorkDayHours;

					// Do split checking...
					if (timesheet.IsSplitTimesheet) {
						// If we are working with a split timesheet and this is the FIRST of two split timesheets,
						// all days less than or equal to the 15th (day <= 15) is billable...
						if (timesheet.SplitIndex == 0) {
							return (date.Day > 15) ? 0m : defaultWorkDayHours;
						} else {
							// If we are working with a split timesheet and this is the SECOND of two split timesheets,
							// all days greater than the 15th (day > 15) is billable...
							return (date.Day > 15) ? defaultWorkDayHours : 0m;
						}
					} else {
						// Return the default work day hours.
						return defaultWorkDayHours;
					}
				}
			}
		}

		/// <summary>
		/// Returns the default invoive amount for the date.
		/// </summary>
		/// <param name="timesheet">The timesheet that the date falls under.</param>
		/// <param name="date">The date whose default invoice amount is to be returned.</param>
		/// <returns>The default invoice anount for the date.</returns>
		//static protected decimal GetInvoiceAmountDefault(Timesheet timesheet, DateTime date) {
		//   lock (m_syncRoot) {
		//      decimal defaultWorkDayHours = Configuration.Configuration.Instance.MiscellaneousConfiguration.DefaultWorkDayHours;
		//      decimal defaultDollarsPerHour = Configuration.Configuration.Instance.InvoiceConfiguration.Rate;
		//      return Timesheet.IsBillableDate(timesheet, date) ? defaultWorkDayHours * defaultDollarsPerHour : 0m;				
		//   }
		//}

		static public bool IsBillableDate(Timesheet timesheet, DateTime date){
			int year = timesheet.MonthlyTimesheets.TimesheetMonth.Year;
			int month = timesheet.MonthlyTimesheets.TimesheetMonth.Month;

			if (date.Year != year || date.Month != month) {
				// If the date to check does not fall within the timesheet, we cannot claim an invoice amount for that date.
				return false;
			} else if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) {
				// If the date falls on a weekend, we cannot claim an invoice amount for that date.
				return false;
			} else {
				// Return the default invoice amount.
				if (!timesheet.IsSplitTimesheet) {
					return true;
				} else if (timesheet.SplitIndex == 0) {
					return (date.Day <= 15);
				} else if (timesheet.SplitIndex == 1) {
					return (date.Day > 15);
				} else {
					throw new Exception(string.Format("Unhandled condition in [{0}], Date: [{1}]", timesheet.GetFileName(), date.ToShortDateString()));
				}
			}
		}

		static public bool WouldTimesheetSplit(TimesheetMonth timesheetMonth, DateTime startDate, DateTime endDate) {
			lock (m_syncRoot) {
				if (startDate > endDate) {
					throw new ArgumentOutOfRangeException("startDate cannot be greater than endDate");
				} else if (startDate.AddDays(6) != endDate) {
					throw new ArgumentOutOfRangeException("startDate through endDate must span exactly 7 days");
				} else {
					int startYear = startDate.Year;
					int startMonth = startDate.Month;

					int endYear = endDate.Year;
					int endMonth = endDate.Month;

					if ((startYear != timesheetMonth.Year || startMonth != timesheetMonth.Month) &&
						(endYear != timesheetMonth.Year || endMonth != timesheetMonth.Month)) {
							throw new ArgumentOutOfRangeException("startDate and/or endDate's year and month must equal timesheetMonth's year and month.");
					}
				}

				DateTime fifteenthOfMonth = new DateTime(timesheetMonth.Year, timesheetMonth.Month, 15);
				if (fifteenthOfMonth.DayOfWeek == DayOfWeek.Saturday || fifteenthOfMonth.DayOfWeek == DayOfWeek.Sunday) {
					return false;
				} else {
					DateTime[] dates = Helpers.Dates.ToDateRange(startDate, endDate);
					return dates.Count(p => p.Day == 15) > 0;
				}
			}
		}		
		#endregion	// Static Members

		// IXmlable Members
		// --------------------------------------------------------------------------
		#region IXmlable Members
		public void FromXml(MonthlyTimesheets monthlyTimesheets, XElement element) {
			this.Initialize();
			this.MonthlyTimesheets = monthlyTimesheets;

			this.WeekIndex = Convert.ToInt32(element.Attribute("weekIndex").Value);
			this.SplitIndex = Convert.ToInt32(element.Attribute("splitIndex").Value);
			this.TimesheetSent = Convert.ToBoolean(element.Attribute("timesheetSent").Value);

			foreach (XElement timesheetDateElement in element.XPathSelectElements("./timesheetDate")) {
				TimesheetDate timesheetDate = new TimesheetDate(this, timesheetDateElement);
				this.Dates.Add(timesheetDate);
			}
		}

		public XElement ToXml() {
			string startDateString = Helpers.Dates.GetYYYYMMDD(this.StartDate.Date);
			string endDateString = Helpers.Dates.GetYYYYMMDD(this.EndDate.Date);

			XElement element = new XElement("timesheet",
				new XAttribute("weekIndex", this.WeekIndex),
				new XAttribute("splitIndex", this.SplitIndex),
				new XAttribute("timesheetSent", this.TimesheetSent)
				);

			foreach (TimesheetDate timesheetDate in this.Dates) {
				element.Add(timesheetDate.ToXml());
			}

			return element;
		}
		#endregion	// IXmlable Members		

		// Calculations
		// --------------------------------------------------------------------------
		#region Calculations
		/// <summary>
		/// Returns the count for the DayType.
		/// </summary>
		/// <param name="dayType">The DayType to query.</param>
		/// <returns>The DayType count found in this Timesheet.</returns>
		/// <remarks>If IsValidDate return false, that date is not included in the final count.</remarks>
		public int GetDayTypeCount(DayType dayType) {
			int count = 0;

			// Calculate only VALID TimesheetDates!			
			foreach (TimesheetDate timesheetDate in this.Dates.Where(p => p.IsValidDate)) {
				if (timesheetDate.DayType == dayType) {
					++count;
				}
			}

			return count;
		}

		/// <summary>
		/// Returns the Weekday count for this Timesheet, that is, the number of TimesheetDate objects that
		/// are marked IsWeenday == true.
		/// </summary>		
		/// <returns>The number of TimesheetDate objects where IsValidDate == true and IsWeekday == true.</returns>
		/// <remarks>If IsValidDate return false, that date is not included in the final count.</remarks>
		public int GetWeekdayCount() {
			return this.Dates.Where(p => p.IsWeekday).Count(p => p.IsValidDate);
		}

		/// <summary>
		/// Returns the Weekend count for this Timesheet, that is, the number of TimesheetDate objects that
		/// are marked IsWeekend == true.
		/// </summary>		
		/// <returns>The number of TimesheetDate objects where IsValidDate == true and IsWeekend == true.</returns>
		/// <remarks>If IsValidDate return false, that date is not included in the final count.</remarks>
		public int GetWeekendCount() {
			return this.Dates.Where(p => p.IsWeekend).Count(p => p.IsValidDate);
		}
		#endregion	// Calculations
	};
};
