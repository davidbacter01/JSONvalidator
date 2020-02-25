using System;

namespace JsonValidator
{
    public class Program
    {
        public static void Main()
        {
            string toCheck = Console.ReadLine();
            Console.WriteLine(GetJSONValidity(toCheck));
        }

        public static string GetJSONValidity(string toCheck)
        {
            if (toCheck == null)
            {
                return "Valid";
            }

            if (toCheck.IndexOf('\"') != 0 || toCheck.LastIndexOf('\"') != toCheck.Length - 1)
            {
                return "Invalid";
            }

            if (!IsCorrectFormatForEscapedChars(toCheck))
            {
                return "Invalid";
            }

            return "Valid";
        }

        private static bool IsCorrectFormatForEscapedChars(string toCheck)
        {
            const string EscapedChars = "\\\"/bfnrtu";
            for (int i = 1; i < toCheck.Length - 1; i++)
            {
                if (toCheck[i] == '\\' && !EscapedChars.Contains(toCheck[i + 1]))
                {
                    return false;
                }
                if (toCheck[i] == '"' && toCheck[i - 1] != '\\')
                {
                    return false;
                }

                if (toCheck[i] == '/' && toCheck[i - 1] != '\\')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
