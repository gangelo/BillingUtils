using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BillingUtils.Code;
using BillingUtils.Code.Helpers;
using BillingUtils.Code.ContextMenus;
using BillingUtils.Code.Configuration;
using BillingUtils.UserControls;
using BillingUtils.UserControls.TreeView;

namespace BillingUtils {

	public partial class TimesheetYearlyOverviewForm : Form {
		private RangeTimesheets RangeTimesheets { get; set; }

		public TimesheetYearlyOverviewForm() {
			InitializeComponent();
			InitializeTreeView();
			InitializeStartDate();
			InitializeEndDate();
			InitializeRefreshButton();			
			SetColors();
		}

		private void InitializeTreeView() {
			m_treeView.CheckBoxes = true;			
			m_treeView.ImageList = DefaultImageList.Instance.ImageList;
			
			m_treeView.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.OnNodeMouseClick);
			
			m_treeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
			m_treeView.DrawNode += new DrawTreeNodeEventHandler(
				delegate(object sender, DrawTreeNodeEventArgs e) {
					TreeNodeEx treeNode = e.Node as TreeNodeEx;
					if (treeNode != null) {
						if (!treeNode.CheckBox) {
							TreeNodeEx.ShowCheckBox(treeNode);
						}
					}
					e.DrawDefault = true;
				});

			m_treeView.TreeViewExNodesCheckedEvent += new TreeViewExTimesheetDateTreeNodesCheckedEventHandler(
				delegate(TreeViewEx treeView, TreeViewExTimesheetDateTreeNodesCheckedEventArgs e) {
					UpdateCalculations(e.TimesheetDateTreeNodes);
				});

			m_treeView.AfterCheck += new TreeViewEventHandler(
				delegate(object sender, TreeViewEventArgs e) {
					TreeViewEx treeView = (TreeViewEx)sender;
					UpdateCalculations(treeView.GetCheckedTimesheetDateTreeNodes());
				});			
		}		

		private void InitializeStartDate() {
			m_startDate.Value = new DateTime(DateTime.Now.Year, 1, 1);
			m_startDate.ValueChanged += new EventHandler(
				delegate(object sender, EventArgs e) {
					InitializeEndDate();
				});
		}

		private void InitializeEndDate() {
			DateTime dateTime = new DateTime(m_startDate.Value.Year, m_startDate.Value.Month, m_startDate.Value.Day);			
			dateTime = dateTime.AddYears(1);			
			m_endDate.Value = dateTime;
			m_endDate.Tag = dateTime;

			m_endDate.ValueChanged += new EventHandler(
				delegate(object sender, EventArgs e) {
					if (m_endDate.Value < m_startDate.Value) {
						m_endDate.Value = (DateTime)m_endDate.Tag;
					} else {
						m_endDate.Tag = m_endDate.Value;
					}
				});
		}

		private void InitializeRefreshButton() {
			m_refresh.Click += new EventHandler(
				delegate(object sender, EventArgs e) {
					m_treeView.Nodes.Clear();															
					UpdateTreeView();
					if (m_treeView.Nodes.Count == 0) {
						UpdateCalculations();
					} else {
						TreeViewHelpers.CheckBoxes.CheckAll((TreeNodeEx)m_treeView.Nodes[0]);
						// No need for the below because calling TreeViewHelpers.CheckBoxes.CheckAll(...)
						// will invoke a callback that updates the calculations.
						//UpdateCalculations(m_treeView.GetCheckedTimesheetDateTreeNodes());
					}
				});
		}		

