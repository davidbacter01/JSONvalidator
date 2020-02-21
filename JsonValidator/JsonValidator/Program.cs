using System;

namespace JsonValidator
{
    public class Program
    {
        const int ControlChar = 32;

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

            if (!CheckForSpecialCharacters(toCheck))
            {
                return "Invalid";
            }

            if (HasCharsThatShouldHaveBackslashBefore(toCheck))
            {
                return "Invalid";
            }

            return "Valid";
        }

        private static bool HasCharsThatShouldHaveBackslashBefore(string toCheck)
        {
            for (int i = 2; i < toCheck.Length; i++)
            {
                if (toCheck[i] == '\\' && toCheck[i - 1] != '\\')
                {
                    return true;
                }

                if (toCheck[i] == '"' && toCheck[i - 1] != '\\')
                {
                    return true;
                }

                if (toCheck[i] == '/' && toCheck[i - 1] != '\\')
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CheckForSpecialCharacters(string toCheck)
        {
            for (int i = 1; i < toCheck.Length - 1; i++)
            {
                if (toCheck[i] < ControlChar)
                {
                    return false;
                }

                if (toCheck[i] == '\\' && !IsValidChar(toCheck[i + 1]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidChar(char c)
        {
            switch (c)
            {
                case '\\':
                case '"':
                case '/':
                case 'b':
                case 'f':
                case 'n':
                case 'r':
                case 't':
                case 'u':
                    return true;
                default:
                    return false;
            }
        }
    }
}
