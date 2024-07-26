using System;
using System.Collections.Generic;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using MassCalculator.Data;

namespace Benchmarking
{
    public class IsotopeDistributionBenchmarks
    {
        private readonly IsotopePatternCalculator _calculator;

        public IsotopeDistributionBenchmarks()
        {
            var database = ElementDatabase.LoadFromFile("Data\\ElementDatabase.json");
            _calculator = new IsotopePatternCalculator(database);
        }

        [Benchmark]
        public IList<PredictedIsotope> CalculateFromFormula_InSeries()
        {
            var composition = Composition.FromFormula("C12H24O8");
            return _calculator.PredictIsotopesFromComposition(composition);
        }

        [Benchmark]
        public IList<PredictedIsotope> CalculateFromFormula_InParallel()
        {
            var composition = Composition.FromFormula("C12H24O8");
            return _calculator.PredictIsotopesFromCompositionAsParallel(composition);
        }
    }

    internal static class Program
    {
        internal static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<IsotopeDistributionBenchmarks>();
        }
    }
}
