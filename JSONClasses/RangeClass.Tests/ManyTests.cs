using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class ManyTests
    {
        [Fact]
        public void MatchingCharAtStartOfTextShouldReturnRemainingText()
        {
            var a = new Many(new Character('a'));
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void MatchingMultipleCopiesOfCharAtStartOfTextShouldReturnRemainingText()
        {
            var a = new Many(new Character('a'));
            Assert.Equal("bc", a.Match("aaaaabc").RemainingText());
        }

        [Fact]
        public void NotMatchingCharAtStartOfTextShouldReturnInitialText()
        {
            var a = new Many(new Character('a'));
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void EmptyTextShouldReturnEmptyText()
        {
            var a = new Many(new Character('a'));
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void NullShouldReturnNull()
        {
            var a = new Many(new Character('a'));
            Assert.Null(a.Match(null).RemainingText());
        }

        [Fact]
        public void DigitsRangeAtStartShouldConsumeAllDigitsInRange()
        {
            var digits = new Many(new Range('0', '9'));
            Assert.Equal("ab123", digits.Match("12345ab123").RemainingText());
        }

        [Fact]
        public void DigitsRangeAtStartNotMatchinShouldReturnInitialText()
        {
            var digits = new Many(new Range('0', '9'));
            Assert.Equal("ab", digits.Match("ab").RemainingText());
        }
    }
}
