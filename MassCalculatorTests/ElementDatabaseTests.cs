using System;
using System.Collections.Generic;
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
            var database = new ElementDatabase([new Element("X", "X", [])]);

            var act = new Func<double>(() => database.GetAverageMass("A"));

            act.Should().Throw<ApplicationException>();
        }

        [Fact]
        public void AverageMassOfElementWithOneIsotope_ShouldBe_TheMassOfTheIsotope()
        {
            var database = new ElementDatabase([
                new Element("X", "X", [new() { Mass = 5, Proportion = 1 }])
            ]);

            database.GetAverageMass("X").Should().Be(5);
        }

        [Fact]
        public void AverageMassOfElementWithTwoIsotopes_ShouldBe_WeightedAverageOfTheIsotopesBasedInAbundance()
        {
            var database = new ElementDatabase([
                ElementBuilder.MakeElementWithIsotopes("X", (5, 0.5), (10, 0.5))
            ]);

            database.GetAverageMass("X").Should().Be(7.5);
        }
        
        [Fact]
        public void MonoisotopicMassOfElementWithTwoIsotopes_ShouldBe_MassOfTheMostAbundantIsotope()
        {
            var database = new ElementDatabase([
                ElementBuilder.MakeElementWithIsotopes("X", (5, 0.25), (10, 0.75))
            ]);

            database.GetMonoisotopicMass("X").Should().Be(10);
        }
        
        [Fact]
        public void MinimumIsotopeMassOfElementWithTwoIsotopes_ShouldBe_MassOfTheFirstOne()
        {
            var database = new ElementDatabase([
                ElementBuilder.MakeElementWithIsotopes("X", (5, 0.25), (10, 0.75))
            ]);

            database.GetMinimumIsotopeMass("X").Should().Be(5);
        }
    }
}
