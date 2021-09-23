using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MassCalculator.Data
{
    public class Composition
    {
        public class Ingredient
        {
            public readonly int Quantity;
            public readonly string ElementSymbol;

            public Ingredient(string elementSymbol, int quantity)
            {
                ElementSymbol = elementSymbol;
                Quantity = quantity;
            }

            public override string ToString()
            {
                return Quantity == 1 ? $"{ElementSymbol}": $"{ElementSymbol}{Quantity}";
            }
        }

        public List<Ingredient> Ingredients { get; }

        public static Composition FromFormula(string formula)
        {
            return new Composition(FormulaParser.Parse(formula).ToList());
        }
        
        private Composition(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients.ToList();
        }

        public override string ToString()
        {
            return HillOrderedComposition(Ingredients);
        }

        private static string HillOrderedComposition(IEnumerable<Ingredient> initialIngredients)
        {
            // https://web.stanford.edu/group/swain/cinf/workshop98aug/hill.html

            var stringBuilder = new StringBuilder();
            var remainingIngredients = new List<Ingredient>(initialIngredients);

            var carbon = remainingIngredients.FirstOrDefault(i => i.ElementSymbol == "C");

            if (carbon != null)
            {
                stringBuilder.Append(carbon);
                remainingIngredients.Remove(carbon);

                var hydrogen = remainingIngredients.FirstOrDefault(i => i.ElementSymbol == "H");
                if (hydrogen != null)
                {
                    stringBuilder.Append(hydrogen);
                    remainingIngredients.Remove(hydrogen);
                }
            }

            foreach (var remainingIngredient in remainingIngredients.OrderBy(i => i.ElementSymbol))
            {
                stringBuilder.Append(remainingIngredient);
            }

            return stringBuilder.ToString();
        }
    }
}