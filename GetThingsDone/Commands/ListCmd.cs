using System;
using System.Collections.Generic;
using System.Text;

namespace GetThingsDone.Commands
{
    class ListCmd : ICommand
    {
        private readonly Persistency _file;

        public ListCmd()
        {
            _file = new Persistency("./Database/Tasks.txt");
            Name = "list";
        }
        public string Name { get; }
        public bool ExecuteCommand()
        {
            var tasks = _file.RetrieveTasks();
            foreach (var t in tasks)
            {
                DisplayTask(t);
            }

            return true;
        }

        private void DisplayTask(Task task)
        {
            Console.WriteLine($"Name: {task.Title}\n" +
                              $"Added: {task.AddedDate}\n" +
                              $"Due: {task.DueDateTime}\n" +
                              $"Description: {task.Description}\n" +
                              $"Priority: {task.Priority}");
            Console.WriteLine();
        }
    }
}
