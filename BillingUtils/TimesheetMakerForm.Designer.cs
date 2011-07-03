namespace BillingUtils {
	partial class TimesheetMakerForm {
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
			System.Windows.Forms.GroupBox m_monthGroupBox;
			System.Windows.Forms.GroupBox m_timesheetsGroupBox;
			System.Windows.Forms.Label m_invoiceNumberLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimesheetMakerForm));
			this.m_calendar = new System.Windows.Forms.MonthCalendar();
			this.m_timesheetsListView = new System.Windows.Forms.ListView();
			this.m_apply = new System.Windows.Forms.Button();
			this.m_bottomOptionsPanel = new System.Windows.Forms.Panel();
			this.m_cancel = new System.Windows.Forms.Button();
			this.m_generate = new System.Windows.Forms.Button();
			this.m_topPanel = new System.Windows.Forms.Panel();
			this.m_invoiceNumbers = new System.Windows.Forms.ComboBox();
			this.m_detailContainer = new System.Windows.Forms.Panel();
			this.m_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.m_timesheetContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.m_calculationsContainer = new System.Windows.Forms.Panel();
			m_monthGroupBox = new System.Windows.Forms.GroupBox();
			m_timesheetsGroupBox = new System.Windows.Forms.GroupBox();
			m_invoiceNumberLabel = new System.Windows.Forms.Label();
			m_monthGroupBox.SuspendLayout();
			m_timesheetsGroupBox.SuspendLayout();
			this.m_bottomOptionsPanel.SuspendLayout();
			this.m_topPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_monthGroupBox
			// 
			m_monthGroupBox.AutoSize = true;
			m_monthGroupBox.Controls.Add(this.m_calendar);
			m_monthGroupBox.Location = new System.Drawing.Point(3, 33);
			m_monthGroupBox.Name = "m_monthGroupBox";
			m_monthGroupBox.Size = new System.Drawing.Size(252, 215);
			m_monthGroupBox.TabIndex = 1;
			m_monthGroupBox.TabStop = false;
			m_monthGroupBox.Text = "Month";
			// 
			// m_calendar
			// 
			this.m_calendar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_calendar.Location = new System.Drawing.Point(3, 18);
			this.m_calendar.Name = "m_calendar";
			this.m_calendar.TabIndex = 0;
			// 
			// m_timesheetsGroupBox
			// 
			m_timesheetsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			m_timesheetsGroupBox.Controls.Add(this.m_timesheetsListView);
			m_timesheetsGroupBox.Location = new System.Drawing.Point(261, 0);
			m_timesheetsGroupBox.Name = "m_timesheetsGroupBox";
			m_timesheetsGroupBox.Size = new System.Drawing.Size(650, 248);
			m_timesheetsGroupBox.TabIndex = 11;
			m_timesheetsGroupBox.TabStop = false;
			m_timesheetsGroupBox.Text = "Timesheets";
			// 
			// m_timesheetsListView
			// 
			this.m_timesheetsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_timesheetsListView.Location = new System.Drawing.Point(3, 18);
			this.m_timesheetsListView.Name = "m_timesheetsListView";
			this.m_timesheetsListView.Size = new System.Drawing.Size(644, 227);
			this.m_timesheetsListView.TabIndex = 0;
			this.m_timesheetsListView.UseCompatibleStateImageBehavior = false;
			// 
			// m_invoiceNumberLabel
			// 
			m_invoiceNumberLabel.AutoSize = true;
			m_invoiceNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			m_invoiceNumberLabel.Location = new System.Drawing.Point(7, 10);
			m_invoiceNumberLabel.Name = "m_invoiceNumberLabel";
			m_invoiceNumberLabel.Size = new System.Drawing.Size(120, 17);
			m_invoiceNumberLabel.TabIndex = 12;
			m_invoiceNumberLabel.Text = "Invoice Number";
			// 
			// m_apply
			// 
			this.m_apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_apply.AutoSize = true;
			this.m_apply.Location = new System.Drawing.Point(751, 13);
			this.m_apply.Name = "m_apply";
			this.m_apply.Size = new System.Drawing.Size(75, 27);
			this.m_apply.TabIndex = 13;
			this.m_apply.Text = "Apply";
			this.m_apply.UseVisualStyleBackColor = true;
			// 
			// m_bottomOptionsPanel
			// 
			this.m_bottomOptionsPanel.Controls.Add(this.m_cancel);
			this.m_bottomOptionsPanel.Controls.Add(this.m_generate);
			this.m_bottomOptionsPanel.Controls.Add(this.m_apply);
			this.m_bottomOptionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_bottomOptionsPanel.Location = new System.Drawing.Point(0, 567);
			this.m_bottomOptionsPanel.Name = "m_bottomOptionsPanel";
			this.m_bottomOptionsPanel.Size = new System.Drawing.Size(919, 48);
			this.m_bottomOptionsPanel.TabIndex = 14;
			// 
			// m_cancel
			// 
			this.m_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_cancel.AutoSize = true;
			this.m_cancel.CausesValidation = false;
			this.m_cancel.Location = new System.Drawing.Point(832, 13);
			this.m_cancel.Name = "m_cancel";
			this.m_cancel.Size = new System.Drawing.Size(75, 27);
			this.m_cancel.TabIndex = 13;
			this.m_cancel.Text = "Cancel";
			this.m_cancel.UseVisualStyleBackColor = true;
			// 
			// m_generate
			// 
			this.m_generate.AutoSize = true;
			this.m_generate.Location = new System.Drawing.Point(12, 13);
			this.m_generate.Name = "m_generate";
			this.m_generate.Size = new System.Drawing.Size(111, 27);
			this.m_generate.TabIndex = 13;
			this.m_generate.Text = "Generate Files";
			this.m_generate.UseVisualStyleBackColor = true;
			// 
			// m_topPanel
			// 
			this.m_topPanel.Controls.Add(this.m_invoiceNumbers);
			this.m_topPanel.Controls.Add(m_invoiceNumberLabel);
			this.m_topPanel.Controls.Add(m_timesheetsGroupBox);
			this.m_topPanel.Controls.Add(m_monthGroupBox);
			this.m_topPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_topPanel.Location = new System.Drawing.Point(0, 0);
			this.m_topPanel.Name = "m_topPanel";
			this.m_topPanel.Size = new System.Drawing.Size(919, 257);
			this.m_topPanel.TabIndex = 15;
			// 
			// m_invoiceNumbers
			// 
			this.m_invoiceNumbers.FormattingEnabled = true;
			this.m_invoiceNumbers.Location = new System.Drawing.Point(134, 6);
			this.m_invoiceNumbers.Name = "m_invoiceNumbers";
			this.m_invoiceNumbers.Size = new System.Drawing.Size(121, 24);
			this.m_invoiceNumbers.TabIndex = 13;
			// 
			// m_detailContainer
			// 
			this.m_detailContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_detailContainer.Location = new System.Drawing.Point(0, 328);
			this.m_detailContainer.Name = "m_detailContainer";
			this.m_detailContainer.Size = new System.Drawing.Size(919, 239);
			this.m_detailContainer.TabIndex = 16;
			// 
			// m_timesheetContextMenu
			// 
			this.m_timesheetContextMenu.Name = "m_timesheetContextMenu";
			this.m_timesheetContextMenu.Size = new System.Drawing.Size(61, 4);
			// 
			// m_calculationsContainer
			// 
			this.m_calculationsContainer.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_calculationsContainer.Location = new System.Drawing.Point(0, 257);
			this.m_calculationsContainer.MinimumSize = new System.Drawing.Size(0, 50);
			this.m_calculationsContainer.Name = "m_calculationsContainer";
			this.m_calculationsContainer.Size = new System.Drawing.Size(919, 71);
			this.m_calculationsContainer.TabIndex = 17;
			// 
			// TimesheetMakerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(919, 615);
			this.Controls.Add(this.m_detailContainer);
			this.Controls.Add(this.m_calculationsContainer);
			this.Controls.Add(this.m_bottomOptionsPanel);
			this.Controls.Add(this.m_topPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "TimesheetMakerForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Timesheet Maker";
			m_monthGroupBox.ResumeLayout(false);
			m_timesheetsGroupBox.ResumeLayout(false);
			this.m_bottomOptionsPanel.ResumeLayout(false);
			this.m_bottomOptionsPanel.PerformLayout();
			this.m_topPanel.ResumeLayout(false);
			this.m_topPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MonthCalendar m_calendar;
		private System.Windows.Forms.ListView m_timesheetsListView;
		private System.Windows.Forms.Button m_apply;
		private System.Windows.Forms.Panel m_bottomOptionsPanel;
		private System.Windows.Forms.Panel m_topPanel;
		private System.Windows.Forms.Panel m_detailContainer;
		private System.Windows.Forms.Button m_cancel;
		private System.Windows.Forms.FolderBrowserDialog m_folderBrowserDialog;
		private System.Windows.Forms.Button m_generate;
		private System.Windows.Forms.ContextMenuStrip m_timesheetContextMenu;
		private System.Windows.Forms.Panel m_calculationsContainer;
		private System.Windows.Forms.ComboBox m_invoiceNumbers;		
	}
}