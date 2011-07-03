namespace BillingUtils {
	partial class TimesheetYearlyOverviewForm {
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
			System.Windows.Forms.Label m_realWorkDaysLabel;
			System.Windows.Forms.Label m_adjustmentHoursLabel;
			System.Windows.Forms.Label m_billableHoursLabel;
			System.Windows.Forms.Label m_maxBillableHoursLabel;
			System.Windows.Forms.Label label3;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimesheetYearlyOverviewForm));
			this.m_calculationsPanel = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.m_realWorkDays = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_years = new System.Windows.Forms.ComboBox();
			this.m_executiveOrders = new System.Windows.Forms.Label();
			this.m_estimatedYearlyIncome = new System.Windows.Forms.Label();
			this.m_adjustmentHours = new System.Windows.Forms.Label();
			this.m_executiveOrdersLabel = new System.Windows.Forms.Label();
			this.m_weekends = new System.Windows.Forms.Label();
			this.m_billableHours = new System.Windows.Forms.Label();
			this.m_weekendsLabel = new System.Windows.Forms.Label();
			this.m_workDaysLabel = new System.Windows.Forms.Label();
			this.m_otherDays = new System.Windows.Forms.Label();
			this.m_workDays = new System.Windows.Forms.Label();
			this.m_otherDaysLabel = new System.Windows.Forms.Label();
			this.m_maxBillableHours = new System.Windows.Forms.Label();
			this.m_sickDays = new System.Windows.Forms.Label();
			this.m_flexDaysLabel = new System.Windows.Forms.Label();
			this.m_sickDaysLabel = new System.Windows.Forms.Label();
			this.m_flexDays = new System.Windows.Forms.Label();
			this.m_halfDays = new System.Windows.Forms.Label();
			this.m_vacationDaysLabel = new System.Windows.Forms.Label();
			this.m_halfDaysLabel = new System.Windows.Forms.Label();
			this.m_vacationDays = new System.Windows.Forms.Label();
			this.m_actionsPanel = new System.Windows.Forms.Panel();
			this.m_refresh = new System.Windows.Forms.Button();
			this.m_endDate = new System.Windows.Forms.DateTimePicker();
			this.m_startDate = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_monthDetailTableContainer = new System.Windows.Forms.Panel();
			this.m_treeView = new BillingUtils.UserControls.TreeView.TreeViewEx();
			m_realWorkDaysLabel = new System.Windows.Forms.Label();
			m_adjustmentHoursLabel = new System.Windows.Forms.Label();
			m_billableHoursLabel = new System.Windows.Forms.Label();
			m_maxBillableHoursLabel = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			this.m_calculationsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.m_actionsPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_realWorkDaysLabel
			// 
			m_realWorkDaysLabel.AutoSize = true;
			m_realWorkDaysLabel.Location = new System.Drawing.Point(14, 7);
			m_realWorkDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			m_realWorkDaysLabel.Name = "m_realWorkDaysLabel";
			m_realWorkDaysLabel.Size = new System.Drawing.Size(350, 17);
			m_realWorkDaysLabel.TabIndex = 0;
			m_realWorkDaysLabel.Text = "Real Work Days (Week Days - Executive Order Days):\r\n";
			// 
			// m_adjustmentHoursLabel
			// 
			m_adjustmentHoursLabel.AutoSize = true;
			m_adjustmentHoursLabel.Location = new System.Drawing.Point(15, 156);
			m_adjustmentHoursLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			m_adjustmentHoursLabel.Name = "m_adjustmentHoursLabel";
			m_adjustmentHoursLabel.Size = new System.Drawing.Size(124, 17);
			m_adjustmentHoursLabel.TabIndex = 22;
			m_adjustmentHoursLabel.Text = "Adjustment Hours:";
			// 
			// m_billableHoursLabel
			// 
			m_billableHoursLabel.AutoSize = true;
			m_billableHoursLabel.Location = new System.Drawing.Point(15, 140);
			m_billableHoursLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			m_billableHoursLabel.Name = "m_billableHoursLabel";
			m_billableHoursLabel.Size = new System.Drawing.Size(99, 17);
			m_billableHoursLabel.TabIndex = 20;
			m_billableHoursLabel.Text = "Billable Hours:";
			// 
			// m_maxBillableHoursLabel
			// 
			m_maxBillableHoursLabel.AutoSize = true;
			m_maxBillableHoursLabel.Location = new System.Drawing.Point(15, 24);
			m_maxBillableHoursLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			m_maxBillableHoursLabel.Name = "m_maxBillableHoursLabel";
			m_maxBillableHoursLabel.Size = new System.Drawing.Size(391, 17);
			m_maxBillableHoursLabel.TabIndex = 2;
			m_maxBillableHoursLabel.Text = "Max Billable Hours (Maximum billable hours allowed by SMS):\r\n";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(15, 198);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(167, 17);
			label3.TabIndex = 24;
			label3.Text = "Estimated Yearly Income:";
			// 
			// m_calculationsPanel
			// 
			this.m_calculationsPanel.AutoSize = true;
			this.m_calculationsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
			this.m_calculationsPanel.Controls.Add(this.pictureBox1);
			this.m_calculationsPanel.Controls.Add(this.m_realWorkDays);
			this.m_calculationsPanel.Controls.Add(this.label1);
			this.m_calculationsPanel.Controls.Add(m_realWorkDaysLabel);
			this.m_calculationsPanel.Controls.Add(m_adjustmentHoursLabel);
			this.m_calculationsPanel.Controls.Add(this.m_years);
			this.m_calculationsPanel.Controls.Add(this.m_executiveOrders);
			this.m_calculationsPanel.Controls.Add(this.m_estimatedYearlyIncome);
			this.m_calculationsPanel.Controls.Add(this.m_adjustmentHours);
			this.m_calculationsPanel.Controls.Add(this.m_executiveOrdersLabel);
			this.m_calculationsPanel.Controls.Add(m_billableHoursLabel);
			this.m_calculationsPanel.Controls.Add(this.m_weekends);
			this.m_calculationsPanel.Controls.Add(this.m_billableHours);
			this.m_calculationsPanel.Controls.Add(this.m_weekendsLabel);
			this.m_calculationsPanel.Controls.Add(this.m_workDaysLabel);
			this.m_calculationsPanel.Controls.Add(this.m_otherDays);
			this.m_calculationsPanel.Controls.Add(this.m_workDays);
			this.m_calculationsPanel.Controls.Add(this.m_otherDaysLabel);
			this.m_calculationsPanel.Controls.Add(this.m_maxBillableHours);
			this.m_calculationsPanel.Controls.Add(this.m_sickDays);
			this.m_calculationsPanel.Controls.Add(this.m_flexDaysLabel);
			this.m_calculationsPanel.Controls.Add(this.m_sickDaysLabel);
			this.m_calculationsPanel.Controls.Add(this.m_flexDays);
			this.m_calculationsPanel.Controls.Add(this.m_halfDays);
			this.m_calculationsPanel.Controls.Add(this.m_vacationDaysLabel);
			this.m_calculationsPanel.Controls.Add(this.m_halfDaysLabel);
			this.m_calculationsPanel.Controls.Add(this.m_vacationDays);
			this.m_calculationsPanel.Controls.Add(m_maxBillableHoursLabel);
			this.m_calculationsPanel.Controls.Add(label3);
			this.m_calculationsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_calculationsPanel.Location = new System.Drawing.Point(0, 328);
			this.m_calculationsPanel.Name = "m_calculationsPanel";
			this.m_calculationsPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
			this.m_calculationsPanel.Size = new System.Drawing.Size(792, 240);
			this.m_calculationsPanel.TabIndex = 1;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.pictureBox1.Location = new System.Drawing.Point(19, 190);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(370, 2);
			this.pictureBox1.TabIndex = 24;
			this.pictureBox1.TabStop = false;
			// 
			// m_realWorkDays
			// 
			this.m_realWorkDays.AutoSize = true;
			this.m_realWorkDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_realWorkDays.Location = new System.Drawing.Point(410, 6);
			this.m_realWorkDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_realWorkDays.Name = "m_realWorkDays";
			this.m_realWorkDays.Size = new System.Drawing.Size(17, 17);
			this.m_realWorkDays.TabIndex = 1;
			this.m_realWorkDays.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(577, 81);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Year";
			this.label1.Visible = false;
			// 
			// m_years
			// 
			this.m_years.FormattingEnabled = true;
			this.m_years.Location = new System.Drawing.Point(621, 78);
			this.m_years.Name = "m_years";
			this.m_years.Size = new System.Drawing.Size(121, 24);
			this.m_years.TabIndex = 1;
			this.m_years.Visible = false;
			// 
			// m_executiveOrders
			// 
			this.m_executiveOrders.AutoSize = true;
			this.m_executiveOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_executiveOrders.Location = new System.Drawing.Point(147, 85);
			this.m_executiveOrders.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_executiveOrders.Name = "m_executiveOrders";
			this.m_executiveOrders.Size = new System.Drawing.Size(17, 17);
			this.m_executiveOrders.TabIndex = 13;
			this.m_executiveOrders.Text = "0";
			// 
			// m_estimatedYearlyIncome
			// 
			this.m_estimatedYearlyIncome.AutoSize = true;
			this.m_estimatedYearlyIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_estimatedYearlyIncome.Location = new System.Drawing.Point(190, 198);
			this.m_estimatedYearlyIncome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_estimatedYearlyIncome.Name = "m_estimatedYearlyIncome";
			this.m_estimatedYearlyIncome.Size = new System.Drawing.Size(40, 17);
			this.m_estimatedYearlyIncome.TabIndex = 25;
			this.m_estimatedYearlyIncome.Text = "0.00";
			// 
			// m_adjustmentHours
			// 
			this.m_adjustmentHours.AutoSize = true;
			this.m_adjustmentHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_adjustmentHours.Location = new System.Drawing.Point(147, 156);
			this.m_adjustmentHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_adjustmentHours.Name = "m_adjustmentHours";
			this.m_adjustmentHours.Size = new System.Drawing.Size(40, 17);
			this.m_adjustmentHours.TabIndex = 23;
			this.m_adjustmentHours.Text = "0.00";
			// 
			// m_executiveOrdersLabel
			// 
			this.m_executiveOrdersLabel.AutoSize = true;
			this.m_executiveOrdersLabel.Location = new System.Drawing.Point(15, 85);
			this.m_executiveOrdersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_executiveOrdersLabel.Name = "m_executiveOrdersLabel";
			this.m_executiveOrdersLabel.Size = new System.Drawing.Size(120, 17);
			this.m_executiveOrdersLabel.TabIndex = 12;
			this.m_executiveOrdersLabel.Text = "Executive Orders:";
			// 
			// m_weekends
			// 
			this.m_weekends.AutoSize = true;
			this.m_weekends.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_weekends.Location = new System.Drawing.Point(147, 69);
			this.m_weekends.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_weekends.Name = "m_weekends";
			this.m_weekends.Size = new System.Drawing.Size(17, 17);
			this.m_weekends.TabIndex = 9;
			this.m_weekends.Text = "0";
			// 
			// m_billableHours
			// 
			this.m_billableHours.AutoSize = true;
			this.m_billableHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_billableHours.Location = new System.Drawing.Point(147, 140);
			this.m_billableHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_billableHours.Name = "m_billableHours";
			this.m_billableHours.Size = new System.Drawing.Size(40, 17);
			this.m_billableHours.TabIndex = 21;
			this.m_billableHours.Text = "0.00";
			// 
			// m_weekendsLabel
			// 
			this.m_weekendsLabel.AutoSize = true;
			this.m_weekendsLabel.Location = new System.Drawing.Point(15, 69);
			this.m_weekendsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_weekendsLabel.Name = "m_weekendsLabel";
			this.m_weekendsLabel.Size = new System.Drawing.Size(79, 17);
			this.m_weekendsLabel.TabIndex = 8;
			this.m_weekendsLabel.Text = "Weekends:";
			// 
			// m_workDaysLabel
			// 
			this.m_workDaysLabel.AutoSize = true;
			this.m_workDaysLabel.Location = new System.Drawing.Point(15, 53);
			this.m_workDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_workDaysLabel.Name = "m_workDaysLabel";
			this.m_workDaysLabel.Size = new System.Drawing.Size(81, 17);
			this.m_workDaysLabel.TabIndex = 4;
			this.m_workDaysLabel.Text = "Work Days:";
			// 
			// m_otherDays
			// 
			this.m_otherDays.AutoSize = true;
			this.m_otherDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_otherDays.Location = new System.Drawing.Point(347, 102);
			this.m_otherDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_otherDays.Name = "m_otherDays";
			this.m_otherDays.Size = new System.Drawing.Size(17, 17);
			this.m_otherDays.TabIndex = 19;
			this.m_otherDays.Text = "0";
			// 
			// m_workDays
			// 
			this.m_workDays.AutoSize = true;
			this.m_workDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_workDays.Location = new System.Drawing.Point(147, 53);
			this.m_workDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_workDays.Name = "m_workDays";
			this.m_workDays.Size = new System.Drawing.Size(17, 17);
			this.m_workDays.TabIndex = 5;
			this.m_workDays.Text = "0";
			// 
			// m_otherDaysLabel
			// 
			this.m_otherDaysLabel.AutoSize = true;
			this.m_otherDaysLabel.Location = new System.Drawing.Point(215, 102);
			this.m_otherDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_otherDaysLabel.Name = "m_otherDaysLabel";
			this.m_otherDaysLabel.Size = new System.Drawing.Size(94, 17);
			this.m_otherDaysLabel.TabIndex = 18;
			this.m_otherDaysLabel.Text = "\"Other\" Days:";
			// 
			// m_maxBillableHours
			// 
			this.m_maxBillableHours.AutoSize = true;
			this.m_maxBillableHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_maxBillableHours.Location = new System.Drawing.Point(410, 24);
			this.m_maxBillableHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_maxBillableHours.Name = "m_maxBillableHours";
			this.m_maxBillableHours.Size = new System.Drawing.Size(17, 17);
			this.m_maxBillableHours.TabIndex = 3;
			this.m_maxBillableHours.Text = "0";
			// 
			// m_sickDays
			// 
			this.m_sickDays.AutoSize = true;
			this.m_sickDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_sickDays.Location = new System.Drawing.Point(347, 86);
			this.m_sickDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_sickDays.Name = "m_sickDays";
			this.m_sickDays.Size = new System.Drawing.Size(17, 17);
			this.m_sickDays.TabIndex = 15;
			this.m_sickDays.Text = "0";
			// 
			// m_flexDaysLabel
			// 
			this.m_flexDaysLabel.AutoSize = true;
			this.m_flexDaysLabel.Location = new System.Drawing.Point(15, 101);
			this.m_flexDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_flexDaysLabel.Name = "m_flexDaysLabel";
			this.m_flexDaysLabel.Size = new System.Drawing.Size(73, 17);
			this.m_flexDaysLabel.TabIndex = 16;
			this.m_flexDaysLabel.Text = "Flex Days:";
			// 
			// m_sickDaysLabel
			// 
			this.m_sickDaysLabel.AutoSize = true;
			this.m_sickDaysLabel.Location = new System.Drawing.Point(215, 86);
			this.m_sickDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_sickDaysLabel.Name = "m_sickDaysLabel";
			this.m_sickDaysLabel.Size = new System.Drawing.Size(74, 17);
			this.m_sickDaysLabel.TabIndex = 14;
			this.m_sickDaysLabel.Text = "Sick Days:";
			// 
			// m_flexDays
			// 
			this.m_flexDays.AutoSize = true;
			this.m_flexDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_flexDays.Location = new System.Drawing.Point(147, 101);
			this.m_flexDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_flexDays.Name = "m_flexDays";
			this.m_flexDays.Size = new System.Drawing.Size(17, 17);
			this.m_flexDays.TabIndex = 17;
			this.m_flexDays.Text = "0";
			// 
			// m_halfDays
			// 
			this.m_halfDays.AutoSize = true;
			this.m_halfDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_halfDays.Location = new System.Drawing.Point(347, 70);
			this.m_halfDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_halfDays.Name = "m_halfDays";
			this.m_halfDays.Size = new System.Drawing.Size(17, 17);
			this.m_halfDays.TabIndex = 11;
			this.m_halfDays.Text = "0";
			// 
			// m_vacationDaysLabel
			// 
			this.m_vacationDaysLabel.AutoSize = true;
			this.m_vacationDaysLabel.Location = new System.Drawing.Point(215, 54);
			this.m_vacationDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_vacationDaysLabel.Name = "m_vacationDaysLabel";
			this.m_vacationDaysLabel.Size = new System.Drawing.Size(103, 17);
			this.m_vacationDaysLabel.TabIndex = 6;
			this.m_vacationDaysLabel.Text = "Vacation Days:";
			// 
			// m_halfDaysLabel
			// 
			this.m_halfDaysLabel.AutoSize = true;
			this.m_halfDaysLabel.Location = new System.Drawing.Point(215, 70);
			this.m_halfDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_halfDaysLabel.Name = "m_halfDaysLabel";
			this.m_halfDaysLabel.Size = new System.Drawing.Size(73, 17);
			this.m_halfDaysLabel.TabIndex = 10;
			this.m_halfDaysLabel.Text = "Half Days:";
			// 
			// m_vacationDays
			// 
			this.m_vacationDays.AutoSize = true;
			this.m_vacationDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_vacationDays.Location = new System.Drawing.Point(347, 54);
			this.m_vacationDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_vacationDays.Name = "m_vacationDays";
			this.m_vacationDays.Size = new System.Drawing.Size(17, 17);
			this.m_vacationDays.TabIndex = 7;
			this.m_vacationDays.Text = "0";
			// 
			// m_actionsPanel
			// 
			this.m_actionsPanel.Controls.Add(this.m_refresh);
			this.m_actionsPanel.Controls.Add(this.m_endDate);
			this.m_actionsPanel.Controls.Add(this.m_startDate);
			this.m_actionsPanel.Controls.Add(this.label4);
			this.m_actionsPanel.Controls.Add(this.label2);
			this.m_actionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_actionsPanel.Location = new System.Drawing.Point(0, 0);
			this.m_actionsPanel.Name = "m_actionsPanel";
			this.m_actionsPanel.Size = new System.Drawing.Size(792, 51);
			this.m_actionsPanel.TabIndex = 0;
			// 
			// m_refresh
			// 
			this.m_refresh.AutoSize = true;
			this.m_refresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_refresh.BackColor = System.Drawing.Color.Transparent;
			this.m_refresh.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_refresh.FlatAppearance.BorderSize = 0;
			this.m_refresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.m_refresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.m_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_refresh.Image = ((System.Drawing.Image)(resources.GetObject("m_refresh.Image")));
			this.m_refresh.Location = new System.Drawing.Point(733, 7);
			this.m_refresh.Name = "m_refresh";
			this.m_refresh.Size = new System.Drawing.Size(38, 38);
			this.m_refresh.TabIndex = 26;
			this.m_refresh.UseVisualStyleBackColor = false;
			// 
			// m_endDate
			// 
			this.m_endDate.Location = new System.Drawing.Point(485, 15);
			this.m_endDate.Name = "m_endDate";
			this.m_endDate.Size = new System.Drawing.Size(240, 22);
			this.m_endDate.TabIndex = 3;
			// 
			// m_startDate
			// 
			this.m_startDate.Location = new System.Drawing.Point(124, 15);
			this.m_startDate.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
			this.m_startDate.MinDate = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
			this.m_startDate.Name = "m_startDate";
			this.m_startDate.Size = new System.Drawing.Size(240, 22);
			this.m_startDate.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(369, 18);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 17);
			this.label4.TabIndex = 2;
			this.label4.Text = "End Year/Month";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(115, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "Start Year/Month";
			// 
			// m_monthDetailTableContainer
			// 
			this.m_monthDetailTableContainer.AutoScroll = true;
			this.m_monthDetailTableContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.m_monthDetailTableContainer.Location = new System.Drawing.Point(282, 125);
			this.m_monthDetailTableContainer.MinimumSize = new System.Drawing.Size(500, 100);
			this.m_monthDetailTableContainer.Name = "m_monthDetailTableContainer";
			this.m_monthDetailTableContainer.Size = new System.Drawing.Size(500, 192);
			this.m_monthDetailTableContainer.TabIndex = 1;
			// 
			// m_treeView
			// 
			this.m_treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_treeView.Location = new System.Drawing.Point(0, 51);
			this.m_treeView.Name = "m_treeView";
			this.m_treeView.Size = new System.Drawing.Size(792, 277);
			this.m_treeView.TabIndex = 2;
			// 
			// TimesheetYearlyOverviewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 568);
			this.Controls.Add(this.m_treeView);
			this.Controls.Add(this.m_monthDetailTableContainer);
			this.Controls.Add(this.m_calculationsPanel);
			this.Controls.Add(this.m_actionsPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "TimesheetYearlyOverviewForm";
			this.Text = "Timesheet Yearly Overview";
			this.m_calculationsPanel.ResumeLayout(false);
			this.m_calculationsPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.m_actionsPanel.ResumeLayout(false);
			this.m_actionsPanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel m_calculationsPanel;
		private System.Windows.Forms.Label m_realWorkDays;
		private System.Windows.Forms.Label m_executiveOrders;
		private System.Windows.Forms.Label m_adjustmentHours;
		private System.Windows.Forms.Label m_executiveOrdersLabel;
		private System.Windows.Forms.Label m_weekends;
		private System.Windows.Forms.Label m_billableHours;
		private System.Windows.Forms.Label m_weekendsLabel;
		private System.Windows.Forms.Label m_workDaysLabel;
		private System.Windows.Forms.Label m_otherDays;
		private System.Windows.Forms.Label m_workDays;
		private System.Windows.Forms.Label m_otherDaysLabel;
		private System.Windows.Forms.Label m_maxBillableHours;
		private System.Windows.Forms.Label m_sickDays;
		private System.Windows.Forms.Label m_flexDaysLabel;
		private System.Windows.Forms.Label m_sickDaysLabel;
		private System.Windows.Forms.Label m_flexDays;
		private System.Windows.Forms.Label m_halfDays;
		private System.Windows.Forms.Label m_vacationDaysLabel;
		private System.Windows.Forms.Label m_halfDaysLabel;
		private System.Windows.Forms.Label m_vacationDays;
		private System.Windows.Forms.ComboBox m_years;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel m_actionsPanel;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label m_estimatedYearlyIncome;
		private System.Windows.Forms.Panel m_monthDetailTableContainer;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker m_endDate;
		private System.Windows.Forms.DateTimePicker m_startDate;
		private System.Windows.Forms.Button m_refresh;
		private UserControls.TreeView.TreeViewEx m_treeView;
	}
}