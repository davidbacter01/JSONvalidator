using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GetThingsDone.Commands
{
    class HelpCmd : ICommand
    {
        public string Name { get; } = "help";
        public bool ExecuteCommand()
        {
            var path = "./Database/CommandsInfo.txt";
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            return true;
        }
    }
}
