using System;
using System.Collections.Generic;
using System.Linq;
using GetThingsDone.Commands;

namespace GetThingsDone
{
    public class ArgsParser
    {
        private readonly string[] _arguments;
        private readonly string[] _simpleCommands;
        private readonly string[] _primaryCommands;
        private readonly string[] _secondaryCommands;

        public ArgsParser(string[] args)
        {
            _arguments = args;
            _simpleCommands = new[] {"list", "help"};
            _primaryCommands = new[] {"add", "remove", "update"};
            _secondaryCommands = new[] {"--title", "--description", "--due", "--priority", "--complexity"};
        }

        public bool TryParse(out ICommand command)
        {
            if (ArgumentsAreValid())
            {
                command = GetCommand();
                return true;
            }

            command = null;
            return false;
        }

        private bool ArgumentsAreValid()
        {
            if (_arguments.Length < 1)
            {
                return false;
            }

            if (_simpleCommands.Contains(_arguments[0]))
            {
                return _arguments.Length == 1;
            }

            return _primaryCommands.Contains(_arguments[0]) && IsPrimaryCommand();
        }

        private bool IsPrimaryCommand()
        {
            return _arguments[0] switch
            {
                "add" => IsValidAdd(),
                "remove" => IsValidRemove(),
                "update" => IsValidUpdate(),
                _ => false
            };
        }

        private bool IsValidAdd()
        {
            if (_arguments.Length < 3)
            {
                return false;
            }

            if (!ArgumentsHaveParamethers())
            {
                return false;
            }

            if (!_secondaryCommands.Contains(_arguments[1]))
            {
                return false;
            }

            return HasTitle() && SecondaryArgumentsAreValid();
        }

        private bool IsValidRemove()
        {
            try
            {
                return _arguments[1] == "--title" &&
                       _arguments[2] != null &&
                       _arguments.Length == 3;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        private bool IsValidUpdate()
        {
            return HasTitle() &&
                   SecondaryArgumentsAreValid() &&
                   ArgumentsHaveParamethers();
        }
        
        private bool HasTitle()
        {
            for (int i = 1; i < _arguments.Length; i += 2)
            {
                if (_arguments[i] == "--title")
                {
                    return true;
                }
            }

            return false;
        }

        private bool SecondaryArgumentsAreValid()
        {
            for (int argIndex = 1; argIndex < _arguments.Length; argIndex += 2)
            {
                if (!_secondaryCommands.Contains(_arguments[argIndex]))
                {
                    return false;
                }
            }

            return true;
        }
        
        private bool ArgumentsHaveParamethers()
        {
            if (_arguments.Length % 2 != 1)
            {
                return false;
            }

            for (int paramIndex = 3; paramIndex < _arguments.Length; paramIndex += 2)
            {
                if (string.IsNullOrEmpty(_arguments[paramIndex]))
                {
                    return false;
                }
            }

            return true;
        }

        private ICommand GetCommand()
        {
            return _arguments[0] switch
            {
                "help" => new HelpCmd(),
                "add" => new AddCmd(_arguments[2]),
                "update" => new UpdateCmd(_arguments),
                "list" => new ListCmd(),
                "remove" => new RemoveCmd(_arguments[2]),
                _ => new HelpCmd()
            };
        }
    }
}
