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
    }
}
