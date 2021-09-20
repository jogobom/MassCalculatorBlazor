using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MassCalculator.Data
{
    public static class FormulaParser
    {
        // Formulae like C12O6H24
        private static readonly Regex SupportedFormat1 = new(@"(?<element>[a-zA-Z]+)(?<quantity>\d+)", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

        public static IEnumerable<Composition.Ingredient> Parse(string formula)
        {
            foreach (var (element, quantity) in ParseIngredientsUsingFormat(SupportedFormat1, formula))
            {
                yield return new Composition.Ingredient{ ElementSymbol = element.ToUpper(), Quantity = Convert.ToInt32(quantity)};
            }
        }

        private static IEnumerable<(string element, string quantity)> ParseIngredientsUsingFormat(Regex regex, string formula)
        {
            Match matchesFirstFormat = regex.Match(formula);
            while (matchesFirstFormat.Success)
            {
                yield return (matchesFirstFormat.Groups["element"].Value, matchesFirstFormat.Groups["quantity"].Value);
                matchesFirstFormat = matchesFirstFormat.NextMatch();
            }
        }
    }
}