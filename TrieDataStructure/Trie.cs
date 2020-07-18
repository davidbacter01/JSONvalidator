using System;
using System.Collections;
using System.Collections.Generic;

namespace TrieDataStructure
{
    public class Trie
    {
        private TrieNode root;
        private readonly List<string> autocompletes;

        public Trie()
        {
            root = new TrieNode();
            autocompletes = new List<string>();
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

                if (letter == word[^1])
                {
                    node.Value = word;
                }
            }
        }

        public bool Contains(string word)
        {
            if (String.IsNullOrEmpty(word))
            {
                throw new ArgumentNullException();
            }

            var current = root;
            foreach(char letter in word)
            {
                if (letter == word[^1])
                {
                    return current.Value == word;
                }

                current = current.children[letter];
            }

            return false;
        }

        public ICollection Autocomplete(string word)
        {
            if (String.IsNullOrEmpty(word))
            {
                throw new ArgumentNullException();
            }

            autocompletes.Clear();
            var node = root;
            foreach (char letter in word)
            {
                if (!node.children.ContainsKey(letter))
                {
                    return autocompletes;
                }

                if (node.Value == word)
                {
                    autocompletes.Add(word);
                }

                node = node.children[letter];
            }

            GetAllChildren(node);
            return autocompletes;
        }

        public void Delete(string word)
        {
            if (String.IsNullOrEmpty(word))
            {
                throw new ArgumentNullException();
            }

            var node = root;
            foreach(var letter in word)
            {
                node = node.children[letter];
                if (letter == word[^1] && node.Value == word)
                {
                    node.Value = null;
                }
            }
        }

        public void Clear()
        {
            this.root = new TrieNode();
        }

        private void GetAllChildren(TrieNode node)
        {
            if (node.Value != null)
            {
                autocompletes.Add(node.Value);
            }

            foreach (var childNode in node.children)
            {
                GetAllChildren(childNode.Value);
            }
        }
    }
}
