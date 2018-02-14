

using System; 
using System.Collections.Generic; 
using System.Linq; 


namespace ORGSharp 
{
	class TableParser : ElementParser 
	{
		bool hasHeader(List<string> contents) 
		{
			return contents.Skip(1).First().ToString()[0] == "-"; 
		}

		TableRow parseRow(string line) 
		{
			return new TableRow(line.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries).ToList());
		}

		// Function should return tuple of (element, remaining string)
		public Tuple<Element, List<string>> parse(List<string> contents) 
		{
			string line = contents.First().ToString();
			string second_row = contents.Skip(1).First().ToString();
			if (line[0] == '|') 
			{
				if (this.hasHeader(contents)) 
				{
					TableRow header = this.parse(contents.Skip(2).ToList()).Item1; 
					var rest = this.prase(contents.Skip(2).ToList());
					return Tuple.Create((new Table(header, new List<TableRow>())).withTable(rest.Item1), rest.Item2);
				}
				else 
				{
					var rest = this.prase(contents.Skip(1).ToList());
					if (rest.Item1 == null) 
					{
						return Tuple.Create((new Table(null, new List<TableRow>())).withItem(this.parseRow(line)), contents.Skip(1).ToList());
					}
					else 
					{
						return Tuple.Create(
							(new Table(null, new List<TableRow>())).withItem(this.parseRow(line)).withTable(rest.Item1),
							rest.Item2
						);
					}
				}
			}
			else 
			{
				return Tuple.Create(null, contents);
			}
		} 
	}
}
