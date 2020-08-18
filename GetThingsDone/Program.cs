using System;

namespace GetThingsDone
{
    public class Program
    {
        static void Main(string[] args)
        {
            var x = new Task("break wood") {Status = Task.State.Pending};
            PrintTask(x);
        }

        private static void PrintTask(Task task)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine($"Title : {task.Title}");
            Console.WriteLine($"Status : {task.Status}");
            Console.WriteLine("---------------------");
            Console.Read();
        }
    }
}
