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

        public Dictionary<char, TrieNode> Children { get; }
        public string Value { get; set; } = null;
        public IEnumerable<string> GetAllChildren()
        {
            var words = new List<string>();
            if (Value == null)
            {
                return words;
            }

            PopulateList(this, words);
            return words;
        }

        private void PopulateList(TrieNode node, List<string> words)
        {
            if (node.Value != null)
            {
                words.Add(node.Value);
            }

            foreach (var childNode in node.Children)
            {
                PopulateList(childNode.Value, words);
            }
        }
    }
}
