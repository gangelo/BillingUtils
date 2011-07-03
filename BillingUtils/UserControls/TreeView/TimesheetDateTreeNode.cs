using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BillingUtils.Code;
using BillingUtils.Code.Helpers;

namespace BillingUtils.UserControls.TreeView {

	public class TimesheetDateTreeNode : TreeNodeEx {
		public TimesheetDateTreeNode(TimesheetDate timesheetDate, int imageIndex = 0) {
			this.ImageIndex = imageIndex;
			this.Tag = timesheetDate;
			Initialize();
		}

		protected override void Initialize() {
			base.Initialize();

			TimesheetDate timesheetDate = this.Tag;
			
			// Text...			
			StringBuilder stringBuilder = new StringBuilder(Dates.GetYYYYMMDD(timesheetDate.Date, '-'));
			stringBuilder.AppendFormat(" ({0})", timesheetDate.GetFormattedInvoiceAmount());
			this.Text = stringBuilder.ToString();
		}

		new public TimesheetDate Tag {
			get { return (TimesheetDate)base.Tag; }
			set { 
				base.Tag = value;				
				TreeNodeEx.ShowCheckBox(this, value.IsValidDate);
			}
		}
	};
};

