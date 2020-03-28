﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class ListTests
    {

        [Fact]
        public void MatchingSequenceNumberSeparatorShouldReturnTrueAndNoRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("", a.Match("1,2,3").RemainingText());
            Assert.True(a.Match("1,2,3").Success());
        }

        [Fact]
        public void MatchingSequenceNumberSeparatorShouldReturnTrueAndRemainingText()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal(",", a.Match("1,2,3,").RemainingText());
            Assert.True(a.Match("1,2,3,").Success());
        }

        [Fact]
        public void MatchingOnlyElementShouldReturnTrueAndRemainingTextAfterElement()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("a", a.Match("1a").RemainingText());
            Assert.True(a.Match("1a").Success());
        }

        [Fact]
        public void StringWithNoMatchingElementShouldReturnTrueAndInitialString()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("abc", a.Match("abc").RemainingText());
            Assert.True(a.Match("abc").Success());
        }

        [Fact]
        public void EmptyStringShouldReturnTrueAndEmptyString()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Equal("", a.Match("").RemainingText());
            Assert.True(a.Match("").Success());
        }

        [Fact]
        public void NullShouldReturnTrueAndNull()
        {
            var a = new List(new Range('0', '9'), new Character(','));
            Assert.Null(a.Match(null).RemainingText());
            Assert.True(a.Match(null).Success());
        }

        [Fact]
        public void ComplexSequenceWithMatchingElementAndSeparatorShouldReturnTrueAndEmptyString()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.True(list.Match("1; 22;\n 333 \t; 22").Success());
            Assert.Equal("", list.Match("1; 22;\n 333 \t; 22").RemainingText());
        }

        [Fact]
        public void ComplexSequenceWithMatchingElementAndNoSeparatorShouldReturnTrueAndRemainingString()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.True(list.Match("1 \n;").Success());
            Assert.Equal(" \n;", list.Match("1 \n;").RemainingText());
        }


        [Fact]
        public void ComplexSequenceWithNoMatchingElementAndNoSeparatorShouldReturnTrueAndInitialString()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);
            Assert.True(list.Match("abc").Success());
            Assert.Equal("abc", list.Match("abc").RemainingText());
        }
    }
}
