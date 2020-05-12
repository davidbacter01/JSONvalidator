using System;
using Xunit;

namespace intArrayClasses.tests
{
    public class IntArrayTests
    {
        [Fact]
        public void AddsAnElementAtTheBegginingOfEmptyArray()
        {
            IntArray arr = new IntArray();
            arr.Add(7);
            Assert.Equal(7, arr[0]);
        }

        [Fact]
        public void AddsAnElementAtFirstEmptyPosition()
        {
            IntArray arr = new IntArray();
            arr.Add(7);
            arr.Add(1);
            Assert.Equal(1, arr[1]);
        }

        [Fact]
        public void ExtendsArrayByFourPositionsWhenNoAvailableSpace()
        {
            IntArray arr = new IntArray();
            arr.Add(7);
            arr.Add(1);
            arr.Add(5);
            arr.Add(6);
            arr.Add(20);
            Assert.Equal(20, arr[4]);
            Assert.Equal(0, arr[7]);
        }

        [Fact]
        public void ReturnsZeroWhenNoElementsWereAdded()
        {
            IntArray arr = new IntArray();
            Assert.Equal(0, arr.Count);
        }

        [Fact]
        public void DoesNotCountEmptyPositionsAtEndOfArray()
        {
            IntArray arr = new IntArray();
            arr.Add(7);
            arr.Add(1);
            arr.Add(5);
            arr.Add(6);
            arr.Add(20);
            Assert.Equal(5, arr.Count);
        }

        [Fact]
        public void ReturnsTrueWhenElementIsFoundAndFalseWhenNot()
        {
            IntArray arr = new IntArray();
            arr.Add(7);
            arr.Add(1);
            arr.Add(5);
            arr.Add(6);
            Assert.True(arr.Contains(5));
            Assert.False(arr.Contains(2));
        }

        [Fact]
        public void ReturnsIndexOfElementOrMinusOne()
        {
            IntArray arr = new IntArray();
            arr.Add(7);
            arr.Add(1);
            arr.Add(5);
            arr.Add(6);
            Assert.Equal(0, arr.IndexOf(7));
            Assert.Equal(-1, arr.IndexOf(2));
        }

        [Fact]
        public void InsertsElementAtSpecifiedIndex()
        {
            IntArray arr = new IntArray();
            arr.Add(7);
            arr.Add(1);
            arr.Add(5);
            arr.Add(6);
            arr.Insert(2, 10);
            Assert.Equal(10, arr[2]);
            Assert.Equal(5, arr[3]);
        }

        [Fact]
        public void DeletesAllElementsInArray()
        {
            IntArray arr = new IntArray();
            arr.Add(7);
            arr.Add(1);
            arr.Add(5);
            arr.Add(6);
            arr.Insert(2, 10);
            arr.Clear();
            Assert.Equal(0, arr[2]);
            Assert.Equal(0, arr[3]);
        }

        [Fact]
        public void DeletesElementAtSpecifiedIndexInArray()
        {
            IntArray arr = new IntArray();
            arr.Add(7);
            arr.Add(1);
            arr.Add(5);
            arr.Add(6);
            arr.RemoveAt(0);
            arr.RemoveAt(1);
            Assert.Equal(1, arr[0]);
            Assert.Equal(6, arr[1]);
            Assert.Equal(0, arr[2]);
            Assert.Equal(0, arr[3]);
        }

        [Fact]
        public void ZeroIsValidElementInArray()
        {
            IntArray arr = new IntArray();
            arr.Add(1);
            arr.Add(0);
            arr.Add(0);
            arr.Add(2);
            Assert.Equal(1, arr[0]);
            Assert.Equal(0, arr[1]);
            Assert.Equal(0, arr[2]);
            Assert.Equal(2, arr[3]);
        }
    }
}
