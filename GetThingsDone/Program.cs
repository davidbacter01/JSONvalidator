using System;
using System.Collections.Generic;
using System.IO;
using GetThingsDone.Commands;

namespace GetThingsDone
{
    public class Program
    {
        static void Main(string[] args)
        {
            var parser = new ArgsParser(args);
            try
            {
                var commands = parser.Parse();
                foreach (var command in commands)
                {
                    Console.WriteLine(command.ExecuteCommand() ? "executed command {0}" : "failed to execute {0}",
                        command.Name);
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Argument format invalid! Type help for more info!");
            }
        }
    }
}
