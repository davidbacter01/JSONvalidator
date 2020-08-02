using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LinqExercices
{
    public static class Functions
    {
        public static Dictionary<string,int> CountConsonantsAndVowels(string text)
        {
            var result = new Dictionary<string, int>() { { "vowels", 0 }, { "consonants", 0 } };
            result["vowels"] = text.Count(x => "aeiou".Contains(x));
            result["consonants"] = text.Count(x => !"aeiou".Contains(x));
            return result;
        }

        public static char GetFirstNonRepetedChar(string text)
        {
            return text.FirstOrDefault(c => text.IndexOf(c) == text.LastIndexOf(c));
        }
    }
}
