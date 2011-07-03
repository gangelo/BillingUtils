using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BillingUtils.Code;
using BillingUtils.Code.Helpers;

namespace BillingUtils.UserControls {

	public partial class TimesheetDetailListView : UserControl {
		// Fields
		// --------------------------------------------------------------------------
		#region Fields
		static private object m_syncRoot = new object();
		static private Color EvenColor { get { return Color.WhiteSmoke; } }
		static private Color OddColor { get { return Color.Gray; } }
		static private Color SplitColor { get { return Color.Salmon; } }
		static private Color SelectedColor { get { return Color.PaleGreen; } }
		
		public class TimesheetDetailEventArgs : EventArgs {
			public Timesheet Timesheet { get; protected set; }

			public TimesheetDetailEventArgs(Timesheet timesheet) {
				this.Timesheet = timesheet;
			}
		};

		public Timesheet Timesheet { get; protected set; }
		public EventHandler<TimesheetDetailEventArgs> TimesheetDetailUpdatingEvent { get; set; }
		public EventHandler<TimesheetDetailEventArgs> TimesheetDetailUpdatedEvent { get; set; }
		#endregion	// Fields

		// Construction/Initialization
		// --------------------------------------------------------------------------
		#region Construction/Initialization
		public TimesheetDetailListView(Timesheet timesheet) {
			InitializeComponent();
			
			this.Timesheet = timesheet;

			InitializeListView();

			// Scroll options...
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

			// Header...
			if (timesheet.IsSplitTimesheet) {
				m_header.Text = string.Format("Week {0} ({1} through {2}, {3} of 2)",
					timesheet.WeekNumber,
					Dates.GetMMDDYYYY(timesheet.StartDate.Date),
					Dates.GetMMDDYYYY(timesheet.EndDate.Date),
					timesheet.SplitIndex
				);
			} else {
				m_header.Text = string.Format("Week {0} ({1} through {2})",
					timesheet.WeekNumber,
					Dates.GetMMDDYYYY(timesheet.StartDate.Date),
					Dates.GetMMDDYYYY(timesheet.EndDate.Date)
				);
			}

			// Background color...
			if (this.Timesheet.IsSplitTimesheet) {
				this.BackColor = TimesheetDetailListView.SplitColor;
			} else {
				this.BackColor = TimesheetDetailListView.GetDefaultTimesheetBackColor(this.Timesheet);
			}
		}

		private void InitializeListView() {
			m_listView.SmallImageList = DefaultImageList.Instance.ImageList;
			m_listView.StateImageList = DefaultImageList.Instance.ImageList;

			m_listView.View = View.Details;
			m_listView.GridLines = true;
			m_listView.FullRowSelect = true;
			m_listView.MultiSelect = false;
			m_listView.Scrollable = true;
			
			m_listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			m_listView.Columns.Add("date", "Date", 150);
			m_listView.Columns.Add("day", "Day", 150);
			m_listView.Columns.Add("type", "Type", 150);
			m_listView.Columns.Add("hours", "Hours", 150).TextAlign = HorizontalAlignment.Right;
			m_listView.Columns.Add("rate", "$ Rate", 150).TextAlign = HorizontalAlignment.Right;
			m_listView.Columns.Add("amount", "$ Amount", 150).TextAlign = HorizontalAlignment.Right;
			m_listView.Columns.Add("notes", "Notes", 150);

			m_listView.MouseDoubleClick += new MouseEventHandler(this.OnListViewMouseDoubleClick);

			foreach (TimesheetDate timesheetDate in this.Timesheet) {
				this.InsertTimesheetDateListViewItem(timesheetDate);
			}

			ResizeTimesheetDetailListViewColumns();
		} 
		#endregion	// Construction/Initialization

		public void UpdateTimesheet() {
			foreach (TimesheetDate timesheetDate in this.Timesheet) {
				UpdateTimesheetDetailListViewItem(timesheetDate);
			}
		}

