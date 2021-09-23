using FluentAssertions;
using MassCalculator.Data;
using Xunit;

namespace MassCalculatorTests
{
    public class CompositionTests
    {
        [Theory]
        [InlineData("C", "C")]
        [InlineData("C2", "C2")]
        [InlineData("CH", "CH")]
        [InlineData("C2H2", "C2H2")]
        [InlineData("H3C2", "C2H3")]
        [InlineData("C2O4", "C2O4")]
        [InlineData("O14P15Cl35", "Cl35O14P15")]
        [InlineData("O14P15Cl35H90C203", "C203H90Cl35O14P15")]
        [InlineData("O1PClH1C", "CHClOP")]
        public void CompositionsShouldBeFormattedAccordingToHillOrdering(string formula, string expectedResult)
        {
            // Hill Order is described at https://web.stanford.edu/group/swain/cinf/workshop98aug/hill.html

            var composition = Composition.FromFormula(formula);

            composition.ToString().Should().Be(expectedResult);
        }
    }
}