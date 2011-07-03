using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using BillingUtils.Code;

namespace BillingUtils.Code.Helpers {

	internal class Excel {
		private static object m_syncRoot = new object();

		static public ExcelCell ToCell(string cell) {
			lock (m_syncRoot) {
				return new ExcelCell(cell);
			}
		}
	};
};
