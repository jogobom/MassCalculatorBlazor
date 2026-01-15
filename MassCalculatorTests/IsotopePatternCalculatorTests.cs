using FluentAssertions;
using MassCalculator.Data;
using Xunit;

namespace MassCalculatorTests
{
    public class IsotopePatternCalculatorTests
    {
        [Fact]
        public void PredictsOneIsotopeForSingleMonoisotopicElement()
        {
            var composition = Composition.FromFormula("A1");

            var database = new ElementDatabase([
                ElementBuilder.MakeElementWithIsotopes("A", (5, 1.0) )
            ]);
            var calculator = new IsotopePatternCalculator(database);

            var isotopePattern = calculator.PredictIsotopesFromComposition(composition);

            isotopePattern.Should().ContainSingle();
            isotopePattern[0].Mass.Should().Be(5);
        }

        [Fact]
        public void PredictsTwoIsotopesForSingleElementThatHasTwoIsotopes()
        {
            var composition = Composition.FromFormula("A1");

            var database = new ElementDatabase([
                ElementBuilder.MakeElementWithIsotopes("A", (5, 0.5), (10, 0.5) )
            ]);
            var calculator = new IsotopePatternCalculator(database);

            var isotopePattern = calculator.PredictIsotopesFromComposition(composition);

            isotopePattern.Should().HaveCount(2);
            isotopePattern[0].Mass.Should().Be(5);
            isotopePattern[1].Mass.Should().Be(10);
        }

        [Fact]
        public void PredictsFourIsotopesForTwoElementsThatHaveTwoIsotopes()
        {
            var composition = Composition.FromFormula("A1B1");

            var database = new ElementDatabase([
                ElementBuilder.MakeElementWithIsotopes("A", (5, 0.5), (10, 0.5) ),
                ElementBuilder.MakeElementWithIsotopes("B", (20, 0.5), (22, 0.5) ),
            ]);
            var calculator = new IsotopePatternCalculator(database);

            var isotopePattern = calculator.PredictIsotopesFromComposition(composition);

            isotopePattern.Should().HaveCount(4);
            isotopePattern[0].Mass.Should().Be(25);
            isotopePattern[1].Mass.Should().Be(27);
            isotopePattern[2].Mass.Should().Be(30);
            isotopePattern[3].Mass.Should().Be(32);
        }

        [Fact]
        public void PredictsThreeIsotopesForTwoElementsThatHaveTwoIsotopesWithSameMass()
        {
            var composition = Composition.FromFormula("A1B1");

            var database = new ElementDatabase([
                ElementBuilder.MakeElementWithIsotopes("A", (5, 0.5), (10, 0.5) ),
                ElementBuilder.MakeElementWithIsotopes("B", (5, 0.5), (10, 0.5) )
            ]);
            var calculator = new IsotopePatternCalculator(database);

            var isotopePattern = calculator.PredictIsotopesFromComposition(composition);

            isotopePattern.Should().HaveCount(3);
            isotopePattern[0].Mass.Should().Be(10);
            isotopePattern[1].Mass.Should().Be(15);
            isotopePattern[2].Mass.Should().Be(20);
        }
    }
}