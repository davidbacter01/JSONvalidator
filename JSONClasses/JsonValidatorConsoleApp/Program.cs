using Classes;
using System;
namespace JsonValidatorConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int pathNumber = 1;
            var json = new Value();

            foreach (string path in args)
            {
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
            string remainingText = json.Match(text).RemainingText();

            int consumedTextLength = text.Length - remainingText.Length;
            string consumedText = text.Substring(0, consumedTextLength);

            string[] consumedLines = consumedText.Split('\n');
            int errorLine = consumedLines.Length;
            int errorColumn = consumedLines[^1].Length;

            Console.WriteLine("Validation fails on line {0} at position {1}", errorLine, errorColumn);
        }
    }
}
