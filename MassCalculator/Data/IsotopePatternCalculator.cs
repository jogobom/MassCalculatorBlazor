using System;
using System.Collections.Generic;
using System.Linq;

namespace MassCalculator.Data
{
    public class IsotopePatternCalculator
    {
        private readonly ElementDatabase database;
        private const int NumberOfRandomPatternsToGenerate = 1000;

        public IsotopePatternCalculator(ElementDatabase database)
        {
            this.database = database;
        }

        public IList<PredictedIsotope> PredictIsotopesFromComposition(Composition composition)
        {
            // For now, just make one guess at a possible sequence using random draws
            // Ideally, we would do infinity random sequences and combine them to get the true expected distribution
            // In reality, we'll do n random sequences and combine them - the bigger n, the closer we'll get to the true distribution (law of large numbers)
            // We could do each in parallel, if we had infinity "threads" because each sequence is independent
            // Monte Carlo!
            return Enumerable.Range(0, NumberOfRandomPatternsToGenerate).Select(_ => PredictRandomIsotopicPeak(composition)).Distinct().OrderBy(p => p.Mass).ToList();
        }

        public IList<PredictedIsotope> PredictIsotopesFromCompositionAsParallel(Composition composition)
        {
            // For now, just make one guess at a possible sequence using random draws
            // Ideally, we would do infinity random sequences and combine them to get the true expected distribution
            // In reality, we'll do n random sequences and combine them - the bigger n, the closer we'll get to the true distribution (law of large numbers)
            // We could do each in parallel, if we had infinity "threads" because each sequence is independent
            // Monte Carlo!
            return Enumerable.Range(0, NumberOfRandomPatternsToGenerate).AsParallel().Select(_ => PredictRandomIsotopicPeak(composition)).Distinct().OrderBy(p => p.Mass).ToList();
        }

        private PredictedIsotope PredictRandomIsotopicPeak(Composition composition)
        {
            var chosenIsotopes = new List<ElementIsotope>();
            foreach (var ingredient in composition.Ingredients)
            {
                // Take random draws from the set of possible isotopes for this element, one for each atom of this element in the compound
                for (var a = 0; a < ingredient.Quantity; a++)
                {
                    chosenIsotopes.Add(database.DrawRandomIsotope(ingredient.ElementSymbol));
                }
            }

            var singlePeakMass = chosenIsotopes.Sum(a => a.Mass);
            return new PredictedIsotope { Mass = singlePeakMass };
        }
    }
}