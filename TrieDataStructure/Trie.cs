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
            if (String.IsNullOrEmpty(word))
            {
                throw new ArgumentNullException();
            }

            var node = root;
            foreach (char letter in word)
            {
                if (!node.children.ContainsKey(letter))
                {
                    node.children[letter] = new TrieNode();
                }

                node = node.children[letter];
            }

            if (node.Value == null)
            {
                node.Value = word;
            }
        }

        public bool Contains(string word)
        {
            if (String.IsNullOrEmpty(word))
            {
                throw new ArgumentNullException();
            }

            var current = root;
            foreach (char letter in word)
            {
                if (!current.children.ContainsKey(letter))
                {
                    return false;
                }

                current = current.children[letter];
            }

            if (current.Value == word)
            {
                return true;
            }

            return false;
        }

        public IEnumerable<string> Autocomplete(string word)
        {
            if (String.IsNullOrEmpty(word))
            {
                throw new ArgumentNullException();
            }

            var words = new List<string>();
            if (!Contains(word))
            {
                return words;
            }

            var node = GetValueNode(word);
            GetAllChildren(node, words);
            return words;
        }

        public void Delete(string word)
        {
            if (String.IsNullOrEmpty(word))
            {
                throw new ArgumentNullException();
            }

            GetValueNode(word).Value = null;
        }

        public void Clear()
        {
            this.root = new TrieNode();
        }

        private void GetAllChildren(TrieNode node, List<string> words)
        {
            if (node.Value != null)
            {
                words.Add(node.Value);
            }

            foreach (var childNode in node.children)
            {
                GetAllChildren(childNode.Value, words);
            }
        }

        private TrieNode GetValueNode(string word)
        {
            var node = root;
            foreach (char character in word)
            {
                node = node.children[character];
            }

            return node;
        }
    }
}
