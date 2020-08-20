using System;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace GetThingsDone
{
    public static class TasksManager
    {
        private static readonly string[] Commands = {"-add", "-remove"};
        private const string Path = "./Database/Tasks.txt";

        public static bool ProcessCommand(string[] command)
        {
            if (!Commands.Contains(command[0]))
            {
                return false;
            }

            switch (command[0])
            {
                case "-add":
                    Console.WriteLine(Add(command[1]) ? "task added" : "task already exists");
                    break;
                case "-remove":
                    Remove(command[1]);
                    break;
            }

            return true;
        }

        private static bool Add(string title)
        {
            var task = new Task(title);
            var jsonTask = JsonSerializer.Serialize(task);
            var taskList = File.ReadAllLines(Path);
            if (taskList.Contains(jsonTask))
            {
                return false;
            }

            File.AppendAllText(Path, jsonTask + "\n");
            return true;
        }

        private static void Remove(string title)
        {
            throw new NotImplementedException();
        }
    }
}
