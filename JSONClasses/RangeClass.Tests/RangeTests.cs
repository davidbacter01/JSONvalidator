using System;
using Xunit;

namespace RangeClass.Tests
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
    }
}
