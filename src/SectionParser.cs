
using System; 
using System.Collections.Generic; 
using System.Linq;


namespace ORGSharp 
{
	class SectionParser : ElementParser 
	{

		// Function should return tuple of (element, remaining string)
		public Tuple<Element, List<string>> parse(List<string> contents) 
		{
			int level = contents.First().TakeWhile(c => c == '*').Count();
			return level > 0 ? 
				new Tuple<Element, List<string>>(new Section(level, contents.First().SkipWhile(c => c == '*').Skip(1).ToString()), contents.Skip(1).ToList()) 
			: new Tuple<Element, List<string>>(null, contents);
		}
	}
}
