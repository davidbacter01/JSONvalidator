using System;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public void ReturnsAllPalindromesFromAString()
        {
            IEnumerable<string> expected = new List<string>() { "a", "aa", "aabaa", "a", "aba", "a","a", "b", "aa", "c" };
            Assert.Equal(expected.OrderBy(x=>x), Functions.GetPalindromes("aabaac").OrderBy(x=>x));
        }

        [Fact]
        public void ReturnsAllSequencesOfNumbersWithSumLessThenGivenInt()
        {
            var nums =new int[] { 1, 2, 3, 4 };
            var expected = new List<List<int>>()
            {
                new List<int>(){ 1 },
                new List<int>(){ 1, 2 },
                new List<int>(){ 2 },
                new List<int>(){ 3 }
            };
            Assert.Equal(expected, Functions.GetValuesWithSum(nums, 3));
        }
    }
}
