using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MassCalculator.Data
{
    public static class FormulaParser
    {
        private static readonly Regex IngredientRegex = new(@"(?<element>[A-Z][a-z]?)(?<quantity>\d+)?", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

        public static IEnumerable<Composition.Ingredient> Parse(string formula)
        {
            foreach (var (element, quantity) in ParseIngredients(formula))
            {
                yield return new Composition.Ingredient(element,
                    string.IsNullOrEmpty(quantity) ? 1 : Convert.ToInt32(quantity));
            }
        }

        private static IEnumerable<(string element, string quantity)> ParseIngredients(string formula)
        {
            // 1. An element symbol may or may not be followed by a number
            // 2. Any two letter symbol is always upper then lower case
            var matchesFirstFormat = IngredientRegex.Match(formula);
            while (matchesFirstFormat.Success)
            {
                yield return (matchesFirstFormat.Groups["element"].Value, matchesFirstFormat.Groups["quantity"].Value);
                matchesFirstFormat = matchesFirstFormat.NextMatch();
            }
        }
    }
}