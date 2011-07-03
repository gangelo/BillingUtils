using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingUtils.UserControls.TreeView {

	public class TimesheetTreeNode : TreeNodeEx {
		public TimesheetTreeNode()
			: base() {
		}

		public TimesheetTreeNode(string text, int imageIndex = 0)
			: base(text, imageIndex) {
		}
	};
};

