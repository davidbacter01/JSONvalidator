using System;
using Xunit;

namespace JsonNumberValidator.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void PositiveIntegerNumberShouldReturnValid()
        {
            string test = "234";
            Assert.Equal("Valid", Program.GetJSONNumberValidity(test));
        }

        [Fact]
        public void NegativeIntNumberShouldReturnValid()
        {
            string test = "-123";
            Assert.Equal("Valid", Program.GetJSONNumberValidity(test));
        }

        [Fact]
        public void FloatingPointtNumberShouldReturnValid()
        {
            string test = "12.34";
            Assert.Equal("Valid", Program.GetJSONNumberValidity(test));
        }

        [Fact]
        public void FloatingPointtNumberWithExponentShouldReturnValid()
        {
            string test = "12.123e3";
            Assert.Equal("Valid", Program.GetJSONNumberValidity(test));
        }
    }
}
