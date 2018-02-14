
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
			int level = contents.TakeWhile(c => c == '*').Count();
			return level > 0 ? 
				Tuple.Create(new Section(level, contents.First().SkipWhile(c => c == '*').Skip(1)), contents.Skip(1).ToList()) 
			: Tuple.Create(null, contents);
		}
	}
}
