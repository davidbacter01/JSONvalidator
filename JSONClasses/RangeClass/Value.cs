using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var jstring = new String();
            var number = new Number();
            var value = new Choice(
                jstring,
                number,
                new Text("true"),
                new Text("false"),
                new Text("null")
                );

            var whitespace = new Many(new Any(" \r\n\t"));
            var element = new Sequence(whitespace, value, whitespace);
            var separator = new Character(',');
            var elements = new Choice(element, new List(element, separator));

            var array = new Sequence(
                new Character('['),
                new Choice(whitespace, elements),
                new Character(']')
                );

            var member = new Sequence(
                whitespace,
                jstring,
                whitespace,
                new Character(':'),
                element
                );

            var members = new Choice(
                member,
                new List(member, separator)
                );

            var jobject = new Sequence(
                new Character('{'),
                new Choice(whitespace, members),
                new Character('}')
                );

            value.Add(array);
            value.Add(jobject);

            pattern = value;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
