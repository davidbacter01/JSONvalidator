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
            var sign = new Optional(new Any("+-"));
            var zero = new Character('0');
            var onenine = new Range('1', '9');
            var digit = new Choice(zero, onenine);
            var fraction = new Optional(new Text("0."));
            this.pattern = new Sequence(sign, fraction, new Many(digit));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
