using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;
        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch match = new SuccesMatch(text);
            foreach (var pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());
                if (!match.Success())
                {
                    return new FailMatch(match.RemainingText());
                }
            }

            return match;
        }
    }
}
