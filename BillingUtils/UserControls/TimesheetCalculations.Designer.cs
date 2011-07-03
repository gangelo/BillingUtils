namespace BillingUtils.UserControls {
	partial class TimesheetCalculations {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.Windows.Forms.Label m_realWorkDaysLabel;
			System.Windows.Forms.Label m_maxBillableHoursLabel;
			System.Windows.Forms.Label m_billableHoursLabel;
			System.Windows.Forms.Label m_adjustmentHoursLabel;
			this.m_realWorkDays = new System.Windows.Forms.Label();
			this.m_executiveOrders = new System.Windows.Forms.Label();
			this.m_executiveOrdersLabel = new System.Windows.Forms.Label();
			this.m_weekends = new System.Windows.Forms.Label();
			this.m_weekendsLabel = new System.Windows.Forms.Label();
			this.m_otherDays = new System.Windows.Forms.Label();
			this.m_otherDaysLabel = new System.Windows.Forms.Label();
			this.m_sickDays = new System.Windows.Forms.Label();
			this.m_sickDaysLabel = new System.Windows.Forms.Label();
			this.m_halfDays = new System.Windows.Forms.Label();
			this.m_halfDaysLabel = new System.Windows.Forms.Label();
			this.m_vacationDays = new System.Windows.Forms.Label();
			this.m_vacationDaysLabel = new System.Windows.Forms.Label();
			this.m_flexDays = new System.Windows.Forms.Label();
			this.m_flexDaysLabel = new System.Windows.Forms.Label();
			this.m_maxBillableHours = new System.Windows.Forms.Label();
			this.m_workDays = new System.Windows.Forms.Label();
			this.m_workDaysLabel = new System.Windows.Forms.Label();
			this.m_billableHours = new System.Windows.Forms.Label();
			this.m_adjustmentHours = new System.Windows.Forms.Label();
			this.m_containerPanel = new System.Windows.Forms.Panel();
			this.m_calculationsPanel = new System.Windows.Forms.Panel();
			this.m_actionsPanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.m_collapseButton = new System.Windows.Forms.PictureBox();
			this.m_message = new System.Windows.Forms.RichTextBox();
			this.m_billableHoursCheckInformation = new System.Windows.Forms.Label();
			this.m_hoursWorkedCheckDifference = new System.Windows.Forms.Label();
			this.m_hoursWorkedCheckDifferenceLabel = new System.Windows.Forms.Label();
			this.m_billableHoursCheckLabel = new System.Windows.Forms.Label();
			this.m_billableHoursCheckPictureBox = new System.Windows.Forms.PictureBox();
			m_realWorkDaysLabel = new System.Windows.Forms.Label();
			m_maxBillableHoursLabel = new System.Windows.Forms.Label();
			m_billableHoursLabel = new System.Windows.Forms.Label();
			m_adjustmentHoursLabel = new System.Windows.Forms.Label();
			this.m_containerPanel.SuspendLayout();
			this.m_calculationsPanel.SuspendLayout();
			this.m_actionsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_collapseButton)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_billableHoursCheckPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// m_realWorkDaysLabel
			// 
			m_realWorkDaysLabel.AutoSize = true;
			m_realWorkDaysLabel.Location = new System.Drawing.Point(14, 7);
			m_realWorkDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			m_realWorkDaysLabel.Name = "m_realWorkDaysLabel";
			m_realWorkDaysLabel.Size = new System.Drawing.Size(260, 34);
			m_realWorkDaysLabel.TabIndex = 0;
			m_realWorkDaysLabel.Text = "Real Work Days:\r\n     (Week Days - Executive Order Days)\r\n";
			// 
			// m_maxBillableHoursLabel
			// 
			m_maxBillableHoursLabel.AutoSize = true;
			m_maxBillableHoursLabel.Location = new System.Drawing.Point(15, 41);
			m_maxBillableHoursLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			m_maxBillableHoursLabel.Name = "m_maxBillableHoursLabel";
			m_maxBillableHoursLabel.Size = new System.Drawing.Size(287, 34);
			m_maxBillableHoursLabel.TabIndex = 2;
			m_maxBillableHoursLabel.Text = "Max Billable Hours:\r\n     (Maximum billable hours allowed by SMS)\r\n";
			// 
			// m_billableHoursLabel
			// 
			m_billableHoursLabel.AutoSize = true;
			m_billableHoursLabel.Location = new System.Drawing.Point(625, 10);
			m_billableHoursLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			m_billableHoursLabel.Name = "m_billableHoursLabel";
			m_billableHoursLabel.Size = new System.Drawing.Size(99, 17);
			m_billableHoursLabel.TabIndex = 20;
			m_billableHoursLabel.Text = "Billable Hours:";
			// 
			// m_adjustmentHoursLabel
			// 
			m_adjustmentHoursLabel.AutoSize = true;
			m_adjustmentHoursLabel.Location = new System.Drawing.Point(625, 26);
			m_adjustmentHoursLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			m_adjustmentHoursLabel.Name = "m_adjustmentHoursLabel";
			m_adjustmentHoursLabel.Size = new System.Drawing.Size(124, 17);
			m_adjustmentHoursLabel.TabIndex = 22;
			m_adjustmentHoursLabel.Text = "Adjustment Hours:";
			// 
			// m_realWorkDays
			// 
			this.m_realWorkDays.AutoSize = true;
			this.m_realWorkDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_realWorkDays.Location = new System.Drawing.Point(146, 7);
			this.m_realWorkDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_realWorkDays.Name = "m_realWorkDays";
			this.m_realWorkDays.Size = new System.Drawing.Size(17, 17);
			this.m_realWorkDays.TabIndex = 1;
			this.m_realWorkDays.Text = "0";
			// 
			// m_executiveOrders
			// 
			this.m_executiveOrders.AutoSize = true;
			this.m_executiveOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_executiveOrders.Location = new System.Drawing.Point(443, 40);
			this.m_executiveOrders.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_executiveOrders.Name = "m_executiveOrders";
			this.m_executiveOrders.Size = new System.Drawing.Size(17, 17);
			this.m_executiveOrders.TabIndex = 9;
			this.m_executiveOrders.Text = "0";
			// 
			// m_executiveOrdersLabel
			// 
			this.m_executiveOrdersLabel.AutoSize = true;
			this.m_executiveOrdersLabel.Location = new System.Drawing.Point(311, 40);
			this.m_executiveOrdersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_executiveOrdersLabel.Name = "m_executiveOrdersLabel";
			this.m_executiveOrdersLabel.Size = new System.Drawing.Size(120, 17);
			this.m_executiveOrdersLabel.TabIndex = 8;
			this.m_executiveOrdersLabel.Text = "Executive Orders:";
			// 
			// m_weekends
			// 
			this.m_weekends.AutoSize = true;
			this.m_weekends.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_weekends.Location = new System.Drawing.Point(443, 24);
			this.m_weekends.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_weekends.Name = "m_weekends";
			this.m_weekends.Size = new System.Drawing.Size(17, 17);
			this.m_weekends.TabIndex = 7;
			this.m_weekends.Text = "0";
			// 
			// m_weekendsLabel
			// 
			this.m_weekendsLabel.AutoSize = true;
			this.m_weekendsLabel.Location = new System.Drawing.Point(311, 24);
			this.m_weekendsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_weekendsLabel.Name = "m_weekendsLabel";
			this.m_weekendsLabel.Size = new System.Drawing.Size(79, 17);
			this.m_weekendsLabel.TabIndex = 6;
			this.m_weekendsLabel.Text = "Weekends:";
			// 
			// m_otherDays
			// 
			this.m_otherDays.AutoSize = true;
			this.m_otherDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_otherDays.Location = new System.Drawing.Point(600, 57);
			this.m_otherDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_otherDays.Name = "m_otherDays";
			this.m_otherDays.Size = new System.Drawing.Size(17, 17);
			this.m_otherDays.TabIndex = 19;
			this.m_otherDays.Text = "0";
			// 
			// m_otherDaysLabel
			// 
			this.m_otherDaysLabel.AutoSize = true;
			this.m_otherDaysLabel.Location = new System.Drawing.Point(468, 57);
			this.m_otherDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_otherDaysLabel.Name = "m_otherDaysLabel";
			this.m_otherDaysLabel.Size = new System.Drawing.Size(94, 17);
			this.m_otherDaysLabel.TabIndex = 18;
			this.m_otherDaysLabel.Text = "\"Other\" Days:";
			// 
			// m_sickDays
			// 
			this.m_sickDays.AutoSize = true;
			this.m_sickDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_sickDays.Location = new System.Drawing.Point(600, 41);
			this.m_sickDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_sickDays.Name = "m_sickDays";
			this.m_sickDays.Size = new System.Drawing.Size(17, 17);
			this.m_sickDays.TabIndex = 17;
			this.m_sickDays.Text = "0";
			// 
			// m_sickDaysLabel
			// 
			this.m_sickDaysLabel.AutoSize = true;
			this.m_sickDaysLabel.Location = new System.Drawing.Point(468, 41);
			this.m_sickDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_sickDaysLabel.Name = "m_sickDaysLabel";
			this.m_sickDaysLabel.Size = new System.Drawing.Size(74, 17);
			this.m_sickDaysLabel.TabIndex = 16;
			this.m_sickDaysLabel.Text = "Sick Days:";
			// 
			// m_halfDays
			// 
			this.m_halfDays.AutoSize = true;
			this.m_halfDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_halfDays.Location = new System.Drawing.Point(600, 25);
			this.m_halfDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_halfDays.Name = "m_halfDays";
			this.m_halfDays.Size = new System.Drawing.Size(17, 17);
			this.m_halfDays.TabIndex = 15;
			this.m_halfDays.Text = "0";
			// 
			// m_halfDaysLabel
			// 
			this.m_halfDaysLabel.AutoSize = true;
			this.m_halfDaysLabel.Location = new System.Drawing.Point(468, 25);
			this.m_halfDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_halfDaysLabel.Name = "m_halfDaysLabel";
			this.m_halfDaysLabel.Size = new System.Drawing.Size(73, 17);
			this.m_halfDaysLabel.TabIndex = 14;
			this.m_halfDaysLabel.Text = "Half Days:";
			// 
			// m_vacationDays
			// 
			this.m_vacationDays.AutoSize = true;
			this.m_vacationDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_vacationDays.Location = new System.Drawing.Point(600, 9);
			this.m_vacationDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_vacationDays.Name = "m_vacationDays";
			this.m_vacationDays.Size = new System.Drawing.Size(17, 17);
			this.m_vacationDays.TabIndex = 13;
			this.m_vacationDays.Text = "0";
			// 
			// m_vacationDaysLabel
			// 
			this.m_vacationDaysLabel.AutoSize = true;
			this.m_vacationDaysLabel.Location = new System.Drawing.Point(468, 9);
			this.m_vacationDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_vacationDaysLabel.Name = "m_vacationDaysLabel";
			this.m_vacationDaysLabel.Size = new System.Drawing.Size(103, 17);
			this.m_vacationDaysLabel.TabIndex = 12;
			this.m_vacationDaysLabel.Text = "Vacation Days:";
			// 
			// m_flexDays
			// 
			this.m_flexDays.AutoSize = true;
			this.m_flexDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_flexDays.Location = new System.Drawing.Point(443, 56);
			this.m_flexDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_flexDays.Name = "m_flexDays";
			this.m_flexDays.Size = new System.Drawing.Size(17, 17);
			this.m_flexDays.TabIndex = 11;
			this.m_flexDays.Text = "0";
			// 
			// m_flexDaysLabel
			// 
			this.m_flexDaysLabel.AutoSize = true;
			this.m_flexDaysLabel.Location = new System.Drawing.Point(311, 56);
			this.m_flexDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_flexDaysLabel.Name = "m_flexDaysLabel";
			this.m_flexDaysLabel.Size = new System.Drawing.Size(73, 17);
			this.m_flexDaysLabel.TabIndex = 10;
			this.m_flexDaysLabel.Text = "Flex Days:";
			// 
			// m_maxBillableHours
			// 
			this.m_maxBillableHours.AutoSize = true;
			this.m_maxBillableHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_maxBillableHours.Location = new System.Drawing.Point(146, 41);
			this.m_maxBillableHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_maxBillableHours.Name = "m_maxBillableHours";
			this.m_maxBillableHours.Size = new System.Drawing.Size(17, 17);
			this.m_maxBillableHours.TabIndex = 3;
			this.m_maxBillableHours.Text = "0";
			// 
			// m_workDays
			// 
			this.m_workDays.AutoSize = true;
			this.m_workDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_workDays.Location = new System.Drawing.Point(443, 8);
			this.m_workDays.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_workDays.Name = "m_workDays";
			this.m_workDays.Size = new System.Drawing.Size(17, 17);
			this.m_workDays.TabIndex = 5;
			this.m_workDays.Text = "0";
			// 
			// m_workDaysLabel
			// 
			this.m_workDaysLabel.AutoSize = true;
			this.m_workDaysLabel.Location = new System.Drawing.Point(311, 8);
			this.m_workDaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_workDaysLabel.Name = "m_workDaysLabel";
			this.m_workDaysLabel.Size = new System.Drawing.Size(81, 17);
			this.m_workDaysLabel.TabIndex = 4;
			this.m_workDaysLabel.Text = "Work Days:";
			// 
			// m_billableHours
			// 
			this.m_billableHours.AutoSize = true;
			this.m_billableHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_billableHours.Location = new System.Drawing.Point(757, 10);
			this.m_billableHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_billableHours.Name = "m_billableHours";
			this.m_billableHours.Size = new System.Drawing.Size(40, 17);
			this.m_billableHours.TabIndex = 21;
			this.m_billableHours.Text = "0.00";
			// 
			// m_adjustmentHours
			// 
			this.m_adjustmentHours.AutoSize = true;
			this.m_adjustmentHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_adjustmentHours.Location = new System.Drawing.Point(757, 26);
			this.m_adjustmentHours.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_adjustmentHours.Name = "m_adjustmentHours";
			this.m_adjustmentHours.Size = new System.Drawing.Size(40, 17);
			this.m_adjustmentHours.TabIndex = 23;
			this.m_adjustmentHours.Text = "0.00";
			// 
			// m_containerPanel
			// 
			this.m_containerPanel.Controls.Add(this.m_billableHoursCheckPictureBox);
			this.m_containerPanel.Controls.Add(this.m_billableHoursCheckLabel);
			this.m_containerPanel.Controls.Add(this.m_message);
			this.m_containerPanel.Controls.Add(this.m_billableHoursCheckInformation);
			this.m_containerPanel.Controls.Add(this.m_hoursWorkedCheckDifference);
			this.m_containerPanel.Controls.Add(this.m_hoursWorkedCheckDifferenceLabel);
			this.m_containerPanel.Controls.Add(this.m_calculationsPanel);
			this.m_containerPanel.Controls.Add(this.m_actionsPanel);
			this.m_containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_containerPanel.Location = new System.Drawing.Point(0, 0);
			this.m_containerPanel.Name = "m_containerPanel";
			this.m_containerPanel.Size = new System.Drawing.Size(1084, 245);
			this.m_containerPanel.TabIndex = 27;
			// 
			// m_calculationsPanel
			// 
			this.m_calculationsPanel.AutoSize = true;
			this.m_calculationsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_calculationsPanel.Controls.Add(this.m_realWorkDays);
			this.m_calculationsPanel.Controls.Add(m_realWorkDaysLabel);
			this.m_calculationsPanel.Controls.Add(m_adjustmentHoursLabel);
			this.m_calculationsPanel.Controls.Add(this.m_executiveOrders);
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
			this.m_calculationsPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_calculationsPanel.Location = new System.Drawing.Point(0, 31);
			this.m_calculationsPanel.Name = "m_calculationsPanel";
			this.m_calculationsPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
			this.m_calculationsPanel.Size = new System.Drawing.Size(1084, 100);
			this.m_calculationsPanel.TabIndex = 27;
			// 
			// m_actionsPanel
			// 
			this.m_actionsPanel.Controls.Add(this.label1);
			this.m_actionsPanel.Controls.Add(this.m_collapseButton);
			this.m_actionsPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_actionsPanel.Location = new System.Drawing.Point(0, 0);
			this.m_actionsPanel.Name = "m_actionsPanel";
			this.m_actionsPanel.Size = new System.Drawing.Size(1084, 31);
			this.m_actionsPanel.TabIndex = 26;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(29, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Calculations";
			// 
			// m_collapseButton
			// 
			this.m_collapseButton.Image = global::BillingUtils.Properties.Resources.Collapse;
			this.m_collapseButton.Location = new System.Drawing.Point(7, 8);
			this.m_collapseButton.Name = "m_collapseButton";
			this.m_collapseButton.Size = new System.Drawing.Size(16, 16);
			this.m_collapseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.m_collapseButton.TabIndex = 0;
			this.m_collapseButton.TabStop = false;
			// 
			// m_message
			// 
			this.m_message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
							| System.Windows.Forms.AnchorStyles.Left)
							| System.Windows.Forms.AnchorStyles.Right)));
			this.m_message.BackColor = System.Drawing.Color.White;
			this.m_message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_message.Location = new System.Drawing.Point(306, 139);
			this.m_message.Margin = new System.Windows.Forms.Padding(4);
			this.m_message.Name = "m_message";
			this.m_message.ReadOnly = true;
			this.m_message.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.m_message.Size = new System.Drawing.Size(764, 96);
			this.m_message.TabIndex = 31;
			this.m_message.Text = "";
			// 
			// m_billableHoursCheckInformation
			// 
			this.m_billableHoursCheckInformation.AutoSize = true;
			this.m_billableHoursCheckInformation.Location = new System.Drawing.Point(29, 165);
			this.m_billableHoursCheckInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_billableHoursCheckInformation.Name = "m_billableHoursCheckInformation";
			this.m_billableHoursCheckInformation.Size = new System.Drawing.Size(269, 34);
			this.m_billableHoursCheckInformation.TabIndex = 28;
			this.m_billableHoursCheckInformation.Text = "Calculation: \"Billable Hours\" must be less \r\nthan or equal to \"Max Billable Hours" +
				 "\"";
			// 
			// m_hoursWorkedCheckDifference
			// 
			this.m_hoursWorkedCheckDifference.AutoSize = true;
			this.m_hoursWorkedCheckDifference.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_hoursWorkedCheckDifference.ForeColor = System.Drawing.Color.Black;
			this.m_hoursWorkedCheckDifference.Location = new System.Drawing.Point(146, 209);
			this.m_hoursWorkedCheckDifference.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_hoursWorkedCheckDifference.Name = "m_hoursWorkedCheckDifference";
			this.m_hoursWorkedCheckDifference.Size = new System.Drawing.Size(17, 17);
			this.m_hoursWorkedCheckDifference.TabIndex = 30;
			this.m_hoursWorkedCheckDifference.Text = "0";
			// 
			// m_hoursWorkedCheckDifferenceLabel
			// 
			this.m_hoursWorkedCheckDifferenceLabel.AutoSize = true;
			this.m_hoursWorkedCheckDifferenceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_hoursWorkedCheckDifferenceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
			this.m_hoursWorkedCheckDifferenceLabel.Location = new System.Drawing.Point(29, 209);
			this.m_hoursWorkedCheckDifferenceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.m_hoursWorkedCheckDifferenceLabel.Name = "m_hoursWorkedCheckDifferenceLabel";
			this.m_hoursWorkedCheckDifferenceLabel.Size = new System.Drawing.Size(88, 17);
			this.m_hoursWorkedCheckDifferenceLabel.TabIndex = 29;
			this.m_hoursWorkedCheckDifferenceLabel.Text = "Difference:";
			// 
			// m_billableHoursCheckLabel
			// 
			this.m_billableHoursCheckLabel.AutoSize = true;
			this.m_billableHoursCheckLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_billableHoursCheckLabel.Location = new System.Drawing.Point(29, 139);
			this.m_billableHoursCheckLabel.Name = "m_billableHoursCheckLabel";
			this.m_billableHoursCheckLabel.Size = new System.Drawing.Size(158, 17);
			this.m_billableHoursCheckLabel.TabIndex = 1;
			this.m_billableHoursCheckLabel.Text = "Billable Hours Check";
			// 
			// m_billableHoursCheckPictureBox
			// 
			this.m_billableHoursCheckPictureBox.BackColor = System.Drawing.Color.Black;
			this.m_billableHoursCheckPictureBox.Location = new System.Drawing.Point(7, 139);
			this.m_billableHoursCheckPictureBox.Name = "m_billableHoursCheckPictureBox";
			this.m_billableHoursCheckPictureBox.Size = new System.Drawing.Size(10, 96);
			this.m_billableHoursCheckPictureBox.TabIndex = 32;
			this.m_billableHoursCheckPictureBox.TabStop = false;
			// 
			// TimesheetCalculations
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_containerPanel);
			this.Name = "TimesheetCalculations";
			this.Size = new System.Drawing.Size(1084, 245);
			this.m_containerPanel.ResumeLayout(false);
			this.m_containerPanel.PerformLayout();
			this.m_calculationsPanel.ResumeLayout(false);
			this.m_calculationsPanel.PerformLayout();
			this.m_actionsPanel.ResumeLayout(false);
			this.m_actionsPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_collapseButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_billableHoursCheckPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label m_realWorkDays;
		private System.Windows.Forms.Label m_executiveOrders;
		private System.Windows.Forms.Label m_executiveOrdersLabel;
		private System.Windows.Forms.Label m_weekends;
		private System.Windows.Forms.Label m_weekendsLabel;
		private System.Windows.Forms.Label m_otherDays;
		private System.Windows.Forms.Label m_otherDaysLabel;
		private System.Windows.Forms.Label m_sickDays;
		private System.Windows.Forms.Label m_sickDaysLabel;
		private System.Windows.Forms.Label m_halfDays;
		private System.Windows.Forms.Label m_halfDaysLabel;
		private System.Windows.Forms.Label m_vacationDays;
		private System.Windows.Forms.Label m_vacationDaysLabel;
		private System.Windows.Forms.Label m_flexDays;
		private System.Windows.Forms.Label m_flexDaysLabel;
		private System.Windows.Forms.Label m_maxBillableHours;
		private System.Windows.Forms.Label m_workDays;
		private System.Windows.Forms.Label m_workDaysLabel;
		private System.Windows.Forms.Label m_billableHours;
		private System.Windows.Forms.Label m_adjustmentHours;
		private System.Windows.Forms.Panel m_containerPanel;
		private System.Windows.Forms.Panel m_actionsPanel;
		private System.Windows.Forms.PictureBox m_collapseButton;
		private System.Windows.Forms.Panel m_calculationsPanel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox m_message;
		private System.Windows.Forms.Label m_hoursWorkedCheckDifference;
		private System.Windows.Forms.Label m_hoursWorkedCheckDifferenceLabel;
		private System.Windows.Forms.Label m_billableHoursCheckLabel;
		private System.Windows.Forms.Label m_billableHoursCheckInformation;
		private System.Windows.Forms.PictureBox m_billableHoursCheckPictureBox;
	}
}
