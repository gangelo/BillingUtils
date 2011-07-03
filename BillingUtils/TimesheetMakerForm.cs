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
using System.Drawing.Drawing2D;

using BillingUtils.Code;
using BillingUtils.Code.Enums;
using BillingUtils.Code.Helpers;
using BillingUtils.Code.Configuration;
using BillingUtils.Code.Generators;
using BillingUtils.Dialogs;
using BillingUtils.UserControls;

namespace BillingUtils {

	public partial class TimesheetMakerForm : Form {
		// Fields
		// --------------------------------------------------------------------------
		#region Fields
		private DateTime PreviousDateTime { get; set; }
		private MonthlyTimesheets m_monthlyTimesheets;
		#endregion	// Fields

		// Construction/Initialization
		// --------------------------------------------------------------------------
		#region Construction/Initialization
		public TimesheetMakerForm() {
			InitializeComponent();
			InitializeForm();
			InitializeInvoiceNumber();
			InitializeCalendar();
			InitializeTimesheetsListView();

			m_calculationsContainer.AutoSize = true;
			m_calculationsContainer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			
			MonthlyTimesheetChangedProcessing();			
		}

		private void InitializeForm() {
			m_generate.Click += new EventHandler(this.OnGenerateFilesClick);

			m_apply.Enabled = false;
			m_apply.Click += new EventHandler(this.OnApplyClick);
			
			this.FormClosing += new FormClosingEventHandler(
				delegate(object sender, FormClosingEventArgs e) {
					if (m_apply.Enabled) {
						DialogResult dialogResult = MessageBox.Show("Are you sure you want to close this dialog? Any changes you've made will be lost if they have not been saved. Click the Apply button to save your changes.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
						e.Cancel = dialogResult == DialogResult.Cancel;
					}
				});
		}

		private void InitializeInvoiceNumber() {
			m_invoiceNumbers.MaxDropDownItems = 20;
			m_invoiceNumbers.DropDownStyle = ComboBoxStyle.DropDownList;			
		}		

		private void InitializeCalendar() {
			this.PreviousDateTime = m_calendar.SelectionStart;			
			m_calendar.DateChanged += new DateRangeEventHandler(this.OnDateChanged);						
		}

		private void InitializeTimesheetsListView() {
			m_timesheetsListView.SmallImageList = DefaultImageList.Instance.ImageList;
			m_timesheetsListView.StateImageList = DefaultImageList.Instance.ImageList;
						
			m_timesheetsListView.View = View.Details;
			m_timesheetsListView.GridLines = true;
			m_timesheetsListView.FullRowSelect = true;
			m_timesheetsListView.MultiSelect = false;
			m_timesheetsListView.HideSelection = false;
			
			m_timesheetsListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			m_timesheetsListView.Columns.Add("timesheet", "Timesheet", 150);
			m_timesheetsListView.Columns.Add("fromDate", "From", 150);
			m_timesheetsListView.Columns.Add("toDate", "To", 150);
			m_timesheetsListView.Columns.Add("totalHours", "Hours", 150).TextAlign = HorizontalAlignment.Right;
			m_timesheetsListView.Columns.Add("rate", "$ Rate(s)", 150).TextAlign = HorizontalAlignment.Right;
			m_timesheetsListView.Columns.Add("amount", "$ Amount", 150).TextAlign = HorizontalAlignment.Right;
			m_timesheetsListView.Columns.Add("notes", "Notes", 150);

			m_timesheetsListView.SelectedIndexChanged += new EventHandler(
				delegate(object sender, EventArgs e) {
					this.OnTimesheetsSelectedIndexChanged(sender, e);
				});			

			InitializeTimesheetContextMenuStrip();
		}

		private void InitializeTimesheetContextMenuStrip() {
			m_timesheetsListView.ContextMenuStrip = m_timesheetContextMenu;

			m_timesheetContextMenu.ShowCheckMargin = true;
			m_timesheetContextMenu.ShowImageMargin = false;
			
			// Add our context menu item...
			ToolStripMenuItem toolStripMenuItem0 = new ToolStripMenuItem("Timesheet Sent");
			toolStripMenuItem0.Click += new EventHandler(this.OnTimesheetSentClick);
			toolStripMenuItem0.CheckOnClick = true;			
			m_timesheetContextMenu.Items.AddRange(new ToolStripItem[] { toolStripMenuItem0 });			
			
			// Context menu Opening event processing...
			m_timesheetContextMenu.Opening += new CancelEventHandler(
				delegate(object sender, CancelEventArgs e) {
					ListViewItem listViewItem = m_timesheetsListView.SelectedItems[0];
					if (!(listViewItem.Tag is Timesheet)) {
						e.Cancel = true;
					} else {
						Timesheet timesheet = (Timesheet)listViewItem.Tag;
						ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)m_timesheetContextMenu.Items[0];
						toolStripMenuItem.Checked = timesheet.TimesheetSent;

						e.Cancel = false;
					}
				}
				);
		}
		#endregion	// Construction/Initialization

