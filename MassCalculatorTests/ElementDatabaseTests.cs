using System;
using System.Linq;
using FluentAssertions;
using MassCalculator.Data;
using Xunit;

namespace MassCalculatorTests
{
    public class ElementDatabaseTests
    {
        [Fact]
        public void AverageMass_WhenElementIsNotKnown_ShouldThrow()
        {
            var database = new ElementDatabase(new []{Element.MakeElement("X", "X", Enumerable.Empty<ElementIsotope>())});

            var act = new Func<double>(() => database.GetAverageMass(new ElementSymbol("A")));

            act.Should().Throw<ApplicationException>();
        }

        [Fact]
        public void AverageMassOfElementWithOneIsotope_ShouldBe_TheMassOfTheIsotope()
        {
            var database = new ElementDatabase(new []{Element.MakeElement("X", "X", new[]{new ElementIsotope{Mass = 5, Proportion = 1}})});

            database.GetAverageMass(new ElementSymbol("X")).Should().Be(5);
        }

        [Fact]
        public void AverageMassOfElementWithTwoIsotopes_ShouldBe_WeightedAverageOfTheIsotopesBasedInAbundance()
        {
            var database = new ElementDatabase(new []
            {
                ElementBuilder.MakeElementWithIsotopes("X", 5, 10)
            });

            database.GetAverageMass(new ElementSymbol("X")).Should().Be(7.5);
        }
    }
}
