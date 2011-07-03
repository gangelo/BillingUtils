using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BillingUtils.Code;

namespace BillingUtils.UserControls {
	
	public partial class TimesheetDetailContainer : UserControl {
		// Region Name
		// --------------------------------------------------------------------------
		#region Region Name
		private MonthlyTimesheets m_monthlyTimesheets;
		
		public EventHandler<TimesheetDetailListView.TimesheetDetailEventArgs> TimesheetDetailUpdatingEvent { get; set; }
		public EventHandler<TimesheetDetailListView.TimesheetDetailEventArgs> TimesheetDetailUpdatedEvent { get; set; }
		#endregion	// Region Name

		// Construction/Initialization
		// --------------------------------------------------------------------------
		#region Construction/Initialization
		public TimesheetDetailContainer() {
		}
		#endregion	// Construction/Initialization

		// Properties
		// --------------------------------------------------------------------------
		#region Properties
		public MonthlyTimesheets MonthlyTimesheets {
			get { return m_monthlyTimesheets; }
			protected set { m_monthlyTimesheets = value; }
		}
		#endregion	// Properties		

		/// <summary>
		/// Clears all Timesheet Detail from the control.
		/// </summary>
		public virtual void Clear() {
			this.MonthlyTimesheets = null;
			this.Controls.Clear();
		}

		public virtual void UpdateMonthlyTimesheets(MonthlyTimesheets monthlyTimesheets) {
			this.Clear();

			// Note: Must populate property MonthlyTimesheets AFTER Clear() is called because
			// Clear() nulls out MonthlyTimesheets.
			this.MonthlyTimesheets = monthlyTimesheets;

			int y = 0;

			foreach (Timesheet timesheet in this.MonthlyTimesheets) {
				TimesheetDetailListView timesheetDetailListView = new TimesheetDetailListView(timesheet);

				timesheetDetailListView.TimesheetDetailUpdatingEvent += 
					new EventHandler<TimesheetDetailListView.TimesheetDetailEventArgs>(this.OnTimesheetUpdating);
				timesheetDetailListView.TimesheetDetailUpdatedEvent +=
					new EventHandler<TimesheetDetailListView.TimesheetDetailEventArgs>(this.OnTimesheetUpdated);

				Controls.Add(timesheetDetailListView);

				timesheetDetailListView.Dock = DockStyle.Top;
				timesheetDetailListView.Location = new Point(0, y + 1);

				timesheetDetailListView.BringToFront();
				
				y += timesheetDetailListView.Height;
			}

			this.AutoScroll = true;
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;			
		}	

		/// <summary>
		/// Scrolls the Timesheet in to view.
		/// </summary>
		/// <param name="timesheet">The Timesheet to scroll in to view.</param>
		public void ScrollInToView(Timesheet timesheet, bool selectTimesheet) {
			this.AutoScroll = false;

			TimesheetDetailListView timesheetDetailListView = GetTimesheetDetailListView(timesheet);				
			Point point = this.ScrollToControl(timesheetDetailListView);			
			this.AutoScrollPosition = point;
			this.TopLevelControl.AutoScrollOffset = point;			
			this.SetDisplayRectLocation(point.X, point.Y);

			this.AutoScroll = true;

			if (selectTimesheet) {
				this.SelectTimesheet(timesheet);
			}
		}

		/// <summary>
		/// Updates the Timesheet.
		/// </summary>
		/// <param name="timesheet">The Timesheet to be updated.</param>
		/// <remarks>Call this member when a Timesheet has been or needs to be updated so that the changes
		/// are reflected in the UI.</remarks>
		public void UpdateTimesheet(Timesheet timesheet) {
			TimesheetDetailListView timesheetDetailListView = GetTimesheetDetailListView(timesheet);				
			timesheetDetailListView.UpdateTimesheet();
		}

		/// <summary>
		/// Selects the Timesheet, that is, the TimesheetDetailListView object is highlighted in some way
		/// to indicate it has been selected by the user.
		/// </summary>
		/// <param name="timesheet">The Timesheet to be selected.</param>
		public void SelectTimesheet(Timesheet timesheet) {
			// Select the indicated TimesheetDetailListView object...
			GetTimesheetDetailListView(timesheet).SelectTimesheet(true);

			// UNselect all other TimesheetDetailListView's...
			IEnumerable<TimesheetDetailListView> notEqualTimesheets = GetTimesheetDetailListViewNotEqual(timesheet);
			if (notEqualTimesheets.Count() > 0) {
				foreach (TimesheetDetailListView timesheetDetailListView in notEqualTimesheets) {
					timesheetDetailListView.SelectTimesheet(false);
				}
			}
		}

		private TimesheetDetailListView GetTimesheetDetailListView(Timesheet timesheet) {
			return this.Controls.OfType<TimesheetDetailListView>().Where(p => p.Timesheet.Equals(timesheet)).First();
		}

		private IEnumerable<TimesheetDetailListView> GetTimesheetDetailListViewNotEqual(Timesheet timesheet) {
			return this.Controls.OfType<TimesheetDetailListView>().Where(p => !p.Timesheet.Equals(timesheet));
		}

		protected void OnTimesheetUpdating(object sender, TimesheetDetailListView.TimesheetDetailEventArgs e) {
			if (this.TimesheetDetailUpdatingEvent != null) {				
				this.TimesheetDetailUpdatingEvent(this, e);
			}
		}

		protected void OnTimesheetUpdated(object sender, TimesheetDetailListView.TimesheetDetailEventArgs e) {
			if (this.TimesheetDetailUpdatedEvent != null) {				
				this.TimesheetDetailUpdatedEvent(this, e);
			}
		}
	};
};
