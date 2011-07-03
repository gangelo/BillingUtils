using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BillingUtils.Code.Helpers {

	internal class Dates {
		private static object m_syncRoot = new object();

		static public char DefaultSeparatorChar { get { return '-'; } }

		static public DateTime[] ToDateRange(DateTime startDate, DateTime endDate) {
			lock (m_syncRoot) {
				Collection<DateTime> collection = new Collection<DateTime>();

				DateTime date = startDate;
				while (date <= endDate) {
					collection.Add(date);
					date = date.AddDays(1);
				}

				return collection.ToArray();
			}
		}

		static public string GetYYYYMMDD(DateTime dateTime) {
			return Dates.GetYYYYMMDD(dateTime, Dates.DefaultSeparatorChar);
		}

		static public string GetYYYYMMDD(DateTime dateTime, char seperatorCharacter) {
			int year = dateTime.Year;
			int month = dateTime.Month;
			int day = dateTime.Day;

			return string.Format("{0}{3}{1:00}{3}{2:00}", year, month, day, seperatorCharacter);			
		}

		static public string GetMMDDYYYY(DateTime dateTime) {
			return Dates.GetMMDDYYYY(dateTime, Dates.DefaultSeparatorChar);
		}

		static public string GetMMDDYYYY(DateTime dateTime, char seperatorCharacter) {
			int year = dateTime.Year;
			int month = dateTime.Month;
			int day = dateTime.Day;

			return string.Format("{0:00}{3}{1:00}{3}{2}", month, day, year, seperatorCharacter);
		}

		static public bool YearMonthEqual(DateTime date1, DateTime date2) {
			return (date1.Year == date2.Year && date1.Month == date2.Month);
		}
	};
};
