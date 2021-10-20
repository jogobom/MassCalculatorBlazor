using System.Collections.Generic;
using System.Linq;

namespace MassCalculator.Data
{
    public class Element
    {
        public Element(string symbol, string name, List<ElementIsotope> isotopes)
        {
            Symbol = symbol;
            Name = name;
            Isotopes = isotopes.ToList();
        }

        public string Symbol { get; }
        public string Name { get; }
        public List<ElementIsotope> Isotopes { get; }
    }
}