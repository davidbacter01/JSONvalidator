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
            var digit = new Choice(new Character('0'), new Range('1', '9'));
            this.pattern =new Sequence(sign, new Many(digit));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
