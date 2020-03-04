using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void ValidCharacterMatchShouldReturnTrue()
        {
            Character x = new Character('x');
            bool expected = true;
            Assert.Equal(expected, x.Match("xilo"));
        }

        [Fact]
        public void InvalidCharacterMatchShouldReturnFalse()
        {
            Character x = new Character('x');
            bool expected = false;
            Assert.Equal(expected, x.Match("filo"));
        }

        [Fact]
        public void CharacterMatchWithNullShouldReturnFalse()
        {
            Character x = new Character('x');
            bool expected = false;
            Assert.Equal(expected, x.Match(null));
        }
    }
}
