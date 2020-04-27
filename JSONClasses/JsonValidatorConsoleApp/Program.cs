using Classes;
using System;
namespace JsonValidatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int pathNumber = 1;
            foreach(string path in args)
            {
                var json = new Value();
                string text = System.IO.File.ReadAllText(args[0]);
                Console.WriteLine("Path number {0} leads to a valid JSON value :" + (json.Match(text).RemainingText() == ""), pathNumber);
                pathNumber++;

                if (json.Match(text).RemainingText() != "")
                    PrintErrorLocation(text, json);
            }

            Console.Read();
        }

        private static void PrintErrorLocation(string text, IPattern json)
        {
            string[] textLines = text.Split('\n');
            string remainingText = json.Match(text).RemainingText();
            int errorLine = Array.IndexOf(textLines, remainingText) + 1;
            int errorColumn = textLines[errorLine - 1].IndexOf(remainingText);
            Console.WriteLine("Validation fails on line {0} at position {1}", errorLine, errorColumn);
        }
    }
}
