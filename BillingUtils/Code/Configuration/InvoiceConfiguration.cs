using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BillingUtils.Code.Configuration {

	public class InvoiceConfiguration {
		static private object m_syncRoot = new object();

		private bool m_isDirty;

		private string m_invoiceTemplate;
		private string m_nameCell;
		private string m_addressCell;
				
		private string m_currentInvoiceNumberCell;

		private string m_qtyStartCell;
		
		private string m_description;
		private string m_descriptionStartCell;
		
		private int m_PONumber;
		private string m_PONumberStartCell;

		//private decimal m_rate;
		private string m_rateStartCell;

		public InvoiceConfiguration() {
			this.IsDirty = false;
		}

		public InvoiceConfiguration(
			string invoiceTemplate,
			string nameCell,
			string addressCell,			
			string currentInvoiceNumberCell,
			string qtyStartCell,
			string description,
			string descriptionStartCell,			
			int PONumber,
			string PONumberStartCell,
			//decimal rate,
			string rateStartCell) {
			m_invoiceTemplate = invoiceTemplate;
			m_nameCell = nameCell;
			m_addressCell = addressCell;			
			m_currentInvoiceNumberCell = currentInvoiceNumberCell;
			m_qtyStartCell = qtyStartCell;
			m_description = description;
			m_descriptionStartCell = descriptionStartCell;
			m_PONumber = PONumber;
			m_PONumberStartCell = PONumberStartCell;
			//m_rate = rate;
			m_rateStartCell = rateStartCell;
			
			this.IsDirty = false;
		}

		public bool IsDirty {
			get { return m_isDirty; }
			set { m_isDirty = value; }
		}

		public string InvoiceTemplate {
			get { return m_invoiceTemplate; }
			set {
				if (!this.IsDirty && !m_invoiceTemplate.Equals(value)) {
					this.IsDirty = true;
				}

				m_invoiceTemplate = value;
			}
		}

		public string NameCell {
			get { return m_nameCell; }
			set {
				if (!this.IsDirty && !m_nameCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_nameCell = value;
			}
		}

		public string AddressCell {
			get { return m_addressCell; }
			set {
				if (!this.IsDirty && !m_addressCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_addressCell = value;
			}
		}		

		public string CurrentInvoiceNumberCell {
			get { return m_currentInvoiceNumberCell; }
			set {
				if (!this.IsDirty && !m_currentInvoiceNumberCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_currentInvoiceNumberCell = value;
			}
		}

		public string QtyStartCell {
			get { return m_qtyStartCell; }
			set {
				if (!this.IsDirty && !m_qtyStartCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_qtyStartCell = value;
			}
		}

		public string Description {
			get { return m_description; }
			set {
				if (!this.IsDirty && !m_description.Equals(value)) {
					this.IsDirty = true;
				}

				m_description = value;
			}
		}

		public string DescriptionStartCell {
			get { return m_descriptionStartCell; }
			set {
				if (!this.IsDirty && !m_descriptionStartCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_descriptionStartCell = value;
			}
		}		

		public int PONumber {
			get { return m_PONumber; }
			set {
				if (!this.IsDirty && m_PONumber != value) {
					this.IsDirty = true;
				}

				m_PONumber = value;
			}
		}

		public string PONumberStartCell {
			get { return m_PONumberStartCell; }
			set {
				if (!this.IsDirty && !m_PONumberStartCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_PONumberStartCell = value;
			}
		}

		//public decimal Rate {
		//   get { return m_rate; }
		//   set {
		//      if (!this.IsDirty && m_rate != value) {
		//         this.IsDirty = true;
		//      }

		//      m_rate = value;
		//   }
		//}

		public string RateStartCell {
			get { return m_rateStartCell; }
			set {
				if (!this.IsDirty && !m_rateStartCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_rateStartCell = value;
			}
		}

		public XElement ToXml() {
			XElement configuration =
				new XElement("invoiceConfiguration",
					new XElement("invoiceTemplate", this.InvoiceTemplate),
					new XElement("nameCell", this.NameCell),
					new XElement("addressCell", this.AddressCell),					
					new XElement("currentInvoiceNumberCell", this.CurrentInvoiceNumberCell),
					new XElement("qtyStartCell", this.QtyStartCell),
					new XElement("description", this.Description),
					new XElement("descriptionStartCell", this.DescriptionStartCell),
					new XElement("PONumber", this.PONumber),
					new XElement("PONumberStartCell", this.PONumberStartCell),
					//new XElement("rate", this.Rate),
					new XElement("rateStartCell", this.RateStartCell)
				);
			return configuration;
		}

		static public InvoiceConfiguration FromXml(XElement root) {
			lock (m_syncRoot) {
				string invoiceTemplate = root.XPathSelectElement("./configuration/invoiceConfiguration/invoiceTemplate").Value;
				string nameCell = root.XPathSelectElement("./configuration/invoiceConfiguration/nameCell").Value;
				string addressCell = root.XPathSelectElement("./configuration/invoiceConfiguration/addressCell").Value;				
				string currentInvoiceNumberCell = root.XPathSelectElement("./configuration/invoiceConfiguration/currentInvoiceNumberCell").Value;
				string qtyStartCell = root.XPathSelectElement("./configuration/invoiceConfiguration/qtyStartCell").Value;
				string description = root.XPathSelectElement("./configuration/invoiceConfiguration/description").Value;
				string descriptionStartCell = root.XPathSelectElement("./configuration/invoiceConfiguration/descriptionStartCell").Value;
				int PONumber = Convert.ToInt32(root.XPathSelectElement("./configuration/invoiceConfiguration/PONumber").Value);
				string PONumberStartCell = root.XPathSelectElement("./configuration/invoiceConfiguration/PONumberStartCell").Value;
				//decimal rate = Convert.ToDecimal(root.XPathSelectElement("./configuration/invoiceConfiguration/rate").Value);
				string rateStartCell = root.XPathSelectElement("./configuration/invoiceConfiguration/rateStartCell").Value;

				return new InvoiceConfiguration(
					invoiceTemplate,
					nameCell,
					addressCell,					
					currentInvoiceNumberCell,
					qtyStartCell,
					description,
					descriptionStartCell,	
					PONumber,
					PONumberStartCell,
					//rate,
					rateStartCell);
			}
		}
	};
};
