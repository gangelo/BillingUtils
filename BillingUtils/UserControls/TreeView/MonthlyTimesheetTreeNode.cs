using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingUtils.UserControls.TreeView {

	public class MonthlyTimesheetTreeNode : TreeNodeEx {
		public MonthlyTimesheetTreeNode()
			: base() {
		}

		public MonthlyTimesheetTreeNode(string text, int imageIndex = 0)
			: base(text, imageIndex) {
		}
	};
};

