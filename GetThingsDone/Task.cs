using System;
using System.Collections.Generic;
using System.Text;

namespace GetThingsDone
{
    public class Task
    {
        public enum Importance
        {
            Low,
            Medium,
            High
        }

        public List<string> Tags { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Importance Priority { get; set; } = Importance.Low;

        public Task()
        {
            Tags = new List<string>();
        }
    }
}
