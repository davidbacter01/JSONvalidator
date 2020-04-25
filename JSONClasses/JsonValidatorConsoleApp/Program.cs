using Classes;
using System;
namespace JsonValidatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var json = new Value();
            int pathNumber = 1;
            foreach(string path in args)
            {
                string text = System.IO.File.ReadAllText(args[0]);
                Console.WriteLine("Path number {0} leads to a valid JSON value :" + (json.Match(text).RemainingText() == ""), pathNumber);
                pathNumber++;
            }
        }
    }
}
