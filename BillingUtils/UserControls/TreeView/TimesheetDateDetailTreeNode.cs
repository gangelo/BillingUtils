using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BillingUtils.Code;

namespace BillingUtils.UserControls.TreeView {

	public class TimesheetDateDetailTreeNode : TreeNodeEx {
		public TimesheetDateDetailTreeNode(string text = null, int imageIndex = 0)
			: base(text, imageIndex) {			
			Initialize();
		}

		protected override void Initialize() {
			// CheckBox...
			this.CheckBox = false;
		}
	};
};


