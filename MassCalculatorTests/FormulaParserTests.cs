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
                new Composition.Ingredient("C", 12 ),
                new Composition.Ingredient("H", 24),
                new Composition.Ingredient("O", 16 ),
            });
        }

        [Fact]
        public void ShouldParseCh()
        {
            FormulaParser.Parse("CH").Should().BeEquivalentTo(new[]
            {
                new Composition.Ingredient("C", 1 ),
                new Composition.Ingredient("H", 1),
            });
        }
    }
}