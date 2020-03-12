using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class OneOrMoreTests
    {
        [Fact]
        public void OnlyDigitsShouldReturnEmptyTextTrue()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.True(a.Match("123").Success());
            Assert.Equal("", a.Match("123").RemainingText());
        }

        [Fact]
        public void MatchingDigitsShouldReturnRemainingTextTrue()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.True(a.Match("1a").Success());
            Assert.Equal("a", a.Match("1a").RemainingText());
        }

        [Fact]
        public void NotMatchingDigitsShouldReturnInitialTextFalse()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.False(a.Match("bc").Success());
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void EmptyTextShouldReturnEmptyTextFalse()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.False(a.Match("").Success());
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void NullShouldReturnNullFalse()
        {
            var a = new OneOrMore(new Range('0', '9'));
            Assert.False(a.Match(null).Success());
            Assert.Null( a.Match(null).RemainingText());
        }
    }
}
