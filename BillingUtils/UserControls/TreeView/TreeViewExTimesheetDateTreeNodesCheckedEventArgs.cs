using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BillingUtils.UserControls.TreeView {

	public delegate void TreeViewExTimesheetDateTreeNodesCheckedEventHandler(TreeViewEx sender, TreeViewExTimesheetDateTreeNodesCheckedEventArgs e);

	public class TreeViewExTimesheetDateTreeNodesCheckedEventArgs : TreeViewExEventArgs {
		private List<TimesheetDateTreeNode> m_timesheetDateTreeNodes;

		public TreeViewExTimesheetDateTreeNodesCheckedEventArgs(List<TimesheetDateTreeNode> timesheetDateTreeNodes = null) {
			this.TimesheetDateTreeNodes = timesheetDateTreeNodes;
		}

		public virtual List<TimesheetDateTreeNode> TimesheetDateTreeNodes {
			get { return m_timesheetDateTreeNodes; }
			set { m_timesheetDateTreeNodes = value; }
		}
	};
};
