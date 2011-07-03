using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using BillingUtils.Code;
using BillingUtils.Code.Configuration;
using BillingUtils.Code.Helpers;

namespace BillingUtils {

	public partial class OptionsForm : Form {
		static private string ClickToSet { get { return "[Click to Set]"; } }

		public OptionsForm() {
			InitializeComponent();

			// Image list...
			m_imageList.ImageSize = new Size(16, 14);
			m_imageList.Images.Add(BillingUtils.Properties.Resources.Locked.ToString(), BillingUtils.Properties.Resources.Calendar);

			InitializeForm();
			InitializeConfiguration();
		}

		private void InitializeForm() {
			m_timesheetTemplateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(this.OnTimesheetTemplateLinkLinkClicked);
			m_invoiceTemplateLink.LinkClicked += new LinkLabelLinkClickedEventHandler(this.OnInvoiceTemplateLinkLinkClicked);
			m_miscDefaultSaveFolderLink.LinkClicked += new LinkLabelLinkClickedEventHandler(this.OnMiscDefaultSaveLocationLinkLinkClicked);
			
			m_openFileDialog.Filter = "Excel Spreadsheets|*.xlsx";
			m_openFileDialog.InitialDirectory = Configuration.Instance.UserDataFolder;

			m_OK.Click += new EventHandler(
				delegate(object sender, EventArgs e) {
					if (SaveConfiguration()) {
						this.Close();
					}
				});

			m_cancel.Click += new EventHandler(
				delegate(object sender, EventArgs e) {
					this.Close();
				});
		}		

		private void InitializeConfiguration() {
			// Get the configuraton...
			Configuration config = Configuration.Instance;

			// Personal information...
			m_name.Text = config.PersonalConfiguration.Name;
			m_address.Text = config.PersonalConfiguration.Address;

			// Miscellaneous information...

			// Default Work Day Hours...
			decimal defaultWorkDayHours = Configuration.Instance.MiscellaneousConfiguration.DefaultWorkDayHours;

			m_defaultWorkDayHours.DropDownStyle = ComboBoxStyle.DropDownList;

			for (decimal i = 0.5m; i < 24m; i += 0.5m) {
				int index = m_defaultWorkDayHours.Items.Add(i);

				if (defaultWorkDayHours == i) {
					m_defaultWorkDayHours.SelectedIndex = index;
				}
			}

			// Default Max Billable Hours Per WorkDay...
			decimal defaultMaxBillableHoursPerWorkDay = Configuration.Instance.MiscellaneousConfiguration.DefaultMaxBillableHoursPerWorkDay;

			m_defaultMaxBillableHoursPerWorkDay.DropDownStyle = ComboBoxStyle.DropDownList;

			for (decimal i = 0.5m; i < 24m; i += 0.5m) {
				int index = m_defaultMaxBillableHoursPerWorkDay.Items.Add(i);

				if (defaultMaxBillableHoursPerWorkDay == i) {
					m_defaultMaxBillableHoursPerWorkDay.SelectedIndex = index;
				}
			}

			string defaultSaveFolder = config.MiscellaneousConfiguration.DefaultSaveFolder;
			m_miscDefaultSaveFolderLink.Text = Paths.MinifyPath(defaultSaveFolder);
			m_miscDefaultSaveFolderLink.Tag = defaultSaveFolder;

			// Timesheet information...
			string timesheetTemplate = config.TimesheetConfiguration.TimesheetTemplate;
			m_timesheetTemplateLink.Text = Paths.MinifyPath(timesheetTemplate);
			m_timesheetTemplateLink.Tag = timesheetTemplate;
			m_timesheetNameCell.Text = config.TimesheetConfiguration.NameCell;
			m_timesheetStartDateCell.Text = config.TimesheetConfiguration.StartDateCell;
			m_timesheetProjectDescription.Text = config.TimesheetConfiguration.ProjectDescription;
			m_timesheetProjectDescriptionCell.Text = config.TimesheetConfiguration.ProjectDescriptionCell;
			m_timesheetMonHourCell.Text = config.TimesheetConfiguration.MondayHourCell;
			m_timesheetTuesHourCell.Text = config.TimesheetConfiguration.TuesdayHourCell;
			m_timesheetWedHourCell.Text = config.TimesheetConfiguration.WednesdayHourCell;
			m_timesheetThursHourCell.Text = config.TimesheetConfiguration.ThursdayHourCell;
			m_timesheetFriHourCell.Text = config.TimesheetConfiguration.FridayHourCell;
			m_timesheetSatHourCell.Text = config.TimesheetConfiguration.SaturdayHourCell;
			m_timesheetSunHourCell.Text = config.TimesheetConfiguration.SundayHourCell;
			m_timesheetNotesAndRemarksCell.Text = config.TimesheetConfiguration.NotesAndRemarksCell;

			// Invoice information...
			string invoiceTemplate = config.InvoiceConfiguration.InvoiceTemplate;
			m_invoiceTemplateLink.Text = Paths.MinifyPath(invoiceTemplate);
			m_invoiceTemplateLink.Tag = invoiceTemplate;
			m_invoiceNameCell.Text = config.InvoiceConfiguration.NameCell;
			m_invoiceAddressCell.Text = config.InvoiceConfiguration.AddressCell;			
			m_invoiceCurrentInvoiceNumberCell.Text = config.InvoiceConfiguration.CurrentInvoiceNumberCell;
			m_invoiceQtyStartCell.Text = config.InvoiceConfiguration.QtyStartCell;
			m_invoiceDescription.Text = config.InvoiceConfiguration.Description;
			m_invoiceDescriptionStartCell.Text = config.InvoiceConfiguration.DescriptionStartCell;
			m_invoicePONumber.Text = Convert.ToString(config.InvoiceConfiguration.PONumber);
			m_invoicePONumberStartCell.Text = config.InvoiceConfiguration.PONumberStartCell;
			//m_invoiceRate.Text = config.InvoiceConfiguration.Rate.ToString("C");
			m_invoiceRateStartCell.Text = config.InvoiceConfiguration.RateStartCell;

			// Rates configuration...
			InitializeRatesListView();

			// Day Types configuration...
			InitializeDayTypesListView();
		}

