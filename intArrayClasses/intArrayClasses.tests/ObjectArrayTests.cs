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
            string concat = "";
            foreach(var value in test)
            {
                concat += value.ToString();
            }

            Assert.Equal("1Truegreat", concat);
        }
    }
}
