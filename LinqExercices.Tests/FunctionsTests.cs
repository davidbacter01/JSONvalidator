using System.Collections.Generic;
using System.Linq;
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
            IEnumerable<string> expected = new List<string>() { "a", "aa", "aabaa", "a", "aba", "a", "a", "b", "aa", "c" };
            Assert.Equal(expected.OrderBy(x => x), Functions.GetPalindromes("aabaac").OrderBy(x => x));
        }

        [Fact]
        public void ReturnsAllSequencesOfNumbersWithSumLessThenGivenInt()
        {
            var nums = new int[] { 1, 2, 3, 4 };
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
                expected.OrderByDescending(ob => ob.Name)
                .Select(prod => prod.Name),
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

        [Fact]
        public void ReturnsListOfProductsWithNoDuplicatesAndTotalQuantityFromTwoGivenLists()
        {
            var p1 = new ProductS() { Name = "laptop", Quantity = 2 };
            var p2 = new ProductS() { Name = "laptop", Quantity = 23 };
            var p3 = new ProductS() { Name = "phone", Quantity = 3 };
            var p4 = new ProductS() { Name = "phone", Quantity = 10 };
            var p5 = new ProductS() { Name = "headset", Quantity = 23 };
            var p6 = new ProductS() { Name = "mouse", Quantity = 19 };
            var first = new List<ProductS>() { p1, p3, p5 };
            var second = new List<ProductS>() { p2, p4, p6 };
            var expected = new List<ProductS>()
            {
                new ProductS() { Name = "laptop", Quantity = 25},
                new ProductS() { Name = "phone", Quantity = 13},
                new ProductS() { Name = "headset", Quantity = 23},
                new ProductS() { Name = "mouse", Quantity = 19 }
            };
            Assert.Equal(expected.Select(x => x.Name), Functions.MergeLists(first, second).Select(x => x.Name));
            Assert.Equal(expected.Select(x => x.Quantity), Functions.MergeLists(first, second).Select(x => x.Quantity));
        }

        [Fact]
        public void ReturnsListOfTestResultsContainingMaxmimumScoresAndNoDuplicates()
        {
            var scores = new List<TestResults>()
            {
                new TestResults() { Id = "test1", FamilyId = "family1", Score = 50 },
                new TestResults() { Id = "test2", FamilyId = "family1", Score = 56 },
                new TestResults() { Id = "test3", FamilyId = "family1", Score = 100 },
                new TestResults() { Id = "test1", FamilyId = "family2", Score = 34 },
                new TestResults() { Id = "test2", FamilyId = "family2", Score = 74 },
                new TestResults() { Id = "test1", FamilyId = "family3", Score = 98 },
                new TestResults() { Id = "test1", FamilyId = "family4", Score = 78 }
            };

            var expected = new List<TestResults>()
            {
                new TestResults() { Id = "test3", FamilyId = "family1", Score = 100},
                new TestResults() { Id = "test2", FamilyId = "family2", Score = 74},
                new TestResults() { Id = "test1", FamilyId = "family3", Score = 98},
                new TestResults() { Id = "test1", FamilyId = "family4", Score = 78}
            };

            var actual = Functions.RemoveLowerScores(scores);
            Assert.Equal(expected.Select(x => x.Id), actual.Select(x => x.Id));
            Assert.Equal(expected.Select(x => x.FamilyId), actual.Select(x => x.FamilyId));
            Assert.Equal(expected.Select(x => x.Score), actual.Select(x => x.Score));
        }

        [Fact]
        public void ReturnsListWithTopOfMostUsedWordsFromAText()
        {
            string text = "a,.b,c a,a!b c,a.b";
            var expected = new[] { "a : 4", "b : 3", "c : 2" };
            Assert.Equal(expected, Functions.GetMostUsedWords(text));
        }

        [Fact]
        public void ReturnsTrueIfSudokuBoardIsValidAndFalseOtherwise()
        {
            var invalidBoard = new List<IEnumerable<int>>()
            {
                new [] {1,2,3,4,5,6,7,8,9},
                new [] {2,3,4,5,6,7,8,9,1},
                new [] {3,4,5,6,7,8,9,1,2},
                new [] {4,5,6,7,8,9,1,2,3},
                new [] {5,6,7,8,9,1,2,3,4},
                new [] {6,7,8,9,1,2,3,4,5},
                new [] {7,8,9,1,2,3,4,5,6},
                new [] {8,9,1,2,3,4,5,6,7},
                new [] {9,1,2,3,4,5,6,7,8}
            };

            var validBoard = new[]
            {
                new[] { 7, 2, 6, 4, 9, 3, 8, 1, 5 },
                new[] { 3, 1, 5, 7, 2, 8, 9, 4, 6 },
                new[] { 4, 8, 9, 6, 5, 1, 2, 3, 7 },
                new[] { 8, 5, 2, 1, 4, 7, 6, 9, 3 },
                new[] { 6, 7, 3, 9, 8, 5, 1, 2, 4 },
                new[] { 9, 4, 1, 3, 6, 2, 7, 5, 8 },
                new[] { 1, 9, 4, 8, 3, 6, 5, 7, 2 },
                new[] { 5, 6, 7, 2, 1, 4, 3, 8, 9 },
                new[] { 2, 3, 8, 5, 7, 9, 4, 6, 1 },
            };

            Assert.False(Functions.IsValidSudoku(invalidBoard));
            Assert.True(Functions.IsValidSudoku(validBoard));
        }

        [Fact]
        public void GetsResultOfPolishReverseNotationEquation()
        {
            Assert.Equal(5, Functions.PostfixCalculator("2 3 +"));
            Assert.Equal(1, Functions.PostfixCalculator("12 6 6 + /"));
            Assert.Equal(3, Functions.PostfixCalculator("12 6 + 6 /"));
        }
    }
}