		private void UpdateConfiguration() {
			Configuration config = Configuration.Instance;

			// Personal information...
			config.PersonalConfiguration.Name = m_name.Text;
			config.PersonalConfiguration.Address = m_address.Text;

			// Miscellaneous information...
			config.MiscellaneousConfiguration.DefaultWorkDayHours = Convert.ToDecimal(m_defaultWorkDayHours.Text);
			config.MiscellaneousConfiguration.DefaultMaxBillableHoursPerWorkDay = Convert.ToDecimal(m_defaultMaxBillableHoursPerWorkDay.Text);

			string defaultSaveFolder = Convert.ToString(m_miscDefaultSaveFolderLink.Tag);
			config.MiscellaneousConfiguration.DefaultSaveFolder = defaultSaveFolder;

			// Timesheet information...
			string timesheetTemplate = Convert.ToString(m_timesheetTemplateLink.Tag);
			config.TimesheetConfiguration.TimesheetTemplate = timesheetTemplate;
			config.TimesheetConfiguration.NameCell = m_timesheetNameCell.Text;
			config.TimesheetConfiguration.StartDateCell = m_timesheetStartDateCell.Text;
			config.TimesheetConfiguration.ProjectDescription = m_timesheetProjectDescription.Text;
			config.TimesheetConfiguration.ProjectDescriptionCell = m_timesheetProjectDescriptionCell.Text;
			config.TimesheetConfiguration.MondayHourCell = m_timesheetMonHourCell.Text;
			config.TimesheetConfiguration.TuesdayHourCell = m_timesheetTuesHourCell.Text;
			config.TimesheetConfiguration.WednesdayHourCell = m_timesheetWedHourCell.Text;
			config.TimesheetConfiguration.ThursdayHourCell = m_timesheetThursHourCell.Text;
			config.TimesheetConfiguration.FridayHourCell = m_timesheetFriHourCell.Text;
			config.TimesheetConfiguration.SaturdayHourCell = m_timesheetSatHourCell.Text;
			config.TimesheetConfiguration.SundayHourCell = m_timesheetSunHourCell.Text;
			config.TimesheetConfiguration.NotesAndRemarksCell = m_timesheetNotesAndRemarksCell.Text; 


			// Invoice information...
			string invoiceTemplate = Convert.ToString(m_invoiceTemplateLink.Tag);
			config.InvoiceConfiguration.InvoiceTemplate = invoiceTemplate;
			config.InvoiceConfiguration.NameCell = m_invoiceNameCell.Text;
			config.InvoiceConfiguration.AddressCell = m_invoiceAddressCell.Text;			
			config.InvoiceConfiguration.CurrentInvoiceNumberCell = m_invoiceCurrentInvoiceNumberCell.Text;
			config.InvoiceConfiguration.QtyStartCell = m_invoiceQtyStartCell.Text;
			config.InvoiceConfiguration.Description = m_invoiceDescription.Text;
			config.InvoiceConfiguration.DescriptionStartCell = m_invoiceDescriptionStartCell.Text;
			config.InvoiceConfiguration.PONumber = Convert.ToInt32(m_invoicePONumber.Text);
			config.InvoiceConfiguration.PONumberStartCell = m_invoicePONumberStartCell.Text;
			//config.InvoiceConfiguration.Rate = Decimal.Parse(m_invoiceRate.Text, NumberStyles.AllowThousands
			//		| NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol);
			
			m_invoiceRateStartCell.Text = config.InvoiceConfiguration.RateStartCell = m_invoiceRateStartCell.Text;
		}

