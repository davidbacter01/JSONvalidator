using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class CharacterTests
    {
        private readonly Character x= new Character('x');
        [Fact]
        public void ValidCharacterMatchShouldReturnRemainingText()
        { 
            Assert.Equal("ilo", x.Match("xilo").RemainingText());
        }

        [Fact]
        public void InvalidCharacterMatchShouldReturnOriginalText()
        {
            Assert.Equal("filo", x.Match("filo").RemainingText());
        }

        [Fact]
        public void CharacterMatchWithNullShouldReturnNull()
        {
            Assert.Null(x.Match(null).RemainingText());
        }
    }
}
