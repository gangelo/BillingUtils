using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace BillingUtils.Code.Helpers {

	internal class Paths {
		private static object m_syncRoot = new object();

		static public string MinifyPath(string path){
			lock (m_syncRoot) {
				if (string.IsNullOrEmpty(path)) {
					return string.Empty;
				} else {
					if (!Path.IsPathRooted(path)) {
						throw new Exception(string.Format("Path [{0}] must be rooted before calling this member.", path));
					}

					string minifiedPath = string.Empty;

					string pathRoot = Path.GetPathRoot(path);
					string directoryName = Path.GetDirectoryName(path).Replace(pathRoot, string.Empty);
					string fileName = Path.GetFileName(path);

					minifiedPath = pathRoot + Path.Combine(EllipsifyPath(directoryName)) + Path.DirectorySeparatorChar + fileName;

					return minifiedPath;
				}
			}
		}

		static private string[] EllipsifyPath(string directoryName) {
			lock (m_syncRoot) {
				string[] splitPath = directoryName.Split(Path.DirectorySeparatorChar);

				for (int i = 1 /* start at 1*/; i < splitPath.Length; i++) {
					splitPath[i] = "...";
				}

				return splitPath;
			}
		}
	};
};
