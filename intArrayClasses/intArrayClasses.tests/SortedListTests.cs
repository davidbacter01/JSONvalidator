using Xunit;

namespace intArrayClasses.tests
{
    public class SortedListTests
    {
        [Fact]
        public void CanCreateSortedListOfIntegers()
        {
            var ints = new SortedList<int>
            {
                1,
                3,
                5,
                2
            };
            string appended = ints[0].ToString() + ints[1].ToString() + ints[2].ToString() + ints[3].ToString();
            Assert.Equal("1235", appended);
        }

        [Fact]
        public void CanInsertAtIndexOnlyIfItDoesntBreakSorting()
        {
            var ints = new SortedList<int>
            {
                1,
                3,
                5,
                2
            };
            //list is now 1 2 3 5
            ints.Insert(3, 4);
            //list is now 1 2 3 4 5
            string appended = ints[0].ToString() +
                ints[1].ToString() +
                ints[2].ToString() +
                ints[3].ToString() +
                ints[4].ToString();
            Assert.Equal("12345", appended);
        }

        [Fact]
        public void CanInsertDuplicatesAtAdjacentIndexes()
        {
            var ints = new SortedList<int> { 1, 2, 3 };
            ints.Insert(1, 2);//list is now 1 2 2 3
            ints.Insert(2, 2);//list is now 1 2 2 2 3
            ints.Insert(4, 2);//list is now 1 2 2 2 2 3
            string appended = ints[0].ToString() +
                ints[1].ToString() +
                ints[2].ToString() +
                ints[3].ToString() +
                ints[4].ToString() +
                ints[5].ToString();
            Assert.Equal("122223", appended);
        }

        [Fact]
        public void CanInsertAtIndexZeroIfDoesntBreakSorting()
        {
            var ints = new SortedList<int> { 1, 2, 3 };
            ints.Insert(0, 0);//list is now 0 1 2 3
            ints.Insert(0, 1);//list is unchanged
            string appended = ints[0].ToString() +
                ints[1].ToString() +
                ints[2].ToString() +
                ints[3].ToString();
            Assert.Equal("0123", appended);
        }

        [Fact]
        public void CanInsertAtCountIfDoesntBreakSorting()
        {
            var ints = new SortedList<int> { 1, 2, 3 };
            ints.Insert(3, 4);//list is now 1 2 3 4
            ints.Insert(4, 3);//list is unchanged
            string appended = ints[0].ToString() +
                ints[1].ToString() +
                ints[2].ToString() +
                ints[3].ToString();
                //ints[4] throws index out of range error
            Assert.Equal("1234", appended);
        }

        [Fact]
        public void CanSetElementIfDoesntBreakSorting()
        {
            var ints = new SortedList<int> { 1, 2, 3 };
            ints[1] = 3; //list is now 1 3 3
            string appended = ints[0].ToString() + ints[1].ToString() + ints[2].ToString();
            Assert.Equal("133", appended);
            ints[1] = 4; //list is unchanged
            appended = ints[0].ToString() + ints[1].ToString() + ints[2].ToString();
            Assert.Equal("133", appended);
            ints[1] = 1; //list is now 1 1 3
            appended = ints[0].ToString() + ints[1].ToString() + ints[2].ToString();
            Assert.Equal("113", appended);
        }

        [Fact]
        public void CanSetElementAtIndexZeroIfDoesntBreakSorting()
        {
            var ints = new SortedList<int> { 1, 2, 3 };
            ints[0] = 3; //list is unchanged
            string appended = ints[0].ToString() + ints[1].ToString() + ints[2].ToString();
            Assert.Equal("123", appended);
            ints[0] = 2; //list is 2 2 3
            appended = ints[0].ToString() + ints[1].ToString() + ints[2].ToString();
            Assert.Equal("223", appended);
            ints[0] = 0; //list is now 0 2 3
            appended = ints[0].ToString() + ints[1].ToString() + ints[2].ToString();
            Assert.Equal("023", appended);
        }
    }
}
