using System;
using System.Collections.Generic;
using System.Text;

namespace GetThingsDone.Commands
{
    class HelpCmd : ICommand
    {
        public string Name { get; } = "help";
        public bool ExecuteCommand()
        {
            throw new NotImplementedException();
        }
    }
}
