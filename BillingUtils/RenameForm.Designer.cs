namespace BillingUtils {
	partial class RenameForm {
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
			System.Windows.Forms.GroupBox m_renameStatusGroupBox;
			System.Windows.Forms.Label m_replaceWithTokenLabel;
			System.Windows.Forms.Label m_fromLabel;
			System.Windows.Forms.Label label1;
			this.m_renameStatus = new System.Windows.Forms.ListView();
			this.m_toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.m_cancel = new System.Windows.Forms.Button();
			this.m_ok = new System.Windows.Forms.Button();
			this.m_folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.m_fromFolder = new System.Windows.Forms.LinkLabel();
			this.m_toToken = new System.Windows.Forms.TextBox();
			this.m_fromTokenToReplace = new System.Windows.Forms.ComboBox();
			this.m_renameSampleLabel = new System.Windows.Forms.Label();
			this.m_renameSample = new System.Windows.Forms.RichTextBox();
			this.m_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			m_renameStatusGroupBox = new System.Windows.Forms.GroupBox();
			m_replaceWithTokenLabel = new System.Windows.Forms.Label();
			m_fromLabel = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			m_renameStatusGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// m_renameStatusGroupBox
			// 
			m_renameStatusGroupBox.Controls.Add(this.m_renameStatus);
			m_renameStatusGroupBox.Location = new System.Drawing.Point(13, 118);
			m_renameStatusGroupBox.Name = "m_renameStatusGroupBox";
			m_renameStatusGroupBox.Size = new System.Drawing.Size(602, 154);
			m_renameStatusGroupBox.TabIndex = 10;
			m_renameStatusGroupBox.TabStop = false;
			m_renameStatusGroupBox.Text = "Rename Status";
			// 
			// m_renameStatus
			// 
			this.m_renameStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_renameStatus.GridLines = true;
			this.m_renameStatus.Location = new System.Drawing.Point(3, 18);
			this.m_renameStatus.Name = "m_renameStatus";
			this.m_renameStatus.Size = new System.Drawing.Size(596, 133);
			this.m_renameStatus.TabIndex = 0;
			this.m_renameStatus.UseCompatibleStateImageBehavior = false;
			this.m_renameStatus.View = System.Windows.Forms.View.List;
			// 
			// m_replaceWithTokenLabel
			// 
			m_replaceWithTokenLabel.AutoSize = true;
			m_replaceWithTokenLabel.Location = new System.Drawing.Point(37, 64);
			m_replaceWithTokenLabel.Name = "m_replaceWithTokenLabel";
			m_replaceWithTokenLabel.Size = new System.Drawing.Size(88, 17);
			m_replaceWithTokenLabel.TabIndex = 6;
			m_replaceWithTokenLabel.Text = "Replace with";
			// 
			// m_fromLabel
			// 
			m_fromLabel.AutoSize = true;
			m_fromLabel.Location = new System.Drawing.Point(32, 10);
			m_fromLabel.Name = "m_fromLabel";
			m_fromLabel.Size = new System.Drawing.Size(93, 17);
			m_fromLabel.TabIndex = 7;
			m_fromLabel.Text = "Rename from";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(5, 38);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(120, 17);
			label1.TabIndex = 6;
			label1.Text = "Token to Replace";
			// 
			// m_toolTip
			// 
			this.m_toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			// 
			// m_cancel
			// 
			this.m_cancel.CausesValidation = false;
			this.m_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cancel.Location = new System.Drawing.Point(537, 278);
			this.m_cancel.Name = "m_cancel";
			this.m_cancel.Size = new System.Drawing.Size(75, 23);
			this.m_cancel.TabIndex = 4;
			this.m_cancel.Text = "Cancel";
			this.m_cancel.UseVisualStyleBackColor = true;
			// 
			// m_ok
			// 
			this.m_ok.Location = new System.Drawing.Point(456, 278);
			this.m_ok.Name = "m_ok";
			this.m_ok.Size = new System.Drawing.Size(75, 23);
			this.m_ok.TabIndex = 5;
			this.m_ok.Text = "OK";
			this.m_ok.UseVisualStyleBackColor = true;
			// 
			// m_fromFolder
			// 
			this.m_fromFolder.AutoSize = true;
			this.m_fromFolder.Location = new System.Drawing.Point(128, 10);
			this.m_fromFolder.Name = "m_fromFolder";
			this.m_fromFolder.Size = new System.Drawing.Size(86, 17);
			this.m_fromFolder.TabIndex = 8;
			this.m_fromFolder.TabStop = true;
			this.m_fromFolder.Text = "[Click to Set]";
			// 
			// m_toToken
			// 
			this.m_toToken.Location = new System.Drawing.Point(131, 61);
			this.m_toToken.Name = "m_toToken";
			this.m_toToken.Size = new System.Drawing.Size(481, 22);
			this.m_toToken.TabIndex = 11;
			// 
			// m_fromTokenToReplace
			// 
			this.m_fromTokenToReplace.DropDownWidth = 250;
			this.m_fromTokenToReplace.FormattingEnabled = true;
			this.m_fromTokenToReplace.Location = new System.Drawing.Point(131, 31);
			this.m_fromTokenToReplace.Name = "m_fromTokenToReplace";
			this.m_fromTokenToReplace.Size = new System.Drawing.Size(481, 24);
			this.m_fromTokenToReplace.TabIndex = 13;
			// 
			// m_renameSampleLabel
			// 
			this.m_renameSampleLabel.AutoEllipsis = true;
			this.m_renameSampleLabel.AutoSize = true;
			this.m_renameSampleLabel.Location = new System.Drawing.Point(70, 90);
			this.m_renameSampleLabel.Name = "m_renameSampleLabel";
			this.m_renameSampleLabel.Size = new System.Drawing.Size(55, 17);
			this.m_renameSampleLabel.TabIndex = 14;
			this.m_renameSampleLabel.Text = "Sample";
			// 
			// m_renameSample
			// 
			this.m_renameSample.BackColor = System.Drawing.SystemColors.Control;
			this.m_renameSample.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_renameSample.ForeColor = System.Drawing.Color.Maroon;
			this.m_renameSample.Location = new System.Drawing.Point(131, 90);
			this.m_renameSample.Multiline = false;
			this.m_renameSample.Name = "m_renameSample";
			this.m_renameSample.ReadOnly = true;
			this.m_renameSample.Size = new System.Drawing.Size(484, 22);
			this.m_renameSample.TabIndex = 15;
			this.m_renameSample.Text = "";
			// 
			// m_errorProvider
			// 
			this.m_errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.m_errorProvider.ContainerControl = this;
			// 
			// RenameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(628, 311);
			this.Controls.Add(this.m_renameSample);
			this.Controls.Add(this.m_renameSampleLabel);
			this.Controls.Add(this.m_fromTokenToReplace);
			this.Controls.Add(this.m_toToken);
			this.Controls.Add(m_renameStatusGroupBox);
			this.Controls.Add(this.m_cancel);
			this.Controls.Add(this.m_ok);
			this.Controls.Add(label1);
			this.Controls.Add(m_replaceWithTokenLabel);
			this.Controls.Add(this.m_fromFolder);
			this.Controls.Add(m_fromLabel);
			this.Name = "RenameForm";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Text = "Timesheet/Invoice Rename";
			m_renameStatusGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView m_renameStatus;
		private System.Windows.Forms.ToolTip m_toolTip;
		private System.Windows.Forms.Button m_cancel;
		private System.Windows.Forms.Button m_ok;
		private System.Windows.Forms.FolderBrowserDialog m_folderBrowserDialog;
		private System.Windows.Forms.LinkLabel m_fromFolder;
		private System.Windows.Forms.TextBox m_toToken;
		private System.Windows.Forms.ComboBox m_fromTokenToReplace;
		private System.Windows.Forms.Label m_renameSampleLabel;
		private System.Windows.Forms.RichTextBox m_renameSample;
		private System.Windows.Forms.ErrorProvider m_errorProvider;

	}
}