		private bool SaveConfiguration() {
			if (!this.ValidateChildren()) {
				return false;
			} else {
				UpdateConfiguration();
				if (Configuration.Instance.IsDirty) {
					Configuration.Instance.Save();
				}

				return true;
			}
		}

		public override bool ValidateChildren() {
			bool hasErrors = false;

			// Personal information...
			if (!ValidateText(m_name)) { hasErrors = true; }
			if (!ValidateText(m_address)) { hasErrors = true; }

			// Timesheet information...			
			string timesheetTemplate = Convert.ToString(m_timesheetTemplateLink.Tag);
			if (File.Exists(timesheetTemplate)) {
				m_errorProvider.SetError(m_timesheetTemplateLink, string.Empty);
			} else {
				hasErrors = true;
				m_errorProvider.SetError(m_timesheetTemplateLink, string.Format("Timesheet template [{0}] does not exist. Choose another template.", timesheetTemplate));
			}

			if (!ValidateText(m_timesheetNameCell)) { hasErrors = true; }
			if (!ValidateText(m_timesheetStartDateCell)) { hasErrors = true; }
			if (!ValidateText(m_timesheetProjectDescription)) { hasErrors = true; }
			if (!ValidateText(m_timesheetProjectDescriptionCell)) { hasErrors = true; }
			if (!ValidateText(m_timesheetMonHourCell)) { hasErrors = true; }
			if (!ValidateText(m_timesheetTuesHourCell)) { hasErrors = true; }
			if (!ValidateText(m_timesheetWedHourCell)) { hasErrors = true; }
			if (!ValidateText(m_timesheetThursHourCell)) { hasErrors = true; }
			if (!ValidateText(m_timesheetFriHourCell)) { hasErrors = true; }
			if (!ValidateText(m_timesheetSatHourCell)) { hasErrors = true; }
			if (!ValidateText(m_timesheetSunHourCell)) { hasErrors = true; }
			if (!ValidateText(m_timesheetNotesAndRemarksCell)) { hasErrors = true; }

			// Invoice information...
			string invoiceTemplate = Convert.ToString(m_invoiceTemplateLink.Tag);
			if (File.Exists(invoiceTemplate)) {
				m_errorProvider.SetError(m_invoiceTemplateLink, string.Empty);
			} else {
				hasErrors = true;
				m_errorProvider.SetError(m_invoiceTemplateLink, string.Format("Invoice template [{0}] does not exist. Choose another template.", invoiceTemplate));
			}

			if (!ValidateText(m_invoiceNameCell)) { hasErrors = true; }
			if (!ValidateText(m_invoiceAddressCell)) { hasErrors = true; }
			if (!ValidateText(m_invoiceCurrentInvoiceNumberCell)) { hasErrors = true; }
			if (!ValidateText(m_invoiceQtyStartCell)) { hasErrors = true; }
			if (!ValidateText(m_invoiceDescription)) { hasErrors = true; }
			if (!ValidateText(m_invoiceDescriptionStartCell)) { hasErrors = true; }
			if (!ValidateText(m_invoicePONumberStartCell)) { hasErrors = true; }
			if (!ValidateText(m_invoiceRateStartCell)) { hasErrors = true; }						
			if (!ValidateInt(m_invoicePONumber, 1, 99999)) { hasErrors = true; }
			//if (!ValidateCurrency(m_invoiceRate, 1.00m, 500.00m)) { hasErrors = true; }

			if (hasErrors) {
				m_tabControl.SelectedTab = m_tabPage1;
			}

			// Check Tab 2 options here...

			return !hasErrors;
		}

