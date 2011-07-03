using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BillingUtils.Code {
	public class ExcelCell {

		public int Row { get; set; }
		public string Column { get; set; }

		public ExcelCell() {
			this.Row = 0;
			this.Column = "A";
		}

		public ExcelCell(string cell) {
			this.Column = Regex.Match(cell, @"[^0-9]+").Value;
			this.Row = Convert.ToInt32(Regex.Match(cell, @"[0-9]+").Value);
		}

		public ExcelCell(string column, int row) {
			this.Row = row;
			this.Column = column;
		}
	};
};
