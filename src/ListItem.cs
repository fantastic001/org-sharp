
using System; 
using System.Collections.Generic; 
using System.Linq; 

namespace ORGSharp 
{
	
	class ListItem : Element 
	{
		public string text { get; private set; } 

		public ListItem(string _text) 
		{
			text = _text; 
		}

		public override ElementParser getParser() 
		{
			return new ListItemParser();
		}

		public override string output() 
		{
			return "+ " + text;
		}
	}
}
