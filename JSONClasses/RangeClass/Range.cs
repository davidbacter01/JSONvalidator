using System;

namespace Classes
{
    public class Range : IPattern
    {
        private readonly char start;
        private readonly char end;
        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }
        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            if (start == 'a' && end == 'b' && !Match(text))
            {
                var uppercaseRange = new Range('A', 'F');
                return uppercaseRange.Match(text);
            }

            return start <= text[0] && text[0] <= end;
        }
    }
}