		// Properties
		// --------------------------------------------------------------------------
		#region Properties
		#endregion	// Properties

		// General Helper Methods
		// --------------------------------------------------------------------------
		#region General Helper Methods
		private void ResizeTimesheetsListViewColumns() {
			m_timesheetsListView.Columns["timesheet"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheetsListView, "timesheet"));
			m_timesheetsListView.Columns["fromDate"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheetsListView, "fromDate"));
			m_timesheetsListView.Columns["toDate"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheetsListView, "toDate"));
			m_timesheetsListView.Columns["totalHours"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheetsListView, "totalHours"));
			m_timesheetsListView.Columns["rate"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheetsListView, "rate"));
			m_timesheetsListView.Columns["amount"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheetsListView, "amount"));
			m_timesheetsListView.Columns["notes"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_timesheetsListView, "notes"));
		}		

		/// <summary>
		/// If the MonthlyTimesheet switched or changed, the timesheets ListView must change to
		/// reflect the MonthlyTimesheet.
		/// </summary>		
		private void MonthlyTimesheetChangedProcessing() {
			MonthlyTimesheetChangedProcessing(0);
		}

		/// <summary>
		/// If the MonthlyTimesheet switched or changed, the timesheets ListView must change to
		/// reflect the MonthlyTimesheet.
		/// </summary>
		/// <param name="selectedIndex">The index of the ListViewItem associated with the Timesheet that should be selected.</param>
		private void MonthlyTimesheetChangedProcessing(int selectedIndex) {			
			// Create a new MonthlyTimesheets object to use...						
			m_monthlyTimesheets = new MonthlyTimesheets(new TimesheetMonth(m_calendar.SelectionStart));
			
			m_timesheetsListView.Items.Clear();

			// Invoice number...
			m_invoiceNumbers.Items.Clear();
			m_invoiceNumbers.SelectedIndexChanged -= new EventHandler(this.OnInvoiceNumbersSelectedIndexChanged);			

			if (m_monthlyTimesheets == null || m_monthlyTimesheets.Count == 0) {				
				m_invoiceNumbers.Enabled = false;
			} else {
				// Set up our Invoice number DropDown...
				m_invoiceNumbers.Enabled = true;
				int invoiceNumber = m_monthlyTimesheets.InvoiceNumber.GetValueOrDefault(1);
				for (int i = 1; i <= 1000; i++) {
					int index = m_invoiceNumbers.Items.Add(i);
					 if (i == invoiceNumber) {						 
						 m_invoiceNumbers.SelectedIndex = index;						 
					}
				}
				m_invoiceNumbers.SelectedIndexChanged += new EventHandler(this.OnInvoiceNumbersSelectedIndexChanged);			

				// Add the Timesheet information to the ListView for Timesheets...
				foreach (Timesheet timesheet in m_monthlyTimesheets) {
					InsertTimesheetListViewItem(timesheet);
				}

				// Add the total row...			
				InsertTimesheetTotalsListViewItem();
			}

			ResizeTimesheetsListViewColumns();

			// WARNING: The call to LoadTimesheetsDetail() must take place BEFORE the m_timesheetsListView 
			// selected index is changed in the below code. Changing the m_timesheetsListView selected prior to
			// calling LoadTimesheetsDetail() causes the SelectedIndexChanged event for m_timesheetsListView
			// which calls TimesheetDetailContainer.ScrollInToView(...), which then crashes because the
			// TimesheetDetailContainer has not been update with the correct Timesheet Detail objects.
			LoadTimesheetsDetail();

			int itemCount = m_timesheetsListView.Items.Count;
			if (itemCount > 0) {
				// This will force the timesheet detail list view to populate with the timesheet detail just selected...
				m_timesheetsListView.Items[(selectedIndex < itemCount) ? selectedIndex : 0].Selected = true;
			}			

			// Calculations...
			AddMonthlyTimesheetCalculations();			
		}

		private void LoadTimesheetsDetail() {
			m_detailContainer.Controls.Clear();
			TimesheetDetailContainer timesheetDetailContainer = new TimesheetDetailContainer();
			m_detailContainer.Controls.Add(timesheetDetailContainer);
			timesheetDetailContainer.Dock = DockStyle.Fill;
			timesheetDetailContainer.UpdateMonthlyTimesheets(m_monthlyTimesheets);

			timesheetDetailContainer.TimesheetDetailUpdatingEvent += new EventHandler<TimesheetDetailListView.TimesheetDetailEventArgs>(
				delegate(object sender, TimesheetDetailListView.TimesheetDetailEventArgs e) {
					m_apply.Enabled = true;
				}
			);

			timesheetDetailContainer.TimesheetDetailUpdatedEvent += new EventHandler<TimesheetDetailListView.TimesheetDetailEventArgs>(
				delegate(object sender, TimesheetDetailListView.TimesheetDetailEventArgs e) {
					UpdateTimesheetListViewItem(e.Timesheet);
					UpdateTimesheetTotalsListViewItem();
					UpdateMonthlyTimesheetCalculations();
					UpdateYearlyTimesheetCalculations();
				}
			);
		}
		#endregion	// General Helper Methods

		// Timesheets ListView Members
		// --------------------------------------------------------------------------
		#region Timesheets ListView Members
		private void InsertTimesheetListViewItem(Timesheet timesheet) {
			ListViewItem timesheetListViewItem = CreateTimesheetListViewItem(timesheet);
			m_timesheetsListView.Items.Add(timesheetListViewItem);
		}

		private void UpdateTimesheetListViewItem(Timesheet timesheet) {
			const string noExistsError = "UpdateTimesheetListViewItem() failed in an attempt " + 
				"to update the Timesheet's ListItem in the ListView because it does not exist; " + 
				"use InsertTimesheetListViewItem() instead.";

			ListViewItem listViewItem;
			if (!GetTimesheetListViewItem(timesheet, out listViewItem)) {
				throw new InvalidOperationException(noExistsError);
			} else {
				listViewItem.StateImageIndex = timesheet.TimesheetSent ? DefaultImageList.Instance.GetLockedIconIndex() : -1;
				listViewItem.ImageIndex = DefaultImageList.Instance.GetCalendarIconIndex();

				listViewItem.SubItems[1].Text = Dates.GetMMDDYYYY(timesheet.StartDate.Date);
				listViewItem.SubItems[2].Text = Dates.GetMMDDYYYY(timesheet.EndDate.Date);
				listViewItem.SubItems[3].Text = timesheet.GetBillableHours().ToString();
				listViewItem.SubItems[4].Text = timesheet.GetFormattedRatesPerHour();
				listViewItem.SubItems[5].Text = timesheet.GetFormattedInvoiceAmount();				
			}
		}

		private bool GetTimesheetListViewItem(Timesheet timesheet, out ListViewItem timesheetListViewItem) {
			return GetTimesheetListViewItem(timesheet, out timesheetListViewItem, false);
		}

		private bool GetTimesheetListViewItem(Timesheet timesheet, out ListViewItem timesheetListViewItem, bool createIfNotExists) {
			int itemCount = m_timesheetsListView.Items.Count;
			if (itemCount == 0) {
				timesheetListViewItem = createIfNotExists ? CreateTimesheetListViewItem(timesheet) : null;
				return false;
			} else {
				foreach (ListViewItem listViewItem in m_timesheetsListView.Items) {
					if (listViewItem.Tag is Timesheet) {
						Timesheet timeheetToCheck = (Timesheet)listViewItem.Tag;
						if (timeheetToCheck.Equals(timesheet)) {
							timesheetListViewItem = listViewItem;
							return true;
						}
					}
				}

				// If we get here there is no ListViewItem associated with the timesheet in the ListView...
				timesheetListViewItem = createIfNotExists ? CreateTimesheetListViewItem(timesheet) : null;
				return false;
			}
		}

		/// <summary>
		/// This member creates ListViewItems for Timsheets.
		/// </summary>
		/// <param name="timesheet">The Timesheet from which the ListViewItems will be created.</param>
		/// <returns>A ListViewItem object.</returns>
		private ListViewItem CreateTimesheetListViewItem(Timesheet timesheet) {
			ListViewItem listViewItem = new ListViewItem(timesheet.GetFileName());
			
			listViewItem.StateImageIndex = timesheet.TimesheetSent ? DefaultImageList.Instance.GetLockedIconIndex() : -1;
			listViewItem.ImageIndex = DefaultImageList.Instance.GetCalendarIconIndex();

			if (timesheet.IsSplitTimesheet) {
				listViewItem.ForeColor = Color.Red;
			}

			listViewItem.SubItems.Add(Dates.GetMMDDYYYY(timesheet.StartDate.Date));
			listViewItem.SubItems.Add(Dates.GetMMDDYYYY(timesheet.EndDate.Date));
			listViewItem.SubItems.Add(timesheet.GetBillableHours().ToString());
			listViewItem.SubItems.Add(timesheet.GetFormattedRatesPerHour());
			listViewItem.SubItems.Add(timesheet.GetFormattedInvoiceAmount());

			listViewItem.Tag = timesheet;

			return listViewItem;
		}

		// Timesheet Totals ListView Members
		// --------------------------------------------------------------------------
		#region Timesheet Totals ListView Members
		private void InsertTimesheetTotalsListViewItem() {
			ListViewItem totalListViewItem = CreateEmptyTimesheetTotalListViewItem();
			totalListViewItem.SubItems[3].Text = m_monthlyTimesheets.GetBillableHours().ToString();
			totalListViewItem.SubItems[4].Text = m_monthlyTimesheets.GetFormattedInvoiceAmount();
			m_timesheetsListView.Items.Add(totalListViewItem);
		}

		private void UpdateTimesheetTotalsListViewItem() {
			const string noExistsError = "UpdateTimesheetTotalsListViewItem() failed in an attempt to update the Timesheet's total ListViewItem in the ListView because it does not exist; use InsertTimesheetTotalsListViewItem() instead.";

			ListViewItem totalListViewItem;
			if (!GetTimesheetTotalListViewItem(out totalListViewItem)) {
				throw new InvalidOperationException(noExistsError);
			} else {
				totalListViewItem.SubItems[3].Text = m_monthlyTimesheets.GetBillableHours().ToString();
				totalListViewItem.SubItems[4].Text = m_monthlyTimesheets.GetFormattedInvoiceAmount();
			}
		}

		private bool GetTimesheetTotalListViewItem(out ListViewItem totalListViewItem) {
			return GetTimesheetTotalListViewItem(out totalListViewItem, false);
		}

		private bool GetTimesheetTotalListViewItem(out ListViewItem totalListViewItem, bool createIfNotExists) {
			int itemCount = m_timesheetsListView.Items.Count;
			if (itemCount == 0) {
				totalListViewItem = createIfNotExists ? CreateEmptyTimesheetTotalListViewItem() : null;
				return false;
			} else {
				ListViewItem listViewItem = m_timesheetsListView.Items[itemCount - 1];
				if (!(listViewItem.Tag is MonthlyTimesheets)) {
					totalListViewItem = createIfNotExists ? CreateEmptyTimesheetTotalListViewItem() : null;
					return false;
				} else {
					totalListViewItem = listViewItem;
					return true;
				}
			}
		}

		private ListViewItem CreateEmptyTimesheetTotalListViewItem() {
			ListViewItem listViewItem = new ListViewItem(string.Empty);

			listViewItem.Font = new Font(listViewItem.Font, FontStyle.Bold);

			listViewItem.SubItems.Add(string.Empty);
			listViewItem.SubItems.Add("Total");
			listViewItem.SubItems.Add(string.Empty);
			listViewItem.SubItems.Add(string.Empty);

			// We need this to identify the ListViewItem as a timesheet total ListViewItem...
			listViewItem.Tag = m_monthlyTimesheets;

			return listViewItem;
		}
		#endregion	// Timesheet Totals ListView Members
		#endregion // Timesheets ListView Members		
	
		// Timesheet Calculations Methods
		// --------------------------------------------------------------------------
		#region Timesheet Calculations Methods
		private void AddMonthlyTimesheetCalculations() {
			// Clear out the old...
			m_calculationsContainer.Controls.Clear();						

			// Add the new...
			TimesheetCalculations timesheetCalculations = new TimesheetCalculations(m_monthlyTimesheets);
			m_calculationsContainer.Controls.Add(timesheetCalculations);
			//timesheetCalculations.Dock = DockStyle.Fill;
			//timesheetCalculations.SendToBack();
		}

		private void UpdateMonthlyTimesheetCalculations() {
			if (m_calculationsContainer.Controls.Count > 0) {
				IEnumerable<TimesheetCalculations> timesheetCalculationsCollection = m_calculationsContainer.Controls.OfType<TimesheetCalculations>();
				if (timesheetCalculationsCollection.Count() > 0) {
					TimesheetCalculations timesheetCalculations = timesheetCalculationsCollection.First();
					timesheetCalculations.Recalculate();
				}
			}
		}

		private void UpdateYearlyTimesheetCalculations() {
			if (MainForm.TimesheetYearlyOverviewForm != null) {
				int selectedYear = MainForm.TimesheetYearlyOverviewForm.SelectedYear;
				if (this.m_monthlyTimesheets.TimesheetMonth.Year == selectedYear) {
					if (MessageBox.Show("The \"Timesheet Yearly Overview\" Form is currently open. " +
						"The changes you've just made will not be reflected unless you save your work. " +
						"\n\nDo you want to save your work now?",
						"Attention",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Information,
						MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
						MonthlyTimesheetSaveProcessing();
						MainForm.TimesheetYearlyOverviewForm.UpdateCalculations();
					}
				}
			}
		}
		#endregion	// Timesheet Calculations Methods

		/// <summary>
		/// Call this member whenever you want to save the MonthlyTimesheet.
		/// DO NOT call this.MonthlyTimesheet.Save() directly because we want to disable the Apply button.
		/// </summary>
		private void MonthlyTimesheetSaveProcessing() {
			m_apply.Enabled = false;
			m_monthlyTimesheets.Save();			
		}

		// Events
		// --------------------------------------------------------------------------
		#region Events
		private void OnInvoiceNumbersSelectedIndexChanged(object sender, EventArgs e) {
			m_apply.Enabled = true;
		}

		/// <summary>
		/// Occurs when the user chooses a specific date in the calendar, or, when the user changes the 
		/// calendar month.
		/// </summary>
		/// <param name="sender">The sender e.g. the MonthlyCalendar control.</param>
		/// <param name="e">The arguments.</param>
		private void OnDateChanged(object sender, DateRangeEventArgs e) {
			DateTime selectedDateTime = m_calendar.SelectionStart;

			// If the date has changed, but only within the same year and month, we want
			// to select the appropriate timesheet in the m_timesheets ListView.
			if (!Dates.YearMonthEqual(selectedDateTime, this.PreviousDateTime)) {
				MonthlyTimesheetSaveProcessing();				
				MonthlyTimesheetChangedProcessing();
			}

			// Update the previous DateTime...
			this.PreviousDateTime = selectedDateTime;
		}

		protected void OnTimesheetsSelectedIndexChanged(object sender, EventArgs e) {
			if (m_timesheetsListView.SelectedItems.Count == 0) {
				m_calendar.BoldedDates = null;
				return;
			} else {
				ListViewItem listViewItem = m_timesheetsListView.SelectedItems[0];
				if (!(listViewItem.Tag is Timesheet)) {
					return;
				} else {
					Timesheet timesheet = (Timesheet)listViewItem.Tag;

					Collection<DateTime> dates = new Collection<DateTime>();

					DateTime date = timesheet.StartDate.Date;
					DateTime endDate = timesheet.EndDate.Date;
					while (date <= endDate) {
						dates.Add(date);
						date = date.AddDays(1);
					}

					m_calendar.BoldedDates = dates.ToArray();

					IEnumerable<TimesheetDetailContainer> timesheetDetailContainers = m_detailContainer.Controls.OfType<TimesheetDetailContainer>();
					if (timesheetDetailContainers.Count() > 0) {
						TimesheetDetailContainer timesheetDetailContainer = timesheetDetailContainers.First();
						if (timesheetDetailContainer != null) {
							timesheetDetailContainer.ScrollInToView(timesheet, true);
						}
					}
				}
			}
		}

		protected void OnApplyClick(object sender, EventArgs e) {
			MonthlyTimesheetSaveProcessing();
		}

		protected void OnGenerateFilesClick(object sender, EventArgs e) {			
			m_folderBrowserDialog.SelectedPath = Configuration.Instance.MiscellaneousConfiguration.DefaultSaveFolder;
			m_folderBrowserDialog.Description = "Save Generated Files To...";
			if (m_folderBrowserDialog.ShowDialog() == DialogResult.OK) {
				MonthlyTimesheets monthlyTimesheets = m_monthlyTimesheets;				

				string outputFolder = m_folderBrowserDialog.SelectedPath;

				FileGenerateConfirmationDialog fileGenerateConfirmationDialog = 
					new FileGenerateConfirmationDialog(monthlyTimesheets, outputFolder);
				if (fileGenerateConfirmationDialog.ShowDialog(this) == DialogResult.Cancel) {
					return;
				} else {
					InvoiceNumberComfirmationDialog invoiceNumberComfirmationDialog =
						new InvoiceNumberComfirmationDialog(monthlyTimesheets, false /* Handle the save below*/);
					if (invoiceNumberComfirmationDialog.ShowDialog(this) == DialogResult.Cancel) {
						return;
					}

					this.Enabled = false;

					// Save whatever changes were made first.
					MonthlyTimesheetSaveProcessing();

					// Generate any unsent Timesheets...
					foreach (Timesheet timesheet in monthlyTimesheets.UnSentTimesheets) {
						TimesheetGenerator timesheetGenerator = new TimesheetGenerator(timesheet, outputFolder);
						if (timesheetGenerator.Generate(false)) {
						}
						timesheetGenerator.Save();
					}

					// Generate our invoice...
					InvoiceGenerator invoiceGenerator = new InvoiceGenerator(monthlyTimesheets, outputFolder);
					if (invoiceGenerator.Generate(false)) {
					}
					invoiceGenerator.Save();

					TimesheetGenerator.QuitExcel();

					this.Enabled = true;
				}
			}
		}

		protected void OnTimesheetSentClick(object sender, EventArgs e) {
			if (m_timesheetsListView.SelectedItems.Count > 0) {			
				ListViewItem listViewItem = m_timesheetsListView.SelectedItems[0];

				if (listViewItem.Tag is Timesheet) {
					// If there is a selected timesheet, determine if the "Timesheet Sent" check is checked
					// or not. If the check is different from the original value (e.g. if it changed), we
					// need to update the timesheet and the UI.
					ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)m_timesheetContextMenu.Items[0];
					bool timesheetSent = toolStripMenuItem.Checked;

					Timesheet timesheet = (Timesheet)listViewItem.Tag;
					if (timesheet.TimesheetSent != timesheetSent) {
						m_apply.Enabled = true;
						timesheet.TimesheetSent = timesheetSent;
						UpdateTimesheetListViewItem(timesheet);
						m_detailContainer.Controls.OfType<TimesheetDetailContainer>().First().UpdateTimesheet(timesheet);
					}
				}
			}
		}
		#endregion	// Events
	};
};
