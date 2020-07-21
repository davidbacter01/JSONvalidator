using System;
using System.Collections;
using System.Collections.Generic;

namespace TrieDataStructure
{
    public class TrieNode
    {
        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
        }

        private Dictionary<char, TrieNode> Children { get; }
        public string Value { get; set; } = null;
        
        public void AddChild(string word)
        {
            TrieNode node = this;
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

        public bool TryGetChild(string word, out TrieNode node)
        {
            node = this;
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

        public IEnumerable<string> GetAllChildren()
        {
            var words = new List<string>();
            if (Value != null)
            {
                words.Add(Value);
            }

            foreach (var child in Children)
            {
                words.AddRange(child.Value.GetAllChildren());
            }

            return words;
        }
    }
}
