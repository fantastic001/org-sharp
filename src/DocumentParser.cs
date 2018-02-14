
using System; 
using System.Collections.Generic; 
using System.Linq; 

namespace ORGSharp 
{
	class DocumentParser 
	{
		
		public Document parse(string contents) 
		{
			ElementParser[] parsers = new ElementParser[] {
				new ListSectionParser(),
				new MacroParser(),
				new SectionParser(),
				new TableParser(),
				new TextParser()
			};
			List<string> lines = contents.Split('\n').ToList();

			Document doc = new Document(new List<Element>()); 
			while (lines.Count() > 0) 
			{
				var parser = parsers.First((p => p.parse(lines).Item1 != null));
				var res = parser.parse(lines); 
				doc = doc.withElement(res.Item1);
				lines = res.Item2;
			}
			return doc; 
		}
	}
}
