using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using BillingUtils.UserControls.TreeView;

namespace BillingUtils.Code.Helpers {
	static public class TreeViewHelpers {
		public class CheckBoxes {
			static private object m_syncRoot = new object();

			static public void CheckAll(TreeNodeEx treeNode) {
				lock (m_syncRoot) {
					TreeViewEx treeView = (TreeViewEx)treeNode.TreeView;
					if (treeView != null) {
						treeView.SuspendCheckEvents();
					}

					CheckBoxes.CheckAll((TreeNode)treeNode);

					if (treeView != null) {
						treeView.InvokeTreeViewExNodesChecked();
						treeView.ResumeCheckEvents();
					}
				}
			}

			static public void UnCheckAll(TreeNodeEx treeNode) {
				lock (m_syncRoot) {
					TreeViewEx treeView = (TreeViewEx)treeNode.TreeView;
					if (treeView != null) {
						treeView.SuspendCheckEvents();
					}

					CheckBoxes.UnCheckAll((TreeNode)treeNode);

					if (treeView != null) {
						treeView.InvokeTreeViewExNodesChecked();
						treeView.ResumeCheckEvents();
					}
				}
			}

			static public void CheckAll(TreeNode treeNode) {
				lock (m_syncRoot) {
					if (treeNode == null) {
						return;
					}

					TreeView treeView = treeNode.TreeView;
					if (treeView == null || !treeView.CheckBoxes) {
						return;
					} else {
						foreach (TreeNode childNode in treeNode.Nodes) {
							CheckBoxes.CheckAll(childNode);
						}
					}

					treeNode.Checked = true;
				}
			}

			static public void UnCheckAll(TreeNode treeNode) {
				lock (m_syncRoot) {
					if (treeNode == null) {
						return;
					}

					TreeView treeView = treeNode.TreeView;
					if (treeView == null || !treeView.CheckBoxes) {
						return;
					} else {
						foreach (TreeNode childNode in treeNode.Nodes) {
							CheckBoxes.UnCheckAll(childNode);
						}
					}

					treeNode.Checked = false;
				}
			}
		};
	};
};
