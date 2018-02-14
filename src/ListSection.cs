using System; 
using System.Collections.Generic; 
using System.Linq; 

namespace ORGSharp {

	class ListSection : Element 
	{
		public List<ListItem> items { get; private set; }

		public ListSection(List<ListItem> _items) 
		{
			items = _items;
		}

		public ListSection withItem(ListItem it) 
		{
			return new ListSection(items.Concat(new List<ListItem>() {it}).ToList());
		}
		
		public override ElementParser getParser() 
		{
			return new ListSectionParser();
		}
		public override string output() 
		{
			string res = ""; 
			foreach (var item in items) 
			{
				res += item.output() + "\n";
			}
			return res;
		}
	}
}

