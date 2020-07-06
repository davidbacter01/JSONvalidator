using System;
using System.Collections.Generic;
using System.Text;

namespace intArrayClasses
{
    public sealed class LinkedListNode<T>
    {
        public T Value { get; internal set; }
        public LinkedListNode<T> Next { get; internal set; }
        public LinkedListNode<T> Previous { get; set; }
    }
}