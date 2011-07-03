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
using System.Diagnostics;

using BillingUtils.Code;
using BillingUtils.Code.Helpers;
using BillingUtils.Code.Configuration;

namespace BillingUtils.Code {
	
	public class RangeTimesheets : YearlyTimesheets {
		private DateTime m_startDate;
		private DateTime m_endDate;

		public RangeTimesheets(DateTime startDate, DateTime endDate)
			: base() {
			m_startDate = new DateTime(startDate.Year, startDate.Month, 1);
			m_endDate = endDate.AddMonths(1).AddDays(-endDate.Day);

			//m_startDate = startDate;
			//m_endDate = endDate;

			for (DateTime dateTime = m_startDate; dateTime <= m_endDate; dateTime = dateTime.AddMonths(1)) {
				Console.WriteLine(string.Format("Adding RangeTimesheets: {0}-{1}", dateTime.Year, dateTime.Month.ToString("00")));
				this.Add(dateTime.Year, dateTime.Month);
			}
		}

		public DateTime StartDate {
			get { return m_startDate; }
			protected set { m_startDate = value; }
		}

		public DateTime EndDate {
			get { return m_endDate; }
			protected set { m_endDate = value; }
		}
	};
};
