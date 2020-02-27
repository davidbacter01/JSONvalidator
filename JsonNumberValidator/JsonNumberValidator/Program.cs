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
            if (number.Length == 0)
            {
                return "Invalid";
            }

            if (number == null)
            {
                return "Invalid";
            }

            if (number[0] == '0')
            {
                return "Invalid";
            }

            if (!IsValidJsonFormat(number))
            {
                return "Invalid";
            }

            return "Valid";
        }

        private static bool IsValidJsonFormat(string number)
        {
            if (number[0] != '-' && !DecimalSistem.Contains(number[0]))
            {
                return false;
            }

            if (!DecimalSistem.Contains(number[number.Length - 1]))
            {
                return false;
            }

            return IsValidInt(number.Substring(1));
        }

        private static bool IsValidInt(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!DecimalSistem.Contains(number[i]) && number[i] != '.')
                {
                    return false;
                }
 
                if (number[i] == '.')
                {
                    return IsValidFraction(number.Substring(i + 1));
                }
            }

            return true;
        }

        private static bool IsValidFraction(string number)
        {
            if (!DecimalSistem.Contains(number[0]))
            {
                return false;
            }

            for (int i = 1; i < number.Length; i++)
            {
                if (!DecimalSistem.Contains(number[i]) && number[i] != 'e' && number[i] != 'E')
                {
                    return false;
                }

                if (number[i] == 'e' || number[i] == 'E')
                {
                    return IsValidExponential(number.Substring(i + 1));
                }
            }

            return true;
        }

        private static bool IsValidExponential(string number)
        {
            if (number.Length < 1)
            {
                return false;
            }

            if (!DecimalSistem.Contains(number[0]) && number[0] != '+' && number[0] != '-')
            {
                return false;
            }

            for (int i = 1; i < number.Length; i++)
            {
                if (!DecimalSistem.Contains(number[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
