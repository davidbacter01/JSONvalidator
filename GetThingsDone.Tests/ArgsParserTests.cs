using GetThingsDone.Commands;
using Xunit;

namespace GetThingsDone.Tests
{
    public class ArgsParserTests
    {
        [Fact]
        public void ValidatesAddCommand()
        {
            var v = new ArgsParser(new[] {"add", "--title","title"});
            Assert.True(v.TryParse(out var add));
            Assert.Equal("add", add.Name);
            v = new ArgsParser(new[] {"add"});
            Assert.False(v.TryParse(out add));
            Assert.Null(add);
            v = new ArgsParser(new[] {"dasd"});
            Assert.False(v.TryParse(out add));
            Assert.Null(add);
            v = new ArgsParser(new[] {"add", "--title"});
            Assert.False(v.TryParse(out add));
            Assert.Null(add);
            v = new ArgsParser(new[] {"add", "--title", "title", "--description", "some description"});
            Assert.True(v.TryParse(out add));
            Assert.Equal("add",add.Name);
            v = new ArgsParser(new[] { "add", "--title", "title", "--description" });
            Assert.False(v.TryParse(out add));
            Assert.Null(add);
        }

        [Fact]
        public void ValidatesListCommand()
        {
            var v = new ArgsParser(new[] {"list"});
            Assert.True(v.TryParse(out var list));
            Assert.Equal("list",list.Name);
            v = new ArgsParser(new[] {"list", "something"});
            Assert.False(v.TryParse(out list));
            Assert.Null(list);
        }
        
        [Fact]
        public void ValidatesHelpCommand()
        {
            var v = new ArgsParser(new [] {"help"});
            Assert.True(v.TryParse(out var help));
            Assert.Equal("help",help.Name);
            v = new ArgsParser(new[] {"help", "something"});
            Assert.False(v.TryParse(out help));
            Assert.Null(help);
        }
        
        [Fact]
        public void ValidatesRemoveCommand()
        {
            var v = new ArgsParser(new[] {"remove", "--title", "this is title"});
            Assert.True(v.TryParse(out var remove));
            Assert.Equal("remove",remove.Name);
            v = new ArgsParser(new[] {"remove", "--title"});
            Assert.False(v.TryParse(out remove));
            Assert.Null(remove);
        }

        [Fact]
        public void ValidatesUpdate()
        {
            var v = new ArgsParser(new[] {"update", "--title", "1", "--description", "description"});
            Assert.True(v.TryParse(out var update));
            Assert.Equal("update",update.Name);
            v = new ArgsParser(new[] {"update", "-title", "this title", "--description", "some description"});
            Assert.False(v.TryParse(out update));
            Assert.Null(update);
        }
    }
}
