using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;

namespace BillingUtils.Code.ContextMenus {

	public class ContextMenuEventArgs<T> : EventArgs where T : class {

		/// <summary>
		/// The object who received the ContextMenu request (action).
		/// </summary>
		public T ActionObject { get; protected set; }

		/// <summary>
		/// The type of Thing being acted on.
		/// </summary>
		public Guid ThingTypeID { get; protected set; }

		public ContextMenuEventArgs(T actionObject)
			: this(actionObject, Guid.Empty) {
		}

		public ContextMenuEventArgs(T actionObject, Guid thingTypeID) {
			this.ActionObject = actionObject;
			this.ThingTypeID = thingTypeID;
		}
	};
};
