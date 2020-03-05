using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class ChoiceTests
    {
        [Fact]
        public void ChoiceWithRangeAndCharacterMatchingShuldReturnRemainingText()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.Equal("12", digit.Match("012").RemainingText());
        }

        [Fact]
        public void NullOrEmptyStringShouldReturnInitialText()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            Assert.Null(digit.Match(null).RemainingText());
        }

        [Fact]
        public void ValidHexPatternShoulReturnRemainingText()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Range('a', 'f'), new Range('A', 'F'));
            Assert.Equal("12", hex.Match("012").RemainingText());
        }

        [Fact]
        public void ValidHexPatternStartingWithLowercaseCharShouldReturnRemainingText()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Range('a', 'f'), new Range('A', 'F'));
            Assert.Equal("8", hex.Match("f8").RemainingText());
        }

        [Fact]
        public void ValidHexPatternStartingWithUppercaseCharShouldReturnRemainingText()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Range('a', 'f'), new Range('A', 'F'));
            Assert.Equal("8", hex.Match("A8").RemainingText());
        }

        [Fact]
        public void InValidHexPatternrShouldReturnOriginalText()
        {
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Range('a', 'f'), new Range('A', 'F'));
            Assert.Equal("g8", hex.Match("g8").RemainingText());
        }

    }
}
