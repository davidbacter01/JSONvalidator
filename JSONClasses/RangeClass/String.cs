using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            pattern =;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
