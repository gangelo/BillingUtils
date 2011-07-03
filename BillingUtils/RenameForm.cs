using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using BillingUtils.Code;
using BillingUtils.Code.Helpers;

namespace BillingUtils {
	public partial class RenameForm : Form {
		static private string ClickToSet { get { return "[Click to Set]"; } }

		private bool RenameComplete { get; set; }

		public RenameForm() {
			InitializeComponent();

			InitializeForm();
			InitializeFromFolderControl();
			InitializeFromTokenToReplace();
			InitializeToToken();
			InitializeListView();

			// Rename sample...
			m_renameSample.Text = string.Empty;

			this.RenameComplete = false;			

			m_folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyDocuments;			
		}

		private void InitializeForm() {
			this.CausesValidation = false;
			
			this.AcceptButton = m_ok;
			this.CancelButton = m_cancel;

			m_ok.CausesValidation = false;
			m_cancel.CausesValidation = false;

			m_ok.Click += new EventHandler(this.OnOKClick);
			m_cancel.Click += new EventHandler(this.OnCancelClick);
		}

		private void InitializeFromFolderControl() {			
			m_fromFolder.LinkClicked += new LinkLabelLinkClickedEventHandler(
				delegate(object sender, LinkLabelLinkClickedEventArgs e) {
					this.OnRenameFromLinkClicked(sender, e);
					this.ValidateChildren();
				});
			m_fromFolder.Validating += new CancelEventHandler(
				delegate(object sender, CancelEventArgs e) {
					string fromFolder = Convert.ToString(m_fromFolder.Tag);
					if (string.IsNullOrEmpty(fromFolder) || fromFolder.Equals(RenameForm.ClickToSet, StringComparison.OrdinalIgnoreCase)) {
						m_errorProvider.SetError((Control)sender, Misc.DefaultErrorMessage);
						e.Cancel = true;
					} else if (!Directory.Exists(fromFolder)) {
						m_errorProvider.SetError((Control)sender, "\"Rename from\" folder does not exist. Choose another folder.");
						e.Cancel = true;
					} else if (m_fromTokenToReplace.Items.Count == 1) {
						m_errorProvider.SetError((Control)sender, "Files in \"Rename from\" do not contain any usable tokens. Choose another folder, or rename the files.");
						e.Cancel = true;
					} else {
						e.Cancel = false;
					}
				});
			m_fromFolder.Validated += new EventHandler(delegate(object sender, EventArgs e) {
				m_errorProvider.SetError((Control)sender, string.Empty);
			});
		}

		private void InitializeFromTokenToReplace() {
			ResetFromFolderComboBox();
			m_fromTokenToReplace.DropDownStyle = ComboBoxStyle.DropDownList;
			//m_fromTokenToReplace.SelectedIndexChanged += new EventHandler(this.OnFromSelectedIndexChanged);
			m_fromTokenToReplace.SelectedIndexChanged += new EventHandler(
				delegate(object sender, EventArgs e) {
					this.OnFromSelectedIndexChanged(sender, e);
					this.ValidateChildren();					
				});
			m_fromTokenToReplace.Validating += new CancelEventHandler(
				delegate(object sender, CancelEventArgs e) {
					string fromToken = m_fromTokenToReplace.Text;
					if (fromToken.Equals(WinFormControls.DefaultComboBoxSelect, StringComparison.OrdinalIgnoreCase)) {
					   m_errorProvider.SetError((Control)sender, Misc.DefaultErrorMessage);
					   e.Cancel = true;						
					} else {
					   e.Cancel = false;
					}
				});
			m_fromTokenToReplace.Validated += new EventHandler(delegate(object sender, EventArgs e) {
				m_errorProvider.SetError((Control)sender, string.Empty);
			});
		}

		private void InitializeToToken() {
			// Replace with...
			m_toToken.Enabled = false;
			m_toToken.TextChanged += new EventHandler(
				delegate(object sender, EventArgs args) {					
					ValidateChildren();
				});
			m_toToken.Validating += new CancelEventHandler(
				delegate(object sender, CancelEventArgs e) {
					ShowRenameSample(false);

					string fromToken = m_fromTokenToReplace.Text;
					string toToken = m_toToken.Text = m_toToken.Text.Trim();
					
					if (string.IsNullOrEmpty(toToken)) {
						m_errorProvider.SetError(m_toToken, Misc.DefaultErrorMessage);
						e.Cancel = true;
					} else if (toToken.Equals(fromToken, StringComparison.OrdinalIgnoreCase)) {
						m_errorProvider.SetError(m_toToken, "\"Replace with\" must be different from \"Token to Replace\"");
						e.Cancel = true;
					} else if (!IsValidFileName(toToken)) {
						m_errorProvider.SetError(m_toToken,
							string.Format("\"Replace with\" token cannot contain invalid characters {0}.", Misc.ToString(Path.GetInvalidFileNameChars())));
						e.Cancel = true;
					} else {
						e.Cancel = false;
					}
				});
			m_toToken.Validated += new EventHandler(delegate(object sender, EventArgs e) {
				m_errorProvider.SetError((Control)sender, string.Empty);
				ShowRenameSample(true);
			});
		}

