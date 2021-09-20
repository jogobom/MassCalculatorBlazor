using System.Linq;
using MassCalculator.Data;

namespace MassCalculatorTests
{
    public static class ElementBuilder
    {
        public static Element MakeElementWithIsotopes(string symbol, params double[] masses)
        {
            var isotopeProportion = 1.0 / masses.Length;
            return new Element(symbol, symbol, masses.Select(m => new ElementIsotope { Mass = m, Proportion = isotopeProportion }).ToList());
        }
    }
}