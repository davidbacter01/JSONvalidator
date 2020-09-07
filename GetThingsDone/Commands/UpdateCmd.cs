using System;
using System.Linq;

namespace GetThingsDone.Commands
{
    class UpdateCmd : ICommand
    {
        private readonly Persistency _file;
        private string[] _args;
        public string Name { get; }

        public UpdateCmd(string[] args)
        {
            Name = "update";
            _args = args;
            _file = new Persistency("./Database/Tasks.txt");
        }

        public bool ExecuteCommand()
        {
            Task toUpdate;
            try
            {
                toUpdate = _file.RetrieveTasks().First(t => t.Title == _args[2]);
            }
            catch (Exception)
            {
                return false;
            }

            if (toUpdate == default)
            {
                return false;
            }

            _args = _args.Skip(2).ToArray();//removes title argument and its parameter in case is desired a title update
            var update = toUpdate;
            var tasks = _file.RetrieveTasks().Where(t => t.Title != update.Title);
            UpdateTask(toUpdate);
            tasks = tasks.Append(toUpdate);
            _file.WriteTasksToFile(tasks);

            return update != toUpdate;
        }

        private bool TryGetArgumentOf(string parameter, out string argument)
        {
            for (int paramIndex = 0; paramIndex < _args.Length; paramIndex ++)
            {
                if (_args[paramIndex] != parameter)
                    continue;

                argument = _args[paramIndex + 1];
                return true;
            }

            argument = "";
            return false;
        }

        private void UpdateTask(Task toUpdate)
        {
            if (TryGetArgumentOf("--title", out var title))
                toUpdate.Title = title;

            if (TryGetArgumentOf("--description", out var d))
                toUpdate.Description = d;

            if (TryGetArgumentOf("--priority", out var p))
                toUpdate.Priority = ConvertToLevel(p);

            if (TryGetArgumentOf("--complexity", out var c))
                toUpdate.Complexity = ConvertToLevel(c);

            if (TryGetArgumentOf("--due", out var due))
                toUpdate.Due = Convert.ToDateTime(due);
        }

        private Task.Level ConvertToLevel(string level)
        {
            return level switch
            {
                "low" => Task.Level.Low,
                "medium" => Task.Level.Medium,
                "high" => Task.Level.High,
                _ => throw new ArgumentException(),
            };
        }
    }
}
