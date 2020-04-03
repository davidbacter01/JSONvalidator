using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Classes.Tests
{
    public class NumberTests
    {
        [Fact]
        public void SimpleNumberShouldReturnTrueAndEmptyString()
        {
            var number = new Number();
            Assert.True(number.Match("1").Success());
            Assert.Equal("", number.Match("1").RemainingText());
        }

        [Fact]
        public void SimpleNumberFromMultipleDigitsShouldReturnTrueAndEmptyString()
        {
            var number = new Number();
            Assert.True(number.Match("123500425").Success());
            Assert.Equal("", number.Match("123500425").RemainingText());
        }

        [Fact]
        public void SimpleNumberWithSignFromMultipleDigitsShouldReturnTrueAndEmptyString()
        {
            var number = new Number();
            Assert.True(number.Match("-123500425").Success());
            Assert.Equal("", number.Match("-123500425").RemainingText());
        }

        [Fact]
        public void FloatingPointNumberShouldReturnTrueAndEmptyString()
        {
            var number = new Number();
            Assert.True(number.Match("0.123").Success());
            Assert.Equal("", number.Match("0.123").RemainingText());
        }

        [Fact]
        public void FloatingPointComplexNumberShouldReturnTrueAndEmptyString()
        {
            var number = new Number();
            Assert.True(number.Match("1230.123").Success());
            Assert.Equal("", number.Match("1230.123").RemainingText());
        }

        [Fact]
        public void NumberStartingWithZeroShouldReturnFalseAndInitialString()
        {
            var number = new Number();
            Assert.True(number.Match("0123").Success());
            Assert.Equal("123", number.Match("0123").RemainingText());
        }

        [Fact]
        public void NumberWithExponentShouldReturnTrueAndEmptyString()
        {
            var number = new Number();
            Assert.True(number.Match("123.123e+123").Success());
            Assert.Equal("", number.Match("123.123e+123").RemainingText());
        }
    }
}
