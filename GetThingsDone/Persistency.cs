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
            try
            {
                var jsonTasks = File.ReadAllLines(_path);
                return jsonTasks.Select(t => JsonSerializer.Deserialize<Task>(t));
            }
            catch (Exception)
            {
                return new Task[] { };
            }
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
