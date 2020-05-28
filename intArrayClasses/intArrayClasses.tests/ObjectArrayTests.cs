using Xunit;

namespace intArrayClasses.tests
{
    public class ObjectArrayTests
    {
        [Fact]
        public void ForeachWorksForObjArray()
        {
            ObjectArray test = new ObjectArray
            {
                1,
                true,
                "great"
            };

            string concat = test[0].ToString() + test[1].ToString() + test[2].ToString();
            Assert.Equal("1Truegreat", concat);
        }
    }
}
