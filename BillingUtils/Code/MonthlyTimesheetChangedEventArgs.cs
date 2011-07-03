using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingUtils.Code {
	
	public class MonthlyTimesheetChangedEventArgs : EventArgs {
		public MonthlyTimesheets MonthlyTimesheets { get; protected set; }

		public MonthlyTimesheetChangedEventArgs(MonthlyTimesheets monthlyTimesheets) {
			this.MonthlyTimesheets = monthlyTimesheets;
		}
	};
};
