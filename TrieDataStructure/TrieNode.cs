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
    }
}
