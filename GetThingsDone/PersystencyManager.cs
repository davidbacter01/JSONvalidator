using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GetThingsDone
{
    public class PersistencyManager
    {
        private readonly string _path;

        public PersistencyManager(string path)
        {
            _path=path;
        }

        public IEnumerable<Task> GetTasks()
        {
            return File.ReadAllLines(_path).Select(t => JsonSerializer.Deserialize<Task>(t));
        }

        public void SaveTasks(IEnumerable<Task> tasks)
        {
            var jsonTasks = tasks.Select(t => JsonSerializer.Serialize(t));
            File.WriteAllLines(_path,jsonTasks);
        }
    }
}
