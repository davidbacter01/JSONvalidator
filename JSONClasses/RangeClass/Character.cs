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

        public bool Match(string text)
        {
            return (string.IsNullOrEmpty(text)) ? false : text[0] == pattern;
        }
    }
}
