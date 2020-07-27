using System;
using System.Collections.Generic;
using Xunit;

namespace LinqExtensions.Tests
{
    public class IEnumerableExtTests
    {
        [Fact]
        public void AllReturnsTrueIfAllElementsFullfillCalbackAndFalseOtherwise()
        {
            IEnumerable<int> ints = new List<int>() { 2, 3, 4, 5, 6 };
            Assert.True(ints.All(e => e > 1));
            Assert.False(ints.All(e => e < 3));
            ints = null;
            Assert.Throws<ArgumentNullException>(() => ints.All(e => e > 3));
        }

        [Fact]
        public void AnyReturnsTrueIfElementFulfillsCallbackAndFalseIfNoneFulfills()
        {
            IEnumerable<int> ints = new List<int>() { 2, 3, 4, 5, 6 };
            Assert.True(ints.Any(e => e == 3));
            Assert.False(ints.Any(e => e > 6));
            ints = null;
            Assert.Throws<ArgumentNullException>(() => ints.Any(e => e > 3));
        }

        [Fact]
        public void FirstReturnsFirstElementFulfillingCondition()
        {
            IEnumerable<int> ints = new List<int>() { 2, 3, 4, 5, 6 };
            Assert.Equal(4, ints.First(e => e > 3));
            Assert.Throws<InvalidOperationException>(() => ints.First(e => e > 7));
        }

        [Fact]
        public void SelectReturnsAnEnumerableWithElementsInNewForm()
        {
            IEnumerable<int> ints = new List<int>() { 2, 3, 4, 5, 6 };
            IEnumerable<int> result = new List<int>() { 3, 4, 5, 6, 7 };
            Assert.Equal(result ,ints.Select(e => e + 1));
        }

        [Fact]
        public void SelectManyReturnsEnumerableOfManyElementsResultedFromSelector()
        {

            Dictionary<int, int> ints = new Dictionary<int, int>
            {
                { 1, 1 },
                { 2, 2 }
            };
            IEnumerable<char> query1 = ints.SelectMany(i => i.Value.ToString());
            IEnumerable<char> expected = new List<char>() { '1', '2' };
            Assert.Equal(expected, query1);
        }

        [Fact]
        public void ReturnsEnumerableOfElementsThatFullfillCondition()
        {
            List<string> fruits = new List<string> { "apple", "passionFruit", "banana", "mango",
                    "orange", "blueberry", "grape", "strawberry" };

            IEnumerable<string> query = fruits.Where(fruit => fruit.Length < 6);
            IEnumerable<string> expected = new List<string>() { "apple", "mango", "grape" };
            Assert.Equal(expected, query);
        }

        [Fact]
        public void ReturnsDictionaryContainingKeysAndValueExtractedByCallbacks()
        {
            IEnumerable<List<int>> arr = new List<List<int>>
            {
                new List<int>() { 10, 20 },
                new List<int>() { 11, 22 },
                new List<int>() { 12, 23 },
                new List<int>() { 13, 25 }
            };

            Dictionary<int, int> expected = new Dictionary<int, int>()
            {
                { 10, 20},
                { 11, 22 },
                { 12, 23 },
                { 13, 25 }
            };

            Dictionary<int,int> actual = arr.ToDictionary(k => k[0], v => v[1]);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnsEnumerableOfZipedElementsBySelector()
        {
            IEnumerable<int> ints1 = new List<int>() { 1, 2, 3, 4, 5 };
            IEnumerable<int> ints2 = new List<int>() { 4, 3, 2, 1 };
            IEnumerable<int> actual = ints1.Zip(ints2, (a, b) => a + b);
            IEnumerable<int> expected = new List<int>() { 5, 5, 5, 5 };
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AggregatesElementsFromSourceToSeed()
        {
            IEnumerable<int> ints = new List<int>() { 1, 2, 3, 4, 5 };
            int seed = 0;
            Assert.Equal(15, ints.Aggregate(seed, (e, s) => e + s));
        }

        [Fact]
        public void ReturnsAJoinedListOfTwoSourcesByComparingKeys()
        {
            IEnumerable<int> outer = new List<int>(){ 5, 3, 7 };
            IEnumerable<string> inner = new List<string>(){ "bee", "giraffe", "tiger", "badger", "ox", "cat", "dog" };
            var actual = outer.Join(inner,
                                   outerElement => outerElement,
                                   innerElement => innerElement.Length,
                                   (outerElement, innerElement) => outerElement + ":" + innerElement);
            IEnumerable<string> expected = new List<string>() { "5:tiger", "3:bee", "3:cat", "3:dog", "7:giraffe" };
            Assert.Equal(expected,actual);
        }
    }
}
