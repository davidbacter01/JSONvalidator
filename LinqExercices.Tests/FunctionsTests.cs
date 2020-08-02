using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LinqExercices.Tests
{
    public class FunctionsTests
    {
        [Fact]
        public void CountsVowelsAndConsonantsInAString()
        {
            var expected = new Dictionary<string, int>() { { "vowels", 3 }, { "consonants", 3 } };
            Assert.Equal(expected, Functions.CountConsonantsAndVowels("aeivbn"));
        }

        [Fact]
        public void GetsFirstCharThatIsNotRepeatedInAString()
        {
            Assert.Equal('b', Functions.GetFirstNonRepetedChar("abacus"));
        }
    }
}
