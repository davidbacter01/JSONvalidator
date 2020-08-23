using System;
using System.Collections.Generic;
using System.Globalization;

namespace GetThingsDone
{
    public static class UiProcessor
    {
        private static readonly TasksManager Manager = new TasksManager();

        public static void ProcessCommand(string[] command)
        {
            if (command.Length == 0)
            {
                Console.WriteLine("Please type -help to see what this app can do!");
                return;
            }

            switch (command[0])
            {
                case "-add":
                    Console.WriteLine(Manager.Add(command[1]) ? "task added" : "task already exists");
                    break;
                case "-remove":
                    Console.WriteLine(Manager.Remove(command[1]) ? "task removed" : "task doesn't exist");
                    break;
                case "-list":
                    DisplayTasks(Manager.GetTasks());
                    break;
                case "-help":
                    DisplayCommands(Manager.GetCommands());
                    break;
                default:
                    Console.WriteLine("Invalid command! type -help to see available options.");
                    break;
            }
        }

        private static void DisplayCommands(IEnumerable<string> commands)
        {
            foreach (var command in commands)
            {
                Console.WriteLine(command);
            }
        }

        private static void DisplayTasks(IEnumerable<Task> tasks)
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($" Task: {task.Title}" +
                                  $"\n Priority: {task.Priority}\n" +
                                  $"Added: {task.AddedDate.ToString(CultureInfo.InvariantCulture)}\n"+
                                  $"Due Date: {task.DueDateTime.ToString(CultureInfo.InvariantCulture)}"+
                                  $" Description:\n{task.Description}");
            }
        }
    }
}
