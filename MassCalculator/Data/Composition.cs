using System.Collections.Generic;
using System.Linq;

namespace MassCalculator.Data
{
    public class Composition
    {
        public struct Ingredient
        {
            public int quantity;
            public ElementSymbol element;
        }

        public List<Ingredient> Ingredients { get; init; } = new();

        public static Composition FromElements(params (int quantity, string element)[] elements)
        {
            return new Composition { Ingredients = elements.Select(e =>
                new Ingredient{quantity = e.quantity, element = new ElementSymbol(e.element)}).ToList() };
        }
    }
}