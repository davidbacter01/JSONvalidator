using System;
using System.Collections.Generic;
using System.IO;

namespace GetThingsDone
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "help")
            {
                var menu = File.ReadAllLines("./Database/CommandsInfo.txt");
                foreach (var line in menu)
                {
                    Console.WriteLine(line);
                }
            }

            try
            {
                var validator = new ArgsValidator(args);
                if (!validator.AreArgumentsValid())
                {
                    Console.WriteLine("Invalid input format!");
                    Console.WriteLine("Type \"help\" to see available commands!");
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Type \"help\" to see available commands!");
            }

            var manager = new TasksManager("./Database/Tasks.txt");
        }
    }
}
