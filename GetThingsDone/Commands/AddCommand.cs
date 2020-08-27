using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GetThingsDone.Commands
{
    public class AddCommand : ICommand
    {
        private readonly Task _toAdd;
        private readonly Persistency _tasksPersistency;
        private readonly HashSet<Task> _tasks;
        public AddCommand(string title)
        {
            _toAdd = new Task() {Title = title, AddedDate = DateTime.Now};
            _tasksPersistency = new Persistency("./Database/Tasks.txt");
            _tasks = new HashSet<Task>(_tasksPersistency.RetrieveTasks());
        }

        public string Name { get; } = "add";
        public bool ExecuteCommand()
        {
            if (!_tasks.Add(_toAdd))
                return false;

            _tasksPersistency.WriteTasksToFile(_tasks);
            return true;
        }
    }
}
