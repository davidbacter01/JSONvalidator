using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;
        public Number()
        {
            this.pattern = new Range('1', '9');
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
