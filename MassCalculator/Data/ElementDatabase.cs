using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MassCalculator.Data
{
    public class ElementDatabase
    {
        private readonly Dictionary<string,Element> knownElements = new();
        private readonly Random random;

        public ElementDatabase(IEnumerable<Element> elements)
        {
            random = new Random();

            foreach (var element in elements)
            {
                knownElements[element.Symbol] = element;
            }
        }

        public static ElementDatabase LoadFromFile(string path)
        {
            var jsonFileContent = File.ReadAllText(path);
            var elementsFromJson = JsonSerializer.Deserialize<List<Element>>(jsonFileContent);
            return new ElementDatabase(elementsFromJson ?? Enumerable.Empty<Element>());
        }

        public double GetAverageMass(string symbol)
        {
            return knownElements.ContainsKey(symbol)
                ? knownElements[symbol].Isotopes.Sum(i => i.Proportion * i.Mass)
                : throw new ApplicationException($"No element with symbol \"{symbol}\" in database");
        }

        public ElementIsotope DrawRandomIsotope(string symbol)
        {
            if (!knownElements.ContainsKey(symbol))
            {
                throw new ApplicationException($"No element with symbol \"{symbol}\" in database");
            }

            var element = knownElements[symbol];
            var randomPercentage = random.NextDouble();
            var totalProportionSoFar = 0.0;

            foreach (var isotope in element.Isotopes)
            {
                totalProportionSoFar += isotope.Proportion;
                if (randomPercentage <= totalProportionSoFar)
                    return isotope;
            }

            throw new ApplicationException($"Somehow managed to run out of isotopes before random percentage was met, check that the proportions for all elements sum to 1.0");
        }
    }
}