using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BillingUtils.UserControls.TreeView {

	public class TreeViewEx : System.Windows.Forms.TreeView {
		private bool m_suspendCheckEvents;

		public event TreeViewExTimesheetDateTreeNodesCheckedEventHandler TreeViewExNodesCheckedEvent;		

		public TreeViewEx() {			
		}

		public bool IsCheckEventsSuspended {
			get { return m_suspendCheckEvents; }
		}

		public virtual void SuspendCheckEvents() {
			m_suspendCheckEvents = true;
		}

		public virtual void ResumeCheckEvents() {
			m_suspendCheckEvents = false;
		}

		public void InvokeTreeViewExNodesChecked() {
			if (this.TreeViewExNodesCheckedEvent != null) {
				this.TreeViewExNodesCheckedEvent(this, new TreeViewExTimesheetDateTreeNodesCheckedEventArgs(this.GetCheckedTimesheetDateTreeNodes()));
			} 
		}

		public List<TimesheetDateTreeNode> GetCheckedTimesheetDateTreeNodes() {
			List<TimesheetDateTreeNode> checkedTreeNodes = new List<TimesheetDateTreeNode>();
			GetCheckedTimesheetDateTreeNodes(checkedTreeNodes, (TreeNodeEx)this.Nodes[0]);
			return checkedTreeNodes;
		}

		protected void GetCheckedTimesheetDateTreeNodes(List<TimesheetDateTreeNode> checkedTreeNodes, TreeNodeEx parentTreeNode) {
			foreach (TreeNodeEx childTreeNode in parentTreeNode.Nodes) {
				GetCheckedTimesheetDateTreeNodes(checkedTreeNodes, childTreeNode);
			}

			if (parentTreeNode.Checked && parentTreeNode is TimesheetDateTreeNode) {
				checkedTreeNodes.Add((TimesheetDateTreeNode)parentTreeNode);
			}
		}

		protected override void OnBeforeCheck(TreeViewCancelEventArgs e) {
			if (!this.IsCheckEventsSuspended) {
				base.OnBeforeCheck(e);
			}
		}

		protected override void OnAfterCheck(TreeViewEventArgs e) {
			if (!this.IsCheckEventsSuspended) {
				base.OnAfterCheck(e);
			}
		}
	};
};