		public int SelectedYear {
			get { return Convert.ToInt32(m_years.SelectedItem); }
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

		public void UpdateCalculations(List<TimesheetDateTreeNode> checkedTreeNodes = null) {
			if (checkedTreeNodes == null || checkedTreeNodes.Count(p => p.CheckBox) == 0) {
				m_realWorkDays.Text = "0";
				m_workDays.Text = "0";
				m_maxBillableHours.Text = "0.0";
				m_weekends.Text = "0";
				m_executiveOrders.Text="";
				m_flexDays.Text = "0";
				m_vacationDays.Text = "0";
				m_halfDays.Text = "0";
				m_sickDays.Text = "0";
				m_otherDays.Text = "0";
				m_billableHours.Text = "0.0";
				m_estimatedYearlyIncome.Text = "$0.00";
				return;
			}

			int executiveOrderCount = checkedTreeNodes.Count(p => p.Tag.DayType.IsExecutiveOrder);
			int flexDayCount = checkedTreeNodes.Count(p => p.Tag.DayType.IsFlexDay);
			int halfDayCount = checkedTreeNodes.Count(p => p.Tag.DayType.IsHalfDay);
			int NACount = checkedTreeNodes.Count(p => p.Tag.DayType.IsNA);
			int otherCount = checkedTreeNodes.Count(p => p.Tag.DayType.IsOther);
			int personalDayCount = checkedTreeNodes.Count(p => p.Tag.DayType.IsPersonalDay);
			int sickDayCount = checkedTreeNodes.Count(p => p.Tag.DayType.IsSickDay);
			int vacationDayCount = checkedTreeNodes.Count(p => p.Tag.DayType.IsVacationDay);
			int workDayCount = checkedTreeNodes.Count(p => p.Tag.DayType.IsWorkDay);
			int weekendCount = checkedTreeNodes.Count(p => p.Tag.DayType.IsWeekend);
			int weekdayCount = checkedTreeNodes.Count(p => p.Tag.IsWeekday);
			
			// Real work days...			
			int realWorkDayCount = weekdayCount - executiveOrderCount;
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
			decimal billableHours = checkedTreeNodes.Sum(p => p.Tag.BillableHours);			
			m_billableHours.Text = billableHours.ToString(Constants.HoursFormatString);

			// Check...
			decimal hoursWorkedCheckDifference = (billableHours - maxBillableHours);

			decimal totalAmount = checkedTreeNodes.Sum(p => p.Tag.InvoiceAmount);			

			// Estimated yearly income...
			m_estimatedYearlyIncome.Text = totalAmount.ToString(Constants.MoneyFormatString);
		}	

		private void UpdateTreeView() {
			DateTime startDate = m_startDate.Value;
			DateTime endDate = m_endDate.Value;

			//DateTime timesheetStartDate = new DateTime(startDate.Year, startDate.Month, 1);
			//DateTime timesheetEndDate = endDate.AddMonths(1).AddDays(-endDate.Day);

			RangeTimesheets rangeTimesheets = new RangeTimesheets(startDate, endDate);
			this.RangeTimesheets = rangeTimesheets;
						
			int totalTimesheets = rangeTimesheets.Count;

			RootTreeNode rootNode = new RootTreeNode("Root", DefaultImageList.Instance.GetRootIconIndex());
			
			// Monthly Timesheets...
			foreach (MonthlyTimesheets monthlyTimesheets in rangeTimesheets.MonthlyTimesheets) {				
			
				// Timesheets...
				foreach (Timesheet timesheet in monthlyTimesheets.Timesheets) {
				
					// TimesheetDates...
					foreach (TimesheetDate timesheetDate in timesheet.Dates.Where(p=>p.IsValidDate)) {
						if (timesheetDate.Date < startDate || timesheetDate.Date > endDate) {
							continue;
						}

						Color foreColor = DayTypes.GetDayTypeForeColor(timesheetDate.DayType);

						TimesheetDateTreeNode treeNode = new TimesheetDateTreeNode(timesheetDate, DefaultImageList.Instance.GetCalendarIconIndex());
						treeNode.ForeColor = foreColor;

						AddTimesheetDateTreeNodeDetailNodes(treeNode, timesheetDate, foreColor);

						rootNode.Nodes.Add(treeNode);
					}
				}				
			}

			rootNode.Expand();
			m_treeView.Nodes.Add(rootNode);
		}

		private void AddTimesheetDateTreeNodeDetailNodes(TimesheetDateTreeNode timesheetDateTreeNode, TimesheetDate timesheetDate, Color foreColor) {
			TreeNodeEx treeNode = null;
			int imageIndex = DefaultImageList.Instance.GetPropertyIconIndex();

			// DayType Name...
			treeNode = new TimesheetDateDetailTreeNode(timesheetDate.DayType.Name, imageIndex);
			treeNode.ForeColor = foreColor;
			timesheetDateTreeNode.Nodes.Add(treeNode);

			// Billable Hours...
			treeNode = new TimesheetDateDetailTreeNode(string.Format("Billable Hours: {0}", timesheetDate.GetFormattedBillableHours()), imageIndex);
			treeNode.ForeColor = foreColor;
			timesheetDateTreeNode.Nodes.Add(treeNode);

			// Rate Per Hour...
			treeNode = new TimesheetDateDetailTreeNode(string.Format("Rate Per Hour: {0}", timesheetDate.GetFormattedRatePerHour()), imageIndex);
			treeNode.ForeColor = foreColor;
			timesheetDateTreeNode.Nodes.Add(treeNode);
		}	
		
		protected virtual void OnNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e) {
			// Check for context menu request.
			if (e.Button == System.Windows.Forms.MouseButtons.Right) {
				TreeNodeEx treeNode = e.Node as TreeNodeEx;
				if (treeNode != null) {
					m_treeView.SelectedNode = treeNode;
					TreeViewExContextMenu contextMenu = new TreeViewExContextMenu(treeNode);
					contextMenu.GetContextMenu().Show(m_treeView, e.Location);					
				}
			}
		}
	};
};
