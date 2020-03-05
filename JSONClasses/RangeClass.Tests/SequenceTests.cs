using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class SequenceTests
    {
        private static readonly IPattern ab = new Sequence(new Character('a'), new Character('b'));

        [Fact]
        public void SequenceOfTwoCharsWhithFirstTwoCharsInStringShouldReturnRemainingText()
        {
            Assert.Equal("cd", ab.Match("abcd").RemainingText());
        }

        [Fact]
        public void SequenceOfTwoWithSecondStringCharNotMatchingShouldReturnInitialText()
        {
            Assert.Equal("ac", ab.Match("ac").RemainingText());
        }

        [Fact]
        public void SequenceOfTwoWithNoCharMatchingShouldReturnInitialText()
        {
            Assert.Equal("def", ab.Match("def").RemainingText());
        }

        [Fact]
        public void CheckingNullInSequenceShouldReturnNull()
        {
            Assert.Null(ab.Match(null).RemainingText());
        }

        private readonly IPattern abc = new Sequence(ab, new Character('c'));

        [Fact]
        public void SequenceOfThreeCharsMatchingFirstThreeInAstringShouldReturnRemainingString()
        {
            Assert.Equal("d", abc.Match("abcd").RemainingText());
        }

        [Fact]
        public void SequenceOfThreeCharsNotMatchingFirstThreeInAstringShouldReturnInitialText()
        {
            Assert.Equal("def", abc.Match("def").RemainingText());
        }

        private static readonly IPattern hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F'));

        private static readonly IPattern hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));

        [Fact]
        public void HexSequenceMatchingTextShouldReturnRemainingText()
        {
            Assert.Equal("ef", hexSeq.Match("uabcdef").RemainingText());
        }
    }
}
