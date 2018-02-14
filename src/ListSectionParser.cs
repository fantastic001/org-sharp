
using System; 
using System.Collections.Generic; 
using System.Linq;


namespace ORGSharp 
{
	class ListSectionParser : ElementParser 
	{

		// Function should return tuple of (element, remaining string)
		public Tuple<Element, List<string>> parse(List<string> contents) 
		{
			ListItemParser itemParser = new ListItemParser(); 
			var first = itemParser.parse(contents); 
			if (first.Item1 != null )
			{
				var second = this.parse(contents.Skip(1).ToList());
				if (second.Item1 != null) 
				{
					return new Tuple<Element, List<string>>(
						(new ListSection(new List<ListItem>() {(ListItem) first.Item1})).withSection((ListSection) second.Item1), 
						second.Item2
					);
						
				}
				else 
				{
					return new Tuple<Element, List<string>>(
							(new ListSection(new List<ListItem>())).withItem((ListItem) first.Item1),
						first.Item2
					);
				}
			}
			else 
			{
				return new Tuple<Element, List<string>>(null, contents);
			}
		}
	}
}
