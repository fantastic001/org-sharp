using System; 

namespace ORGSharp 
{
	abstract class Element 
	{
		
		public Element() 
		{
			
		}

		public abstract ElementParser getParser();
		public abstract string output(); 

		
	}
}
