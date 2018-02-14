using System; 
using System.Collections.Generic; 
using System.Linq; 

namespace ORGSharp 
{
	class Section : Element
	{
		public int level {get; private set; } 
		public string text {get; private set;} 

		public Section(int l, string t) 
		{
			text = t;
			level = l;
		}

		public override ElementParser getParser() 
		{
			return new SectionParser();
		}
		public override string output() 
		{
			string res = ""; 
			for (int i = 0; i<level; i++) 
			{
				res += "*";
			}
			return res + " " + text;
		}
	}
}
