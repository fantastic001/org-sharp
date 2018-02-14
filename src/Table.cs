using System; 
using System.Collections.Generic; 
using System.Linq; 

namespace ORGSharp 
{
	class Table : Element
	{
		public TableRow header 	{get; private set;} 
		public List<TableRow> rows {get; private set; } 

		public Table(TableRow header, List<TableRow> rows) {
			this.header = header; 
			this.rows = rows; 
		}

		public Table withRow(TableRow row) {
			return new Table(header, rows.Concat(new List<TableRow>() {row}).ToList());
		}
		public Table withTable(Table table) {
			return new Table(header, rows.Concat(table.rows).ToList());
		}
		

		public override ElementParser getParser() 
		{
			return new TableParser();
		}
		public override string output() 
		{
			return header.columns.Count() > 0 ? 
				header.output() + "\n---------------------\n" + 
					String.Join("\n", from r in rows select r.output()) + "\n"
				: String.Join("\n", from r in rows select r.output());
		}
	}
}
