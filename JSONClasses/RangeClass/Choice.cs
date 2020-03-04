using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Choice : IPattern
    {
        private IPattern[] patterns;
        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public bool Match(string text)
        {
            foreach (IPattern pattern in patterns)
            {
                if (!pattern.Match(text))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