		public void SelectTimesheet(bool select) {
			if (select) {
				this.BackColor = TimesheetDetailListView.SelectedColor;
			} else {
				this.BackColor = TimesheetDetailListView.GetDefaultTimesheetBackColor(this.Timesheet);
			}
		}

		static private Color GetDefaultTimesheetBackColor(Timesheet timesheet) {			
			if (timesheet.IsSplitTimesheet) {
				return TimesheetDetailListView.SplitColor;
			} else {
				int result;
				Math.DivRem(timesheet.WeekNumber, 2, out result);
				return (result == 0) ? TimesheetDetailListView.EvenColor : TimesheetDetailListView.OddColor;
			}
		}

		// Timesheet Detail ListView Members
		// --------------------------------------------------------------------------
		#region Timesheet Detail ListView Members
		private void InsertTimesheetDateListViewItem(TimesheetDate timesheetDate) {
			ListViewItem timesheetDateListViewItem = CreateTimesheetDetailListViewItem(timesheetDate);
			m_listView.Items.Add(timesheetDateListViewItem);
		}

		private void UpdateTimesheetDetailListViewItem(TimesheetDate timesheetDate) {
			const string noExistsError = "UpdateTimesheetDateListViewItem() failed in an attempt " +
				"to update the Timesheet's Detail ListItem in the ListView because it does not exist; " +
				"use InsertDayTypesListViewItem() instead.";

			ListViewItem listViewItem;
			if (!GetTimesheetDetailListViewItem(timesheetDate, out listViewItem)) {
				throw new InvalidOperationException(noExistsError);
			} else {
				listViewItem.StateImageIndex = timesheetDate.Timesheet.TimesheetSent ? DefaultImageList.Instance.GetLockedIconIndex() : -1;
				listViewItem.ImageIndex = DefaultImageList.Instance.GetCalendarIconIndex();

				listViewItem.Text = Dates.GetMMDDYYYY(timesheetDate.Date);
				listViewItem.SubItems[1].Text = timesheetDate.Date.DayOfWeek.ToString();
				listViewItem.SubItems[2].Text = timesheetDate.DayType.Name;
				listViewItem.SubItems[3].Text = timesheetDate.BillableHours.ToString();
				listViewItem.SubItems[4].Text = timesheetDate.GetFormattedRatePerHour();
				listViewItem.SubItems[5].Text = timesheetDate.GetFormattedInvoiceAmount();
				listViewItem.SubItems[6].Text = timesheetDate.Notes;
			}
		}

		private bool GetTimesheetDetailListViewItem(TimesheetDate timesheetDate, out ListViewItem timesheetDetailListViewItem) {
			return GetTimesheetDetailListViewItem(timesheetDate, out timesheetDetailListViewItem, false);
		}

		private bool GetTimesheetDetailListViewItem(TimesheetDate timesheetDate, out ListViewItem timesheetDetailListViewItem, bool createIfNotExists) {
			int itemCount = m_listView.Items.Count;
			if (itemCount == 0) {
				timesheetDetailListViewItem = createIfNotExists ? CreateTimesheetDetailListViewItem(timesheetDate) : null;
				return false;
			} else {
				foreach (ListViewItem listViewItem in m_listView.Items) {
					if (listViewItem.Tag is TimesheetDate) {
						TimesheetDate timeheetDateToCheck = (TimesheetDate)listViewItem.Tag;
						if (timeheetDateToCheck.Equals(timesheetDate)) {
							timesheetDetailListViewItem = listViewItem;
							return true;
						}
					}
				}

				// If we get here there is no ListViewItem associated with the timesheetDate in the ListView...
				timesheetDetailListViewItem = createIfNotExists ? CreateTimesheetDetailListViewItem(timesheetDate) : null;
				return false;
			}
		}

