namespace BillingUtils.Dialogs {
	partial class InvoiceNumberComfirmationDialog {
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
			this.m_cancel = new System.Windows.Forms.Button();
			this.m_ok = new System.Windows.Forms.Button();
			this.m_invoiceNumber = new System.Windows.Forms.ComboBox();
			this.m_invoiceNumberLabel = new System.Windows.Forms.Label();
			this.m_topPanel = new System.Windows.Forms.Panel();
			this.m_instructions = new System.Windows.Forms.RichTextBox();
			this.m_invoiceNumberWarning = new System.Windows.Forms.RichTextBox();
			this.m_topPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_cancel
			// 
			this.m_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_cancel.AutoSize = true;
			this.m_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cancel.Location = new System.Drawing.Point(391, 218);
			this.m_cancel.Name = "m_cancel";
			this.m_cancel.Size = new System.Drawing.Size(75, 27);
			this.m_cancel.TabIndex = 4;
			this.m_cancel.Text = "Cancel";
			this.m_cancel.UseVisualStyleBackColor = true;
			// 
			// m_ok
			// 
			this.m_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_ok.AutoSize = true;
			this.m_ok.Location = new System.Drawing.Point(310, 218);
			this.m_ok.Name = "m_ok";
			this.m_ok.Size = new System.Drawing.Size(75, 27);
			this.m_ok.TabIndex = 3;
			this.m_ok.Text = "OK";
			this.m_ok.UseVisualStyleBackColor = true;
			// 
			// m_invoiceNumber
			// 
			this.m_invoiceNumber.FormattingEnabled = true;
			this.m_invoiceNumber.Location = new System.Drawing.Point(117, 101);
			this.m_invoiceNumber.Name = "m_invoiceNumber";
			this.m_invoiceNumber.Size = new System.Drawing.Size(101, 24);
			this.m_invoiceNumber.TabIndex = 5;
			// 
			// m_invoiceNumberLabel
			// 
			this.m_invoiceNumberLabel.AutoSize = true;
			this.m_invoiceNumberLabel.Location = new System.Drawing.Point(5, 104);
			this.m_invoiceNumberLabel.Name = "m_invoiceNumberLabel";
			this.m_invoiceNumberLabel.Size = new System.Drawing.Size(106, 17);
			this.m_invoiceNumberLabel.TabIndex = 6;
			this.m_invoiceNumberLabel.Text = "Invoice Number";
			// 
			// m_topPanel
			// 
			this.m_topPanel.Controls.Add(this.m_instructions);
			this.m_topPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_topPanel.Location = new System.Drawing.Point(0, 0);
			this.m_topPanel.Name = "m_topPanel";
			this.m_topPanel.Padding = new System.Windows.Forms.Padding(8);
			this.m_topPanel.Size = new System.Drawing.Size(474, 95);
			this.m_topPanel.TabIndex = 8;
			// 
			// m_instructions
			// 
			this.m_instructions.BackColor = System.Drawing.SystemColors.Control;
			this.m_instructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_instructions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_instructions.Location = new System.Drawing.Point(8, 8);
			this.m_instructions.Margin = new System.Windows.Forms.Padding(8);
			this.m_instructions.Name = "m_instructions";
			this.m_instructions.ReadOnly = true;
			this.m_instructions.Size = new System.Drawing.Size(458, 79);
			this.m_instructions.TabIndex = 3;
			this.m_instructions.Text = "Choose the Invoice Number to be used as the Invoice Number in the generated Invoi" +
				 "ce.\n\nClick OK to continue, click Cancel to cancel the operation.\n";
			// 
			// m_invoiceNumberWarning
			// 
			this.m_invoiceNumberWarning.BackColor = System.Drawing.SystemColors.Control;
			this.m_invoiceNumberWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_invoiceNumberWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.m_invoiceNumberWarning.Location = new System.Drawing.Point(8, 136);
			this.m_invoiceNumberWarning.Margin = new System.Windows.Forms.Padding(8);
			this.m_invoiceNumberWarning.Name = "m_invoiceNumberWarning";
			this.m_invoiceNumberWarning.ReadOnly = true;
			this.m_invoiceNumberWarning.Size = new System.Drawing.Size(458, 71);
			this.m_invoiceNumberWarning.TabIndex = 9;
			this.m_invoiceNumberWarning.Text = "Attention: The Invoice Number has been incremented to reflect the next logical in" +
				 "voice number to be used. If this is not correct, please choose the correct invoi" +
				 "ce number to be used.\n";
			// 
			// InvoiceNumberComfirmationDialog
			// 
			this.AcceptButton = this.m_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.m_cancel;
			this.ClientSize = new System.Drawing.Size(474, 257);
			this.ControlBox = false;
			this.Controls.Add(this.m_invoiceNumberWarning);
			this.Controls.Add(this.m_topPanel);
			this.Controls.Add(this.m_invoiceNumberLabel);
			this.Controls.Add(this.m_invoiceNumber);
			this.Controls.Add(this.m_cancel);
			this.Controls.Add(this.m_ok);
			this.Name = "InvoiceNumberComfirmationDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Invoice Number Comfirmation";
			this.m_topPanel.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button m_cancel;
		private System.Windows.Forms.Button m_ok;
		private System.Windows.Forms.ComboBox m_invoiceNumber;
		private System.Windows.Forms.Label m_invoiceNumberLabel;
		private System.Windows.Forms.Panel m_topPanel;
		private System.Windows.Forms.RichTextBox m_instructions;
		private System.Windows.Forms.RichTextBox m_invoiceNumberWarning;
	}
}