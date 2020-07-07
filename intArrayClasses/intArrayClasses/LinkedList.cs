using System;
using System.Collections;
using System.Collections.Generic;

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
        }

        public int Count { get; private set; } = 0;

        public LinkedListNode<T> First { get => sentinel.Next; }

        public LinkedListNode<T> Last { get => sentinel.Previous; }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            AddAfter(Last, item);
        }

        public void AddLast(T item)
        {
            Add(item);
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

            if (listNode != sentinel)
            {
                if (Find(listNode.Value) == null)
                {
                    throw new InvalidOperationException("node is not in the current linked list!");
                }
            }

            var newNode = new LinkedListNode<T>
            {
                Value = value,
                Next = listNode.Next,
                Previous = listNode
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
            var current = First;

            while (!current.Value.Equals(item))
            {
                if (current.Next == sentinel)
                {
                    return null;
                }

                current = current.Next;
            }

            return current;
        }

        public LinkedListNode<T> FindLast(T item)
        {
            var current = Last;
            while (!current.Value.Equals(item))
            {
                if (current.Previous == sentinel)
                {
                    return null;
                }

                current = current.Previous;
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

            if (array.Length - arrayIndex - 1 < Count)
            {
                throw new ArgumentException("Not enough space in target array!");
            }

            var current = sentinel.Next;
            for (int i = arrayIndex; i < Count; i++)
            {
                array[i] = current.Value;
                current = current.Next;
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
            var current = First;
            for (int i = 0; i < Count; i++)
            {
                if (current.Value.Equals(item))
                {
                    current = current.Previous;
                    current.Next = current.Next.Next;
                    current.Next.Previous = current;
                    Count--;
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public void RemoveFirst()
        {
            if (sentinel.Next == sentinel.Previous)
            {
                throw new InvalidOperationException("linked list is empty");
            }

            Remove(First.Value);
        }

        public void RemoveLast()
        {
            if (sentinel.Next == sentinel.Previous)
            {
                throw new InvalidOperationException("linked list is empty");
            }

            Remove(Last.Value);
        }

        IEnumerator IEnumerable.GetEnumerator()

        {
            var current = First;
            while (current != sentinel)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }
}
