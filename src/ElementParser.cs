
using System; 
using System.Collections.Generic; 
using System.Linq;

namespace ORGSharp 
{
	interface ElementParser 
	{

		// Function should return tuple of (element, remaining string)
		Tuple<Element, List<string>> parse(List<string> contents); 
	}
}