		private bool ValidateText(Control control) {
			return ValidateText(control, Misc.DefaultErrorMessage);
		}

		private bool ValidateText(Control control, string errorMessage) {
			string text = control.Text.Trim();
			control.Text = text;
			bool isValid = !string.IsNullOrEmpty(text);
			m_errorProvider.SetError(control, isValid ? string.Empty : errorMessage);
			return isValid;
		}

		private bool ValidateInt(Control control, int min, int max) {
			string text = control.Text.Trim();
			control.Text = text;
			if (string.IsNullOrEmpty(text)) {
				m_errorProvider.SetError(control, Misc.DefaultErrorMessage);
				return false;
			} else {
				int result = 0;
				if (!int.TryParse(text, out result)) {
					m_errorProvider.SetError(control, "Field must be numeric.");
					return false;
				} else if (result < min || result > max) {
					m_errorProvider.SetError(control, string.Format("Field must GT or EQ to {0} and LT or EQ to {1}.", min, max));
					return false;
				} else {
					return true;
				}
			}
		}

		private bool ValidateCurrency(Control control, decimal min, decimal max) {
			string text = control.Text.Trim();
			control.Text = text;
			if (string.IsNullOrEmpty(text)) {
				m_errorProvider.SetError(control, Misc.DefaultErrorMessage);
				return false;
			} else {
				decimal result = 0m;

				if (!Decimal.TryParse(text, NumberStyles.AllowThousands
					| NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture, out result)) {
					m_errorProvider.SetError(control, "Field must be numeric.");
					return false;
				} else if (result < min || result > max) {
					m_errorProvider.SetError(control, string.Format("Field must GT or EQ to {0} and LT or EQ to {1}.", min, max));
					return false;
				} else {
					return true;
				}
			}
		}

		private bool GetTemplate(string title, out string template) {
			template = string.Empty;

			m_openFileDialog.Title = title;			
			if (m_openFileDialog.ShowDialog() != DialogResult.OK) {
				return false;
			} else {
				template = m_openFileDialog.FileName;
				return true;
			}			
		}

		// Day Types Configuration Members
		// --------------------------------------------------------------------------
		#region Day Types Configuration Members
		private void InitializeDayTypesListView() {
			m_dayTypes.SmallImageList = m_imageList;

			m_dayTypes.View = View.Details;
			m_dayTypes.GridLines = true;
			m_dayTypes.FullRowSelect = true;
			m_dayTypes.MultiSelect = false;
			m_dayTypes.Scrollable = true;

			m_dayTypes.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			m_dayTypes.Columns.Add("name", "name", 150);
			m_dayTypes.Columns.Add("description", "Description", 150);

			foreach (DayType dayType in Configuration.Instance.DayTypeConfiguration.DayTypes) {
				this.InsertDayTypesListViewItem(dayType);
			}

			ResizeDayTypesListViewColumns();
		}

