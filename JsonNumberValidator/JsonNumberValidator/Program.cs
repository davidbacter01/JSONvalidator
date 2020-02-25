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
            const string DecimalSistem = "0123456789";
            if (!DecimalSistem.Contains(number[0]) && !(number[0] == '-'))
            {
                return "Invalid";
            }

            for (int i = 1; i < number.Length; i++)
            {
                if (!DecimalSistem.Contains(number[i]))
                {
                    return "Invalid";
                }
            }

            return "Valid";
        }
    }
}
