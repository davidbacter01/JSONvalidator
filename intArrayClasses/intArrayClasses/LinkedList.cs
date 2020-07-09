using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace intArrayClasses
{
    public class LinkedList<T> : ICollection<T>
    {
        private readonly LinkedListNode<T> sentinel;
        public LinkedList()
        {
            sentinel = new LinkedListNode<T>();
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
            sentinel.ParentList = this;
        }

        public int Count { get; private set; } = 0;

        public LinkedListNode<T> First { get => sentinel.Next; }

        public LinkedListNode<T> Last { get => sentinel.Previous; }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            AddAfter(Last, item);
        }

        public void Add(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node is null");
            }

            if (node.ParentList != this)
            {
                throw new InvalidOperationException("node belongs to a different list or it's ParentList is not set");
            }

            AddAfter(Last, node);
        }

        public void AddLast(T item)
        {
            Add(item);
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node is null");
            }

            if (node.ParentList != this)
            {
                throw new InvalidOperationException("node belongs to a different list or it's ParentList is not set");
            }

            Add(node);
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            AddAfter(sentinel, node);
        }

        public void AddAfter(LinkedListNode<T> target, LinkedListNode<T> toAdd)
        {
            if (toAdd == null)
            {
                throw new ArgumentNullException("node is null");
            }

            if (toAdd.ParentList != this)
            {
                throw new InvalidOperationException("node belongs to a different list or it's ParentList is not set");
            }

            toAdd.Next = target.Next;
            toAdd.Previous = target;
            target.Next.Previous = toAdd;
            target.Next = toAdd;
            Count++;
        }

        public void AddBefore(LinkedListNode<T> target, LinkedListNode<T> toAdd)
        {
            AddAfter(target.Previous, toAdd);
        }

        public void AddFirst(T item)
        {
            AddAfter(sentinel, item);
        }

        public void AddBefore(LinkedListNode<T> listNode, T value)
        {
            AddAfter(listNode.Previous, value);
        }

        public void AddAfter(LinkedListNode<T> listNode, T value)
        {
            if (listNode == null)
            {
                throw new ArgumentNullException("linkedListNode can't be null!");
            }

            if (listNode.ParentList != this)
            {
                throw new InvalidOperationException("node is not in the current linked list!");
            }


            var newNode = new LinkedListNode<T>
            {
                Value = value,
                Next = listNode.Next,
                Previous = listNode,
                ParentList = this
            };
            var current = listNode.Next;
            current.Previous = newNode;
            listNode.Next = newNode;
            Count++;
        }

        public void Clear()
        {
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
            Count = 0;
        }

        public LinkedListNode<T> Find(T item)
        {
            for (var current = First; current != sentinel; current = current.Next)
            {
                if (current.Value.Equals(item))
                {
                    return current;
                }
            }

            return null;
        }

        public LinkedListNode<T> FindLast(T item)
        {
            LinkedListNode<T> current;
            for (current=Last;
                current.Value.Equals(item);
                current=current.Previous)
            {
                if (current.Previous == sentinel)
                {
                    return null;
                } 
            }

            return current;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array is null");
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException("arrayIndex out of range");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Not enough space in target array!");
            }

            int index = arrayIndex;
            foreach (var value in this)
            {
                array[index] = value;
                index++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = First;
            for (int i = 0; i < Count; i++)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> current;
            for (current = First; current != sentinel; current = current.Next)
            {
                if (current.Value.Equals(item))
                {
                    current = current.Previous;
                    current.Next = current.Next.Next;
                    current.Next.Previous = current;
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public void Remove(LinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node is null");
            }

            if (node.ParentList != this)
            {
                throw new InvalidOperationException("node is not in this list");
            }

            for (var current = First; current != sentinel; current = current.Next)
            {
                if (current.Equals(node))
                {
                    current = current.Previous;
                    current.Next = current.Next.Next;
                    current.Next.Previous = current;
                    Count--;
                }
            }
        }

        public void RemoveFirst()
        {
            if (sentinel.Next == sentinel.Previous)
            {
                throw new InvalidOperationException("linked list is empty");
            }

            Remove(First);
        }

        public void RemoveLast()
        {
            if (sentinel.Next == sentinel.Previous)
            {
                throw new InvalidOperationException("linked list is empty");
            }

            Remove(Last);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
