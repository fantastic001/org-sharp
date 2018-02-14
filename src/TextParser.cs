

using System; 
using System.Collections.Generic; 
using System.Linq; 


namespace ORGSharp 
{
	class TextParser : ElementParser 
	{

		// Function should return tuple of (element, remaining string)
		public Tuple<Element, List<string>> parse(List<string> contents) 
		{
			return Tuple.Create(new Text(contents.First()), contents.Skip(1).ToList());
		} 
	}
}
