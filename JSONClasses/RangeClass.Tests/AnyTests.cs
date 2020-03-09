using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class AnyTests
    {
        private static IPattern e = new Any("eE");
        [Fact]
        public void MatchingFirstLetterShouldReturnRemainingText()
        {
            Assert.Equal("a", e.Match("ea").RemainingText());
        }

        [Fact]
        public void MatchingFirstLetterInOtherPartOfConstructorTextShouldReturnRemainingText()
        {
            Assert.Equal("a", e.Match("Ea").RemainingText());
        }

        [Fact]
        public void NotMatchingFirstLetterShouldReturnInitialText()
        {
            Assert.Equal("a", e.Match("a").RemainingText());
        }

        [Fact]
        public void EmptyTextShouldReturnEmptyText()
        {
            Assert.Equal("", e.Match("").RemainingText());
        }

        [Fact]
        public void NullTextShouldReturnNull()
        {
            Assert.Null(e.Match(null).RemainingText());
        }

        [Fact]
        public void MatchingSignShouldReturnRemainingText()
        {
            var sign = new Any("+-");
            Assert.Equal("3", sign.Match("-3").RemainingText());
        }
    }
}
