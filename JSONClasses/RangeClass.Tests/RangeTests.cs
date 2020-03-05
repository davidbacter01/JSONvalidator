using System;
using Xunit;

namespace Classes.Tests
{
    public class RangeTests
    {
        [Fact]
        public void StringWithAllCharsInParameterRangeShouldReturnRemainingTxt()
        {
            var digit = new Range('a', 'f');
            Assert.Equal("bc", digit.Match("abc").RemainingText());
        }

        [Fact]
        public void StringWithACharOutOfParameterRangeShouldReturnInitialText()
        {
            var digit = new Range('a', 'f');
            Assert.Equal("1abc", digit.Match("1abc").RemainingText());
        }

        [Fact]
        public void EmptyStringShouldReturnEmptyString()
        {
            var digit = new Range('a', 'f');
            Assert.Equal("", digit.Match("").RemainingText());
        }

        [Fact]
        public void NullShouldReturnNull()
        {
            var digit = new Range('a', 'f');
            Assert.Null(digit.Match(null).RemainingText());
        }
    }
}
