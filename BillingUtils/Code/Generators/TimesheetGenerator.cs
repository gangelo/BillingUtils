using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Office.Tools.Excel;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

using BillingUtils.Code;
using BillingUtils.Code.Configuration;

namespace BillingUtils.Code.Generators {

	public class TimesheetGenerator : ExcelGenerator {
		public Timesheet Timesheet { get; protected set; }

		public TimesheetGenerator(Timesheet timesheet, string outputPath)
			: base(Configuration.Configuration.Instance.TimesheetConfiguration.TimesheetTemplate, Path.Combine(new string[] { outputPath, timesheet.GetFileName() })) {
			this.Timesheet = timesheet;
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

			TimesheetConfiguration timesheetConfiguration = Configuration.Configuration.Instance.TimesheetConfiguration;
			PersonalConfiguration personalConfiguration = Configuration.Configuration.Instance.PersonalConfiguration;

			ExcelCell cell = null;

			// Notes and remarks cell
			ExcelCell notesAndRemarksCell = Helpers.Excel.ToCell(timesheetConfiguration.NotesAndRemarksCell);

			// Timesheet name...
			cell = Helpers.Excel.ToCell(timesheetConfiguration.NameCell);
			excelApplication.Cells[cell.Row, cell.Column].Value = personalConfiguration.Name;

			// From date...
			cell = Helpers.Excel.ToCell(timesheetConfiguration.StartDateCell);
			excelApplication.Cells[cell.Row, cell.Column].Value = this.Timesheet.StartDate.Date;

			// Timesheet project description...
			cell = Helpers.Excel.ToCell(timesheetConfiguration.ProjectDescriptionCell);
			excelApplication.Cells[cell.Row, cell.Column].Value = timesheetConfiguration.ProjectDescription;

			// Billable hours...
			// -------------------------------------------------------------------
			string hourCellString = string.Empty;
			DayOfWeek dayOfWeek;
			TimesheetDate timesheetDate = null;

			// Monday...
			hourCellString = timesheetConfiguration.MondayHourCell;
			dayOfWeek = DayOfWeek.Monday;

			cell = Helpers.Excel.ToCell(hourCellString);
			timesheetDate = this.Timesheet.Dates.First(p => p.Date.DayOfWeek == dayOfWeek);
			excelApplication.Cells[cell.Row, cell.Column].Value = timesheetDate.BillableHours;
			if (timesheetDate.HasNotes) {
				AddNote(excelApplication, timesheetDate.Date, timesheetDate.Notes, notesAndRemarksCell);
			}

			// Tuesday...
			hourCellString = timesheetConfiguration.TuesdayHourCell;
			dayOfWeek = DayOfWeek.Tuesday;

			cell = Helpers.Excel.ToCell(hourCellString);
			timesheetDate = this.Timesheet.Dates.First(p => p.Date.DayOfWeek == dayOfWeek);
			excelApplication.Cells[cell.Row, cell.Column].Value = timesheetDate.BillableHours;
			if (timesheetDate.HasNotes) {
				AddNote(excelApplication, timesheetDate.Date, timesheetDate.Notes, notesAndRemarksCell);
			}

			// Wednesday...
			hourCellString = timesheetConfiguration.WednesdayHourCell;
			dayOfWeek = DayOfWeek.Wednesday;

			cell = Helpers.Excel.ToCell(hourCellString);
			timesheetDate = this.Timesheet.Dates.First(p => p.Date.DayOfWeek == dayOfWeek);
			excelApplication.Cells[cell.Row, cell.Column].Value = timesheetDate.BillableHours;
			if (timesheetDate.HasNotes) {
				AddNote(excelApplication, timesheetDate.Date, timesheetDate.Notes, notesAndRemarksCell);
			}

			// Thursday...
			hourCellString = timesheetConfiguration.ThursdayHourCell;
			dayOfWeek = DayOfWeek.Thursday;

			cell = Helpers.Excel.ToCell(hourCellString);
			timesheetDate = this.Timesheet.Dates.First(p => p.Date.DayOfWeek == dayOfWeek);
			excelApplication.Cells[cell.Row, cell.Column].Value = timesheetDate.BillableHours;
			if (timesheetDate.HasNotes) {
				AddNote(excelApplication, timesheetDate.Date, timesheetDate.Notes, notesAndRemarksCell);
			}

			// Friday...
			hourCellString = timesheetConfiguration.FridayHourCell;
			dayOfWeek = DayOfWeek.Friday;

			cell = Helpers.Excel.ToCell(hourCellString);
			timesheetDate = this.Timesheet.Dates.First(p => p.Date.DayOfWeek == dayOfWeek);
			excelApplication.Cells[cell.Row, cell.Column].Value = timesheetDate.BillableHours;
			if (timesheetDate.HasNotes) {
				AddNote(excelApplication, timesheetDate.Date, timesheetDate.Notes, notesAndRemarksCell);
			}

			// Saturday...
			hourCellString = timesheetConfiguration.SaturdayHourCell;
			dayOfWeek = DayOfWeek.Saturday;

			cell = Helpers.Excel.ToCell(hourCellString);
			timesheetDate = this.Timesheet.Dates.First(p => p.Date.DayOfWeek == dayOfWeek);
			excelApplication.Cells[cell.Row, cell.Column].Value = timesheetDate.BillableHours;
			if (timesheetDate.HasNotes) {
				AddNote(excelApplication, timesheetDate.Date, timesheetDate.Notes, notesAndRemarksCell);
			}

			// Sunday...
			hourCellString = timesheetConfiguration.SundayHourCell;
			dayOfWeek = DayOfWeek.Sunday;

			cell = Helpers.Excel.ToCell(hourCellString);
			timesheetDate = this.Timesheet.Dates.First(p => p.Date.DayOfWeek == dayOfWeek);
			excelApplication.Cells[cell.Row, cell.Column].Value = timesheetDate.BillableHours;
			if (timesheetDate.HasNotes) {
				AddNote(excelApplication, timesheetDate.Date, timesheetDate.Notes, notesAndRemarksCell);
			}

			return true;
		} 
		#endregion	// Abstract Overrides

		private void AddNote(Excel.Application excelApplication, DateTime date, string notes, ExcelCell notesAndRemarksCell) {
			notes = notes.Trim();

			if (!string.IsNullOrEmpty(notes)) {
				dynamic range = excelApplication.Cells[notesAndRemarksCell.Row, notesAndRemarksCell.Column];

				// If the Notes and Remarks cell is populated with other notes, prepend a  ", " to properly
				// format additional notes.
				if (!string.IsNullOrEmpty(range.Value)) {
					range.Value += ", ";
				}

				range.Value += string.Format("{0} - {1}", Helpers.Dates.GetMMDDYYYY(date, '/'), notes);
			}
		}
	};
};
