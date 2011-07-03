using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BillingUtils.Code.Configuration {

	public class Configuration {
		// Fields
		// --------------------------------------------------------------------------
		#region Fields
		static private readonly object m_syncRoot = new object();
		static private readonly Configuration m_instance;

		private bool m_isDirty;

		private PersonalConfiguration m_personalConfiguration;
		private MiscellaneousConfiguration m_miscellaneousConfiguration;
		private TimesheetConfiguration m_timesheetConfiguration;
		private InvoiceConfiguration m_invoiceConfiguration;
		private DayTypeConfiguration m_dayTypeConfiguration;
		private RatesConfiguration m_ratesConfiguration;

		private string m_applicationDataFolder;
		#endregion	// Fields

		// Constructors
		// --------------------------------------------------------------------------
		#region Constructors
		static Configuration() {
			m_instance = new Configuration();
		}

		protected Configuration() {
			this.ApplicationDataFolder = "Billing Utilities";
			
			// Create the user data folder for the first time if it does not exist.
			if (!Directory.Exists(this.UserDataFolder)) {
				Directory.CreateDirectory(this.UserDataFolder);
			}

			// Create the user test data folder for the first time if it does not exist.
			if (!Directory.Exists(this.UserTestDataFolder)) {
				Directory.CreateDirectory(this.UserTestDataFolder);
			}

			this.PersonalConfiguration = new PersonalConfiguration("[Name Here]", "[Address Here]");
			this.MiscellaneousConfiguration = new MiscellaneousConfiguration(9.0m, 8.0m, this.UserDataFolder);

			this.TimesheetConfiguration = new TimesheetConfiguration(this.UserDataFolder + "\\TimesheetTemplate.xlsx",
				"E10", "E17", "[Project Description Here]", "D22", "J22", "K22", "L22", "M22", "N22", "O22", "P22", "D43");

			this.InvoiceConfiguration = new InvoiceConfiguration(this.UserDataFolder + "\\InvoiceTemplate.xlsx",
				"B3", "B4", "I4", "B15", "[Description Here]", "C15", 1, "G15", /* 1.00m,*/ "H15");

			Collection<DayType> dayTypes = new Collection<DayType>();
			dayTypes.Add(new DayType(DayType.ExecutiveOrderName, "Used to designate a Federal Holidays"));
			dayTypes.Add(new DayType(DayType.FlexDayName, "Used to designate a Flex Day (usually every other Friday)"));
			dayTypes.Add(new DayType(DayType.HalfDayName, "Used to designate a half day of work"));
			dayTypes.Add(new DayType(DayType.OtherName, "Used to designate a day that fits in to no other Day Type"));
			dayTypes.Add(new DayType(DayType.PersonalDayName, "Used to designate a day taken off other than vacation or due to sickness"));
			dayTypes.Add(new DayType(DayType.SickDayName, "Used to designate a day taken off due to sickness"));
			dayTypes.Add(new DayType(DayType.VacationDayName, "Used to designate a day take as vacation"));
			dayTypes.Add(new DayType(DayType.WorkDayName, "Used to designate a normal work day"));
			dayTypes.Add(new DayType(DayType.WeekendName, "Saturday or Sunday"));

			this.DayTypeConfiguration = new DayTypeConfiguration(dayTypes);

			Collection<Rate> rates = new Collection<Rate>();
			rates.Add(new Rate(0, new DateTime(1900, 1, 1)));
			rates.Add(new Rate(81, new DateTime(2009, 1, 1)));
			rates.Add(new Rate(85, new DateTime(2010, 12, 26)));
			this.RatesConfiguration = new RatesConfiguration(rates);

			if (!File.Exists(this.ConfigurationFile)) {
				CreateConfigurationFile();
			}
			
			LoadConfigurationFile();
		}
		#endregion	// Constructors

		static public Configuration Instance {
			get {
				lock (m_syncRoot) {
					if (m_instance == null) {
						throw new InvalidOperationException("Singleton instance object is null.");
					} else {
						return m_instance;
					}
				}
			}
		}

		// Properties
		// --------------------------------------------------------------------------
		#region Properties
		/// <summary>
		/// Determines if the configuration has changeed. If the configuration has changed
		/// it should be either saved or the changes discarded.
		/// </summary>
		public virtual bool IsDirty {
			get {
				if (this.PersonalConfiguration == null ||
					this.MiscellaneousConfiguration == null ||
					this.TimesheetConfiguration == null ||
					this.InvoiceConfiguration == null ||
					this.DayTypeConfiguration == null ||
					this.RatesConfiguration == null) {
					throw new InvalidOperationException("Property IsDirty was called while not properly instantiated.");
				} else {
					return m_isDirty ||
						this.PersonalConfiguration.IsDirty ||
						this.MiscellaneousConfiguration.IsDirty ||
						this.TimesheetConfiguration.IsDirty ||
						this.InvoiceConfiguration.IsDirty ||
						this.DayTypeConfiguration.IsDirty ||
						this.RatesConfiguration.IsDirty;
				}
			}
			protected set { m_isDirty = value; }
		}

		public virtual PersonalConfiguration PersonalConfiguration {
			get { return m_personalConfiguration; }
			protected set { m_personalConfiguration = value; }
		}

		public virtual MiscellaneousConfiguration MiscellaneousConfiguration {
			get { return m_miscellaneousConfiguration; }
			protected set { m_miscellaneousConfiguration = value; }
		}

		public virtual TimesheetConfiguration TimesheetConfiguration {
			get { return m_timesheetConfiguration; }
			protected set { m_timesheetConfiguration = value; }
		}

		public virtual InvoiceConfiguration InvoiceConfiguration {
			get { return m_invoiceConfiguration; }
			protected set { m_invoiceConfiguration = value; }
		}

		public virtual DayTypeConfiguration DayTypeConfiguration {
			get { return m_dayTypeConfiguration; }
			protected set { m_dayTypeConfiguration = value; }
		}

		public virtual RatesConfiguration RatesConfiguration {
			get { return m_ratesConfiguration; }
			protected set { m_ratesConfiguration = value; }
		}	

		protected virtual string ApplicationDataFolder {
			get { return m_applicationDataFolder; }
			set { m_applicationDataFolder = value; }
		}

		public string UserDataFolder {
			get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + this.ApplicationDataFolder; }
		}

		public string UserBackupDataFolder {
			get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + this.ApplicationDataFolder + @"\Backup"; }
		}

		public string UserTestDataFolder {
			get { return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + this.ApplicationDataFolder + @"\TestData"; }
		}

		public string ConfigurationFile {
			get { return this.UserDataFolder + @"\" + "Application.xml"; }
		}
		#endregion	// Properties

		// Methods
		// --------------------------------------------------------------------------
		#region Methods
		protected virtual void LoadConfigurationFile() {
			XElement root = XElement.Load(this.ConfigurationFile);

			this.PersonalConfiguration = PersonalConfiguration.FromXml(root);
			this.MiscellaneousConfiguration = MiscellaneousConfiguration.FromXml(root);
			this.TimesheetConfiguration = TimesheetConfiguration.FromXml(root);
			this.InvoiceConfiguration = InvoiceConfiguration.FromXml(root);
			this.RatesConfiguration = RatesConfiguration.FromXml(root);
			this.DayTypeConfiguration = DayTypeConfiguration.FromXml(root);			

			// Set the configuration to NOT dirty - we just loaded it!
			this.IsDirty = false;
		}

		protected virtual void CreateConfigurationFile() {
			XElement root = new XElement("root");
			XElement configuration =
				new XElement("configuration",
					new XElement(this.PersonalConfiguration.ToXml()),
					new XElement(this.MiscellaneousConfiguration.ToXml()),
					new XElement(this.TimesheetConfiguration.ToXml()),
					new XElement(this.InvoiceConfiguration.ToXml()),
					new XElement(this.RatesConfiguration.ToXml()),
					new XElement(this.DayTypeConfiguration.ToXml())					
				);			
			
			root.Add(configuration);

			root.Save(this.ConfigurationFile);
		}

		public void Save() {
			if (!this.IsDirty) {
				// Nothing to save, just get out.
				return;
			} else {
				CreateConfigurationFile();

				// Set the configuration to NOT dirty - we just saved it!
				this.IsDirty = false;
			}
		}
		#endregion	// Methods
	};
};
