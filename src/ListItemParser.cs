

using System; 
using System.Collections.Generic; 
using System.Linq; 


namespace ORGSharp 
{
	class ListItemParser : ElementParser 
	{

		// Function should return tuple of (element, remaining string)
		public Tuple<Element, List<string>> parse(List<string> contents) 
		{
			return contents.First().SkipWhile(c => c == ' ')
				.Take(2).ToString() == "+ " ? 
			new Tuple<Element, List<string>>(
				new ListItem(contents.First().SkipWhile(c => c == ' ').Skip(2).ToString()), 
				contents.Skip(1).ToList()
			)
			: new Tuple<Element, List<string>>(null, contents);
		} 
	}
}
