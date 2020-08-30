using System;
using System.Collections.Generic;
using System.Text;

namespace GetThingsDone.Commands
{
    class RemoveCmd : ICommand
    {
        public string Name { get; } = "remove";
        public bool ExecuteCommand()
        {
            throw new NotImplementedException();
        }
    }
}
