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
                return "Valid";
            }

            if (toCheck.IndexOf('\"') != 0 || toCheck.LastIndexOf('\"') != toCheck.Length - 1)
            {
                return "Invalid";
            }

            if (ContainsBackslash(toCheck))
            {
                return "Invalid";
            }

            return "Valid";
        }

        private static bool ContainsBackslash(string toCheck)
        {
            for (int i = 1; i < toCheck.Length - 1; i++)
            {
                if (toCheck[i] == '\\' && toCheck[i - 1] != '\\' || toCheck[i + 1] != '\\' || toCheck[i + 1] != 'n')
                {
                    return true;
                }
            }

            return false;
        }
    }
}
