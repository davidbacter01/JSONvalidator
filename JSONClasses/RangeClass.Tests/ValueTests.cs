using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class ValueTests
    {
        readonly IPattern value = new Value();

        [Fact]
        public void ValidNumberShouldReturnTrueAndEmptyString()
        {
            Assert.True(value.Match("123").Success());
            Assert.Equal("", value.Match("123").RemainingText());
        }

        [Fact]
        public void ValidObjectShouldReturnTrueAndEmptyString()
        {
            Assert.True(value.Match("[ 123 ]").Success());
            Assert.Equal("", value.Match("[ 123 ]").RemainingText());
        }

        [Fact]
        public void ValidArrayShouldReturnTrueAndEmptyString()
        {
            Assert.True(value.Match("[ \"somethin\" ]").Success());
            Assert.Equal("", value.Match("[ \"somethin\" ]").RemainingText());
        }

        [Fact]
        public void ValidComplexObjectShouldReturnTrueAndEmptyString()
        {
            Assert.True(value.Match("{ \"john\":123 }").Success());
            Assert.Equal("", value.Match("{ \"john\":123 }").RemainingText());
        }

        [Fact]
        public void ValidExtraComplexObjectShouldReturnTrueAndEmptyString()
        {
            Assert.True(value.Match(
            "[{\"color\": \"magenta\",\"value\": \"#f0f\"},{\"color\": \"yellow\",\"value\": \"#ff0\"},{ \"color\": \"black\",\"value\": \"#000\"}]").Success());
            Assert.Equal("", value.Match("[{\"color\": \"magenta\",\"value\": \"#f0f\"},{\"color\": \"yellow\",\"value\": \"#ff0\"},{ \"color\": \"black\",\"value\": \"#000\"}]").RemainingText());
        }



    }
}
