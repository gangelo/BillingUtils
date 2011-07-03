namespace BillingUtils {
	partial class TimesheetDateEditForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label m_billableHoursLabel;
			System.Windows.Forms.Label m_timesheetAmountLabel;
			System.Windows.Forms.Label m_notesLabel;
			System.Windows.Forms.Label m_dayTypeLabel;
			System.Windows.Forms.Label m_slash;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimesheetDateEditForm));
			this.m_ok = new System.Windows.Forms.Button();
			this.m_cancel = new System.Windows.Forms.Button();
			this.m_billableHours = new System.Windows.Forms.ComboBox();
			this.m_invoiceAmount = new System.Windows.Forms.TextBox();
			this.m_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.m_zero = new System.Windows.Forms.LinkLabel();
			this.m_notes = new System.Windows.Forms.TextBox();
			this.m_dayTypes = new System.Windows.Forms.ComboBox();
			this.m_clearNotes = new System.Windows.Forms.LinkLabel();
			this.m_defaultWorkDayHours = new System.Windows.Forms.LinkLabel();
			m_billableHoursLabel = new System.Windows.Forms.Label();
			m_timesheetAmountLabel = new System.Windows.Forms.Label();
			m_notesLabel = new System.Windows.Forms.Label();
			m_dayTypeLabel = new System.Windows.Forms.Label();
			m_slash = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// m_billableHoursLabel
			// 
			m_billableHoursLabel.AutoSize = true;
			m_billableHoursLabel.Location = new System.Drawing.Point(33, 17);
			m_billableHoursLabel.Name = "m_billableHoursLabel";
			m_billableHoursLabel.Size = new System.Drawing.Size(95, 17);
			m_billableHoursLabel.TabIndex = 0;
			m_billableHoursLabel.Text = "Billable Hours";
			// 
			// m_timesheetAmountLabel
			// 
			m_timesheetAmountLabel.AutoSize = true;
			m_timesheetAmountLabel.Location = new System.Drawing.Point(2, 47);
			m_timesheetAmountLabel.Name = "m_timesheetAmountLabel";
			m_timesheetAmountLabel.Size = new System.Drawing.Size(126, 17);
			m_timesheetAmountLabel.TabIndex = 3;
			m_timesheetAmountLabel.Text = "Timesheet Amount";
			// 
			// m_notesLabel
			// 
			m_notesLabel.AutoSize = true;
			m_notesLabel.Location = new System.Drawing.Point(83, 107);
			m_notesLabel.Name = "m_notesLabel";
			m_notesLabel.Size = new System.Drawing.Size(45, 17);
			m_notesLabel.TabIndex = 5;
			m_notesLabel.Text = "Notes";
			// 
			// m_dayTypeLabel
			// 
			m_dayTypeLabel.AutoSize = true;
			m_dayTypeLabel.Location = new System.Drawing.Point(59, 76);
			m_dayTypeLabel.Name = "m_dayTypeLabel";
			m_dayTypeLabel.Size = new System.Drawing.Size(69, 17);
			m_dayTypeLabel.TabIndex = 3;
			m_dayTypeLabel.Text = "Day Type";
			// 
			// m_ok
			// 
			this.m_ok.AutoSize = true;
			this.m_ok.Location = new System.Drawing.Point(325, 144);
			this.m_ok.Name = "m_ok";
			this.m_ok.Size = new System.Drawing.Size(75, 27);
			this.m_ok.TabIndex = 7;
			this.m_ok.Text = "OK";
			this.m_ok.UseVisualStyleBackColor = true;
			// 
			// m_cancel
			// 
			this.m_cancel.AutoSize = true;
			this.m_cancel.CausesValidation = false;
			this.m_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cancel.Location = new System.Drawing.Point(406, 144);
			this.m_cancel.Name = "m_cancel";
			this.m_cancel.Size = new System.Drawing.Size(75, 27);
			this.m_cancel.TabIndex = 8;
			this.m_cancel.Text = "Cancel";
			this.m_cancel.UseVisualStyleBackColor = true;
			// 
			// m_billableHours
			// 
			this.m_billableHours.FormattingEnabled = true;
			this.m_billableHours.Location = new System.Drawing.Point(134, 13);
			this.m_billableHours.Name = "m_billableHours";
			this.m_billableHours.Size = new System.Drawing.Size(121, 24);
			this.m_billableHours.TabIndex = 1;
			// 
			// m_invoiceAmount
			// 
			this.m_invoiceAmount.Location = new System.Drawing.Point(134, 44);
			this.m_invoiceAmount.Name = "m_invoiceAmount";
			this.m_invoiceAmount.Size = new System.Drawing.Size(121, 22);
			this.m_invoiceAmount.TabIndex = 4;
			// 
			// m_errorProvider
			// 
			this.m_errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.m_errorProvider.ContainerControl = this;
			// 
			// m_zero
			// 
			this.m_zero.AutoSize = true;
			this.m_zero.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_zero.Location = new System.Drawing.Point(261, 19);
			this.m_zero.Name = "m_zero";
			this.m_zero.Size = new System.Drawing.Size(22, 13);
			this.m_zero.TabIndex = 2;
			this.m_zero.TabStop = true;
			this.m_zero.Text = "0.0";
			// 
			// m_notes
			// 
			this.m_notes.Location = new System.Drawing.Point(134, 104);
			this.m_notes.Name = "m_notes";
			this.m_notes.Size = new System.Drawing.Size(310, 22);
			this.m_notes.TabIndex = 6;
			// 
			// m_dayTypes
			// 
			this.m_dayTypes.FormattingEnabled = true;
			this.m_dayTypes.Location = new System.Drawing.Point(134, 72);
			this.m_dayTypes.Name = "m_dayTypes";
			this.m_dayTypes.Size = new System.Drawing.Size(121, 24);
			this.m_dayTypes.TabIndex = 9;
			// 
			// m_clearNotes
			// 
			this.m_clearNotes.AutoSize = true;
			this.m_clearNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_clearNotes.Location = new System.Drawing.Point(450, 109);
			this.m_clearNotes.Name = "m_clearNotes";
			this.m_clearNotes.Size = new System.Drawing.Size(31, 13);
			this.m_clearNotes.TabIndex = 2;
			this.m_clearNotes.TabStop = true;
			this.m_clearNotes.Text = "Clear";
			// 
			// m_defaultWorkDayHours
			// 
			this.m_defaultWorkDayHours.AutoSize = true;
			this.m_defaultWorkDayHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_defaultWorkDayHours.Location = new System.Drawing.Point(299, 19);
			this.m_defaultWorkDayHours.Name = "m_defaultWorkDayHours";
			this.m_defaultWorkDayHours.Size = new System.Drawing.Size(22, 13);
			this.m_defaultWorkDayHours.TabIndex = 2;
			this.m_defaultWorkDayHours.TabStop = true;
			this.m_defaultWorkDayHours.Text = "0.0";
			// 
			// m_slash
			// 
			m_slash.AutoSize = true;
			m_slash.Location = new System.Drawing.Point(285, 17);
			m_slash.Name = "m_slash";
			m_slash.Size = new System.Drawing.Size(12, 17);
			m_slash.TabIndex = 10;
			m_slash.Text = "/";
			// 
			// TimesheetDateEditForm
			// 
			this.AcceptButton = this.m_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.m_cancel;
			this.CausesValidation = false;
			this.ClientSize = new System.Drawing.Size(493, 183);
			this.Controls.Add(m_slash);
			this.Controls.Add(this.m_dayTypes);
			this.Controls.Add(this.m_clearNotes);
			this.Controls.Add(this.m_defaultWorkDayHours);
			this.Controls.Add(this.m_zero);
			this.Controls.Add(this.m_notes);
			this.Controls.Add(this.m_invoiceAmount);
			this.Controls.Add(m_notesLabel);
			this.Controls.Add(this.m_billableHours);
			this.Controls.Add(m_dayTypeLabel);
			this.Controls.Add(m_timesheetAmountLabel);
			this.Controls.Add(m_billableHoursLabel);
			this.Controls.Add(this.m_cancel);
			this.Controls.Add(this.m_ok);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TimesheetDateEditForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Timesheet Date Edit";
			((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button m_ok;
		private System.Windows.Forms.Button m_cancel;
		private System.Windows.Forms.ComboBox m_billableHours;
		private System.Windows.Forms.TextBox m_invoiceAmount;
		private System.Windows.Forms.ErrorProvider m_errorProvider;
		private System.Windows.Forms.LinkLabel m_zero;
		private System.Windows.Forms.TextBox m_notes;
		private System.Windows.Forms.ComboBox m_dayTypes;
		private System.Windows.Forms.LinkLabel m_clearNotes;
		private System.Windows.Forms.LinkLabel m_defaultWorkDayHours;
	}
}