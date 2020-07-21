using System;
using System.Collections.Generic;

namespace TrieDataStructure
{
    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode();
        }

        public void AddWord(string word)
        {
            ExceptNullOrEmpty(word);

            var node = root;
            foreach (char letter in word)
            {
                if (!node.Children.ContainsKey(letter))
                {
                    node.Children[letter] = new TrieNode();
                }

                node = node.Children[letter];
            }

            if (node.Value == null)
            {
                node.Value = word;
            }
        }

        public bool Contains(string word)
        {
            ExceptNullOrEmpty(word);

            if (!TryGetValueNode(word, out var node))
            {
                return false;
            }

            return node.Value == word;
        }

        public IEnumerable<string> Autocomplete(string word)
        {
            ExceptNullOrEmpty(word);

            if (!TryGetValueNode(word, out var node))
            {
                return new List<string>();
            }

            return node.GetAllChildren();
        }

        public void Delete(string word)
        {
            ExceptNullOrEmpty(word);

            if (TryGetValueNode(word, out TrieNode node))
            {
                node.Value = null;
            }
        }

        public void Clear()
        {
            this.root = new TrieNode();
        }

        private bool TryGetValueNode(string word, out TrieNode node)
        {
            node = root;
            foreach (char character in word)
            {
                if (!node.Children.ContainsKey(character))
                {
                    return false;
                }

                node = node.Children[character];
            }

            return true;
        }

        private void ExceptNullOrEmpty(string word)
        {
            if (String.IsNullOrEmpty(word))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
