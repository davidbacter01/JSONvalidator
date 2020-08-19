using System;

namespace GetThingsDone
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tasks = new TasksLists();
            tasks.CaptureTasks(args);
            foreach (var task in tasks.Tasks)
            {
                PrintTask(task);
            }
        }

        private static void PrintTask(Task task)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($" Title: {task.Title}");
            Console.WriteLine($" Status: {task.Status}");
            Console.WriteLine($" Task priority: {task.Importance}");
            Console.WriteLine($" Description:\n {task.Description}");
            Console.WriteLine("----------------------------------");
        }
    }
}
