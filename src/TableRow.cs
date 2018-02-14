using System; 
using System.Collections.Generic; 
using System.Linq;

namespace ORGSharp 
{
	class TableRow : Element 
	{
		public List<string> columns {get; private set;} 

		public TableRow(List<string> columns) 
		{
			this.columns = columns; 
		}

		public override ElementParser getParser() 
		{
			return new TableRowParser(); 
		}
		public override string output() 
		{
			return "|" +  String.Join("|", from c in columns select " " + c + " ") + "|";
		}
	}
}
