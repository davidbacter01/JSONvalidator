using System;
using System.Collections;
using System.Collections.Generic;

namespace TrieDataStructure
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> children;

        public TrieNode()
        {
            children = new Dictionary<char, TrieNode>();
        }

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

            foreach (var childNode in node.children)
            {
                PopulateList(childNode.Value, words);
            }
        }
    }
}
