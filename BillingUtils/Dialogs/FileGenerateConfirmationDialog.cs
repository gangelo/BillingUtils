using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using BillingUtils.Code;
using BillingUtils.Code.Helpers;

namespace BillingUtils.Dialogs {

	public partial class FileGenerateConfirmationDialog : Form {		
		private MonthlyTimesheets MonthlyTimesheets { get; set; }
		private string OutputFolder { get; set; }

		// Construction/Initialization
		// --------------------------------------------------------------------------
		#region Construction/Initialization
		public FileGenerateConfirmationDialog(MonthlyTimesheets monthlyTimesheets, string outputFolder) {
			InitializeComponent();
			InitializeForm();
			InitializeTimesheetsListView();

			this.MonthlyTimesheets = monthlyTimesheets;
			this.OutputFolder = outputFolder;

			foreach (Timesheet timesheet in this.MonthlyTimesheets) {
				InsertTimesheetListViewItem(timesheet);
			}

			ResizeTimesheetsListViewColumns();
		}

		private void InitializeForm() {
			m_ok.Click += new EventHandler(this.OnOkClick);
			m_cancel.Click += new EventHandler(this.OnCancelClick);
		}

		private void InitializeTimesheetsListView() {
			m_imageList.Images.Add(BillingUtils.Properties.Resources.Locked.ToString(), BillingUtils.Properties.Resources.Locked);

			m_timesheets.SmallImageList = m_imageList;

			m_timesheets.View = View.Details;
			m_timesheets.GridLines = true;
			m_timesheets.FullRowSelect = true;
			m_timesheets.MultiSelect = false;
			m_timesheets.HideSelection = false;

			m_timesheets.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			m_timesheets.Columns.Add("timesheet", "Timesheet", 150);
			m_timesheets.Columns.Add("fromDate", "From", 150);
			m_timesheets.Columns.Add("toDate", "To", 150);
			m_timesheets.Columns.Add("totalHours", "Hours", 150).TextAlign = HorizontalAlignment.Right;
			m_timesheets.Columns.Add("rate", "$ Rate", 150).TextAlign = HorizontalAlignment.Right;
			m_timesheets.Columns.Add("amount", "$ Amount", 150).TextAlign = HorizontalAlignment.Right;
			m_timesheets.Columns.Add("action", "Action", 150);			
		}
		#endregion	// Construction/Initialization

		private void ResizeTimesheetsListViewColumns() {
			m_timesheets.Columns["timesheet"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheets, "timesheet"));
			m_timesheets.Columns["fromDate"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheets, "fromDate"));
			m_timesheets.Columns["toDate"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheets, "toDate"));
			m_timesheets.Columns["totalHours"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheets, "totalHours"));
			m_timesheets.Columns["rate"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheets, "rate"));
			m_timesheets.Columns["amount"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheets, "amount"));
			m_timesheets.Columns["action"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheets, "action"));
		}

		private void InsertTimesheetListViewItem(Timesheet timesheet) {
			ListViewItem timesheetListViewItem = CreateTimesheetListViewItem(timesheet);
			m_timesheets.Items.Add(timesheetListViewItem);
		}

		/// <summary>
		/// This member creates ListViewItems for Timsheets.
		/// </summary>
		/// <param name="timesheet">The Timesheet from which the ListViewItems will be created.</param>
		/// <returns>A ListViewItem object.</returns>
		private ListViewItem CreateTimesheetListViewItem(Timesheet timesheet) {
			ListViewItem listViewItem = new ListViewItem(timesheet.GetFileName());

			listViewItem.ImageIndex = timesheet.TimesheetSent ? (int)Timesheet.ImageListIndexes.Locked : -1;
		
			listViewItem.SubItems.Add(timesheet.StartDate.Date.ToShortDateString());
			listViewItem.SubItems.Add(timesheet.EndDate.Date.ToShortDateString());
			listViewItem.SubItems.Add(timesheet.GetBillableHours().ToString());
			listViewItem.SubItems.Add(timesheet.GetFormattedRatesPerHour());
			listViewItem.SubItems.Add(timesheet.GetFormattedInvoiceAmount());

			string action = string.Empty;

			if (timesheet.TimesheetSent) {
				action = "No Action";
			} else if (File.Exists(Path.Combine(new string[] { this.OutputFolder, timesheet.GetFileName() }))) {
				action = "Overwrite";
				listViewItem.ForeColor = Color.Red;
			} else {
				action = "Create";
			}

			listViewItem.SubItems.Add(action);

			listViewItem.Tag = timesheet;

			return listViewItem;
		}
		
		// Events
		// --------------------------------------------------------------------------
		#region Events
		void OnOkClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
		}

		void OnCancelClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}
		#endregion	// Events
	};
};
