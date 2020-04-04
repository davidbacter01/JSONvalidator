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
                new Range('{', '~')
                );

            var hex = new Choice(
                digit,
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                ));

            var escapedChars = new Sequence(
                new Character('\\'),
                new Choice(
                    new Any("\"\\/bfnrt"),
                    hexSeq)
                );

            var validCharacters = new OneOrMore(
                new Choice(
                    lowercase,
                    uppercase,
                    space,
                    digit,
                    symbols,
                    escapedChars)
                );

            this.pattern = new Sequence(quotes, new Optional(validCharacters), quotes);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
