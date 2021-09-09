using System;
using FluentAssertions;
using MassCalculator.Data;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace MassCalculatorTests
{
    public class ElementDatabaseTests
    {
        [Fact]
        public void AverageMass_WhenElementIsNotKnown_ShouldThrow()
        {
            var database = new ElementDatabase(new []{new ElementIsotope{Mass = 5, Symbol = "X"}});

            var act = new Func<double>(() => database.GetAverageMass("A"));

            act.Should().Throw<ApplicationException>();
        }

        [Fact]
        public void AverageMassOfElementWithOneIsotope_ShouldBe_TheMassOfTheIsotope()
        {
            var database = new ElementDatabase(new []{new ElementIsotope{Mass = 5, Symbol = "X", Proportion = 1}});

            database.GetAverageMass("X").Should().Be(5);
        }

        [Fact]
        public void AverageMassOfElementWithTwoIsotopes_ShouldBe_WeightedAverageOfTheIsotopesBasedInAbundance()
        {
            var database = new ElementDatabase(new []
            {
                new ElementIsotope{Mass = 5, Symbol = "X", Proportion = 0.5},
                new ElementIsotope{Mass = 10, Symbol = "X", Proportion = 0.5}
            });

            database.GetAverageMass("X").Should().Be(7.5);
        }
    }
}
