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
                return new FailMatch(text);
            }

            return start <= text[0] && text[0] <= end ? new SuccesMatch(text[1..^0]) as IMatch : new FailMatch(text);
        }
    }
}
