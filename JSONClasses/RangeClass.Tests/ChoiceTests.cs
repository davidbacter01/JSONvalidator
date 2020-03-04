using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class ChoiceTests
    {
        [Fact]
        public void ChoiceWithRangeAndCharacterMatchingShuldReturnTrue()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            bool expected = true;
            Assert.Equal(expected, digit.Match("012"));
        }

        [Fact]
        public void NullOrEmptyStringShouldReturnFalse()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            bool expected = false;
            Assert.Equal(expected, digit.Match(null));
        }

        [Fact]
        public void ValidHexPatternShouldTrue()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Range('a', 'f'), new Range('A', 'F'));
            bool expected = true;
            Assert.Equal(expected, hex.Match("012"));
        }

    }
}
