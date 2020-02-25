using System;

namespace JsonNumberValidator
{
    public class Program
    {
        public const string DecimalSistem = "0123456789";
        public static void Main()
        {
            string numberToCheck = Console.ReadLine();
            Console.WriteLine(GetJSONNumberValidity(numberToCheck));
        }

        public static string GetJSONNumberValidity(string number)
        {
            if (number[0] != '-' && !DecimalSistem.Contains(number[0]))
            {
                return "Invalid";
            }

            bool hasFloatingPoint = false;
            for (int i = 1; i < number.Length; i++)
            {
                if (number[i] == '.' && hasFloatingPoint)
                {
                    return "Invalid";
                }
                else if (number[i] == '.' && !hasFloatingPoint)
                {
                    hasFloatingPoint = true;
                }
            }

            return "Valid";
        }
    }
}
