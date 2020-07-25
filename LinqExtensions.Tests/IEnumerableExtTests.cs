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
        }
    }
}
