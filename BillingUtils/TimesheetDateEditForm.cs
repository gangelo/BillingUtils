using System;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BillingUtils.Code;
using BillingUtils.Code.Configuration;
using BillingUtils.Code.Helpers;

namespace BillingUtils {

	public partial class TimesheetDateEditForm : Form {
		public TimesheetDate TimesheetDate { get; protected set; }

		public TimesheetDateEditForm(TimesheetDate timesheetDate) {
			InitializeComponent();

			this.TimesheetDate = timesheetDate;

			this.Text = string.Format("Edit {0}", Dates.GetYYYYMMDD(this.TimesheetDate.Date));

			InitializeBillableHours();
			InitializeInvoiceAmount();
			InitializeDayTypes();

			m_defaultWorkDayHours.Text = Configuration.Instance.MiscellaneousConfiguration.DefaultWorkDayHours.ToString("0.0");
			m_notes.Text = this.TimesheetDate.Notes;

			m_clearNotes.Click += new EventHandler(
				delegate(object sender, EventArgs e) {
					m_notes.Text = string.Empty;
				});

			m_ok.Click += new EventHandler(
				delegate(object sender, EventArgs e) {
					this.DialogResult = DialogResult.OK;
					this.Close();
				});

			m_cancel.Click += new EventHandler(
				delegate(object sender, EventArgs e) {
					this.DialogResult = DialogResult.Cancel;
					this.Close();
				});

			m_zero.Click += new EventHandler(
				delegate(object sender, EventArgs e) {
					m_billableHours.SelectedIndex = 0;
				});

			m_defaultWorkDayHours.Click += new EventHandler(
				delegate(object sender, EventArgs e) {
					int index = m_billableHours.FindStringExact(m_defaultWorkDayHours.Text);
					m_billableHours.SelectedIndex = index;
				});
		}

		public bool ValuesChanged {
			get {
				return this.BillableHours != this.TimesheetDate.BillableHours ||
					this.InvoiceAmount != this.TimesheetDate.InvoiceAmount ||
					!this.Notes.Equals(this.TimesheetDate.Notes) ||
					!this.DayType.Name.Equals(this.TimesheetDate.DayType.Name);
			}
		}

		public decimal BillableHours {
			get { return Convert.ToDecimal(m_billableHours.Text); }
		}

		public decimal InvoiceAmount {
			get {
				return Decimal.Parse(m_invoiceAmount.Text, NumberStyles.AllowThousands
					| NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol);
			}
		}

		public DayType DayType {
			get { return new DayType(Convert.ToString(m_dayTypes.SelectedItem)); }
		}

		public string Notes {
			get { return m_notes.Text.Trim(); }
		}

		public void InitializeBillableHours() {
			m_billableHours.DropDownStyle = ComboBoxStyle.DropDownList;

			for (decimal i = 0m; i < 24m; i += 0.5m) {
				int index = m_billableHours.Items.Add(i);

				if (TimesheetDate.BillableHours == i) {
					m_billableHours.SelectedIndex = index;
				}
			}

			m_billableHours.SelectedIndexChanged += new EventHandler(this.OnBillableHoursSelectedIndexChanged);
		}

		public void InitializeInvoiceAmount() {
			m_invoiceAmount.ReadOnly = true;
			m_invoiceAmount.TextAlign = HorizontalAlignment.Right;
			m_invoiceAmount.Text = this.TimesheetDate.InvoiceAmount.ToString("C");
		}

		public void InitializeDayTypes() {
			m_dayTypes.DropDownStyle = ComboBoxStyle.DropDownList;

			Collection<DayType> dayTypes = Configuration.Instance.DayTypeConfiguration.DayTypes;
			foreach (DayType dayType in dayTypes) {
				int index = m_dayTypes.Items.Add(dayType.Name);
				if (this.TimesheetDate.DayType.Name.Equals(dayType.Name, StringComparison.CurrentCultureIgnoreCase)) {
					m_dayTypes.SelectedIndex = index;
				}
			}
		}

		protected void OnBillableHoursSelectedIndexChanged(object sender, EventArgs e) {
			// _PRIORITY_: Test this! decimal defaultDollarsPerHour = Configuration.Instance.InvoiceConfiguration.Rate;
			decimal defaultDollarsPerHour = Rates.GetRate(this.TimesheetDate.Date).Amount;
			m_invoiceAmount.Text = string.Format("{0:C}", defaultDollarsPerHour * this.BillableHours);
		}
	};
};
