using System;
using System.Collections.Generic;
using System.Text;

namespace GetThingsDone
{
    public static class UiProcessor
    {
        private static readonly TasksManager Manager = new TasksManager();

        public static void ProcessCommand(string[] command)
        {
            try
            {
                if (!Manager.ContainsCommand(command[0]))
                {
                    Console.WriteLine("Invalid command! Please type -help to see available options");
                    return;
                }
            }
            catch (IndexOutOfRangeException)
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
                case "-help":
                    DisplayCommands(Manager.GetCommands());
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
    }
}
