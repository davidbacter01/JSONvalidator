using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Text : IPattern
    {
        private readonly string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new FailMatch(text);


            return text.StartsWith(prefix)
                ? new SuccesMatch(text.Remove(0, prefix.Length)) as IMatch
                : new FailMatch(text);
        }
    }
}
