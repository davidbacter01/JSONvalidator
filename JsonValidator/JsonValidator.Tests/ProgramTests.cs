using System;
using Xunit;

namespace JsonValidator.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void CorrectJSONStringShouldReturnCorrect()
        {
            string test = "\"Test\"";
            Assert.Equal("Valid JSON string", Program.CheckJSONValidity(test));
        }

        [Fact]
        public void ValidJSONStringWithLineBreakShouldReturnValid()
        {
            string test = "\"Test\\u0097\nAnother line\"";
            Assert.Equal("Valid JSON string", Program.CheckJSONValidity(test));
        }

        [Fact]
        public void InValidJSONStringWithQuotationMissingAtStarShouldReturnInvalid()
        {
            string test = "Test\"";
            Assert.Equal("Invalid JSON string!", Program.CheckJSONValidity(test));
        }
    }
}
