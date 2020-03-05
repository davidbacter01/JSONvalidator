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

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(text, false);
            }

            return start <= text[0] && text[0] <= end ? new Match(text[1..^0], true) : new Match(text, false);
        }
    }
}
