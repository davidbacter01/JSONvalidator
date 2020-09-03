using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace GetThingsDone.Commands
{
    public class AddCmd : ICommand
    {
        private readonly Task _toAdd;
        private readonly Persistency _tasksPersistency;
        private readonly HashSet<Task> _tasks;
        public AddCmd(string title)
        {
            _toAdd = new Task() {Title = title, AddedDate = DateTime.Now};
            _tasksPersistency = new Persistency("./Database/Tasks.txt");
            try
            {
                _tasks = new HashSet<Task>(_tasksPersistency.RetrieveTasks());
            }
            catch (JsonException)
            {
                _tasks=new HashSet<Task>();
            }
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
