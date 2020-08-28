using Xunit;

namespace GetThingsDone.Tests
{
    public class ArgsValidatorTests
    {
        [Fact]
        public void ValidatesAddCommand()
        {
            var v = new ArgsValidator(new[] {"add", "--title","title"});
            Assert.True(v.AreArgumentsValid());
            v = new ArgsValidator(new[] {"add"});
            Assert.False(v.AreArgumentsValid());
            v = new ArgsValidator(new[] {"dasd"});
            Assert.False(v.AreArgumentsValid());
            v = new ArgsValidator(new[] {"add", "--title"});
            Assert.False(v.AreArgumentsValid());
            v = new ArgsValidator(new[] {"add", "--title", "title", "--description", "some description"});
            Assert.True(v.AreArgumentsValid());
            v = new ArgsValidator(new[] { "add", "--title", "title", "--description" });
            Assert.False(v.AreArgumentsValid());
        }

        [Fact]
        public void ValidatesListCommand()
        {
            var v = new ArgsValidator(new[] {"list"});
            Assert.True(v.AreArgumentsValid());
            v = new ArgsValidator(new[] {"list", "something"});
            Assert.False(v.AreArgumentsValid());
        }

        [Fact]
        public void ValidatesHelpCommand()
        {
            var v = new ArgsValidator(new [] {"help"});
            Assert.True(v.AreArgumentsValid());
            v = new ArgsValidator(new[] {"help", "something"});
            Assert.False(v.AreArgumentsValid());
        }

        [Fact]
        public void ValidatesRemoveCommand()
        {
            var v = new ArgsValidator(new[] {"remove", "--title", "this is title"});
            Assert.True(v.AreArgumentsValid());

        }
    }
}
