using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace MassCalculator.Data
{
    public class ElementDatabase
    {
        private readonly Dictionary<string,List<ElementIsotope>> knownIsotopes = new();

        public ElementDatabase(IEnumerable<ElementIsotope> isotopes)
        {
            foreach (var isotope in isotopes)
            {
                if (knownIsotopes.ContainsKey(isotope.Symbol))
                {
                    knownIsotopes[isotope.Symbol].Add(isotope);
                }
                else
                {
                    knownIsotopes.Add(isotope.Symbol, new List<ElementIsotope>{isotope});
                }
            }
        }

        public static ElementDatabase LoadFromFile(string path)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return new ElementDatabase(csv.GetRecords<ElementIsotope>());
        }

        public double GetAverageMass(string symbol)
        {
            return knownIsotopes.ContainsKey(symbol)
                ? knownIsotopes[symbol].Sum(i => i.Proportion * i.Mass)
                : throw new ApplicationException($"No element with symbol \"{symbol}\" in database");
        }
    }
}