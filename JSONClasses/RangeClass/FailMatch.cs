using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class FailMatch : IMatch
    {
        private readonly string text;
        public FailMatch(string text)
        {
            this.text = text;
        }
        public string RemainingText()
        {
            return text;
        }

        public bool Success() => false;
    }
}
