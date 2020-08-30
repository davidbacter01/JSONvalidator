using System;
using System.Collections.Generic;
using System.Text;

namespace GetThingsDone.Commands
{
    class UpdateCmd : ICommand
    {
        public string Name { get; } = "update";
        public bool ExecuteCommand()
        {
            throw new NotImplementedException();
        }
    }
}
