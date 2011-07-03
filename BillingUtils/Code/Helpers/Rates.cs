using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BillingUtils.Code;

namespace BillingUtils.Code.Helpers {
	
	internal class Rates {
		static private object m_syncRoot = new object();

		static public Rate GetRate(DateTime dateTime) {
			lock (m_syncRoot) {				
				Configuration.Configuration config = Configuration.Configuration.Instance;
				IEnumerable<Rate> rates = config.RatesConfiguration.Rates;

				if (rates == null || rates.Count() == 0) {
					return Rate.DefaultRate;
				} else {
					return rates
						.OrderByDescending(p => p.EffectiveDate)
						.FirstOrDefault(p => p.EffectiveDate <= dateTime);
				}
			}
		}

		/// <summary>
		/// This function returns the DISTINCT Rates used by the given timesheet.
		/// </summary>
		/// <param name="timesheet">The Timesheet whose Rates are to be returned.</param>
		/// <returns>An Enumerable collection distinct Rates used by this Timesheet.</returns>
		static public IEnumerable<Rate> GetRates(Timesheet timesheet) {
			lock (m_syncRoot) {
				Configuration.Configuration config = Configuration.Configuration.Instance;
				IEnumerable<Rate> rates = config.RatesConfiguration.Rates;

				List<Rate> filteredRates = new List<Rate>();

				for (int i = 0; i < timesheet.Dates.Count(); i++) {
					TimesheetDate timesheetDate = timesheet[i];
					if (timesheetDate.IsValidDate) {						
						filteredRates.Add(timesheetDate.Rate);
					}
				}

				return filteredRates.Distinct().OrderBy(p => p.EffectiveDate);
			}
		}
	};
};
