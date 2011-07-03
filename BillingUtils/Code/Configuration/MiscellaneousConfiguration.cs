using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BillingUtils.Code.Configuration {

	public class MiscellaneousConfiguration {
		static private object m_syncRoot = new object();

		private bool m_isDirty;

		private decimal m_defaultWorkDayHours;
		private decimal m_defaultMaxBillableHoursPerWorkDay;
		private string m_defaultSaveFolder;

		public MiscellaneousConfiguration() {
			this.IsDirty = false;
		}

		public MiscellaneousConfiguration(decimal defaultWorkDayHours, decimal defaultMaxBillableHoursPerWorkDay, string defaultSaveFolder) {
			m_defaultWorkDayHours = defaultWorkDayHours;
			m_defaultMaxBillableHoursPerWorkDay = defaultMaxBillableHoursPerWorkDay;
			m_defaultSaveFolder = defaultSaveFolder;

			this.IsDirty = false;
		}


		public bool IsDirty {
			get { return m_isDirty; }
			set { m_isDirty = value; }
		}

		public decimal DefaultWorkDayHours {
			get { return m_defaultWorkDayHours; }
			set {
				if (!this.IsDirty && m_defaultWorkDayHours != value) {
					this.IsDirty = true;
				}

				m_defaultWorkDayHours = value;
			}
		}

		public decimal DefaultMaxBillableHoursPerWorkDay {
			get { return m_defaultMaxBillableHoursPerWorkDay; }
			set {
				if (!this.IsDirty && m_defaultMaxBillableHoursPerWorkDay != value) {
					this.IsDirty = true;
				}

				m_defaultMaxBillableHoursPerWorkDay = value;
			}
		}

		public string DefaultSaveFolder {
			get { return m_defaultSaveFolder; }
			set {
				if (!this.IsDirty && !m_defaultSaveFolder.Equals(value, StringComparison.InvariantCultureIgnoreCase)) {
					this.IsDirty = true;
				}

				m_defaultSaveFolder = value;
			}
		}		

		public XElement ToXml() {
			XElement configuration =
				new XElement("miscellaneousConfiguration",
					new XElement("defaultWorkDayHours", this.DefaultWorkDayHours),
					new XElement("defaultMaxBillableHoursPerWorkDay", this.DefaultMaxBillableHoursPerWorkDay),		
					new XElement("defaultSaveFolder", this.DefaultSaveFolder)			
				);
			return configuration;
		}

		static public MiscellaneousConfiguration FromXml(XElement root) {
			lock (m_syncRoot) {
				decimal defaultWorkDayHours = Convert.ToDecimal(root.XPathSelectElement("./configuration/miscellaneousConfiguration/defaultWorkDayHours").Value);
				decimal defaultMaxBillableHoursPerWorkDay = Convert.ToDecimal(root.XPathSelectElement("./configuration/miscellaneousConfiguration/defaultMaxBillableHoursPerWorkDay").Value);				
				string defaultSaveFolder = root.XPathSelectElement("./configuration/miscellaneousConfiguration/defaultSaveFolder").Value;

				return new MiscellaneousConfiguration(defaultWorkDayHours, defaultMaxBillableHoursPerWorkDay, defaultSaveFolder);
			}
		}
	};
};

