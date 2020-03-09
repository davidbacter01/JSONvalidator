using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class TextTests
    {
        private static IPattern tru = new Text("true");

        [Fact]
        public void EntireTextMatchingPrefixShouldReturnEmptyText()
        {
            Assert.Equal("", tru.Match("true").RemainingText());
        }

        [Fact]
        public void TextMatchingPrefixShouldReturnRemainingText()
        {
            Assert.Equal("X", tru.Match("trueX").RemainingText());
        }

        [Fact]
        public void TextNotMatchingPrefixShouldReturnInitialText()
        {
            Assert.Equal("false", tru.Match("false").RemainingText());
        }

        [Fact]
        public void EmptyTextShouldReturnEmptyText()
        {
            Assert.Equal("", tru.Match("").RemainingText());
        }

        [Fact]
        public void NullShouldReturnNull()
        {
            Assert.Null(tru.Match(null).RemainingText());
        }

        [Fact]
        public void EmptyPrefixMatchingTextShouldReturnInitialText()
        {
            var empty = new Text("");
            Assert.Equal("true", empty.Match("true").RemainingText());
        }
    }
}
