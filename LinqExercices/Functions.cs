using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Immutable;

namespace LinqExercices
{
    public static class Functions
    {
        public static Dictionary<string,int> CountConsonantsAndVowels(string text)
        {
            if (text == null)
            {
                throw new InvalidOperationException();
            }

            var result = new Dictionary<string, int>() { { "vowels", 0 }, { "consonants", 0 } };
            result["vowels"] = text.Count(x => "aeiouAEIOU".Contains(x));
            result["consonants"] = text.Count(x => !"aeiouAEIOU".Contains(x));
            return result;
        }

        public static char GetFirstNonRepetedChar(string text)
        {
            if (text == null)
            {
                throw new InvalidOperationException();
            }

            return text.FirstOrDefault(c => text.IndexOf(c) == text.LastIndexOf(c));
        }

        public static bool TryStringToInt(string number,out int result)
        {
            if (number == null)
            {
                throw new InvalidOperationException();
            }

            if (number.All(x => x <= '9' && x >= '0'))
            {
                result = number.Aggregate(0, (x, y) => x * 10 + y - 48);
                return true;
            }

            result = -1;
            return false;
        }

        public static char GetMaximumOccurencesChar(string text)
        {
            if (text == null)
            {
                throw new InvalidOperationException();
            }

            return text.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
        }

        public static IEnumerable<string> GetPalindromes(string text)
        {
            if (text == null)
            {
                throw new InvalidOperationException();
            }

            var substrings = from x in Enumerable.Range(0, text.Length)
                            from y in Enumerable.Range(0, text.Length - x + 1)
                            where y >= 1
                            select text.Substring(x, y);
            return substrings.Where(x => x.SequenceEqual(x.Reverse()));
        }

        public static IEnumerable<IEnumerable<int>> GetValuesWithSum(IEnumerable<int> numbers, int sum)
        {
            if (numbers == null)
            {
                throw new InvalidOperationException();
            }

            var pairs = from x in Enumerable.Range(0, numbers.Count())
                        from y in Enumerable.Range(0, numbers.Count() - x + 1)
                        where y >= 1
                        select numbers.Skip(x).Take(y);
            return pairs.Where(x => x.Sum() <= sum);
        }
    }
}
