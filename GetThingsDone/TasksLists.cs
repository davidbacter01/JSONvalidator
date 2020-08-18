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
            foreach (var task in tasks)
            {
                var actualTask = new Task(task);
                ClarifyTask(actualTask);
                Tasks.Add(actualTask);
            }
        }

        private void ClarifyTask(Task task)
        {
            GetTaskDescription(task);
            Console.WriteLine($"Can task \"{task.Title}\" be acted in the next 2 minutes? Y/N");
            var answer = Console.ReadLine();
            while (answer != null 
                   && answer.ToLower() != "y" 
                   && answer.ToLower() != "n")
            {
                Console.WriteLine("I don't understand your answer... Please answer with Y(yes) or N(no)!");
                answer = Console.ReadLine();
            }
        }

        private void GetTaskDescription(Task task)
        {
            Console.WriteLine($"Please provide a description of how \"{task.Title}\" task can be completed!");
            task.Description = Console.ReadLine();
            while (string.IsNullOrEmpty(task.Description))
            {
                Console.WriteLine("Please provide a valid description!");
                task.Description = Console.ReadLine();
            }
        }
    }
}
