using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingUtils.UserControls.TreeView {

	public class RootTreeNode : TreeNodeEx {
		public RootTreeNode() {
			Initialize();
		}

		public RootTreeNode(string text, int imageIndex = 0)
			: base(text, imageIndex) {
			Initialize();
		}

		protected override void Initialize() {
			this.CheckBox = false;
		}
	};
};
