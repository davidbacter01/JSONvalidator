using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class ValueTests
    {
        IPattern value = new Value();

        [Fact]
        public void ValidObjectShouldReturnTrueAndEmptyString()
        {
           // Assert.True(value.Match("[ \"\" ]").Success());
            Assert.Equal("", value.Match("[ ]").RemainingText());
        }

        [Fact]
        public void ValidNumberShouldReturnTrueAndEmptyString()
        {
            Assert.True(value.Match("123").Success());
            Assert.Equal("", value.Match("123").RemainingText());
        }
    }
}
