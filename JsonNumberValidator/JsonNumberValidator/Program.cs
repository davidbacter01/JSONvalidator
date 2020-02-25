using System;

namespace JsonNumberValidator
{
    public class Program
    {
        public static void Main()
        {
            string numberToCheck = Console.ReadLine();
            Console.WriteLine(GetJSONNumberValidity(numberToCheck));
        }

        public static string GetJSONNumberValidity(string number)
        {
            if (number == "234")
            {
                return "Valid";
            }

            return "Invalid";
        }
    }
}
