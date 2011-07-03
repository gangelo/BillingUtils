using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

using BillingUtils.Code.Helpers;

namespace BillingUtils.Code {

	public class TimesheetDate : IXmlable<Timesheet> {
		private decimal m_billableHours;		
		private string m_notes;
		private DayType m_dayType;
		private bool m_suspendChangedEvent;

		public EventHandler<TimesheetDateChangedEventArgs> TimesheetDateChangedEvent { get; set; }

		public TimesheetDate(Timesheet timesheet, XElement element) {			
			this.FromXml(timesheet, element);
		}

		public TimesheetDate(Timesheet timesheet, DateTime date)
			: this(timesheet, date, 0m, new BillingUtils.Code.DayType(BillingUtils.Code.DayType.NAName), string.Empty) {
		}

		public TimesheetDate(Timesheet timesheet, DateTime date, decimal billableHours, DayType dayType, string notes) {
			this.Timesheet = timesheet;
			this.Date = date;
			this.BillableHours = billableHours;			
			this.DayType = dayType;
			this.Notes = notes;
		}

		public virtual Timesheet Timesheet { get; protected set; }
		public virtual DateTime Date { get; protected set; }		

		public virtual decimal BillableHours {
			get { return m_billableHours; }
			set { 
				m_billableHours = value;

				if (!this.IsSuspendChangedEvent && this.TimesheetDateChangedEvent != null) {
					this.TimesheetDateChangedEvent(this, new TimesheetDateChangedEventArgs(this));
				}
			}
		}

		public virtual Rate Rate {
			get { return Rates.GetRate(this.Date); }
		}

		public virtual decimal RatePerHour {
			get { return Rates.GetRate(this.Date).Amount; }
		}

		public virtual decimal InvoiceAmount {
			get { return m_billableHours * this.RatePerHour; }
		}

		public virtual DayType DayType {
			get { return m_dayType; }
			set {
				m_dayType = value;

				if (!this.IsSuspendChangedEvent && this.TimesheetDateChangedEvent != null) {
					this.TimesheetDateChangedEvent(this, new TimesheetDateChangedEventArgs(this));
				}
			}
		}

		public virtual string Notes {
			get { return string.IsNullOrEmpty(m_notes) ? string.Empty : m_notes; }
			set {
				m_notes = value.Trim();

				if (!this.IsSuspendChangedEvent && this.TimesheetDateChangedEvent != null) {
					this.TimesheetDateChangedEvent(this, new TimesheetDateChangedEventArgs(this));
				}
			}
		}

		/// <summary>
		/// Returns true if the day of week is Saturday or Sunday.
		/// </summary>
		/// <remarks>This property DOES NOT check DayType, rather, IsWeekend is determined by the day of week. For instance,
		/// if the day of week for this date is Saturday or Sunday, IsWeekend will return true.</remarks>
		public bool IsWeekend {
			get { return (this.Date.DayOfWeek == DayOfWeek.Saturday || this.Date.DayOfWeek == DayOfWeek.Sunday); }
		}

		/// <summary>
		/// Returns true if the day of week is not Saturday or Sunday.
		/// </summary>
		/// <remarks>This property DOES NOT check DayType, rather, IsWeekday is determined by the day of week. For instance,
		/// if the day of week for this date is NOT Saturday or Sunday, IsWeekday will return true.</remarks>
		public bool IsWeekday {
			get { return !this.IsWeekend; }
		}

		public bool HasNotes {
			get { return !string.IsNullOrEmpty(this.Notes); }
		}

		public virtual string GetFormattedBillableHours() {
			return this.BillableHours.ToString("0.0");
		}

		public virtual string GetFormattedRatePerHour() {
			return this.RatePerHour.ToString("C");
		}

		public virtual string GetFormattedInvoiceAmount() {			
			return this.InvoiceAmount.ToString("C");
		}

		public virtual bool IsSuspendChangedEvent {
			get { return m_suspendChangedEvent; }
			protected set { m_suspendChangedEvent = value; }
		}

		public virtual void SuspendChangedEvent(bool suspend) {
			this.IsSuspendChangedEvent = suspend;
		}

		/// <summary>
		/// This method returns false if A) This Date's year and/or month are NOT equal to the
		/// MonthlyTimesheets' TimesheetMonth year and/or month or B) This Date is part of a split
		/// Timesheet, and, the date is not applicable due to the split index e.g. if the Timesheet this
		/// date belongs to is the FIRST of a split Timesheet and the date is GT the 15th of the month, the
		/// date is invalid because the SECOND of the split Timesheets handles that date;  if the Timesheet this
		/// date belongs to is the SECOND of a split Timesheet and the date is LE the 15th of the month, the
		/// date is invalid because the FIRST of the split Timesheets handles the date.
		/// </summary>
		public bool IsValidDate {
			get {
				TimesheetMonth timesheetMonth = this.Timesheet.MonthlyTimesheets.TimesheetMonth;
				int year = timesheetMonth.Year;
				int month = timesheetMonth.Month;

				if (this.Date.Year != year || this.Date.Month != month) {
					return false;
				} else if ((this.Timesheet.SplitIndex == 0 && this.Date.Day > 15) ||
					(this.Timesheet.SplitIndex == 1 && this.Date.Day <= 15)) {
					return false;
				} else {
					return true;
				}
			}
		}

		// IXmlable Members
		// --------------------------------------------------------------------------
		#region IXmlable Members
		public void FromXml(Timesheet timesheet, XElement element) {
			this.Timesheet = timesheet;

			this.Date = Convert.ToDateTime(element.Attribute("date").Value);
			this.BillableHours = Convert.ToDecimal(element.Attribute("billableHours").Value);
			
			XAttribute dayTypeAttribute = element.Attribute("dayType");
			if (dayTypeAttribute == null) {
				this.DayType = GetAutoDayType(timesheet);
			} else {
				Code.DayType dayType = new Code.DayType(dayTypeAttribute.Value);
				if (!this.IsValidDate) {
					this.DayType = new Code.DayType(Code.DayType.NAName);
				} else if (dayType.GetIsValidDayType()) {
					this.DayType = dayType;
				} else {
					this.DayType = GetAutoDayType(timesheet);
				}
			}

			this.Notes = Convert.ToString(element.Element("notes").Value);
		}

		public XElement ToXml() {
			XElement element = new XElement("timesheetDate",
				new XAttribute("date", Helpers.Dates.GetYYYYMMDD(this.Date)),
				new XAttribute("billableHours", this.BillableHours),				
				new XAttribute("dayType", this.DayType),
				new XElement("notes", new XCData(this.Notes))
				);

			return element;
			
		}
		#endregion	// IXmlable Members

		private DayType GetAutoDayType(Timesheet timesheet) {						
			if (!this.IsValidDate) {
				return new DayType(BillingUtils.Code.DayType.NAName);
			} else if (this.IsWeekend) {
				return new DayType(BillingUtils.Code.DayType.WeekendName);
			} else { // Weekday...
				if (this.Date.DayOfWeek == DayOfWeek.Friday) {
					return new DayType((this.BillableHours == 0) ? BillingUtils.Code.DayType.FlexDayName : BillingUtils.Code.DayType.WorkDayName);
				} else if (this.BillableHours == 0) {
					return new DayType(BillingUtils.Code.DayType.OtherName);
				} else {
					return new DayType(BillingUtils.Code.DayType.WorkDayName);
				}
			}
		}
	};
};