		private void InsertDayTypesListViewItem(DayType dayType) {
			ListViewItem timesheetDateListViewItem = CreateDayTypesListViewItem(dayType);
			m_dayTypes.Items.Add(timesheetDateListViewItem);
		}

		private ListViewItem CreateDayTypesListViewItem(DayType dayType) {
			ListViewItem listViewItem = new ListViewItem(dayType.Name);

			listViewItem.ImageIndex = 0;
			listViewItem.SubItems.Add(dayType.Description);			

			listViewItem.Tag = dayType;

			return listViewItem;
		}

		private void ResizeDayTypesListViewColumns() {
			m_dayTypes.Columns["name"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_dayTypes, "name"));
			m_dayTypes.Columns["description"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_dayTypes, "description"));			
		}
		#endregion	// Day Types Configuration Members

		// Rates Configuration Members
		// --------------------------------------------------------------------------
		#region Rates Configuration Members
		private void InitializeRatesListView() {
			m_rates.SmallImageList = m_imageList;

			m_rates.View = View.Details;
			m_rates.GridLines = true;
			m_rates.FullRowSelect = true;
			m_rates.MultiSelect = false;
			m_rates.Scrollable = true;

			m_rates.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			m_rates.Columns.Add("effectiveDate", "Effective Date", 200);
			m_rates.Columns.Add("amount", "Amount", 150);

			foreach (Rate rate in Configuration.Instance.RatesConfiguration.Rates) {
				this.InsertRatesListViewItem(rate);
			}

			ResizeRatesListViewColumns();
		}

		private void InsertRatesListViewItem(Rate rate) {
			ListViewItem rateListViewItem = CreateRateListViewItem(rate);
			m_rates.Items.Add(rateListViewItem);
		}

		private ListViewItem CreateRateListViewItem(Rate rate) {
			ListViewItem listViewItem = new ListViewItem(Dates.GetYYYYMMDD(rate.EffectiveDate));

			listViewItem.ImageIndex = 0;
			listViewItem.SubItems.Add(rate.Amount.ToString("C"));

			listViewItem.Tag = rate;

			return listViewItem;
		}

		private void ResizeRatesListViewColumns() {
			m_rates.Columns["effectiveDate"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_rates, "effectiveDate"));
			m_rates.Columns["amount"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_rates, "amount"));
		}
		#endregion	// Rates Configuration Members

		protected void OnTimesheetTemplateLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			string template;
			if (GetTemplate("Select Timesheet Excel Template", out template)) {
				m_timesheetTemplateLink.Text = Paths.MinifyPath(template);
				m_timesheetTemplateLink.Tag = template;
				this.ValidateChildren();
			}
		}

		protected void OnInvoiceTemplateLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			string template;
			if (GetTemplate("Select Invoice Excel Template", out template)) {
				m_invoiceTemplateLink.Text = Paths.MinifyPath(template);
				m_invoiceTemplateLink.Tag = template;
				this.ValidateChildren();
			}
		}

		protected void OnMiscDefaultSaveLocationLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {			
			m_folderBrowserDialog.Description = "Select Default Save folder.";
			m_folderBrowserDialog.SelectedPath = Configuration.Instance.MiscellaneousConfiguration.DefaultSaveFolder;
			if (m_folderBrowserDialog.ShowDialog() == DialogResult.OK) {
				string selectedPath = m_folderBrowserDialog.SelectedPath;
				m_miscDefaultSaveFolderLink.Text = Paths.MinifyPath(selectedPath);
				m_miscDefaultSaveFolderLink.Tag = selectedPath;
				this.ValidateChildren();
			}
		}
	};
};
