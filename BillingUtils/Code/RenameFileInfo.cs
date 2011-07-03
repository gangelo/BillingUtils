using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace BillingUtils.Code {
	
	public class RenameFileInfo {
		public string FromFullFileName { get; protected set; }
		public string ToFullFileName { get; protected set; }

		public string FromFileName { get; protected set; }
		public string ToFileName { get; protected set; }		

		public RenameFileInfo(string fromFullFileName, string toFullFileName) {
			this.FromFullFileName = fromFullFileName;
			this.ToFullFileName = toFullFileName;

			this.FromFileName = Path.GetFileName(fromFullFileName);
			this.ToFileName = Path.GetFileName(toFullFileName);
		}

		public string FromFilePath { get { return Path.GetDirectoryName(this.FromFullFileName); } }
		public string ToFilePath { get { return Path.GetDirectoryName(this.ToFullFileName); } }

		public bool AreFilePathsEqual { get { return this.FromFilePath.Equals(this.ToFilePath, StringComparison.OrdinalIgnoreCase); } }
		public bool AreFileNamesEqual { get { return this.FromFileName.Equals(this.ToFileName, StringComparison.OrdinalIgnoreCase); } }
		public bool AreFullFileNamesEqual { get { return this.FromFullFileName.Equals(this.ToFullFileName, StringComparison.OrdinalIgnoreCase); } }
	};
};
