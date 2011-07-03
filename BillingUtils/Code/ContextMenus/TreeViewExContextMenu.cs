using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;

using BillingUtils.Code.Helpers;
using BillingUtils.UserControls.TreeView;

namespace BillingUtils.Code.ContextMenus  {
	
	public class TreeViewExContextMenu {
		public TreeNodeEx TreeNode { get; protected set; }

		// Menu...
		protected ContextMenu ContextMenu { get; set; }

		protected virtual MenuItem CheckAllMenuItem { get; set; }
		protected virtual MenuItem UnCheckAllMenuItem { get; set; }
		protected virtual MenuItem CollapseAllMenuItem { get; set; }
		protected virtual MenuItem ExpandAllMenuItem { get; set; }

		public EventHandler<ContextMenuEventArgs<TreeNodeEx>> CheckAllEvent { get; set; }
		public EventHandler<ContextMenuEventArgs<TreeNodeEx>> UnCheckAllEvent { get; set; }
		public EventHandler<ContextMenuEventArgs<TreeNodeEx>> CollapseAllEvent { get; set; }
		public EventHandler<ContextMenuEventArgs<TreeNodeEx>> ExpandAllEvent { get; set; }		
		
		static TreeViewExContextMenu() {			
		}

		public TreeViewExContextMenu(TreeNodeEx treeNode) {
			this.TreeNode = treeNode;

			this.ContextMenu = new ContextMenu();			
			this.ContextMenu.Tag = this;

			this.CheckAllMenuItem = new MenuItem("&Check All");
			this.UnCheckAllMenuItem = new MenuItem("&UnCheck All");
			this.CollapseAllMenuItem = new MenuItem("Co&llapse All");
			this.ExpandAllMenuItem = new MenuItem("E&xpand All");
		}

		
		/// <summary>
		/// Returns the context menu object.
		/// </summary>
		/// <remarks>You MUST call this method at the end of all overridden methods e.g. return base.GetContextMenu();</remarks>
		/// <returns>The ContextMenu object.</returns>
		public virtual ContextMenu GetContextMenu() {
			this.AddMenuItems();

			//
			// Check All/UnCheck All...
			//
			this.CheckAllMenuItem.Enabled = this.CanCheck();
			this.CheckAllMenuItem.Click += new EventHandler(this.OnCheckAllClick);

			this.UnCheckAllMenuItem.Enabled = this.CanCheck();
			this.UnCheckAllMenuItem.Click += new EventHandler(this.OnUnCheckAllClick);

			//
			// Collapse All/Expand All...
			//
			this.CollapseAllMenuItem.Enabled = this.CanCollapse();
			this.CollapseAllMenuItem.Click += new EventHandler(this.OnCollapseAllClick);

			this.ExpandAllMenuItem.Enabled = this.CanExpand();
			this.ExpandAllMenuItem.Click += new EventHandler(this.OnExpandAllClick);

			return this.ContextMenu;
		}

		protected virtual void AddMenuItems() {
			AddCheckUnCheckAllMenuItems();
			this.ContextMenu.MenuItems.Add("-");
			AddExpandCollapseMenuItems();
		}

		protected virtual void AddCheckUnCheckAllMenuItems() {			
			this.ContextMenu.MenuItems.Add(this.CheckAllMenuItem);
			this.ContextMenu.MenuItems.Add(this.UnCheckAllMenuItem);
		}
		
		protected virtual void AddExpandCollapseMenuItems() {			
			this.ContextMenu.MenuItems.Add(this.ExpandAllMenuItem);
			this.ContextMenu.MenuItems.Add(this.CollapseAllMenuItem);
		}

		protected virtual bool CanCheck() {
			return true;
		}		

		protected virtual bool CanExpand() {
			return !this.TreeNode.IsExpanded || this.TreeNode.Nodes.Count > 0;
		}

		protected virtual bool CanCollapse() {
			return this.TreeNode.IsExpanded;
		}
		
		// Events
		// --------------------------------------------------------------------------
		#region Events

		// Expand All...
		protected void OnExpandAllClick(object sender, EventArgs e) {
			if (this.ExpandAllEvent == null) {
				TreeNodeEx treeNode = this.TreeNode;
				TreeViewEx treeView = treeNode.TreeView;
				treeView.BeginUpdate();
				treeNode.ExpandAll();
				treeView.SelectedNode = treeNode;
				treeNode.EnsureVisible();
				treeView.EndUpdate();
			} else {
				this.ExpandAllEvent(this, new ContextMenuEventArgs<TreeNodeEx>(this.TreeNode));
			}
		}

		// Collapse All...
		protected void OnCollapseAllClick(object sender, EventArgs e) {
			if (this.CollapseAllEvent == null) {
				TreeNodeEx treeNode = this.TreeNode;
				TreeViewEx treeView = treeNode.TreeView;
				treeView.BeginUpdate();
				treeNode.Collapse();
				treeView.SelectedNode = treeNode;
				treeNode.EnsureVisible();
				treeView.EndUpdate();
			} else {
				this.CollapseAllEvent(this, new ContextMenuEventArgs<TreeNodeEx>(this.TreeNode));
			}
		}

		// Check All...
		protected void OnCheckAllClick(object sender, EventArgs e) {
			if (this.CheckAllEvent == null) {
				TreeNodeEx treeNode = this.TreeNode;
				TreeViewEx treeView = treeNode.TreeView;
				treeView.BeginUpdate();
				TreeViewHelpers.CheckBoxes.CheckAll(treeNode);
				treeView.EndUpdate();
			} else {
				this.CheckAllEvent(this, new ContextMenuEventArgs<TreeNodeEx>(this.TreeNode));
			}
		}

		// UnCheck All...
		protected void OnUnCheckAllClick(object sender, EventArgs e) {
			if (this.UnCheckAllEvent == null) {
				TreeNodeEx treeNode = this.TreeNode;
				TreeViewEx treeView = treeNode.TreeView;
				treeView.BeginUpdate();
				TreeViewHelpers.CheckBoxes.UnCheckAll(treeNode);
				treeView.EndUpdate();
			} else {
				this.UnCheckAllEvent(this, new ContextMenuEventArgs<TreeNodeEx>(this.TreeNode));
			}
		}
		#endregion	// Events
	};
};