		private void InitializeListView() {
			m_renameStatus.View = View.Details;
			m_renameStatus.GridLines = true;

			m_renameStatus.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			m_renameStatus.Columns.Add("renameStatus", "Status", 100);
			m_renameStatus.Columns.Add("fromFullFileName", "Renamed From", 150);
			m_renameStatus.Columns.Add("toFullFileName", "Renamed To", 150);			
		}

		private void ResetFromFolderComboBox() {
			m_fromTokenToReplace.Enabled = false;
			m_fromTokenToReplace.Items.Clear();
			m_fromTokenToReplace.SelectedIndex = m_fromTokenToReplace.Items.Add(WinFormControls.DefaultComboBoxSelect);
		}

		private bool GetFolder(out string selectedPath) {
			if (m_folderBrowserDialog.ShowDialog() == DialogResult.OK) {
				selectedPath = m_folderBrowserDialog.SelectedPath;
				return true;
			} else {
				selectedPath = string.Empty;
				return false;
			}
		}

		//static private string GetFolderName(string selectedPath) {
		//   return Path.GetFileName(selectedPath);
		//}

		private void ResizeListViewColumns() {
			m_renameStatus.Columns["renameStatus"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_renameStatus, "renameStatus"));
			m_renameStatus.Columns["fromFullFileName"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_renameStatus, "fromFullFileName"));
			m_renameStatus.Columns["toFullFileName"].AutoResize(WinFormControls.GetListViewAutoResizeStyle(m_renameStatus, "toFullFileName"));
		}

		/// <summary>
		/// This member displays a sample of what a file in the rename from 
		/// directory will look like renamed, based on the user input.
		/// </summary>
		/// <param name="show">If true, the sample is shown, otherwise, it is hidden.</param>
		private void ShowRenameSample(bool show) {
			m_renameSample.Text = string.Empty;

			string fromToken = m_fromTokenToReplace.Text;
			string toToken = m_toToken.Text.Trim();			

			if (show && !toToken.Equals(fromToken, StringComparison.CurrentCultureIgnoreCase)) {
				string fromPath = Convert.ToString(m_fromFolder.Tag);

				DirectoryInfo directoryInfo = new DirectoryInfo(fromPath);
				FileInfo[] files = directoryInfo.GetFiles();
				if (files.Count() > 0) {
					FileInfo file = files[0];

					RenameFileInfo renameFileInfo = GetRenameFileInfo(file);

					string fromFileName = renameFileInfo.FromFileName;
					string toFileName = renameFileInfo.ToFileName;					
					
					string renameSample = string.Format("Rename from {0} to {1}", fromFileName, toFileName);
					m_renameSample.Text = renameSample;

					// Bold the "From" and "To" file names so they stand out...
					Font boldFont = new Font(m_renameSample.Font, FontStyle.Bold);
					m_renameSample.Select(m_renameSample.Text.IndexOf(fromFileName), fromFileName.Length);
					m_renameSample.SelectionFont = boldFont;

					m_renameSample.Select(m_renameSample.Text.IndexOf(toFileName), toFileName.Length);
					m_renameSample.SelectionFont = boldFont;
				}				
			}
		}

		private bool IsValidFileName(string fileName) {
			return fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
		}

		private bool IsValidPath(string path) {
			return path.IndexOfAny(Path.GetInvalidPathChars()) < 0;
		}

		private RenameFileInfo GetRenameFileInfo(FileInfo fromFileInfo) {
			string from = m_fromTokenToReplace.Text;
			string to = m_toToken.Text.Trim();

			string fromFullFileName = fromFileInfo.FullName;
			string toFullFileName = Path.Combine(new string[] { Path.GetDirectoryName(fromFullFileName), Path.GetFileName(fromFullFileName.Replace(from, to)) });

			return new RenameFileInfo(fromFullFileName, toFullFileName);
		}

		private bool DoRename(out int renamedCount) {
			renamedCount = 0;

			try {
				try {
					string fromPath = Convert.ToString(m_fromFolder.Tag);
					
					DirectoryInfo directoryInfo = new DirectoryInfo(fromPath);
					foreach (FileInfo file in directoryInfo.GetFiles()) {
						RenameFileInfo renameFileInfo = GetRenameFileInfo(file);

						string fromFullFileName = renameFileInfo.FromFullFileName;
						string toFullFileName = renameFileInfo.ToFullFileName;

						File.Move(fromFullFileName, toFullFileName);

						ListViewItem listViewItem = m_renameStatus.Items.Add("OK");
						listViewItem.ToolTipText = string.Format("Copied [{0}] to [{1}]", fromFullFileName, toFullFileName);

						listViewItem.SubItems.Add(Path.GetFileName(fromFullFileName));
						listViewItem.SubItems.Add(Path.GetFileName(toFullFileName));

						++renamedCount;
					}

					ResizeListViewColumns();

					this.RenameComplete = true;

					return true;
				} catch (Exception e) {
					MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			} finally {
			}

			return false;
		}

		private void OnFromSelectedIndexChanged(object sender, EventArgs args) {
			if (m_fromTokenToReplace.SelectedIndex == 0) {
				// If the default ("--- Select ---") is selected, disable the "rename to"
				// textbox and blank out the text...
				m_toToken.Enabled = false;
				m_toToken.Text = string.Empty;
			} else {
				// If any value other than the default ("--- Select ---") is selected,
				// enable the "rename to" textbox and prepopulate the value with what the 
				// user chose so the user can easily make changes - saves some typing...
				m_toToken.Enabled = true;
				m_toToken.Text = m_fromTokenToReplace.Text;
			}
		}

		private void OnRenameFromLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			ResetFromFolderComboBox();

			m_folderBrowserDialog.ShowNewFolderButton = false;
			m_folderBrowserDialog.Description = "Choose \"Rename From\" Location";

			string selectedPath;
			if (this.GetFolder(out selectedPath)) {
				m_fromFolder.Tag = selectedPath;
				m_fromFolder.Text = Paths.MinifyPath(selectedPath);
				m_toolTip.SetToolTip(m_fromFolder, "Rename from " + selectedPath);				

				// The below processing scans the files in the the "rename from" folder and determines what
				// tokens in each file name are common to each file. These tokens are assumed to be changable by 
				// user without disturbing the uniqueness of the file name. Tokens considered "changable" MUST
				// be common to every file name found in the folder...
				Dictionary<string, int> tokens = new Dictionary<string, int>();
				DirectoryInfo directoryInfo = new DirectoryInfo(selectedPath);
				FileInfo[] files = directoryInfo.GetFiles();
				int fileCount = files.Count();
				foreach (FileInfo file in files) {
					string[] splitFileName = Path.GetFileName(file.FullName).Split(new string[] { " ", "." }, StringSplitOptions.RemoveEmptyEntries);
					foreach (string part in splitFileName) {
						if (tokens.ContainsKey(part)) {
							++tokens[part];
						} else {
							tokens.Add(part, 1);
						}
					}
				}

				if (tokens.Count > 0) {
					foreach (KeyValuePair<string, int> item in tokens.Where(p => p.Value == fileCount)) {
						m_fromTokenToReplace.Items.Add(item.Key);
					}

					m_fromTokenToReplace.Enabled = true;
				}
			}
		}

		private void OnRenameToLinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			m_folderBrowserDialog.ShowNewFolderButton = true;
			m_folderBrowserDialog.Description = "Choose \"Rename To\" Location";

			string selectedPath;
			if (this.GetFolder(out selectedPath)) {
				m_toToken.Tag = selectedPath;
				m_toToken.Text = Paths.MinifyPath(selectedPath);
				m_toolTip.SetToolTip(m_toToken, "Replace with " + selectedPath);
			}
		}

		private void OnOKClick(object sender, EventArgs e) {			
			if (this.ValidateChildren()){			
				int renamedCount;
				if (this.DoRename(out renamedCount)) {
					m_ok.Enabled = false;

					MessageBox.Show(string.Format("{0} files renamed. Click \"Cancel\" to close this Dialog.", renamedCount), "Success",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}

		private void OnCancelClick(object sender, EventArgs e) {
			this.Close();
		}

		protected override void OnClosing(CancelEventArgs e) {
			if (!this.RenameComplete) {				
				// If the rename operation has NOT been completed, display a confirmation box.
				e.Cancel = MessageBox.Show("Cancel rename operation? Are you sure?", "Attention",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
			}
		}
	};
};
