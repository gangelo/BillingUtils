using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using Microsoft.Office.Tools.Excel;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace BillingUtils.Code.Generators {

	public abstract class ExcelGenerator {
		// Fields
		// --------------------------------------------------------------------------
		#region Fields
		public bool m_excelTemplateExists;
		private string m_excelTemplate;
		private string m_outputFolder;
		private string m_outputFileName;		
		private Excel.Workbook m_excelWorkBook;

		static private Excel.Application m_excelApplication;
		#endregion	// Fields

		// Construction/Initialization
		// --------------------------------------------------------------------------
		#region Construction/Initialization
		public ExcelGenerator(string excelTemplate, string outputFileName) {			
			if (!File.Exists(excelTemplate)) {
				throw new ArgumentException(string.Format("Excel template [{0}] does not exist.", excelTemplate));
			}

			try {
				try {
					this.OutputFolder = Path.GetDirectoryName(outputFileName);
					this.OutputFileName = Path.GetFileName(outputFileName);
				} catch (Exception e) {
					throw e;
				}
			} finally {
			}

			this.ExcelTemplate = excelTemplate;
		} 
		#endregion	// Construction/Initialization

		// Properties
		// --------------------------------------------------------------------------
		#region Properties
		protected virtual Excel.Workbook ExcelWorkbook {
			get { return m_excelWorkBook; }
			set { m_excelWorkBook = value; }
		}

		/// <summary>
		/// The template from which the output file will be based.
		/// </summary>
		public virtual string ExcelTemplate {
			get { return m_excelTemplate; }
			protected set { m_excelTemplate = value; }
		}

		/// <summary>
		/// The folder where the output file is to be created/copied.
		/// </summary>
		public virtual string OutputFolder {
			get { return m_outputFolder; }
			protected set { m_outputFolder = value; }
		}

		/// <summary>
		/// The name of the file to output.
		/// </summary>
		public virtual string OutputFileName {
			get { return m_outputFileName; }
			protected set { m_outputFileName = value; }
		}
		#endregion	// Properties

		public virtual string GetFullOutputFileName() {
			return Path.Combine(new string[] { this.OutputFolder, this.OutputFileName });
		}

		public virtual bool Generate(bool promptOnOverwrite) {
			string outputFileName = this.GetFullOutputFileName();

			if (promptOnOverwrite) {
				if (File.Exists(outputFileName)) {
					if (MessageBox.Show(string.Format("The output file [{0}] already exists. If you continue, this file will be overwritten. Do you want to overwrite this file?", Helpers.Paths.MinifyPath(outputFileName)),
						"Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
						return false;
					}
				}
			}

			File.Copy(this.ExcelTemplate, outputFileName, true);

			Excel.Application excelApplication = ExcelGenerator.GetExcelApplication(true);
			excelApplication.Visible = true;
			this.ExcelWorkbook = excelApplication.Workbooks.Open(
				outputFileName, 
				Type.Missing, // UpdateLinks 
				false,
				Type.Missing, // Format
				Type.Missing, // Password
				Type.Missing,	// WriteResPassword
				true, // IgnoreReadOnlyRecommented
				Type.Missing, // Origin
				Type.Missing,	// Delimited
				Type.Missing,	// Editable
				Type.Missing,	// Notify 
				Type.Missing, // Converter 
				Type.Missing, // AddToMru 
				Type.Missing, // Local
				Type.Missing // CorruptLoad
				);			
			
			return true;
		}

		protected abstract bool UpdateWorkbook();

		static protected Excel.Application GetExcelApplication() {
			return ExcelGenerator.GetExcelApplication(false);
		}

		static protected Excel.Application GetExcelApplication(bool createIfNotExist) {				
				if (createIfNotExist && m_excelApplication == null) {
					m_excelApplication = new Excel.Application();
				}
			
				return m_excelApplication;
		}

		public void Save() {
			if (this.ExcelWorkbook != null) {		
				this.ExcelWorkbook.Close(true);				
			}
			this.ExcelWorkbook = null;
		}

		static public void QuitExcel() {
			if (ExcelGenerator.m_excelApplication != null) {
				ExcelGenerator.m_excelApplication.Quit();
				// The below three lines make sure that the Excel Application instance
				// is removed from memory before this application closes.
				ExcelGenerator.m_excelApplication = null;				
			}

			GC.Collect();
			GC.WaitForPendingFinalizers();				
		}
		

		// Excel Events
		// --------------------------------------------------------------------------
		#region Excel Events
		//protected virtual void OnWorkbookBeforeClose(Excel.Workbook Workbook, ref bool cancel) {
		//   this.ExcelApplication = null;

		//   GC.Collect();
		//   GC.WaitForPendingFinalizers();
		//} 
		#endregion	// Excel Events
	};
};
