using System;

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
        public DateTime DueDateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Level Priority { get; set; } = Level.Low;
        public Level ComplexityLevel { get; set; } = Level.Low;
    }
}
