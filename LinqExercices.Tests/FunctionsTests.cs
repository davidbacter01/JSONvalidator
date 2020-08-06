using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace LinqExercices.Tests
{
    public class FunctionsTests
    {
        ICollection<Feature> features = new Feature[] { new Feature() { Id = 1 }, new Feature() { Id = 2 }, new Feature() { Id = 3 } };
        IEnumerable<ProductQ> products = new ProductQ[]
        {
                new ProductQ()
                {
                    Name="prod1",
                    Features=new Feature[]{new Feature() { Id = 12},new Feature() { Id = 2} }
                },
                new ProductQ()
                {
                    Name="prod2",
                    Features=new Feature[]{new Feature() { Id = 1},new Feature() { Id = 2}, new Feature() { Id = 3} }
                },
                new ProductQ()
                {
                    Name="prod3",
                    Features=new Feature[]{new Feature() { Id = 12 },new Feature() { Id = 1122} }
                },
        };

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

        [Fact]
        public void ReturnsAllSequencesOfNumbersThatEvaluateToResult()
        {
            var expected = new[] { "+1-2+3-4+5=3", "-1+2+3+4-5=3", "-1-2-3+4+5=3" };
            Assert.Equal(expected, Functions.GetValidSequenceOfSigns(5, 3));
        }

        [Fact]
        public void ReturnsAllTripletsInAnArray()
        {
            var expected = new[]
            {
                new[] { 6, 8, 10 },
                new[] { 8, 6, 10 },
                new[] { 3, 4, 5 },
                new[] { 4, 3, 5 },
                new[] { 5, 12, 13 },
                new[] { 12, 5, 13 }
            };
            Assert.Equal(expected, Functions.GetTriplets(new[] { 6, 8, 10, 3, 4, 5, 12, 13, 1 }));
        }

        [Fact]
        public void ReturnsListOfAllProductsThatHaveAtLeastOneFeatureFromGivenList()
        {
            var expected = new ProductQ[]
            {
                new ProductQ()
                {
                    Name="prod1",
                    Features=new Feature[]{new Feature() { Id = 12},new Feature() { Id = 2} }
                },
                new ProductQ()
                {
                    Name="prod2",
                    Features=new Feature[]{new Feature() { Id = 1},new Feature() { Id = 2}, new Feature() { Id = 3} }
                }
            };

            Assert.Equal(
                expected.OrderByDescending(ob=>ob.Name)
                .Select(prod=>prod.Name), 
                Functions.GetWithMinimumOneFeature(products, features)
                .OrderByDescending(ob => ob.Name)
                .Select(prod => prod.Name));
        }

        [Fact]
        public void ReturnsListOfAllProductsThatHaveAllFeaturesFromGivenList()
        {
            var expected = new ProductQ[]
            {
                new ProductQ()
                {
                    Name="prod2",
                    Features=new Feature[]{new Feature() { Id = 1},new Feature() { Id = 2}, new Feature() { Id = 3} }
                }
            };

            Assert.Equal(
                expected.OrderByDescending(ob => ob.Name)
                .Select(prod => prod.Name),
                Functions.GetWithAllFeatures(products, features)
                .OrderByDescending(ob => ob.Name)
                .Select(prod => prod.Name));
        }

        [Fact]
        public void ReturnsListOfAllProductsThatHaveNoFeaturesFromGivenList()
        {
            var expected = new ProductQ[]
            {
                new ProductQ()
                {
                    Name="prod3",
                    Features=new Feature[]{new Feature() { Id = 12},new Feature() { Id = 1122}}
                }
            };

            Assert.Equal(
                expected.OrderByDescending(ob => ob.Name)
                .Select(prod => prod.Name),
                Functions.GetWithNoFeatures(products, features)
                .OrderByDescending(ob => ob.Name)
                .Select(prod => prod.Name));
        }
    }
}
