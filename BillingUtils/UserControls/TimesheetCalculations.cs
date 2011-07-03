using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BillingUtils.Code;
using BillingUtils.Code.Helpers;
using BillingUtils.Code.Configuration;

namespace BillingUtils.UserControls {
	
	public partial class TimesheetCalculations : UserControl {
		private int ExpandHeight { get; set; }
		private int CollapseHeight { get; set; }

		public MonthlyTimesheets MonthlyTimesheets { get; protected set; }

		public TimesheetCalculations() {
			InitializeComponent();
		}

		public TimesheetCalculations(MonthlyTimesheets monthlyTimesheets) {
			InitializeComponent();

			this.MonthlyTimesheets = monthlyTimesheets;

			m_collapseButton.Click += new EventHandler(
				delegate(object sender, EventArgs e) {
					bool expanded = Convert.ToBoolean(this.Tag);

					this.Height = expanded ? this.CollapseHeight : this.ExpandHeight;
					m_collapseButton.Image = expanded ? BillingUtils.Properties.Resources.Expand : BillingUtils.Properties.Resources.Collapse;

					this.Tag = !expanded;
				}
				);

			m_collapseButton.Image = BillingUtils.Properties.Resources.Collapse;

			this.Tag = true;	// Expanded

			SetColors();

			Recalculate();
		}

		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);

			this.ExpandHeight = this.Height;
			this.CollapseHeight = m_actionsPanel.Height;
		}

		private void SetColors() {
			m_executiveOrdersLabel.ForeColor = DayTypes.GetDayTypeForeColor(DayType.ExecutiveOrder);
			m_flexDaysLabel.ForeColor = DayTypes.GetDayTypeForeColor(DayType.FlexDay);
			m_halfDaysLabel.ForeColor = DayTypes.GetDayTypeForeColor(DayType.HalfDay);
			m_otherDaysLabel.ForeColor = DayTypes.GetDayTypeForeColor(DayType.Other);
			m_sickDaysLabel.ForeColor = DayTypes.GetDayTypeForeColor(DayType.SickDay);
			m_vacationDaysLabel.ForeColor = DayTypes.GetDayTypeForeColor(DayType.VacationDay);
			m_weekendsLabel.ForeColor = DayTypes.GetDayTypeForeColor(DayType.Weekend);
			m_workDaysLabel.ForeColor = DayTypes.GetDayTypeForeColor(DayType.WorkDay);

			m_executiveOrders.ForeColor = DayTypes.GetDayTypeForeColor(DayType.ExecutiveOrder);
			m_flexDays.ForeColor = DayTypes.GetDayTypeForeColor(DayType.FlexDay);
			m_halfDays.ForeColor = DayTypes.GetDayTypeForeColor(DayType.HalfDay);
			m_otherDays.ForeColor = DayTypes.GetDayTypeForeColor(DayType.Other);
			m_sickDays.ForeColor = DayTypes.GetDayTypeForeColor(DayType.SickDay);
			m_vacationDays.ForeColor = DayTypes.GetDayTypeForeColor(DayType.VacationDay);
			m_weekends.ForeColor = DayTypes.GetDayTypeForeColor(DayType.Weekend);
			m_workDays.ForeColor = DayTypes.GetDayTypeForeColor(DayType.WorkDay);
		}

		private void DoBillableHoursCheck() {
			decimal value = Convert.ToDecimal(m_hoursWorkedCheckDifference.Tag);

			const string okMessage = "Success:\r\n\r\nThe hours you have worked are either less than or equal to the maximum allowable hours for this month." +
				" No changes to your billable hours are necessary.";

			const string notOkMessage = "Warning:\r\n\r\nThe hours you have worked are greater than the maximum allowable hours for this month." +
				"  Changes must be made to your billable hours before you submit your timesheet and invoice.";
			
			m_message.Text = (value <= 0.00m) ? okMessage : notOkMessage;
			m_message.ForeColor = (value <= 0.00m) ? Color.DarkGreen : Color.DarkRed;
		}

		public void Recalculate() {
			MonthlyTimesheets monthlyTimesheets = this.MonthlyTimesheets;

			int executiveOrderCount = monthlyTimesheets.GetDayTypeCount(DayType.ExecutiveOrder);
			int flexDayCount = monthlyTimesheets.GetDayTypeCount(DayType.FlexDay);
			int halfDayCount = monthlyTimesheets.GetDayTypeCount(DayType.HalfDay);
			int NACount = monthlyTimesheets.GetDayTypeCount(DayType.NA);
			int otherCount = monthlyTimesheets.GetDayTypeCount(DayType.Other);
			int personalDayCount = monthlyTimesheets.GetDayTypeCount(DayType.PersonalDay);
			int sickDayCount = monthlyTimesheets.GetDayTypeCount(DayType.SickDay);
			int vacationDayCount = monthlyTimesheets.GetDayTypeCount(DayType.VacationDay);
			int workDayCount = monthlyTimesheets.GetDayTypeCount(DayType.WorkDay);
			int weekendCount = monthlyTimesheets.GetDayTypeCount(DayType.Weekend);

			// Real work days...			
			int realWorkDayCount = monthlyTimesheets.GetWeekdayCount() - executiveOrderCount;
			m_realWorkDays.Text = realWorkDayCount.ToString();

			// Work days...			
			m_workDays.Text = workDayCount.ToString();

			// Max billable hours			
			decimal maxBillableHours = (realWorkDayCount * Configuration.Instance.MiscellaneousConfiguration.DefaultMaxBillableHoursPerWorkDay);
			m_maxBillableHours.Text = maxBillableHours.ToString(Constants.HoursFormatString);

			// Weekends...			
			m_weekends.Text = weekendCount.ToString();

			// Executive orders...			
			m_executiveOrders.Text = executiveOrderCount.ToString();

			// Flex days...			
			m_flexDays.Text = flexDayCount.ToString();

			// Vacation days...			
			m_vacationDays.Text = vacationDayCount.ToString();

			// Half days...			
			m_halfDays.Text = halfDayCount.ToString();

			// Sick days...			
			m_sickDays.Text = sickDayCount.ToString();

			// "Other" days...			
			m_otherDays.Text = otherCount.ToString();

			// N/A?

			// Billable hours...
			decimal billableHours = monthlyTimesheets.GetBillableHours();
			m_billableHours.Text = billableHours.ToString(Constants.HoursFormatString);

			// Check...
			decimal hoursWorkedCheckDifference = (billableHours - maxBillableHours);

			m_hoursWorkedCheckDifference.Tag = hoursWorkedCheckDifference;
			m_hoursWorkedCheckDifference.Text = (hoursWorkedCheckDifference > 0.00m) ? "+" : "";
			m_hoursWorkedCheckDifference.Text += hoursWorkedCheckDifference.ToString();
			bool isOver = hoursWorkedCheckDifference > 0.00m;
			m_hoursWorkedCheckDifference.ForeColor = isOver ? Color.DarkRed : Color.DarkGreen;

			m_billableHoursCheckLabel.ForeColor = isOver ? Color.DarkRed : Color.DarkGreen;
			m_billableHoursCheckInformation.ForeColor = isOver ? Color.DarkRed : Color.DarkGreen;
			m_hoursWorkedCheckDifferenceLabel.ForeColor = isOver ? Color.DarkRed : Color.DarkGreen;
			m_billableHoursCheckPictureBox.BackColor = isOver ? Color.DarkRed : Color.DarkGreen;

			DoBillableHoursCheck();
		}
	};
};
