using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BillingUtils.Code.Configuration {

	public class PersonalConfiguration {
		static private object m_syncRoot = new object();

		private bool m_isDirty;

		private string m_name;
		private string m_address;

		public PersonalConfiguration() {
			this.IsDirty = false;
		}

		public PersonalConfiguration(string name, string address) {
			m_name = name;
			m_address = address;

			this.IsDirty = false;
		}


		public bool IsDirty {
			get { return m_isDirty; }
			set { m_isDirty = value; }
		}

		public string Name {
			get { return m_name; }
			set {
				if (!this.IsDirty && !m_name.Equals(value)) {
					this.IsDirty = true;
				}

				m_name = value;
			}
		}

		public string Address {
			get { return m_address; }
			set {
				if (!this.IsDirty && !m_address.Equals(value)) {
					this.IsDirty = true;
				}

				m_address = value;
			}
		}

		public XElement ToXml() {
			XElement configuration =
				new XElement("personalConfiguration",
					new XElement("name",	this.Name),
					new XElement("address",	this.Address)
				);
			return configuration;
		}

		static public PersonalConfiguration FromXml(XElement root) {
			lock (m_syncRoot) {
				string name = root.XPathSelectElement("./configuration/personalConfiguration/name").Value;
				string address = root.XPathSelectElement("./configuration/personalConfiguration/address").Value;

				return new PersonalConfiguration(name, address);
			}
		}
	};
};
