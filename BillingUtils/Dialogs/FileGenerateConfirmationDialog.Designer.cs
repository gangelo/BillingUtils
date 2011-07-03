namespace BillingUtils.Dialogs {
	partial class FileGenerateConfirmationDialog {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileGenerateConfirmationDialog));
			this.m_ok = new System.Windows.Forms.Button();
			this.m_cancel = new System.Windows.Forms.Button();
			this.m_instructions = new System.Windows.Forms.RichTextBox();
			this.m_bottomPanel = new System.Windows.Forms.Panel();
			this.m_middlePanel = new System.Windows.Forms.Panel();
			this.m_timesheets = new System.Windows.Forms.ListView();
			this.m_topPanel = new System.Windows.Forms.Panel();
			this.m_imageList = new System.Windows.Forms.ImageList(this.components);
			this.m_bottomPanel.SuspendLayout();
			this.m_middlePanel.SuspendLayout();
			this.m_topPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_ok
			// 
			this.m_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_ok.AutoSize = true;
			this.m_ok.Location = new System.Drawing.Point(614, 11);
			this.m_ok.Name = "m_ok";
			this.m_ok.Size = new System.Drawing.Size(75, 27);
			this.m_ok.TabIndex = 2;
			this.m_ok.Text = "OK";
			this.m_ok.UseVisualStyleBackColor = true;
			// 
			// m_cancel
			// 
			this.m_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_cancel.AutoSize = true;
			this.m_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cancel.Location = new System.Drawing.Point(695, 11);
			this.m_cancel.Name = "m_cancel";
			this.m_cancel.Size = new System.Drawing.Size(75, 27);
			this.m_cancel.TabIndex = 2;
			this.m_cancel.Text = "Cancel";
			this.m_cancel.UseVisualStyleBackColor = true;
			// 
			// m_instructions
			// 
			this.m_instructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_instructions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_instructions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.m_instructions.Location = new System.Drawing.Point(8, 8);
			this.m_instructions.Margin = new System.Windows.Forms.Padding(8);
			this.m_instructions.Name = "m_instructions";
			this.m_instructions.ReadOnly = true;
			this.m_instructions.Size = new System.Drawing.Size(766, 108);
			this.m_instructions.TabIndex = 3;
			this.m_instructions.Text = resources.GetString("m_instructions.Text");
			// 
			// m_bottomPanel
			// 
			this.m_bottomPanel.Controls.Add(this.m_cancel);
			this.m_bottomPanel.Controls.Add(this.m_ok);
			this.m_bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_bottomPanel.Location = new System.Drawing.Point(0, 438);
			this.m_bottomPanel.Name = "m_bottomPanel";
			this.m_bottomPanel.Padding = new System.Windows.Forms.Padding(8);
			this.m_bottomPanel.Size = new System.Drawing.Size(782, 51);
			this.m_bottomPanel.TabIndex = 4;
			// 
			// m_middlePanel
			// 
			this.m_middlePanel.Controls.Add(this.m_timesheets);
			this.m_middlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_middlePanel.Location = new System.Drawing.Point(0, 124);
			this.m_middlePanel.Name = "m_middlePanel";
			this.m_middlePanel.Padding = new System.Windows.Forms.Padding(8);
			this.m_middlePanel.Size = new System.Drawing.Size(782, 314);
			this.m_middlePanel.TabIndex = 6;
			// 
			// m_timesheets
			// 
			this.m_timesheets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_timesheets.Location = new System.Drawing.Point(8, 8);
			this.m_timesheets.Name = "m_timesheets";
			this.m_timesheets.Size = new System.Drawing.Size(766, 298);
			this.m_timesheets.TabIndex = 1;
			this.m_timesheets.UseCompatibleStateImageBehavior = false;
			// 
			// m_topPanel
			// 
			this.m_topPanel.Controls.Add(this.m_instructions);
			this.m_topPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_topPanel.Location = new System.Drawing.Point(0, 0);
			this.m_topPanel.Name = "m_topPanel";
			this.m_topPanel.Padding = new System.Windows.Forms.Padding(8);
			this.m_topPanel.Size = new System.Drawing.Size(782, 124);
			this.m_topPanel.TabIndex = 7;
			// 
			// m_imageList
			// 
			this.m_imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.m_imageList.ImageSize = new System.Drawing.Size(16, 16);
			this.m_imageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// FileGenerateConfirmationDialog
			// 
			this.AcceptButton = this.m_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.CancelButton = this.m_cancel;
			this.ClientSize = new System.Drawing.Size(782, 489);
			this.ControlBox = false;
			this.Controls.Add(this.m_middlePanel);
			this.Controls.Add(this.m_topPanel);
			this.Controls.Add(this.m_bottomPanel);
			this.MinimumSize = new System.Drawing.Size(800, 400);
			this.Name = "FileGenerateConfirmationDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Warning!";
			this.m_bottomPanel.ResumeLayout(false);
			this.m_bottomPanel.PerformLayout();
			this.m_middlePanel.ResumeLayout(false);
			this.m_topPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button m_ok;
		private System.Windows.Forms.Button m_cancel;
		private System.Windows.Forms.RichTextBox m_instructions;
		private System.Windows.Forms.Panel m_bottomPanel;
		private System.Windows.Forms.Panel m_middlePanel;
		private System.Windows.Forms.Panel m_topPanel;
		private System.Windows.Forms.ListView m_timesheets;
		private System.Windows.Forms.ImageList m_imageList;
	}
}