using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetThingsDone
{
    public class TasksLists
    {
        public List<Task> Tasks;

        public TasksLists()
        {
            Tasks = new List<Task>();
        }
        public void CaptureTasks(string[] tasks)
        {
            foreach (var taskTitle in tasks)
            {
                var task = new Task(taskTitle);
                ClarifyTask(task);
                if (IsActionableNow(task))
                {
                    continue;
                }

                Tasks.Add(task);
            }
        }

        private void ClarifyTask(Task task)
        {
            GenerateTaskDescription(task);
        }

        private bool IsActionableNow(Task task)
        {
            Console.WriteLine($"Can task \"{task.Title}\" be completed in the next 2 minutes? Y/N");
            var answer = Console.ReadLine();
            while (answer != null
                   && answer.ToLower() != "y"
                   && answer.ToLower() != "n")
            {
                Console.WriteLine("I don't understand your answer... Please answer with Y(yes) or N(no)!");
                answer = Console.ReadLine();
            }

            if (answer.ToLower() == "y")
            {
                Console.WriteLine("This is a task that you should start on right now! I wont add it to your tasks.");
            }

            return answer.ToLower() == "y";
        }

        private void GenerateTaskDescription(Task task)
        {
            Console.WriteLine($"Please provide a description of how \"{task.Title}\" task can be completed!");
            task.Description = Console.ReadLine();
            while (string.IsNullOrEmpty(task.Description) && task.Description.Length < 100)
            {
                Console.WriteLine("Please provide a valid description of at least 100 characters!");
                task.Description = Console.ReadLine();
            }
        }
    }
}
