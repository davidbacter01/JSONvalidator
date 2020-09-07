using System;
using System.Collections.Generic;

namespace GetThingsDone
{
    public class Task
    {
        public enum Level
        {
            Low,
            Medium,
            High
        }

        public DateTime AddedDate { get; set; }
        public DateTime Due { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Level Priority { get; set; } = Level.Low;
        public Level Complexity { get; set; } = Level.Low;
        public List<string> Tags { get; } = new List<string>();
    }
}
