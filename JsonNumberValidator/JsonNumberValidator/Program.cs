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

        private static bool IsValidFormat(string number)
        {
            if (number[0] != '-' && !DecimalSistem.Contains(number[0]))
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
                else if (number[i] == '.')
                {
                    return IsValidFloat(number.Substring(i + 1));
                }
            }

            return true;
        }

        private static bool IsValidFloat(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!DecimalSistem.Contains(number[i]) && number[i] != 'e' && number[i] != 'E')
                {
                    return false;
                }
                else if ((number[i] == 'e' || number[i] == 'E') && i != number.Length - 1)
                {
                    return IsValidExponential(number.Substring(i + 1));
                }
                else if ((number[i] == 'e' || number[i] == 'E') && i == number.Length - 1)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValidExponential(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!DecimalSistem.Contains(number[i]) && number[i] != '+' && number[i] != '-')
                {
                    return false;
                }
                else if ((number[i] == '+'|| number[i] == '-') && i != number.Length - 1)
                {
                    return DecimalSistem.Contains(number[i + 1]);
                }
            }

            return true;
        }
    }
}
