using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace intArrayClasses
{
    public class ReadonlyList<T> : IList<T>
    {
        private readonly T[] list;
        public ReadonlyList(T[] readOnlyList) 
        {
            list = readOnlyList;
        }
        
        public T this[int index]
        {
            get => list[index];
            set => throw new NotSupportedException("This list is readonly!");
        }

        public bool IsReadOnly => true;

        public int Count { get => list.Length; }

        public void Add(T element) => throw new NotSupportedException("This list is readonly!");

        public void Clear() => throw new NotSupportedException("This list is readonly!");

        public bool Contains(T item)
        {
            return IndexOf(item) > -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Target array must not be null!");
            }

            if (arrayIndex < 0 || arrayIndex > Count)
            {
                throw new ArgumentOutOfRangeException("arrayIndex parameter is out of range!");
            }

            if (array.Length - arrayIndex - 1 < Count)
            {
                throw new ArgumentException("Not enough space in target array!");
            }

            int listIndex = 0;

            for (int i = arrayIndex; i < array.Length; i++)
            {
                array[i] = list[listIndex];
                listIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return list[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(list[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T element) => throw new NotSupportedException("This list is readonly!");

        public bool Remove(T item) => throw new NotSupportedException("This list is readonly!");

        public void RemoveAt(int index) => throw new NotSupportedException("This list is readonly!");

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return list[i];
            }
        }
    }
}
