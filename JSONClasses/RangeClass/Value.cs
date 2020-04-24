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
            var elements = new List(element, separator);

            var array = new Sequence(
                new Character('['),
                new Choice(elements, element, whitespace),
                new Character(']')
                );

            var member = new Sequence(
                whitespace,
                jstring,
                whitespace,
                new Character(':'),
                element
                );

            var members = new List(member, separator);

            var jobject = new Sequence(
                new Character('{'),
                new Choice(members, member, whitespace),
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
