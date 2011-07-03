using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BillingUtils.Code;
using BillingUtils.Code.Configuration;

namespace BillingUtils.Dialogs {

	public partial class InvoiceNumberComfirmationDialog : Form {
		/// <summary>
		/// The invoice number as found in the configuration before being altered.
		/// </summary>
		private int OriginalInvoiceNumber { get; set; }
		
		private MonthlyTimesheets MonthlyTimesheets { get; set; }
		public bool SaveOnOK { get; set; }

		/// <summary>
		/// The invoice number chosen by the user.
		/// </summary>
		public int SelectedInvoiceNumber { get; protected set; }

		public InvoiceNumberComfirmationDialog(MonthlyTimesheets monthlyTimesheets, bool saveOnOK) {
			InitializeComponent();

			this.SaveOnOK = saveOnOK;
			this.MonthlyTimesheets = monthlyTimesheets;

			int invoiceNumber = this.MonthlyTimesheets.InvoiceNumber.GetValueOrDefault(0);
			this.OriginalInvoiceNumber = invoiceNumber;
			this.SelectedInvoiceNumber = invoiceNumber;

			InitializeForm();
			InitializeInvoiceNumber();
		}

		private void InitializeForm() {
			m_ok.Click += new EventHandler(this.OnOkClick);
			m_cancel.Click += new EventHandler(this.OnCancelClick);
		}

		private void InitializeInvoiceNumber() {
			m_invoiceNumber.DropDownStyle = ComboBoxStyle.DropDownList;			

			for (int i = 1; i <= 1000; i++) {
				int invoiceNumber = i;
				int index = m_invoiceNumber.Items.Add(invoiceNumber);
				if (invoiceNumber == this.OriginalInvoiceNumber) {
					m_invoiceNumber.SelectedIndex = index;
				}
			}

			m_invoiceNumber.SelectedIndexChanged += new EventHandler(this.OnInvoiceNumberSelectedIndexChanged);			
		}

		private void ResetInvoiceNumberToOriginalInvoiceNumber() {
			int index = m_invoiceNumber.Items.IndexOf(this.OriginalInvoiceNumber);
			m_invoiceNumber.SelectedIndex = index;
		}

		private void OnOkClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.OK;
			int selectedInvoiceNumber = this.SelectedInvoiceNumber;
			this.MonthlyTimesheets.InvoiceNumber = selectedInvoiceNumber;
			if (this.SaveOnOK) {
				this.MonthlyTimesheets.Save();
			}
		}

		private void OnCancelClick(object sender, EventArgs e) {
			this.DialogResult = DialogResult.Cancel;
		}

		private void OnInvoiceNumberSelectedIndexChanged(object sender, EventArgs e) {
			int selectedInvoiceNumber = Convert.ToInt32(m_invoiceNumber.SelectedItem);

			if (selectedInvoiceNumber < this.OriginalInvoiceNumber) {
				if (MessageBox.Show("The invoice number you selected is less than the previously used invoice number." +
					"\n\nClick OK to continue, or Cancel to choose another invoice number.",
					"Attention!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) {
					ResetInvoiceNumberToOriginalInvoiceNumber();
					return;
				}
			} else if (selectedInvoiceNumber > this.OriginalInvoiceNumber) {
				if (MessageBox.Show(string.Format("The invoice number you selected is greater than the next logical invoice number to be used ({0})." +
					"\n\nClick OK to continue, or Cancel to choose another invoice number.", this.OriginalInvoiceNumber + 1),
					"Attention!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) {
					ResetInvoiceNumberToOriginalInvoiceNumber();
					return;
				}
			}

			this.SelectedInvoiceNumber = selectedInvoiceNumber;
		}
	};
};
