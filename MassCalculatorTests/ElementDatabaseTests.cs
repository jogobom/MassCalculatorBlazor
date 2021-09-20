using System;
using System.Collections.Generic;
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
            var database = new ElementDatabase(new []{new Element("X", "X", new List<ElementIsotope>())});

            var act = new Func<double>(() => database.GetAverageMass("A"));

            act.Should().Throw<ApplicationException>();
        }

        [Fact]
        public void AverageMassOfElementWithOneIsotope_ShouldBe_TheMassOfTheIsotope()
        {
            var database = new ElementDatabase(new []
            {
                new Element("X", "X", new List<ElementIsotope>
                {
                    new() {Mass = 5, Proportion = 1}
                })
            });

            database.GetAverageMass("X").Should().Be(5);
        }

        [Fact]
        public void AverageMassOfElementWithTwoIsotopes_ShouldBe_WeightedAverageOfTheIsotopesBasedInAbundance()
        {
            var database = new ElementDatabase(new []
            {
                ElementBuilder.MakeElementWithIsotopes("X", 5, 10)
            });

            database.GetAverageMass("X").Should().Be(7.5);
        }
    }
}
