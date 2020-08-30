using System;
using System.Collections.Generic;
using GetThingsDone.Commands;

namespace GetThingsDone
{
    public class ArgsParser
    {
        private readonly Queue<string> _args;
        private readonly ArgsValidator _validator;

        public ArgsParser(string[] args)
        {
            _args = new Queue<string>(args);
            try
            {
                _validator = new ArgsValidator(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public IEnumerable<ICommand> Parse()
        {
            if (!_validator.AreArgumentsValid())
            {
                throw new ArgumentException("invalid arguments");
            }

            return ParseToCommands();
        }

        private IEnumerable<ICommand> ParseToCommands()
        {
            if (_args.Dequeue() == "add")
            {
                return new[] {new AddCmd(_args.Dequeue()),};
            }

            throw new NotImplementedException();
        }
    }
}
