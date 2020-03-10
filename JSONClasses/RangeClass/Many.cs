using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Many : IPattern
    {
        private readonly IPattern pattern;
        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            string consumedText = pattern.Match(text).RemainingText();
            while (pattern.Match(consumedText).Success())
            {
                consumedText = pattern.Match(consumedText).RemainingText();
            }

            return new SuccesMatch(consumedText);          
        }
    }
}
