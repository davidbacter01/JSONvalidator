using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var quotes = new Character('"');

            var space = new Character(' ');
            var lowercase = new Range('a', 'z');
            var uppercase = new Range('A', 'Z');
            var digit = new Range('0', '9');

            var symbols = new Choice(
                new Range(' ', '!'),
                new Range('#', '/'),
                new Range(':', '@'),
                new Choice(new Character('['), new Range(']', '`')),
                new Range('{', '~'));

            var validCharacters = new OneOrMore(
                new Choice(
                    lowercase,
                    uppercase,
                    space,
                    digit,
                    symbols));

            this.pattern = new Sequence(quotes, new Optional(validCharacters), quotes);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
