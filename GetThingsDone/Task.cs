using System;
using System.Collections.Generic;
using System.Text;

namespace GetThingsDone
{
    public class Task
    {
        public enum State
        {
            Pending,
            Done
        }

        public enum Priority
        {
            Low,
            Medium,
            High
        }

        public List<string> Tags { get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public State Status { get; set; } = State.Pending;
        public Priority Importance { get; set; } = Priority.Low;

        public Task(string title)
        {
            Title = title;
            Tags = new List<string>();
        }
    }
}
