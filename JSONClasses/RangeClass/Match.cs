using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Match : IMatch
    {
        private readonly string text;
        private readonly bool success;
        public Match(string text, bool success)
        {
            this.text = text;
            this.success = success;
        }
        public string RemainingText()
        {
            return text;
        }

        public bool Success() => success;
    }
}
