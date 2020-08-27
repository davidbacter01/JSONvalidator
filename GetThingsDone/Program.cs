using System;
using System.Collections.Generic;
using System.IO;

namespace GetThingsDone
{
    public class Program
    {
        static void Main(string[] args)
        {
            var argsValidator = new ArgsValidator(args);
            if (argsValidator.AreArgumentsValid())
            {
                var organizer = new TaskOrganizer(
                    "./Database/Tasks.txt",
                    "./Database/Complex.txt",
                    "./Database/Projects.txt");
                organizer.ProcessCommands(args);
            }
            else
            {
                Console.WriteLine("Invalid command! Run help for commands list!");
            }
        }
    }
}
