using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BillingUtils.Code.Configuration {
	
	public class TimesheetConfiguration {
		static private object m_syncRoot = new object();

		private bool m_isDirty;

		private string m_timesheetTemplate;		
		private string m_nameCell;
		private string m_startDateCell;

		private string m_projectDescription;
		private string m_projectDescriptionCell;

		private string m_mondayHourCell;
		private string m_tuesdayHourCell;
		private string m_wednesdayHourCell;
		private string m_thursdayHourCell;
		private string m_fridayHourCell;
		private string m_saturdayHourCell;
		private string m_sundayHourCell;

		private string m_notesAndRemarksCell;

		public TimesheetConfiguration() {
			this.IsDirty = false;
		}

		public TimesheetConfiguration(
			string timesheetTemplate,
			string nameCell,
			string startDateCell,
			string projectDescription,
			string projectDescriptionCell,
			string mondayHourCell,
			string tuesdayHourCell,
			string wednesdayHourCell,
			string thursdayHourCell,
			string fridayHourCell,
			string saturdayHourCell,
			string sundayHourCell,
			string notesAndRemarksCell) {
			m_timesheetTemplate = timesheetTemplate;
			m_nameCell = nameCell;
			m_startDateCell = startDateCell;
			m_projectDescription = projectDescription;
			m_projectDescriptionCell = projectDescriptionCell;
			m_mondayHourCell = mondayHourCell;
			m_tuesdayHourCell = tuesdayHourCell;
			m_wednesdayHourCell = wednesdayHourCell;
			m_thursdayHourCell = thursdayHourCell;
			m_fridayHourCell = fridayHourCell;
			m_saturdayHourCell = saturdayHourCell;
			m_sundayHourCell = sundayHourCell;
			m_notesAndRemarksCell = notesAndRemarksCell;

			this.IsDirty = false;
		}	

		public bool IsDirty {
			get { return m_isDirty; }
			set { m_isDirty = value; }			
		}

		public string TimesheetTemplate {
			get { return m_timesheetTemplate; }
			set {
				if (!this.IsDirty && !m_timesheetTemplate.Equals(value)) {
					this.IsDirty = true;
				}

				m_timesheetTemplate = value;
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

		public string StartDateCell {
			get { return m_startDateCell; }
			set {
				if (!this.IsDirty && !m_startDateCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_startDateCell = value;
			}
		}

		public string ProjectDescription {
			get { return m_projectDescription; }
			set {
				if (!this.IsDirty && !m_projectDescription.Equals(value)) {
					this.IsDirty = true;
				}

				m_projectDescription = value;
			}
		}

		public string ProjectDescriptionCell {
			get { return m_projectDescriptionCell; }
			set {
				if (!this.IsDirty && !m_projectDescriptionCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_projectDescriptionCell = value;
			}
		}

		public string MondayHourCell {
			get { return m_mondayHourCell; }
			set {
				if (!this.IsDirty && !m_mondayHourCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_mondayHourCell = value;
			}
		}

		public string TuesdayHourCell {
			get { return m_tuesdayHourCell; }
			set {
				if (!this.IsDirty && !m_tuesdayHourCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_tuesdayHourCell = value;
			}
		}

		public string WednesdayHourCell {
			get { return m_wednesdayHourCell; }
			set {
				if (!this.IsDirty && !m_wednesdayHourCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_wednesdayHourCell = value;
			}
		}

		public string ThursdayHourCell {
			get { return m_thursdayHourCell; }
			set {
				if (!this.IsDirty && !m_thursdayHourCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_thursdayHourCell = value;
			}
		}

		public string FridayHourCell {
			get { return m_fridayHourCell; }
			set {
				if (!this.IsDirty && !m_fridayHourCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_fridayHourCell = value;
			}
		}

		public string SaturdayHourCell {
			get { return m_saturdayHourCell; }
			set {
				if (!this.IsDirty && !m_saturdayHourCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_saturdayHourCell = value;
			}
		}

		public string SundayHourCell {
			get { return m_sundayHourCell; }
			set {
				if (!this.IsDirty && !m_sundayHourCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_sundayHourCell = value;
			}
		}

		public string NotesAndRemarksCell {
			get { return m_notesAndRemarksCell; }
			set {
				if (!this.IsDirty && !m_notesAndRemarksCell.Equals(value)) {
					this.IsDirty = true;
				}

				m_notesAndRemarksCell = value;
			}
		}

		public XElement ToXml() {
			XElement configuration =
				new XElement("timesheetConfiguration",
					new XElement("timesheetTemplate", this.TimesheetTemplate),
					new XElement("nameCell", this.NameCell),
					new XElement("startDateCell", this.StartDateCell),
					new XElement("projectDescription", this.ProjectDescription),
					new XElement("projectDescriptionCell", this.ProjectDescriptionCell),
					new XElement("mondayHourCell", this.MondayHourCell),
					new XElement("tuesdayHourCell", this.TuesdayHourCell),
					new XElement("wednesdayHourCell", this.WednesdayHourCell),
					new XElement("thursdayHourCell", this.ThursdayHourCell),
					new XElement("fridayHourCell", this.FridayHourCell),
					new XElement("saturdayHourCell", this.SaturdayHourCell),
					new XElement("sundayHourCell", this.SundayHourCell),
					new XElement("notesAndRemarksCell", this.NotesAndRemarksCell)
				);
			return configuration;
		}

		static public TimesheetConfiguration FromXml(XElement root) {
			lock (m_syncRoot) {
				string timesheetTemplate = root.XPathSelectElement("./configuration/timesheetConfiguration/timesheetTemplate").Value;
				string nameCell = root.XPathSelectElement("./configuration/timesheetConfiguration/nameCell").Value;
				string startDateCell = root.XPathSelectElement("./configuration/timesheetConfiguration/startDateCell").Value;
				string projectDescription = root.XPathSelectElement("./configuration/timesheetConfiguration/projectDescription").Value;
				string projectDescriptionCell = root.XPathSelectElement("./configuration/timesheetConfiguration/projectDescriptionCell").Value;
				string mondayHourCell = root.XPathSelectElement("./configuration/timesheetConfiguration/mondayHourCell").Value;
				string tuesdayHourCell = root.XPathSelectElement("./configuration/timesheetConfiguration/tuesdayHourCell").Value;
				string wednesdayHourCell = root.XPathSelectElement("./configuration/timesheetConfiguration/wednesdayHourCell").Value;
				string thursdayHourCell = root.XPathSelectElement("./configuration/timesheetConfiguration/thursdayHourCell").Value;
				string fridayHourCell = root.XPathSelectElement("./configuration/timesheetConfiguration/fridayHourCell").Value;
				string saturdayHourCell = root.XPathSelectElement("./configuration/timesheetConfiguration/saturdayHourCell").Value;
				string sundayHourCell = root.XPathSelectElement("./configuration/timesheetConfiguration/sundayHourCell").Value;
				string notesAndRemarksCell = root.XPathSelectElement("./configuration/timesheetConfiguration/notesAndRemarksCell").Value;

				return new TimesheetConfiguration(
					timesheetTemplate,
					nameCell,
					startDateCell,
					projectDescription,
					projectDescriptionCell,
					mondayHourCell,
					tuesdayHourCell,
					wednesdayHourCell,
					thursdayHourCell,
					fridayHourCell,
					saturdayHourCell,
					sundayHourCell,
					notesAndRemarksCell);
			}
		}
	};
};
