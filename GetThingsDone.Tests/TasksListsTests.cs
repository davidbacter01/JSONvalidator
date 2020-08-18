using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GetThingsDone.Tests
{
    public class TasksListsTests
    {
        [Fact]
        public void CreatesListOfTasksFromListOfStrings()
        {
            var strings = new[] {"task 1", "task 2", "task 3"};
            var expected = new[] {new Task("task 1"), new Task("task 2"), new Task("task 3")};
            var tasks=new TasksLists();
            tasks.CaptureTasks(strings);
            Assert.Equal(expected.Count(),tasks.Tasks.Count());
        }
    }
}
