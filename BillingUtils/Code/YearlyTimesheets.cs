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

using BillingUtils.Code;
using BillingUtils.Code.Helpers;
using BillingUtils.Code.Configuration;

namespace BillingUtils.Code {	

	public class YearlyTimesheets : IEnumerable, IEnumerator {
		static public object m_syncRoot = new object();
		public int Year { get; protected set; }
		protected Collection<MonthlyTimesheets> m_collection;
		protected virtual int EnumeratorIndex { get; set; }

		public YearlyTimesheets() {
			Initialize();
		}

		public YearlyTimesheets(int year)
			: this() {
			this.Year = year;

			for (int month = 1; month < 13; month++) {
				this.Add(year, month);
			}
		}

		protected virtual void Initialize() {
			this.EnumeratorIndex = 0;
			this.MonthlyTimesheets = new Collection<MonthlyTimesheets>();
		} 		

		// Add Members
		// --------------------------------------------------------------------------
		#region Add Members
		protected virtual void Add(int year, int month) {
			this.Add(new TimesheetMonth(year, month));
		}		

		protected virtual void Add(TimesheetMonth timesheetMonth) {
			MonthlyTimesheets monthlyTimesheets = new MonthlyTimesheets(timesheetMonth);
			this.MonthlyTimesheets.Add(monthlyTimesheets);
		}
		#endregion	// Add Members

		public virtual decimal GetBillableHours() {
			if (this.MonthlyTimesheets.Count == 0) {
				return 0m;
			} else {				
				return this.MonthlyTimesheets.Sum(p => p.GetBillableHours());
			}
		}

		public virtual decimal GetInvoiceAmount() {
			if (this.MonthlyTimesheets.Count == 0) {
				return 0m;
			} else {
				return this.MonthlyTimesheets.Sum(p => p.GetInvoiceAmount());
			}
		}

		public virtual string GetFormattedInvoiceAmount() {
			return this.GetInvoiceAmount().ToString("C");
		}

		public virtual string[] GetFileNames(bool addPath) {
			string appFolder = Configuration.Configuration.Instance.UserDataFolder;

			Collection<string> fileNames = new Collection<string>();
			
			foreach (MonthlyTimesheets monthlyTimesheet in this.MonthlyTimesheets) {
				foreach (Timesheet timesheet in monthlyTimesheet) {
					string fileName = (addPath) ? Path.Combine(new string[] { appFolder, timesheet.GetFileName() }) : timesheet.GetFileName();
					fileNames.Add(fileName);
				}
			}

			return fileNames.ToArray();
		}

		/// <summary>
		/// Removes all Timesheets from the collection and resets the Enumerator position.
		/// </summary>
		public virtual void Clear() {
			this.Initialize();
		}

		public virtual int Count {
			get { return this.MonthlyTimesheets.Count(); }
		}

		public virtual MonthlyTimesheets this[int index] {
			get { return this.MonthlyTimesheets[index]; }
		}

		public virtual Collection<MonthlyTimesheets> MonthlyTimesheets {
			get { return m_collection; }
			set {
				m_collection = value;

				//foreach (MonthlyTimesheets monthlyTimesheet in m_collection) {
				//   this.AttachChangedEvent(monthlyTimesheet);
				//}

				//// If suspend changed event is not set, notify anyone who needs to know that
				//// this monthly timesheet has changed...
				//if (!this.IsSuspendChangedEvent && this.MonthlyTimesheetChangedEvent != null) {
				//   this.MonthlyTimesheetChangedEvent(this, new MonthlyTimesheetChangedEventArgs(this));
				//}
			}
		}

		#region IEnumerable Members
		IEnumerator IEnumerable.GetEnumerator() {
			return this.MonthlyTimesheets.GetEnumerator();
		}
		#endregion	// IEnumerable Members

		#region IEnumerator Members
		public virtual object Current {
			get {
				try {
					try {
						return this.MonthlyTimesheets[this.EnumeratorIndex];
					} catch (IndexOutOfRangeException) {
						throw new InvalidOperationException();
					}
				} finally {
				}
			}
		}

		public virtual bool MoveNext() {
			this.EnumeratorIndex++;
			return (this.EnumeratorIndex < this.MonthlyTimesheets.Count);
		}

		public virtual void Reset() {
			this.EnumeratorIndex = -1;
		}
		#endregion // IEnumerator Members

		// Calculations
		// --------------------------------------------------------------------------
		#region Calculations
		public int GetDayTypeCount(DayType dayType) {
			int count = 0;

			// Calculate only VALID TimesheetDates!						
			foreach (MonthlyTimesheets monthlyTimesheet in this.MonthlyTimesheets) {
				count += monthlyTimesheet.GetDayTypeCount(dayType);
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
			return this.MonthlyTimesheets.Sum(p => p.GetWeekdayCount());
		}

		/// <summary>
		/// Returns the Weekend count for all Timesheets, that is, the number of TimesheetDate objects in 
		/// each Timesheet object that are marked IsWeenday == true.
		/// </summary>		
		/// <returns>The total number of TimesheetDate objects in each Timesheet objects where IsValidDate == true and IsWeekend == true.</returns>
		/// <remarks>If TimesheetDate.IsValidDate return false, that date is not included in the final count.</remarks>
		public int GetWeekendCount() {
			return this.MonthlyTimesheets.Sum(p => p.GetWeekendCount());
		}
		#endregion	// Calculations
	};
};
