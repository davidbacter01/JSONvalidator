using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GetThingsDone
{
    public class TaskOrganizer
    {
        private readonly TasksManager _simpleTasks;
        private readonly TasksManager _complexTasks;
        private readonly TasksManager _projects;
        private readonly PersistencyManager _simplePersistency;
        private readonly PersistencyManager _complexPersistency;
        private readonly PersistencyManager _projectsPersistency;

        public TaskOrganizer(string simpleTasksPath, string complexTasksPath, string projectsPath)
        {
            _simplePersistency = new PersistencyManager(simpleTasksPath);
            _complexPersistency = new PersistencyManager(complexTasksPath);
            _projectsPersistency = new PersistencyManager(projectsPath);
            _simpleTasks=new TasksManager(_simplePersistency.GetTasks());
            _complexTasks=new TasksManager(_complexPersistency.GetTasks());
            _projects = new TasksManager(_projectsPersistency.GetTasks());
        }

        public void ProcessCommands(string[] commands)
        {
            if (commands[0] != "help")
                return;

            var printable = File.ReadAllLines("./Database/CommandsInfo.txt");
            foreach (var line in printable)
            {
                Console.WriteLine(line);
            }
        }
    }
}
