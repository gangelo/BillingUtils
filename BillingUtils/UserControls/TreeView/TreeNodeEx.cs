using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BillingUtils.UserControls.TreeView {

	public abstract class TreeNodeEx : TreeNode {
		private bool m_checkBox = true;

		// Hide TreeView CheckBox Code
		// --------------------------------------------------------------------------
		#region Hide TreeView CheckBox Code
		// Constants used to hide a CheckBox...
		private const int TVIF_STATE = 0x8;
		private const int TVIS_STATEIMAGEMASK = 0xF000;
		private const int TV_FIRST = 0x1100;
		private const int TVM_SETITEM = TV_FIRST + 63;

		[DllImport("user32.dll")]
		static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam,
		IntPtr lParam);

		// Struct used to set node properties.
		protected struct TVITEM {
			public int mask;
			public IntPtr hItem;
			public int state;
			public int stateMask;
			[MarshalAs(UnmanagedType.LPTStr)]
			public String lpszText;
			public int cchTextMax;
			public int iImage;
			public int iSelectedImage;
			public int cChildren;
			public IntPtr lParam;
		}
		#endregion	// Hide TreeView CheckBox Code

		public TreeNodeEx()
			: base() {			
		}

		public TreeNodeEx(string text, int imageIndex = 0)
			: base(text, imageIndex, 0) {			
		}

		protected virtual void Initialize() {			
		}

		new public TreeViewEx TreeView { get { return (TreeViewEx)base.TreeView; } }

		/// <summary>
		/// Sets a value indicating whether or not the CheckBox for this node will be shown.
		/// </summary>
		public virtual bool CheckBox {
			get { return m_checkBox; }
			set { m_checkBox = value; }
		}		

		// Hide TreeView CheckBox Code
		// --------------------------------------------------------------------------
		#region Hide TreeView CheckBox Code
		static public void ShowCheckBox(TreeNode treeNode, bool show = true) {
			if (treeNode.TreeView == null) {
				return;
			} else {
				TVITEM tvi = new TVITEM();
				tvi.hItem = treeNode.Handle;
				tvi.mask = TVIF_STATE;
				tvi.stateMask = TVIS_STATEIMAGEMASK;
				tvi.state = 0;
				IntPtr lparam = Marshal.AllocHGlobal(Marshal.SizeOf(tvi));
				Marshal.StructureToPtr(tvi, lparam, false);
				SendMessage(treeNode.TreeView.Handle, TVM_SETITEM, IntPtr.Zero, lparam);
			}
		}
		#endregion	// Hide TreeView CheckBox Code
	};
};
