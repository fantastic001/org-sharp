

using System; 
using System.Collections.Generic; 
using System.Linq; 


namespace ORGSharp 
{
	class TableParser : ElementParser 
	{
		bool hasHeader(List<string> contents) 
		{
			return contents.Skip(1).First().ToString()[0] == '-'; 
		}

		TableRow parseRow(string line) 
		{
			return new TableRow(line.Split('|').ToList());
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
					TableRow header = (TableRow) this.parse(contents.Skip(2).ToList()).Item1; 
					var rest = this.parse(contents.Skip(2).ToList());
					return new Tuple<Element, List<string>>((new Table(header, new List<TableRow>())).withTable((Table) rest.Item1), rest.Item2);
				}
				else 
				{
					var rest = this.parse(contents.Skip(1).ToList());
					if (rest.Item1 == null) 
					{
						return new Tuple<Element, List<string>>((new Table(null, new List<TableRow>())).withRow(this.parseRow(line)), contents.Skip(1).ToList());
					}
					else 
					{
						return new Tuple<Element, List<string>>(
							(new Table(null, new List<TableRow>())).withRow(this.parseRow(line)).withTable((Table) rest.Item1),
							rest.Item2
						);
					}
				}
			}
			else 
			{
				return new Tuple<Element, List<string>>(null, contents);
			}
		} 
	}
}
