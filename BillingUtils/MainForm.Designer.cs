namespace BillingUtils {
	partial class MainForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.m_mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timesheetInvoiceRenameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timesheetMakerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flexDaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.yearlyOverviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.m_mainMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_mainMenuStrip
			// 
			this.m_mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.m_mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.m_mainMenuStrip.Name = "m_mainMenuStrip";
			this.m_mainMenuStrip.Size = new System.Drawing.Size(1006, 26);
			this.m_mainMenuStrip.TabIndex = 1;
			this.m_mainMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 22);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timesheetInvoiceRenameToolStripMenuItem,
            this.timesheetMakerToolStripMenuItem});
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
			this.openToolStripMenuItem.Text = "&Open";
			// 
			// timesheetInvoiceRenameToolStripMenuItem
			// 
			this.timesheetInvoiceRenameToolStripMenuItem.Name = "timesheetInvoiceRenameToolStripMenuItem";
			this.timesheetInvoiceRenameToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
			this.timesheetInvoiceRenameToolStripMenuItem.Text = "Timesheet/Invoice &Rename";
			this.timesheetInvoiceRenameToolStripMenuItem.Visible = false;
			this.timesheetInvoiceRenameToolStripMenuItem.Click += new System.EventHandler(this.OnTimesheetInvoiceRenameClick);
			// 
			// timesheetMakerToolStripMenuItem
			// 
			this.timesheetMakerToolStripMenuItem.Name = "timesheetMakerToolStripMenuItem";
			this.timesheetMakerToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
			this.timesheetMakerToolStripMenuItem.Text = "Timesheet &Maker";
			this.timesheetMakerToolStripMenuItem.Click += new System.EventHandler(this.OnTimesheetMakerClick);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flexDaysToolStripMenuItem,
            this.yearlyOverviewToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(49, 22);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// flexDaysToolStripMenuItem
			// 
			this.flexDaysToolStripMenuItem.Name = "flexDaysToolStripMenuItem";
			this.flexDaysToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
			this.flexDaysToolStripMenuItem.Text = "&Flex Days";
			this.flexDaysToolStripMenuItem.Click += new System.EventHandler(this.OnViewFlexDaysClick);
			// 
			// yearlyOverviewToolStripMenuItem
			// 
			this.yearlyOverviewToolStripMenuItem.Name = "yearlyOverviewToolStripMenuItem";
			this.yearlyOverviewToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
			this.yearlyOverviewToolStripMenuItem.Text = "&Timesheet Yearly Overview";
			this.yearlyOverviewToolStripMenuItem.Click += new System.EventHandler(this.OnTimesheetYearlyOverviewClick);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(55, 22);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.optionsToolStripMenuItem.Text = "&Options";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OnOptionsClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_aboutMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(48, 22);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// m_aboutMenuItem
			// 
			this.m_aboutMenuItem.Name = "m_aboutMenuItem";
			this.m_aboutMenuItem.Size = new System.Drawing.Size(152, 22);
			this.m_aboutMenuItem.Text = "&About";
			this.m_aboutMenuItem.Click += new System.EventHandler(this.OnAboutClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1006, 725);
			this.Controls.Add(this.m_mainMenuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.m_mainMenuStrip;
			this.Name = "MainForm";
			this.Text = "Billing Utilities";
			this.m_mainMenuStrip.ResumeLayout(false);
			this.m_mainMenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip m_mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem timesheetInvoiceRenameToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem timesheetMakerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem flexDaysToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem yearlyOverviewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem m_aboutMenuItem;
	}
}

