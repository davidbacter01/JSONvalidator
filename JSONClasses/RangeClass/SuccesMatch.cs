using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class SuccesMatch : IMatch
    {
        private readonly string text;
        public SuccesMatch(string text)
        {
            this.text = text;
        }

        public string RemainingText()
        {
            return text;
        }

        public bool Success() => true;
    }
}
