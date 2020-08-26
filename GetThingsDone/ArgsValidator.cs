using System;
using System.Linq;

namespace GetThingsDone
{
    public class ArgsValidator
    {
        private readonly string[] _arguments;
        private readonly string[] _primaryCommands;
        private readonly string[] _secondaryCommands;

        public ArgsValidator(string[] args)
        {
            _arguments = args ?? throw new ArgumentNullException(nameof(args));
            _primaryCommands = new[] {"add", "remove", "update", "list", "help"};
            _secondaryCommands = new[] {"--title", "--description", "--due_date", "--priority", "--complexity"};
        }

        public bool AreArgumentsValid()
        {
            if (!_primaryCommands.Contains(_arguments[0]))
            {
                return false;
            }

            return ValidateSecondaryArguments();
        }

        private bool ValidateSecondaryArguments()
        {
            for (int i = 2; i < _arguments.Length; i += 2)
            {
                if (!_secondaryCommands.Contains(_arguments[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
