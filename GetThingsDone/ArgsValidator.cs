using System;
using System.Linq;

namespace GetThingsDone
{
    public class ArgsValidator
    {
        private readonly string[] _arguments;
        private readonly string[] _simpleCommands;
        private readonly string[] _primaryCommands;
        private readonly string[] _secondaryCommands;

        public ArgsValidator(string[] args)
        {
            _arguments = args;
            _simpleCommands = new[] {"list", "help"};
            _primaryCommands = new[] {"add", "remove", "update"};
            _secondaryCommands = new[] {"--title", "--description", "--due_date", "--priority", "--complexity"};
        }

        public bool AreArgumentsValid()
        {
            if (_simpleCommands.Contains(_arguments[0]))
            {
                return _arguments.Length == 1;
            }

            if (_primaryCommands.Contains(_arguments[0]))
            {
                return ValidatePrimaryCommands();
            }

            return false;
        }

        private bool ValidatePrimaryCommands()
        {
            return _arguments[0] switch
            {
                "add" => ValidateAdd(),
                "remove" => ValidateRemove(),
                "update" => ValidateUpdate(),
                _ => false
            };
        }

        private bool ValidateUpdate()
        {
            throw new NotImplementedException();
        }

        private bool ValidateRemove()
        {
            return _arguments[1] == "--title" &&
                   _arguments[2] != null &&
                   _arguments.Length == 3;
        }

        private bool ValidateAdd()
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

            return HasTitle() && ValidateSecondaryArguments();
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

        private bool ValidateSecondaryArguments()
        {
            for (int i = 1; i < _arguments.Length; i += 2)
            {
                if (!_secondaryCommands.Contains(_arguments[i]))
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

            for (int i = 3; i < _arguments.Length; i++)
            {
                if (string.IsNullOrEmpty(_arguments[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
