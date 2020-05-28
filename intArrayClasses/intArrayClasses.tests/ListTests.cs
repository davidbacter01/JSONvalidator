using Xunit;

namespace intArrayClasses.tests
{
    public class ListTests
    {
        [Fact]
        public void CanCreateIntList()
        {
            List<int> test = new List<int>() { 1, 2, 3 };
            int sum = test[0] + test[1] + test[2];
            Assert.Equal(6, sum);
        }

        [Fact]
        public void CanCreateStringList()
        {
            List<string> test = new List<string>() { "one", "two", "three" };
            string sum = test[0] + test[1] + test[2];
            Assert.Equal("onetwothree", sum);
        }
    }
}
