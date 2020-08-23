using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace GetThingsDone
{
    public  class TasksManager
    {
        private readonly Dictionary<string, string> _commands;
        private const string Path = "./Database/Tasks.txt";

        public TasksManager()
        {
            _commands = new Dictionary<string, string>
            {
                {"-add", "adds a task with the specified title to the database (ex: -add \"new task\")"},
                {"-remove","removes the task with the specified title from the database (ex: -remove \"existing task\")"},
                {"-list","view all saved tasks"},
                {"-help","see all available commands"}
            };
        }

        public IEnumerable<Task> GetTasks()
        {
            return File.ReadAllLines(Path).Select(x => JsonSerializer.Deserialize<Task>(x));
        }

        public IEnumerable<string> GetCommands()
        {
            return _commands.Select(x => $"{x.Key}\n{x.Value}");
        }

        public bool Add(string title)
        {
            var task = new Task() {Title = title};
            var jsonTask = JsonSerializer.Serialize(task);
            var taskList = File.ReadAllLines(Path);
            if (taskList.Contains(jsonTask))
            {
                return false;
            }

            File.AppendAllText(Path, jsonTask + "\n");
            return true;
        }

        public bool Remove(string title)
        {
            var taskList = File.ReadAllLines(Path);
            var updatedTasks = taskList.Where(t => !t.Contains($"\"Title\":\"{title}\"")).ToArray();
            if (taskList == updatedTasks)
            {
                return false;
            }

            File.WriteAllLines(Path, updatedTasks);
            return true;
        }
    }
}
