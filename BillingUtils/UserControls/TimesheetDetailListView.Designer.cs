namespace BillingUtils.UserControls {
	partial class TimesheetDetailListView {
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
			this.m_listView = new System.Windows.Forms.ListView();
			this.m_header = new System.Windows.Forms.Label();
			this.m_headerContainer = new System.Windows.Forms.Panel();
			this.m_mainContainer = new System.Windows.Forms.Panel();
			this.m_headerContainer.SuspendLayout();
			this.m_mainContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_listView
			// 
			this.m_listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_listView.Location = new System.Drawing.Point(8, 2);
			this.m_listView.MinimumSize = new System.Drawing.Size(25, 25);
			this.m_listView.Name = "m_listView";
			this.m_listView.Size = new System.Drawing.Size(627, 212);
			this.m_listView.TabIndex = 1;
			this.m_listView.UseCompatibleStateImageBehavior = false;
			// 
			// m_header
			// 
			this.m_header.AutoSize = true;
			this.m_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_header.Location = new System.Drawing.Point(3, 5);
			this.m_header.Name = "m_header";
			this.m_header.Size = new System.Drawing.Size(71, 17);
			this.m_header.TabIndex = 0;
			this.m_header.Text = "[Header]";
			// 
			// m_headerContainer
			// 
			this.m_headerContainer.AutoSize = true;
			this.m_headerContainer.Controls.Add(this.m_header);
			this.m_headerContainer.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_headerContainer.Location = new System.Drawing.Point(5, 5);
			this.m_headerContainer.Name = "m_headerContainer";
			this.m_headerContainer.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
			this.m_headerContainer.Size = new System.Drawing.Size(643, 27);
			this.m_headerContainer.TabIndex = 2;
			// 
			// m_mainContainer
			// 
			this.m_mainContainer.Controls.Add(this.m_listView);
			this.m_mainContainer.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_mainContainer.Location = new System.Drawing.Point(5, 32);
			this.m_mainContainer.Name = "m_mainContainer";
			this.m_mainContainer.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
			this.m_mainContainer.Size = new System.Drawing.Size(643, 216);
			this.m_mainContainer.TabIndex = 3;
			// 
			// TimesheetDetailListView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_mainContainer);
			this.Controls.Add(this.m_headerContainer);
			this.MinimumSize = new System.Drawing.Size(150, 50);
			this.Name = "TimesheetDetailListView";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Size = new System.Drawing.Size(653, 249);
			this.m_headerContainer.ResumeLayout(false);
			this.m_headerContainer.PerformLayout();
			this.m_mainContainer.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView m_listView;
		private System.Windows.Forms.Label m_header;
		private System.Windows.Forms.Panel m_headerContainer;
		private System.Windows.Forms.Panel m_mainContainer;
	}
}
