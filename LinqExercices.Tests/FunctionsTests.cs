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

        [Fact]
        public void ConvertsStringToInt()
        {
            Functions.TryStringToInt("1234", out int result);
            Functions.TryStringToInt("97861", out int second);
            Assert.Equal(1234, result);
            Assert.Equal(97861, second);
        }

        [Fact]
        public void GetsTheCharWithMostOccurrences()
        {
            Assert.Equal('x', Functions.GetMaximumOccurencesChar("asdfxasxxghjjuxxx"));
        }
    }
}
