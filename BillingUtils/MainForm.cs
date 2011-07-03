using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace BillingUtils {
	public partial class MainForm : Form, IMessageFilter {
		static public TimesheetYearlyOverviewForm TimesheetYearlyOverviewForm { get; protected set; }
		static public OptionsForm OptionsForm { get; protected set; }

		// P/Invoke declarations
		[DllImport("user32.dll")]
		private static extern IntPtr WindowFromPoint(Point point);

		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);  

		public MainForm() {
			InitializeComponent();
			Application.AddMessageFilter(this);
		}

		public bool PreFilterMessage(ref Message m) {
			if (m.Msg == 0x20a) {
				// WM_MOUSEWHEEL, find the control at screen position m.LParam
				Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
				IntPtr hWnd = WindowFromPoint(pos);
				if (hWnd != IntPtr.Zero && hWnd != m.HWnd && Control.FromHandle(hWnd) != null) {
					SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
					return true;
				}
			}
			return false;
		}

		private void OnTimesheetInvoiceRenameClick(object sender, EventArgs e) {
			RenameForm form = new RenameForm();
			form.MdiParent = this;
			form.Show();
		}

		private void OnTimesheetMakerClick(object sender, EventArgs e) {
			timesheetMakerToolStripMenuItem.Enabled = false;

			TimesheetMakerForm form = new TimesheetMakerForm();
			form.FormClosed += new FormClosedEventHandler(
					delegate(object _sender, FormClosedEventArgs _e) {
						timesheetMakerToolStripMenuItem.Enabled = true;
					});
			form.MdiParent = this;
			form.Show();
		}

		private void OnOptionsClick(object sender, EventArgs e) {
			if (MainForm.OptionsForm == null) {
				optionsToolStripMenuItem.Enabled = false;
				MainForm.OptionsForm = new OptionsForm();
				MainForm.OptionsForm.MdiParent = this;
				MainForm.OptionsForm.Show();

				MainForm.OptionsForm.FormClosed += new FormClosedEventHandler(
					delegate(object _sender, FormClosedEventArgs _e) {
						optionsToolStripMenuItem.Enabled = true;
						MainForm.OptionsForm.Dispose();
						MainForm.OptionsForm = null;
					});
			} else {
				MainForm.OptionsForm.Activate();
			}
		}

		private void OnViewFlexDaysClick(object sender, EventArgs e) {
			MessageBox.Show("This option is not available at this time.");
		}

		private void OnTimesheetYearlyOverviewClick(object sender, EventArgs e) {
			if (MainForm.TimesheetYearlyOverviewForm == null) {
				yearlyOverviewToolStripMenuItem.Enabled = false;
				MainForm.TimesheetYearlyOverviewForm = new TimesheetYearlyOverviewForm();
				MainForm.TimesheetYearlyOverviewForm.MdiParent = this;
				MainForm.TimesheetYearlyOverviewForm.Show();

				MainForm.TimesheetYearlyOverviewForm.FormClosed += new FormClosedEventHandler(
					delegate(object _sender, FormClosedEventArgs _e) {						
						yearlyOverviewToolStripMenuItem.Enabled = true;
						MainForm.TimesheetYearlyOverviewForm.Dispose();
						MainForm.TimesheetYearlyOverviewForm = null;
					});
			} else {
				MainForm.TimesheetYearlyOverviewForm.Activate();
			}
		}

		private void OnAboutClick(object sender, EventArgs e) {
			using (AboutBox form = new AboutBox()) {
				form.ShowDialog(this);
			}
		}
	};
};
