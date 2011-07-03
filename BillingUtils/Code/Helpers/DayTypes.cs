using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace BillingUtils.Code.Helpers {

	internal class DayTypes {
		private static object m_syncRoot = new object();

		static public Color GetDayTypeForeColor(DayType dayType, decimal hours) {
			lock (m_syncRoot) {
				if (dayType.IsWorkDay) {
					// If it is a work day and no hours are allotted, this should be flagged.
					return (hours == 0.00m) ? ColorTranslator.FromHtml("#990000") : GetDayTypeForeColor(dayType);
				} else {
					// If it is NOT a work day and hours ARE allotted, this should be flagged.
					return (hours == 0.00m) ? GetDayTypeForeColor(dayType) : ColorTranslator.FromHtml("#990000");
				}
			}
		}

		static public Color GetDayTypeForeColor(DayType dayType) {
			lock (m_syncRoot) {
				if (dayType.IsWorkDay)
					return Color.Black;
				else if (dayType.IsWeekend)
					return Color.MidnightBlue;
				else if (dayType.IsExecutiveOrder)
					return Color.DarkCyan;
				else if (dayType.IsFlexDay)
					return Color.DarkGreen;
				else if (dayType.IsVacationDay)
					return Color.DarkGoldenrod;
				else if (dayType.IsSickDay)
					return Color.MediumVioletRed;
				else if (dayType.IsHalfDay)
					return ColorTranslator.FromHtml("#666666");
				else if (dayType.IsOther)
					return Color.Indigo;
				else if (dayType.IsNA)
					return Color.Indigo;
				else {
					MessageBox.Show(string.Format("DayTypes.{0} is unhandled in GetDayTypeForeColor(); using default ForeColor.", dayType.Name), "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return Color.FromKnownColor(KnownColor.ControlText);
				}
			}
		}
	};
};
