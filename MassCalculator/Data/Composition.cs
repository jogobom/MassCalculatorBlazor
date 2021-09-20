using System.Collections.Generic;
using System.Linq;

namespace MassCalculator.Data
{
    public class Composition
    {
        public struct Ingredient
        {
            public int Quantity;
            public string ElementSymbol;
        }

        public List<Ingredient> Ingredients { get; private init; } = new();

        public static Composition FromFormula(string formula)
        {
            return new Composition { Ingredients = FormulaParser.Parse(formula).ToList() };
        }
    }
}