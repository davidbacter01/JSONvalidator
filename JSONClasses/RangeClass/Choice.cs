using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Choice : IPattern
    {
        private readonly IPattern[] patterns;
        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            foreach (IPattern pattern in patterns)
            {
                if (pattern.Match(text))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
