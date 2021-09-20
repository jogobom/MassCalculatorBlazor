using System.Collections.Generic;
using System.Linq;

namespace MassCalculator.Data
{
    public class Element
    {
        public ElementSymbol Symbol { get; }
        public string Name { get; }
        public List<ElementIsotope> Isotopes { get; private init; } = new();

        private Element(ElementSymbol symbol, string name)
        {
            Symbol = symbol;
            Name = name;
        }

        public static Element MakeElement(string symbol, string name, IEnumerable<ElementIsotope> isotopes)
        {
            var newElement = new Element(new ElementSymbol(symbol), name)
            {
                Isotopes = isotopes.ToList()
            };
            return newElement;
        }
    }
}