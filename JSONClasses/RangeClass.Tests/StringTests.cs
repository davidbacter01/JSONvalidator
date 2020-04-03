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
            Assert.True(text.Match("asd").Success());
            Assert.Equal("", text.Match("asd").RemainingText());
        }
    }
}
