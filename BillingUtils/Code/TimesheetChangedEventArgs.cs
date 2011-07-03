using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingUtils.Code {
	
	public class TimesheetChangedEventArgs : EventArgs {
		public Timesheet Timesheet { get; protected set; }

		public TimesheetChangedEventArgs(Timesheet timesheet) {
			
			this.Timesheet = timesheet;
		}
	};
};
