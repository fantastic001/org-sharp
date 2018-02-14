
using System; 
using System.Collections.Generic; 
using System.Linq; 

namespace ORGSharp {

	class Macro : Element 
	{
		public string key {get; private set;} 
		public string val {get; private set;}

		public Macro(string _key, string _val) 
		{
			key = _key; 
			val = _val;
		}

		public override ElementParser getParser() 
		{
			return new MacroParser(); 
		}	
		public override string output() 
		{
			return "#+"  + key + ": " + val;
		}
	}
}
