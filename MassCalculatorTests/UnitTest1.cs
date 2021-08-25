using System;
using FluentAssertions;
using Xunit;

namespace MassCalculatorTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            false.Should().BeTrue();
        }
    }
}
