using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingUtils.Code {
	
	public class TimesheetMonth {
		public int Year { get; protected set; }
		public int Month { get; protected set; }
		public string SortName { get; protected set; }

		public TimesheetMonth(DateTime dateTime) {
			this.Year = dateTime.Year;
			this.Month = dateTime.Month;
			this.InitializeSortName(dateTime);
		}

		public TimesheetMonth(int year, int month) {
			this.Year = year;
			this.Month = month;
			this.InitializeSortName(year, month);
		}

		private void InitializeSortName(DateTime dateTime) {
			this.SortName = dateTime.ToString("MMM");
		}

		private void InitializeSortName(int year, int month) {
			this.InitializeSortName(new DateTime(year, month, 1));
		}
	};
};
