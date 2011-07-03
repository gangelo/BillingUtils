using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingUtils.Code {

	public class DayType {
		// Fields
		// --------------------------------------------------------------------------
		#region Fields
		public const string ExecutiveOrderName = "Executive Order";
		public const string FlexDayName = "Flex Day";
		public const string HalfDayName = "Half Day";
		public const string NAName = "N/A";
		public const string OtherName = "Other";
		public const string PersonalDayName = "Personal Day";
		public const string SickDayName = "Sick Day";
		public const string VacationDayName = "Vacation Day";
		public const string WeekendName = "Weekend";
		public const string WorkDayName = "Work Day";

		public string Name { get; protected set; }
		public string Description { get; protected set; } 
		#endregion	// Fields

		// Construction/Initialization
		// --------------------------------------------------------------------------
		#region Construction/Initialization
		public DayType(string name) {
			this.Name = name;
		}

		public DayType(string name, string description) {
			this.Name = name;
			this.Description = description;
		} 
		#endregion	// Construction/Initialization

		// Properties
		// --------------------------------------------------------------------------
		#region Properties
		public bool IsExecutiveOrder { get { return this.Name.Equals(DayType.ExecutiveOrderName, StringComparison.CurrentCultureIgnoreCase); } }
		public bool IsFlexDay { get { return this.Name.Equals(DayType.FlexDayName, StringComparison.CurrentCultureIgnoreCase); } }
		public bool IsHalfDay { get { return this.Name.Equals(DayType.HalfDayName, StringComparison.CurrentCultureIgnoreCase); } }
		public bool IsNA { get { return this.Name.Equals(DayType.NAName, StringComparison.CurrentCultureIgnoreCase); } }
		public bool IsOther { get { return this.Name.Equals(DayType.OtherName, StringComparison.CurrentCultureIgnoreCase); } }
		public bool IsPersonalDay { get { return this.Name.Equals(DayType.PersonalDayName, StringComparison.CurrentCultureIgnoreCase); } }
		public bool IsSickDay { get { return this.Name.Equals(DayType.SickDayName, StringComparison.CurrentCultureIgnoreCase); } }
		public bool IsVacationDay { get { return this.Name.Equals(DayType.VacationDayName, StringComparison.CurrentCultureIgnoreCase); } }
		public bool IsWorkDay { get { return this.Name.Equals(DayType.WorkDayName, StringComparison.CurrentCultureIgnoreCase); } }
		public bool IsWeekend { get { return this.Name.Equals(DayType.WeekendName, StringComparison.CurrentCultureIgnoreCase); } }

		static public DayType ExecutiveOrder { get { return new DayType(DayType.ExecutiveOrderName); } }
		static public DayType FlexDay { get { return new DayType(DayType.FlexDayName); } }
		static public DayType HalfDay { get { return new DayType(DayType.HalfDayName); } }
		static public DayType NA { get { return new DayType(DayType.NAName); } }
		static public DayType Other { get { return new DayType(DayType.OtherName); } }
		static public DayType PersonalDay { get { return new DayType(DayType.PersonalDayName); } }
		static public DayType SickDay { get { return new DayType(DayType.SickDayName); } }
		static public DayType VacationDay { get { return new DayType(DayType.VacationDayName); } }
		static public DayType WorkDay { get { return new DayType(DayType.WorkDayName); } }
		static public DayType Weekend { get { return new DayType(DayType.WeekendName); } } 
		#endregion	// Properties

		// General Methods
		// --------------------------------------------------------------------------
		#region General Methods
		public override string ToString() {
			return this.Name;
		}

		public bool GetIsValidDayType() {
			return (
				this.IsExecutiveOrder ||
				this.IsFlexDay ||
				this.IsHalfDay ||
				// _PRIORITY_: Should this be considered a "valid" day type?
				//this.IsNA ||
				this.IsOther ||
				this.IsPersonalDay ||
				this.IsSickDay ||
				this.IsVacationDay ||
				this.IsWorkDay ||
				this.IsWeekend
				);
		} 
		#endregion	// General Methods

		static public bool operator ==(DayType dayType1, DayType dayType2) {
			return dayType1.Name.Equals(dayType2.Name, StringComparison.CurrentCultureIgnoreCase);
		}

		static public bool operator !=(DayType dayType1, DayType dayType2) {
			return !(dayType1 == dayType2);
		}
	};
};
