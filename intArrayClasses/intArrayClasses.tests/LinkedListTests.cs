using System.Reflection;
using Xunit;

namespace intArrayClasses.tests
{
    public class LinkedListTests
    {
        [Fact]
        public void AddsItemsToLinkedList()
        {
            var list = new LinkedList<int>
            {
                1,
                2,
                3
            };

            int result = 0;
            foreach (var item in list)
            {
                result += item;
            }

            Assert.Equal(3, list.Count);
            Assert.Equal(6, result);
        }

        [Fact]
        public void ReturnsTrueWhenLinkedListContainsElementAndFalseOtherwise()
        {
            var list = new LinkedList<int>
            {
                1,
                2,
                3
            };

            Assert.Contains(1, list);
            Assert.DoesNotContain(0, list);
        }

        [Fact]
        public void ClearsALinkedList()
        {
            var list = new LinkedList<int>
            {
                1,
                2,
                3
            };

            list.Clear();
            Assert.True(list.Count == 0);
            Assert.DoesNotContain(1, list);
            Assert.DoesNotContain(2, list);
            Assert.DoesNotContain(3, list);
        }

        [Fact]
        public void GetsFirstAndLastElementOfLinkedList()
        {
            var list = new LinkedList<int>
            {
                1,
                2,
                3
            };

            Assert.Equal(1, list.First.Value);
            Assert.Equal(3, list.Last.Value);
        }

        [Fact]
        public void RemovesAnElementFromLinkedList()
        {
            var list = new LinkedList<int>
            {
                1,
                2,
                3
            };

            list.Remove(3);
            Assert.True(list.Count == 2);
            Assert.DoesNotContain(3, list);
            Assert.Contains(1, list);
            Assert.Contains(2, list);
        }

        [Fact]
        public void AddsToStartOfLinkedList()
        {
            var list = new LinkedList<int>
            {
                1,
                2,
                3
            };

            list.AddFirst(4);
            var expected = new LinkedList<int> { 4, 1, 2, 3 };
            Assert.Equal(expected, list);
        }

        [Fact]
        public void AddsNewNodeWithSpecifiedValueBeforeSpecifiedNode()
        {
            var list = new LinkedList<int>
            {
                1,
                2,
                3
            };
            list.AddBefore(list.Find(2), 3);
            var expected = new LinkedList<int> { 1, 3, 2, 3 };
            Assert.Equal(expected, list);
        }

        [Fact]
        public void CopiesInAnArrayAtSpecifiedIndex()
        {
            var list = new LinkedList<int> { 1, 2, 3 };
            int[] arr = { 3, 2, 1 };
            list.CopyTo(arr, 0);
            int[] expected = { 1, 2, 3};
            Assert.Equal(expected, arr);
        }
    }
}
