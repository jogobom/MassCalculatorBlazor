using FluentAssertions;
using MassCalculator.Data;
using Xunit;

namespace MassCalculatorTests
{
    public class FormulaParserTests
    {
        [Fact]
        public void ShouldParseC12H24O16()
        {
            FormulaParser.Parse("C12H24O16").Should().BeEquivalentTo(new[]
            {
                new Composition.Ingredient { ElementSymbol = "C", Quantity = 12 },
                new Composition.Ingredient { ElementSymbol = "H", Quantity = 24 },
                new Composition.Ingredient { ElementSymbol = "O", Quantity = 16 },
            });
        }
    }
}