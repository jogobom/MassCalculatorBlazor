using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MassCalculator.Data
{
    public class ElementDatabase
    {
        private readonly Dictionary<string,Element> _knownElements = new();
        private readonly Random _random;

        public ElementDatabase(IEnumerable<Element> elements)
        {
            _random = new Random();

            foreach (var element in elements)
            {
                _knownElements[element.Symbol] = element;
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
            return _knownElements.ContainsKey(symbol)
                ? _knownElements[symbol].Isotopes.Sum(i => i.Proportion * i.Mass)
                : throw new ApplicationException($"No element with symbol \"{symbol}\" in database");
        }
        
        public double GetMonoisotopicMass(string symbol)
        {
            return _knownElements.ContainsKey(symbol)
                ? _knownElements[symbol].Isotopes.OrderBy(i => i.Nucleons).First().Mass
                : throw new ApplicationException($"No element with symbol \"{symbol}\" in database");
        }

        public ElementIsotope DrawRandomIsotope(string symbol)
        {
            if (!_knownElements.ContainsKey(symbol))
            {
                throw new ApplicationException($"No element with symbol \"{symbol}\" in database");
            }

            var element = _knownElements[symbol];
            var randomPercentage = _random.NextDouble();
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