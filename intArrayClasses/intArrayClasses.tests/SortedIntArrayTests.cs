using Xunit;

namespace intArrayClasses.tests
{
    public class SortedIntArrayTests
    {
        [Fact]
        public void ArrayIsAlwaysSortedAfterAddOperation()
        {
            SortedIntArray arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(3);
            arr.Add(4);
            arr.Add(1);
            arr.Add(2);
            Assert.Equal(1, arr[0]);
            Assert.Equal(2, arr[1]);
            Assert.Equal(3, arr[2]);
            Assert.Equal(4, arr[3]);
            Assert.Equal(5, arr[4]);
        }

        [Fact]
        public void InsertOperationIsAllowedOnlyIfItDoesntBreakSorting()
        {
            SortedIntArray arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(3);
            arr.Add(6);
            arr.Add(1);
            arr.Add(2);
            arr.Insert(1, 6);
            arr.Insert(3, 4);
            Assert.Equal(1, arr[0]);
            Assert.Equal(2, arr[1]);
            Assert.Equal(3, arr[2]);
            Assert.Equal(4, arr[3]);
            Assert.Equal(5, arr[4]);
            Assert.Equal(6, arr[5]);
        }

        [Fact]
        public void InsertingAtIndexOperationIsAllowedOnlyIfItDoesntBreakSorting()
        {
            SortedIntArray arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(3);
            arr.Add(4);
            arr.Add(1);
            arr.Add(2);
            arr[3] = 10;
            arr[2] = 2;
            Assert.Equal(1, arr[0]);
            Assert.Equal(2, arr[1]);
            Assert.Equal(2, arr[2]);
            Assert.Equal(4, arr[3]);
        }
    }
}
