using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace GetThingsDone
{
    public class Persistency
    {
        private readonly string _path;

        public Persistency(string path)
        {
            _path = path;
        }

        public IEnumerable<Task> RetrieveTasks()
        {
            var jsonTasks = File.ReadAllLines(_path);
            if (jsonTasks == null)
            {
                return new Task[] { };
            }

            return jsonTasks.Select(t => JsonSerializer.Deserialize<Task>(t));
        }

        public void WriteTasksToFile(IEnumerable<Task> tasks)
        {
            if (tasks == null)
            {
                throw new ArgumentNullException("tasks list can't be null");
            }

            var jsonTasks = tasks.Select(t => JsonSerializer.Serialize(t));
            File.WriteAllLines(_path, jsonTasks);
        }
    }
}
