using System; 
using System.Collections.Generic; 
using System.Linq; 

namespace ORGSharp 
{
	class Text : Element 
	{
		public string text {get; private set;} 
		public Text(string text) 
		{
			this.text = text; 
		}

		public Text withText(string t) 
		{
			return new Text(text + "\n" + t);
		}

		public override ElementParser getParser() 
		{
			return new TextParser();
		}
		public override string output() 
		{
			return "\n" + text + "\n";
		}
	}
}
