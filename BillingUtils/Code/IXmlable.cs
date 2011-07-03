using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace BillingUtils.Code {

	public interface IXmlable<T> {
		void FromXml(T parentObject, XElement element);
		XElement ToXml();
	};
};
