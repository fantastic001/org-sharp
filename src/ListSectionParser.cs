
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
					return Tuple.Create(
						ListSection(new List<ListItem>() {first.Item1}).withSection(second.Item1), 
						second.Item2
					);
						
				}
				else 
				{
					return Tuple.Create(
							(new ListSection(new List<ListItem>())).withItem(first.Item1),
						first.Item2
					);
				}
			}
			else 
			{
				return Tuple.Create(null, contents);
			}
		}
	}
}
