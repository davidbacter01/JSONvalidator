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
        public void ArrayIsAlwaysSortedAfterInsertOperation()
        {
            SortedIntArray arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(3);
            arr.Add(4);
            arr.Add(1);
            arr.Add(2);
            arr.Insert(1, 6);
            Assert.Equal(1, arr[0]);
            Assert.Equal(2, arr[1]);
            Assert.Equal(3, arr[2]);
            Assert.Equal(4, arr[3]);
            Assert.Equal(5, arr[4]);
            Assert.Equal(6, arr[5]);
        }

        [Fact]
        public void ArrayIsAlwaysSortedAfterInsertingAtIndexOperation()
        {
            SortedIntArray arr = new SortedIntArray();
            arr.Add(5);
            arr.Add(3);
            arr.Add(4);
            arr.Add(1);
            arr.Add(2);
            arr[3] = 10;
            Assert.Equal(1, arr[0]);
            Assert.Equal(2, arr[1]);
            Assert.Equal(3, arr[2]);
            Assert.Equal(5, arr[3]);
            Assert.Equal(10, arr[4]);
        }
    }
}
