using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;
        public Number()
        {
            var sign = new Any("+-");
            var digits = new Many(new Range('0', '9'));
            var e = new Any("eE");
            var dot = new Character('.');
            var zero = new Character('0');
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
