using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetThingsDone.Commands
{
    class RemoveCmd : ICommand
    {
        private readonly Persistency _file;
        private readonly string _taskName;
        public string Name { get; }

        public RemoveCmd(string taskName)
        {
            _file = new Persistency("./Database/Tasks.txt");
            _taskName = taskName;
            Name = "remove";
        }
        
        public bool ExecuteCommand()
        {
            var tasks = _file.RetrieveTasks();
            var updatedTasks = tasks.Where(t => t.Title != _taskName);
            if (tasks.Equals(updatedTasks))
            {
                return false;
            }

            _file.WriteTasksToFile(updatedTasks);
            return true;
        }
    }
}
