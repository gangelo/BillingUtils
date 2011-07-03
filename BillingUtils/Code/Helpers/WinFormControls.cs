using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace BillingUtils.Code.Helpers {

	internal class WinFormControls {
		private static object m_syncRoot = new object();

		static public string DefaultComboBoxSelect { get { return "--- Select ---"; } }

		static public ColumnHeaderAutoResizeStyle GetListViewAutoResizeStyle(ListView listView, string columnKey) {
			lock (m_syncRoot) {
				ColumnHeader columnHeader = null;

				columnHeader = listView.Columns[columnKey];
				columnHeader.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
				int columnContent = columnHeader.Width;

				columnHeader.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
				int headerSize = columnHeader.Width;

				return (columnContent > headerSize) ? ColumnHeaderAutoResizeStyle.ColumnContent : ColumnHeaderAutoResizeStyle.HeaderSize;
			}
		}
	};
};
