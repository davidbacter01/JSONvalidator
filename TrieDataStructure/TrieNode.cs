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
