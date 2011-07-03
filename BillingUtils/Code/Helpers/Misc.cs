using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace BillingUtils.Code.Helpers {

	internal class Misc {
		private static object m_syncRoot = new object();
		
		static public string DefaultErrorMessage { get { return "Information is required. Please enter the required information."; } }
				
		static public string ToString(char[] chars) {
			lock (m_syncRoot) {
				StringBuilder charArray = new StringBuilder();

				for (int i = 0; i < chars.Length; i++) {
					char c = chars[i];
					charArray.Append(c);
					if (i < chars.Length - 1) {
						charArray.Append(", ");
					}
				}

				return charArray.ToString();
			}
		}
	};
};
