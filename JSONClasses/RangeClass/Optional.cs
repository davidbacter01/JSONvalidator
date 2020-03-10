using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Optional : IPattern
    {
        private readonly IPattern pattern;
        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return new SuccesMatch(pattern.Match(text).RemainingText());
        }
    }
}
