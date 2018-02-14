

using System; 
using System.Collections.Generic; 
using System.Linq; 


namespace ORGSharp 
{
	class MacroParser : ElementParser 
	{

		// Function should return tuple of (element, remaining string)
		public Tuple<Element, List<string>> parse(List<string> contents) 
		{
			return contents.First().Take(2).ToString() == "#+" && contents.First().Skip(2).TakeWhile(c => c != ':').Count() > 0 ? 
				Tuple.Create(new Macro(contents.First().Skip(2).TakeWhile(c => c != ':').ToString(), contents.First().SkipWhile(c => c != ':').ToString()), contents.Skip(1).ToList()) 
			: Tuple.Create(null, contents);
		} 
	}
}
