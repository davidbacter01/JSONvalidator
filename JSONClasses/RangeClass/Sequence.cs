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
            string initialText = text;
            IMatch match = new Match(text, true);
            foreach(var pattern in patterns)
            {
                match = pattern.Match(text);
                if (!match.Success())
                {
                    return new Match(initialText, false);
                }

                text = match.RemainingText();
            }

            return match;
        }
    }
}
