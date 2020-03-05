using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Character : IPattern
    {
        private readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(text, false);
            }

            return text[0] == pattern ? new Match(text[1..^0], true) : new Match(text, false);
        }
    }
}
