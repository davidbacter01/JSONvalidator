using System;
using System.Collections;
using System.Collections.Generic;

namespace intArrayClasses
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int[] buckets;
        private Element<TKey, TValue>[] elements;
        private int freeIndex;

        public Dictionary(int capacity = 5)
        {
            buckets = new int[capacity];
            Array.Fill(buckets, -1);
            elements = new Element<TKey, TValue>[capacity];
            freeIndex = -1;
        }

        public TValue this[TKey key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key is null");
                }

                int index = GetKeyPosition(key);
                if (index < 0)
                {
                    throw new KeyNotFoundException("key is not in this dictionary");
                }

                return elements[index].Value;
            }

            set
            {
                if (key == null)
                {
                    throw new ArgumentNullException("key is null");
                }

                int index = GetKeyPosition(key);
                if (index < 0)
                {
                    Add(key, value);
                    return;
                }

                elements[index].Value = value; 
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
            if (buckets[bucketIndex] == -1)
            {
                if (freeIndex > -1)
                {
                    buckets[bucketIndex] = freeIndex;
                    int temp = elements[freeIndex].Next;
                    elements[freeIndex] = element;
                    freeIndex = temp;
                    Count++;
                    return;
                }

                elements[Count] = element;
                buckets[bucketIndex] = Count;
                Count++;
                return;
            }

            if (freeIndex == -1)
            {
                elements[Count] = element;
                element.Next = buckets[bucketIndex];
                buckets[bucketIndex] = Count;
            }
            else
            {
                element.Next = buckets[bucketIndex];
                elements[freeIndex] = element;
                buckets[bucketIndex] = freeIndex;
                freeIndex = elements[freeIndex].Next;
            }

            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Array.Fill(elements, default);
            freeIndex = -1;
            Array.Fill(buckets, -1);
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

            foreach (KeyValuePair<TKey,TValue> pair in this)
            {
                array[arrayIndex] = pair;
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

            int index = GetKeyPosition(key);
            if (index == -1)
            {
                return false;
            }

            int bucketIndex = GetBucketPosition(key);
            if (elements[buckets[bucketIndex]].Key.Equals(key))
            {
                freeIndex = buckets[bucketIndex];
                buckets[bucketIndex] = -1;
                elements[freeIndex].Next = -1;
                Count--;
                return true;
            }

            for (int i = elements[index].Next; i != -1; i = elements[i].Next)
            {
                if (elements[i].Key.Equals(key))
                {
                    elements[index].Next = elements[i].Next;
                    freeIndex = i;
                    elements[i].Next = -1;
                    Count--;
                    return true;
                }

                index = elements[index].Next;
            }

            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if (item.Key == null)
            {
                throw new ArgumentNullException("key is null");
            }

            int index = GetKeyPosition(item.Key);
            if (index < 0)
            {
                throw new ArgumentException("item is not in this dictionary");
            }

            if (elements[index].Value.Equals(item.Value))
            {
                return Remove(item.Key);
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key is null");
            }

            int index = GetKeyPosition(key);
            if (index < 0)
            {
                value = default;
                return false;
            }

            value = elements[index].Value;
            return true;
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
