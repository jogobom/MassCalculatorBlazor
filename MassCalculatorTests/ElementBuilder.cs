using System.Linq;
using MassCalculator.Data;

namespace MassCalculatorTests
{
    public static class ElementBuilder
    {
        public static Element MakeElementWithIsotopes(string symbol, params (double mass, double proportion)[] isotopes)
        {
            return new Element(symbol, symbol, isotopes.Select(i => new ElementIsotope { Mass = i.mass, Proportion = i.proportion }).ToList());
        }
    }
}