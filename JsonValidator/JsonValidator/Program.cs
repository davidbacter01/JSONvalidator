using System;

namespace JsonValidator
{
    public class Program
    {
        public static void Main()
        {
            string toCheck = Console.ReadLine();
            Console.WriteLine(CheckJSONValidity(toCheck));
        }

        public static string CheckJSONValidity(string toCheck)
        {
            if (toCheck == null)
            {
                return "Valid JSON string";
            }

            if (toCheck.IndexOf('\"') != 0 && toCheck.LastIndexOf('\"') != toCheck.Length - 1)
            {
                return "Invalid JSON string!";
            }

            return "Valid JSON string";
        }
    }
}
