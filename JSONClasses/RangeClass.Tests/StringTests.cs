using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class StringTests
    {
        IPattern text = new String();

        [Fact]
        public void SimpleTextShouldReturnTrueAndEmptyString()
        {
            Assert.True(text.Match("\"asd\"").Success());
            Assert.Equal("", text.Match("\"asd\"").RemainingText());
        }

        [Fact]
        public void EmptyStringBetweenQuotesShouldReturnTrueAndEmptyString()
        {
            Assert.True(text.Match("\"\"").Success());
            Assert.Equal("", text.Match("\"\"").RemainingText());
        }

        [Fact]
        public void SpaceBetweenQuotesShouldReturnTrueAndEmptyString()
        {
            Assert.True(text.Match("\" \"").Success());
            Assert.Equal("", text.Match("\" \"").RemainingText());
        }

        [Fact]
        public void MultipleSpacesBetweenQuotesShouldReturnTrueAndEmptyString()
        {
            Assert.True(text.Match("\"     \"").Success());
            Assert.Equal("", text.Match("\"    \"").RemainingText());
        }

        [Fact]
        public void StringWithMoreComplexFormShouldReturnTrueAndEmptyString()
        {
            Assert.True(text.Match("\"as321#';!qwe AR\"").Success());
            Assert.Equal("", text.Match("\"as321#';!qwe AR\"").RemainingText());
        }

        [Fact]
        public void StringWithInvalidCharactersAndComplexFormShouldReturnFalseAndInitialString()
        {
            Assert.False(text.Match("\"as321\\#';!qwe AR\"").Success());
            Assert.Equal("\"as321\\#';/!qwe AR\"", text.Match("\"as321\\#';!qwe AR\"").RemainingText());
        }

        [Fact]
        public void StringWithEscapedCharactersShouldReturnTrueAndEmptyString()
        {
            Assert.True(text.Match("\"Hex\u0ADa\"").Success());
        }
    }
}
