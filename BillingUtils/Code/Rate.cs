using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingUtils.Code {

	public class Rate {
		// Fields
		// --------------------------------------------------------------------------
		#region Fields
		public decimal Amount { get; protected set; }
		public DateTime EffectiveDate { get; protected set; }
		#endregion	// Fields

		// Construction/Initialization
		// --------------------------------------------------------------------------
		#region Construction/Initialization
		public Rate(decimal amount, DateTime effectiveDate) {
			this.Amount = amount;
			this.EffectiveDate = effectiveDate;
		}
		#endregion	// Construction/Initialization

		// Properties
		// --------------------------------------------------------------------------
		#region Properties
		static public Rate DefaultRate {
			get { return new Rate(0, new DateTime(1900, 1, 1)); } 
		}
		#endregion	// Properties

		// General Methods
		// --------------------------------------------------------------------------
		#region General Methods
		public override string ToString() {
			return this.Amount.ToString("C");
		}
		#endregion	// General Methods

		static public bool operator ==(Rate rate1, Rate rate2) {
			return (rate1.Amount == rate2.Amount && rate1.EffectiveDate == rate2.EffectiveDate);
		}

		static public bool operator !=(Rate rate1, Rate rate2) {
			return !(rate1 == rate2);
		}
	};
};
