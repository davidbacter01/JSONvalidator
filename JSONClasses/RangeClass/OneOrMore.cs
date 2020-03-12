using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class OneOrMore : IPattern
    {
        private readonly IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = new Sequence(pattern, new Many(pattern));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
