using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BillingUtils.Code {
	
	internal class DefaultImageList {
		static private ImageList m_imageList;
		static private DefaultImageList m_instance;

		protected DefaultImageList() {
		}

		static DefaultImageList() {
			m_imageList = new ImageList();
			m_instance = new DefaultImageList();

			m_imageList.Images.Add("Clear", Properties.Resources.Clear);
			m_imageList.Images.Add("Root", Properties.Resources.Root);			
			m_imageList.Images.Add("Calendar", Properties.Resources.Calendar);
			m_imageList.Images.Add("Property", Properties.Resources.Property);
			m_imageList.Images.Add("Pencil", Properties.Resources.Pencil);
			m_imageList.Images.Add("Locked", Properties.Resources.Locked);		
		}

		static public DefaultImageList Instance {
			get { return m_instance; }
		}

		public ImageList ImageList {
			get { return m_imageList; }
		}

		public int GetClearIconIndex() {
			return m_imageList.Images.IndexOfKey("Clear");
		}

		public int GetRootIconIndex() {
			return m_imageList.Images.IndexOfKey("Root");
		}

		public int GetCalendarIconIndex() {
			return m_imageList.Images.IndexOfKey("Calendar");			
		}

		public int GetPropertyIconIndex() {
			return m_imageList.Images.IndexOfKey("Property");
		}

		public int GetPencilIconIndex() {
			return m_imageList.Images.IndexOfKey("Pencil");
		}

		public int GetLockedIconIndex() {
			return m_imageList.Images.IndexOfKey("Locked");
		}
	};
};
