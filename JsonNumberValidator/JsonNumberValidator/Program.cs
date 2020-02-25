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
            if (number == null)
            {
                return "Invalid";
            }

            if (!IsValidFormat(number))
            {
                return "Invalid";
            }

            return "Valid";
        }

        static bool IsValidFormat(string number)
        {
            if (number[0] != '-' && !DecimalSistem.Contains(number[0]))
            {
                return false;
            }

            bool hasFloatingPoint = false;
            for (int i = 1; i < number.Length; i++)
            {
                if (number[i] == '.' && hasFloatingPoint)
                {
                    return false;
                }
                else if (number[i] == '.' && !hasFloatingPoint)
                {
                    hasFloatingPoint = true;
                }
                else if (!IsExponent(number[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsExponent(char c)
        {
           return c != '.' && !DecimalSistem.Contains(c) || c != 'e';
        }
    }
}
