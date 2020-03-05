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

            return !string.IsNullOrEmpty(text) && text[0] == pattern 
                ? new SuccesMatch(text[1..^0])
                : new FailMatch(text);
        }
    }
}
