using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace intArrayClasses
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int[] buckets = { -1, -1, -1, -1, -1 };
        private readonly List<Element<TKey, TValue>> elements;
        private readonly Stack<int> freeIndex;

        public Dictionary()
        {
            elements = new List<Element<TKey, TValue>>();
            freeIndex = new Stack<int>();
        }

        public TValue this[TKey key] 
        { 
            get
            {
                int index = GetHashPosition(key);
                for (int elementIndex = buckets[index];
                    elementIndex == -1; 
                    elementIndex = elements[elementIndex].next)
                {
                    if (elements[elementIndex].key.Equals(key))
                    {
                        return elements[elementIndex].value;
                    }
                }

                throw new KeyNotFoundException("key doesn't exist");
            }

            set
            {
                try
                {
                    this[key] = value;
                }
                catch (KeyNotFoundException)
                {
                    Add(key, value);
                }
            }
        }

        public ICollection<TKey> Keys { get; } = new List<TKey>();

        public ICollection<TValue> Values { get; } = new List<TValue>();

        public int Count { get; private set; } = 0;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key is null");
            }

            if (Keys.Contains(key))
            {
                throw new ArgumentException("An element with the same key already exists in the Dictionary<TKey,TValue>.");
            }

            var element = new Element<TKey, TValue>(key, value);
            var index = GetHashPosition(key);
            if (freeIndex.Count == 0)
            {
                elements.Add(element);
            }
            else
            {
                elements[freeIndex.Pop()] = element;
            }

            element.next = elements.IndexOf(elements[buckets[index]]);
            buckets[index] = elements.IndexOf(element);
            Keys.Add(key);
            Values.Add(value);
            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            elements.Clear();
            freeIndex.Clear();
            Array.Clear(buckets, 0, buckets.Length);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (item.Key == null)
            {
                throw new ArgumentNullException("Key is null");
            }

            foreach (Element<TKey,TValue> element in elements)
            {
                if (element.key.Equals(item.Key) && element.value.Equals(item.Value))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key is null");
            }

            return Keys.Contains(key);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array is null");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("not enough space in array");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("index is less than zero");
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach(Element<TKey,TValue> element in elements)
            {
                yield return new KeyValuePair<TKey, TValue>(element.key, element.value);
            }
        }

        public bool Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key is null");
            }

            if (!Keys.Contains(key))
            {
                return false;
            }

            int bucketIndex = GetHashPosition(key);
            int elementIndex = buckets[bucketIndex];
            if (elements[elementIndex].next < 0)
            {
                buckets[bucketIndex] = -1;
                freeIndex.Push(elementIndex);
                return true;
            }

            buckets[bucketIndex] = elements[elementIndex].next;
            freeIndex.Push(elementIndex);
            return true;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            foreach (Element<TKey, TValue> element in elements)
            {
                if (element.key.Equals(item.Key) && element.value.Equals(item.Value))
                {
                    return Remove(item.Key);
                }
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key is null");
            }

            foreach (var pair in this)
            {
                if (pair.Key.Equals(key))
                {
                    value = pair.Value;
                    return true;
                }
            }

            value = default;
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int GetHashPosition(TKey key) => Math.Abs(key.GetHashCode()) % buckets.Length;
    }
}
