using System;
using Xunit;

namespace Classes.Tests
{
    public class RangeTests
    {
        [Fact]
        public void StringWithAllCharsInParameterRangeShouldReturnTrue()
        {
            var digit = new Range('a', 'f');
            bool expected = true;
            Assert.Equal(expected, digit.Match("abc"));
        }

        [Fact]
        public void StringWithACharOutOfParameterRangeShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            bool expected = false;
            Assert.Equal(expected, digit.Match("1abc"));
        }

        [Fact]
        public void EmptyStringShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            bool expected = false;
            Assert.Equal(expected, digit.Match(""));
        }

        [Fact]
        public void NullShouldReturnFalse()
        {
            var digit = new Range('a', 'f');
            bool expected = false;
            Assert.Equal(expected, digit.Match(null));
        }
    }
}
