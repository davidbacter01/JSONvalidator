using Xunit;
using TrieDataStructure;
using System.Collections.Generic;
using Xunit.Sdk;
using System;

namespace TrieDataStructureTests
{
    public class TrieTests
    {
        [Fact]
        public void ReturnsEmptyListForEmptyQuery()
        {
            var tries = new Trie();
            Assert.Throws<ArgumentNullException>(() => tries.Autocomplete(""));
        }

        [Fact]
        public void ReturnsEmptyListIfNotInTrie()
        {
            var trie = new Trie();
            Assert.Equal(new List<string>(), trie.Autocomplete("a"));
        }

        [Fact]
        public void ReturnsSearchedStringIfIsInTrieAndHasNoChildren()
        {
            var trie = new Trie();
            trie.AddWord("word");
            Assert.Equal(new List<string> { "word" },trie.Autocomplete("word"));
        }

        [Fact]
        public void ReturnsAllStringsHavingTheSearchedStringAsPrefix()
        {
            var trie = new Trie();
            trie.AddWord("argo");
            trie.AddWord("bbcde");
            trie.AddWord("abla");
            trie.AddWord("ab");
            trie.AddWord("abc");
            trie.AddWord("abcd");
            trie.AddWord("abea");
            List<string> expected = new List<string>() { "ab", "abla", "abc", "abcd", "abea" };
            Assert.Equal(expected, trie.Autocomplete("ab"));
        }

        [Fact]
        public void RemovesWordFromTrie()
        {
            var trie = new Trie();
            trie.AddWord("argo");
            trie.AddWord("bbcde");
            trie.AddWord("abla");
            trie.AddWord("ab");
            trie.AddWord("abc");
            trie.AddWord("abcd");
            trie.AddWord("abea");
            trie.Delete("abla");
            List<string> expected = new List<string>() { "ab", "abc", "abcd", "abea" };
            Assert.False(trie.Contains("abla"));
            Assert.Equal(expected, trie.Autocomplete("ab"));
        }
    }
}
