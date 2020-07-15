using System;
using System.Collections;
using System.Collections.Generic;

namespace intArrayClasses
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int[] buckets;
        private Element<TKey, TValue>[] elements;
        private readonly Stack<int> freeIndex;

        public Dictionary(int capacity = 5)
        {
            buckets = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                buckets[i] = -1;
            }

            elements = new Element<TKey, TValue>[capacity];
            freeIndex = new Stack<int>();
        }

        public TValue this[TKey key]
        {
            get
            {
                for (int i = buckets[GetBucketPosition(key)]; i != -1; i = elements[i].Next)
                {
                    if (elements[i].Key.Equals(key))
                    {
                        return elements[i].Value;
                    }
                }

                throw new KeyNotFoundException("key doesn't exist");
            }

            set
            {
                for (int i = buckets[GetBucketPosition(key)]; i != -1; i = elements[i].Next)
                {
                    if (elements[i].Key.Equals(key))
                    {
                        elements[i].Value = value;
                        return;
                    }
                }

                Add(key, value);
            }
        }

        public ICollection<TKey> Keys 
        { 
            get 
            {
                List<TKey> keys = new List<TKey>();
                foreach (var element in this)
                {
                    keys.Add(element.Key);
                }

                return keys;
            } 
        }

        public ICollection<TValue> Values 
        { 
            get
            {
                List<TValue> values = new List<TValue>();
                foreach (var element in elements)
                {
                    values.Add(element.Value);
                }

                return values;
            } 
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key is null");
            }

            if (GetKeyPosition(key) > -1)
            {
                throw new ArgumentException("An element with the same key already exists in the Dictionary<TKey,TValue>.");
            }

            if (elements.Length == Count)
            {
                Array.Resize(ref elements, elements.Length * 2);
            }

            var element = new Element<TKey, TValue> { Key = key, Value = value };
            var bucketIndex = GetBucketPosition(key);
            if (!(buckets[bucketIndex] == -1))
            {
                element.Next = buckets[bucketIndex];
            }

            if (freeIndex.Count == 0)
            {
                elements[Count] = element;
                buckets[bucketIndex] = Count;
            }
            else
            {
                int newIndex = freeIndex.Pop();
                elements[newIndex] = element;
                buckets[bucketIndex] = newIndex;
            }

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Array.Clear(elements, 0, elements.Length);
            freeIndex.Clear();
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = -1;
            }

            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (item.Key == null)
            {
                throw new ArgumentNullException("Key is null");
            }

            foreach (KeyValuePair<TKey,TValue> pair in this)
            {
                if (pair.Equals(item))
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

            return GetKeyPosition(key) > -1;
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

            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex] = new KeyValuePair<TKey, TValue>(elements[i].Key, elements[i].Value);
                arrayIndex++;
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                for (int j = buckets[i]; j != -1; j = elements[j].Next)
                {
                    yield return new KeyValuePair<TKey, TValue>(elements[j].Key, elements[j].Value);
                }
            }
        }

        public bool Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key is null");
            }

            if (GetKeyPosition(key) == -1)
            {
                return false;
            }

            int bucketIndex = GetBucketPosition(key);
            int elementIndex = buckets[bucketIndex];
            if (elements[elementIndex].Key.Equals(key))
            {
                freeIndex.Push(elementIndex);
                buckets[bucketIndex] = elements[elementIndex].Next;
                return true;
            }

            for (int i = elements[elementIndex].Next; i != -1; i = elements[i].Next)
            {
                if (elements[i].Key.Equals(key))
                {
                    elements[elementIndex].Next = elements[i].Next;
                    freeIndex.Push(i);
                    return true;
                }

                elementIndex = elements[elementIndex].Next;
            }

            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            foreach (KeyValuePair<TKey,TValue> pair in this)
            {
                if (pair.Equals(item))
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

        private int GetBucketPosition(TKey key) => Math.Abs(key.GetHashCode()) % buckets.Length;

        private int GetKeyPosition(TKey key)
        {
            int index = GetBucketPosition(key);
            for (int i = buckets[index]; i != -1; i = elements[i].Next)
            {
                if (elements[i].Key.Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
