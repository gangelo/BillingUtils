using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Tools.Excel;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

using BillingUtils.Code.Helpers;
using BillingUtils.Code.Configuration;

namespace BillingUtils.Code.Generators {

	public class InvoiceGenerator : ExcelGenerator {
		public MonthlyTimesheets MonthlyTimesheets { get; protected set; }

		public InvoiceGenerator(MonthlyTimesheets monthlyTimeSheets, string outputPath)
			: base(Configuration.Configuration.Instance.InvoiceConfiguration.InvoiceTemplate, Path.Combine(new string[] { outputPath, monthlyTimeSheets.GetFileName() })) {
			this.MonthlyTimesheets = monthlyTimeSheets;
		}

		public override bool Generate(bool promptOnOverwrite) {
			if (!base.Generate(promptOnOverwrite)) {
				return false;
			} else {
				return UpdateWorkbook();
			}
		}

		// Abstract Overrides
		// --------------------------------------------------------------------------
		#region Abstract Overrides
		protected override bool UpdateWorkbook() {
			Excel.Application excelApplication = ExcelGenerator.GetExcelApplication();

			InvoiceConfiguration invoiceConfiguration = Configuration.Configuration.Instance.InvoiceConfiguration;
			PersonalConfiguration personalConfiguration = Configuration.Configuration.Instance.PersonalConfiguration;

			// Name...
			ExcelCell nameCell = Helpers.Excel.ToCell(invoiceConfiguration.NameCell);
			excelApplication.Cells[nameCell.Row, nameCell.Column].Value = personalConfiguration.Name;

			// Address...
			ExcelCell addressCell = Helpers.Excel.ToCell(invoiceConfiguration.AddressCell);
			excelApplication.Cells[addressCell.Row, addressCell.Column].Value = personalConfiguration.Address;

			// Invoice Number...
			ExcelCell invoiceNumberCell = Helpers.Excel.ToCell(invoiceConfiguration.CurrentInvoiceNumberCell);
			excelApplication.Cells[invoiceNumberCell.Row, invoiceNumberCell.Column].Value = this.MonthlyTimesheets.InvoiceNumber;

			int rowIndex = -1;
			//for (int i = 0; i < this.MonthlyTimesheets.Count; i++) {
			foreach (Timesheet timesheet in this.MonthlyTimesheets) {
				//Timesheet timesheet = this.MonthlyTimesheets[i];

				if (timesheet.IsSplitRate()) {
					// If we have a Timesheet that has split rates (e.g. all TimesheetDates do not have the same
					// RatePerHour), we need to handle this separately so it is properly reflected on the Invoice.					
					AddSplitRateEntries(ref rowIndex, timesheet, invoiceConfiguration);
				} else {
					// Note: If timesheet.IsSplitRate() == false, all the TimesheetDates within the Timesheet
					// have the same rate/hour, so all we need to do is get the RatePerHour from any TimesheetDate
					// within the Timesheet and we're good to go...
					decimal ratePerHour = timesheet[0].RatePerHour;
					AddEntry(++rowIndex, timesheet.GetBillableHours(), ratePerHour, timesheet.WeekNumber, timesheet.StartDate.Date, timesheet.EndDate.Date, invoiceConfiguration);
				}
			}

			return true;
		}

		private void AddSplitRateEntries(ref int entryIndex, Timesheet timesheet, InvoiceConfiguration invoiceConfiguration) {
			if (!timesheet.IsSplitRate()) {
				MessageBox.Show("InvoiceGenerator.AddSplitRateEntries(...) encountered a problem; parameter 'timesheet' must be a 'split rate' Timesheet (e.g Timesheet.IsSplitRate() == true).");
				return;
			}

			decimal ratePerHour = 0;
			decimal billableHours = 0;

			IEnumerable<TimesheetDate> timesheetDates = timesheet.Dates.Where(p => p.IsValidDate);
			foreach (TimesheetDate timesheetDate in timesheetDates) {
				if (ratePerHour == 0) {
					ratePerHour = timesheetDate.RatePerHour;
					billableHours += timesheetDate.BillableHours;
				} else if (timesheetDate.RatePerHour != ratePerHour) {
					// Add Entries...
					AddEntry(++entryIndex, billableHours, ratePerHour, timesheet.WeekNumber, timesheet.StartDate.Date, timesheet.EndDate.Date, invoiceConfiguration, true);

					// Reset our counters...					
					ratePerHour = timesheetDate.RatePerHour;
					billableHours = timesheetDate.BillableHours;
				} else {
					// Roll up totals...
					billableHours += timesheetDate.BillableHours;
				}
			}

			// Get the last entry...
			if (timesheetDates != null) {
				AddEntry(++entryIndex, billableHours, ratePerHour, timesheet.WeekNumber, timesheet.StartDate.Date, timesheet.EndDate.Date, invoiceConfiguration, true);
			}
		}
		#endregion	// Abstract Overrides

		protected virtual void AddEntry(
			int entryIndex,
			decimal billableHours,
			decimal ratePerHour,
			int weekNumber,
			DateTime startDate,
			DateTime endDate,
			InvoiceConfiguration invoiceConfiguration,
			bool isSplitRate = false) {
			Excel.Application excelApplication = ExcelGenerator.GetExcelApplication();

			// Qty...
			ExcelCell qtyStartCell = Helpers.Excel.ToCell(invoiceConfiguration.QtyStartCell);
			excelApplication.Cells[qtyStartCell.Row + entryIndex, qtyStartCell.Column].Value = billableHours;

			// Description...
			ExcelCell descriptionStartCell = Helpers.Excel.ToCell(invoiceConfiguration.DescriptionStartCell);

			string description = string.Format("{0} | {1}", invoiceConfiguration.Description, this.GetTimesheetWeekString(weekNumber, startDate, endDate, isSplitRate));
			excelApplication.Cells[descriptionStartCell.Row + entryIndex, descriptionStartCell.Column].Value = description;

			// PO Number...
			int PONumber = invoiceConfiguration.PONumber;
			ExcelCell POStartCell = Helpers.Excel.ToCell(invoiceConfiguration.PONumberStartCell);
			excelApplication.Cells[POStartCell.Row + entryIndex, POStartCell.Column].Value = invoiceConfiguration.PONumber;

			// Rate...			
			ExcelCell rateStartCell = Helpers.Excel.ToCell(invoiceConfiguration.RateStartCell);
			excelApplication.Cells[rateStartCell.Row + entryIndex, rateStartCell.Column].Value = ratePerHour;
		}

		protected string GetTimesheetWeekString(int weekNumber, DateTime startDate, DateTime endDate, bool isSplitRate = false) {
			string fromDate = Helpers.Dates.GetMMDDYYYY(startDate.Date, '-');
			string toDate = Helpers.Dates.GetMMDDYYYY(endDate.Date, '-');

			const string formatString = "Week {0} ({1} Thru {2})";

			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(formatString, weekNumber.ToString(), fromDate, toDate);
			if (isSplitRate) {
				stringBuilder.Append(" | Rate Change");
			}
			return stringBuilder.ToString();
		}
	};
};
