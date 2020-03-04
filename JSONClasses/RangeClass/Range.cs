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
            return string.IsNullOrEmpty(text) ? false : start <= text[0] && text[0] <= end;
        }
    }
}
