using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

using BillingUtils.Code;

namespace BillingUtils.Code.Configuration {

	public class DayTypeConfiguration {
		static private object m_syncRoot = new object();

		private bool m_isDirty;

		private SortedDictionary<string, DayType> m_dayTypes;
		
		public DayTypeConfiguration() {
			this.IsDirty = false;			
		}

		public DayTypeConfiguration(Collection<DayType> dayTypes) {
			m_dayTypes = new SortedDictionary<string, DayType>();

			foreach (DayType dayType in dayTypes) {
				m_dayTypes.Add(dayType.Name, dayType);
			}

			this.IsDirty = false;
		}

		public bool IsDirty {
			get { return m_isDirty; }
			set { m_isDirty = value; }
		}

		public Collection<DayType> DayTypes {
			get { 
				Collection<DayType> dayTypes = new Collection<DayType>();

				foreach (DayType dayType in m_dayTypes.Values) {
					dayTypes.Add(dayType);
				}

				return dayTypes;
			}
		}

		public XElement ToXml() {
			XElement configuration = new XElement("dayTypes");

			foreach (KeyValuePair<string, DayType> keyValuePair in m_dayTypes) {
				configuration.Add(
					new XElement("type", 
						new XElement("name", keyValuePair.Value.Name),
						new XElement("description", keyValuePair.Value.Description)
					));
			}

			return configuration;
		}

		static public DayTypeConfiguration FromXml(XElement root) {
			lock (m_syncRoot) {
				Collection<DayType> dayTypes = new Collection<DayType>();

				foreach (XElement type in root.XPathSelectElements("./configuration/dayTypes/type")) {
					string name = type.XPathSelectElement("name").Value;
					string description = type.XPathSelectElement("description").Value;
					dayTypes.Add(new DayType(name, description));
				}

				return new DayTypeConfiguration(dayTypes);
			}
		}
	};
};
