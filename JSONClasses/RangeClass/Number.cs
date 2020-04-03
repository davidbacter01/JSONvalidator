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
            var digits = new OneOrMore(digit);
            var integer = new Sequence(onenine, new Optional(digits));
            var fraction = new Optional(new Sequence(new Character('.'), digits));
            pattern = new Sequence(sign, new Choice(integer, zero),fraction);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
