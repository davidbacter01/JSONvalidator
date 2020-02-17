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

            if (toCheck.IndexOf('\"') != 0 || toCheck.LastIndexOf('\"') != toCheck.Length - 1)
            {
                return "Invalid";
            }

            for (int i = 1; i < toCheck.Length - 1; i++)
            {
                if (toCheck[i] == '\\' && toCheck[i - 1] != '\\' || toCheck[i + 1] != '\\')
                {
                    return "Invalid";
                }
            }

            return "Valid";
        }
    }
}
