using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Any : IPattern
    {
        private readonly string accepted;
        public Any(string accepted) 
        {
            this.accepted = accepted;
        }
            
        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new FailMatch(text);

            return accepted.Contains(text[0])
                ? new SuccesMatch(text[1..^0]) as IMatch
                : new FailMatch(text);
        }
    }
}
