using System;
using System.Collections.Generic;
using System.Linq;

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
            root.AddChild(word);
        }

        public bool Contains(string word)
        {
            ExceptNullOrEmpty(word);
            return root.GetAllChildren().Contains(word);
        }

        public IEnumerable<string> Autocomplete(string word)
        {
            ExceptNullOrEmpty(word);
            if (!root.TryGetChild(word, out var node))
            {
                return new List<string>();
            }

            return node.GetAllChildren();
        }

        public void Delete(string word)
        {
            ExceptNullOrEmpty(word);
            if (root.TryGetChild(word, out TrieNode node))
            {
                node.Value = null;
            }
        }

        public void Clear()
        {
            this.root = new TrieNode();
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
