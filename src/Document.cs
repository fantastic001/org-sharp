
using System; 
using System.Collections.Generic;
using System.Linq;

namespace ORGSharp {
	
	class Document {

		public List<Element> elements { get; private set; }

		public Document(List<Element> elements) {
			this.elements = elements; 
		}

		public Document withElement(Element e) {
			return new Document(elements.Concat(new Element[] {e}).ToList());
		}
	}
}
