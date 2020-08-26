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

        public DateTime AddedDate { get; }
        public DateTime DueDateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Level Priority { get; set; } = Level.Low;
        public Level ComplexityLevel { get; set; } = Level.Low;
        public Task()
        {
            AddedDate = DateTime.Now;
        }
    }
}
