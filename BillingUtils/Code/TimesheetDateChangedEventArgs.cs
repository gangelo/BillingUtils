using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingUtils.Code {

	public class TimesheetDateChangedEventArgs : EventArgs {
		public TimesheetDate TimesheetDate { get; protected set; }

		public TimesheetDateChangedEventArgs(TimesheetDate timesheetDate) {
			this.TimesheetDate = timesheetDate;
		}
	};
};
