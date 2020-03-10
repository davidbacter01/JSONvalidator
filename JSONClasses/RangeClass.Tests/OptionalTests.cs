using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class OptionalTests
    {
      /*  var a = new Optional(new Character('a'));
        a.Match(null); // true / null
        */

        [Fact]
        public void MatchingCharacterAtThextStartShouldReturnRestOfText()
        {
            var a = new Optional(new Character('a'));
            Assert.Equal("bc", a.Match("abc").RemainingText());
        }

        [Fact]
        public void MatchingCharacterAtThextStartShouldConsumeOnlyOnce()
        {
            var a = new Optional(new Character('a'));
            Assert.Equal("abc", a.Match("aabc").RemainingText());
        }

        [Fact]
        public void NotMatchingCharacterAtThextStartShouldReturnInitialText()
        {
            var a = new Optional(new Character('a'));
            Assert.Equal("bc", a.Match("bc").RemainingText());
        }

        [Fact]
        public void EmptyTextShouldReturnEmptyText()
        {
            var a = new Optional(new Character('a'));
            Assert.Equal("", a.Match("").RemainingText());
        }

        [Fact]
        public void NullShouldReturnNull()
        {
            var a = new Optional(new Character('a'));
            Assert.Null(a.Match(null).RemainingText());
            Assert.True(a.Match(null).Success());
        }
    }
}