		/// <summary>
		/// This member creates ListViewItems for Timsheets.
		/// </summary>
		/// <param name="timesheet">The Timesheet from which the ListViewItems will be created.</param>
		/// <returns>A ListViewItem object.</returns>
		private ListViewItem CreateTimesheetDetailListViewItem(TimesheetDate timesheetDate) {
			ListViewItem listViewItem = new ListViewItem(Dates.GetMMDDYYYY(timesheetDate.Date));

			Timesheet timesheet = timesheetDate.Timesheet;

			if (timesheet.IsSplitTimesheet) {
				if (timesheetDate.IsWeekday) {
					listViewItem.ForeColor = (timesheetDate.IsValidDate && timesheetDate.BillableHours == 0) ? Color.DarkRed : Color.Red;
				} else {
					listViewItem.ForeColor = Color.Red;
				}
			} else {
				if (timesheetDate.IsValidDate) {
					if (timesheetDate.IsWeekday && timesheetDate.BillableHours == 0) {
						listViewItem.ForeColor = Color.DarkRed;
					}
				}
			}

			listViewItem.Font = (timesheetDate.IsValidDate) ? listViewItem.Font : new Font(listViewItem.Font, FontStyle.Strikeout);			 
			
			listViewItem.StateImageIndex = timesheetDate.Timesheet.TimesheetSent ? DefaultImageList.Instance.GetLockedIconIndex() : -1;
			listViewItem.ImageIndex = DefaultImageList.Instance.GetCalendarIconIndex();

			listViewItem.SubItems.Add(timesheetDate.Date.DayOfWeek.ToString());
			listViewItem.SubItems.Add(timesheetDate.DayType.Name);
			listViewItem.SubItems.Add(timesheetDate.BillableHours.ToString());
			listViewItem.SubItems.Add(timesheetDate.GetFormattedRatePerHour());
			listViewItem.SubItems.Add(timesheetDate.GetFormattedInvoiceAmount());
			listViewItem.SubItems.Add(timesheetDate.Notes);

			listViewItem.Tag = timesheetDate;

			return listViewItem;
		}

		private void ResizeTimesheetDetailListViewColumns() {
			m_listView.Columns["date"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_listView, "date"));
			m_listView.Columns["day"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_listView, "day"));
			m_listView.Columns["type"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_listView, "type"));
			m_listView.Columns["hours"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_listView, "hours"));
			m_listView.Columns["rate"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_listView, "rate"));
			m_listView.Columns["amount"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_listView, "amount"));
			m_listView.Columns["notes"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_listView, "notes"));
		}
		#endregion	// Timesheet Detail ListView Members

		// Events
		// --------------------------------------------------------------------------
		#region Events
		protected void OnListViewMouseDoubleClick(object sender, MouseEventArgs e) {
			if (m_listView.SelectedIndices.Count > 0) {				
				TimesheetDate timesheetDate = (TimesheetDate)m_listView.SelectedItems[0].Tag;
				if (!timesheetDate.IsValidDate || timesheetDate.Timesheet.TimesheetSent) {
					// If the Timesheet has been sent, or, if it is an invali date, do not allow updates.
					return;
				} else {
					TimesheetDateEditForm form = new TimesheetDateEditForm(timesheetDate);
					if (form.ShowDialog(this) == DialogResult.OK) {
						if (form.ValuesChanged) {
							if (this.TimesheetDetailUpdatingEvent != null) {
								TimesheetDetailEventArgs args = new TimesheetDetailEventArgs(this.Timesheet);
								this.TimesheetDetailUpdatingEvent(this, args);
							}

							// Suspend the changed events because we're going to make the calls to update our
							// Timesheet and Timesheet detail manually.
							timesheetDate.SuspendChangedEvent(true);
							timesheetDate.BillableHours = form.BillableHours;							
							timesheetDate.DayType = form.DayType;
							timesheetDate.Notes = form.Notes;
							timesheetDate.SuspendChangedEvent(false);

							UpdateTimesheetDetailListViewItem(timesheetDate);
							ResizeTimesheetDetailListViewColumns();

							if (this.TimesheetDetailUpdatedEvent != null) {
								TimesheetDetailEventArgs args = new TimesheetDetailEventArgs(this.Timesheet);
								this.TimesheetDetailUpdatedEvent(this, args);
							}
						}
					}
				}
			} 
		#endregion	// Events
		}
	};
};
