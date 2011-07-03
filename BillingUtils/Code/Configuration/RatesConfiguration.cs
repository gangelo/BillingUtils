using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

using BillingUtils.Code;
using BillingUtils.Code.Helpers;

namespace BillingUtils.Code.Configuration {

	public class RatesConfiguration {
		static private object m_syncRoot = new object();

		private bool m_isDirty;

		private SortedDictionary<DateTime, Rate> m_rates;
		
		public RatesConfiguration() {
			this.IsDirty = false;			
		}

		public RatesConfiguration(IEnumerable<Rate> rates) {
			m_rates = new SortedDictionary<DateTime, Rate>();

			foreach (Rate rate in rates) {
				m_rates.Add(rate.EffectiveDate, rate);
			}

			this.IsDirty = false;
		}

		public bool IsDirty {
			get { return m_isDirty; }
			set { m_isDirty = value; }
		}

		public IEnumerable<Rate> Rates {
			get { 
				Collection<Rate> rates = new Collection<Rate>();

				foreach (Rate rate in m_rates.Values) {
					rates.Add(rate);
				}

				return rates;
			}
		}

		public XElement ToXml() {
			XElement configuration = new XElement("rates");

			foreach (KeyValuePair<DateTime, Rate> keyValuePair in m_rates) {
				configuration.Add(
					new XElement("rate", 
						new XAttribute("effectiveDate", Dates.GetYYYYMMDD(keyValuePair.Value.EffectiveDate)),
						new XAttribute("amount", keyValuePair.Value.Amount)
					));
			}

			return configuration;
		}

		static public RatesConfiguration FromXml(XElement root) {
			lock (m_syncRoot) {
				Collection<Rate> rates = new Collection<Rate>();

				foreach (XElement type in root.XPathSelectElements("./configuration/rates/rate")) {
					DateTime effectiveDate = Convert.ToDateTime(type.Attribute("effectiveDate").Value);
					decimal rate = Convert.ToDecimal(type.Attribute("amount").Value);
					rates.Add(new Rate(rate, effectiveDate));
				}

				return new RatesConfiguration(rates);
			}
		}
	};
};
