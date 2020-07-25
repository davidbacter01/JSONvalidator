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

            // Query using SelectMany().
            IEnumerable<char> query1 = ints.SelectMany(i=>i.Value.ToString());
            IEnumerable<char> expected = new List<char>() { '1', '2' };
            Assert.Equal(expected, query1);
        }
    }
}
