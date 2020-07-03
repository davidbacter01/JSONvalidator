using System;
using System.Collections;
using System.Collections.Generic;

namespace intArrayClasses
{
    public class List<T> : IList<T>
    {
        private T[] list;
        private const int Size = 4;
        public List()
        {
            list = new T[Size];
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly => throw new NotImplementedException();

        public virtual T this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }

        public virtual void Add(T element)
        {
            ResizeIfNeeded();
            Count++;
            list[Count - 1] = element;
        }

        public bool Contains(T element) => IndexOf(element) > -1;

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (list[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T element)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException("index is not a valid index in the IList<T>!");
            }

            ResizeIfNeeded();
            ShiftRight(index, list);
            list[index] = element;
            Count++;
        }

        public void Clear()
        {
            Array.Clear(list, 0, list.Length);
            Count = 0;
        }


        public bool Remove(T item)
        {
            if (IndexOf(item) > -1)
            {
                RemoveAt(IndexOf(item));
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("index is not a valid index in the IList<T>!");
            }

            ShiftLeft(index);
            Count--;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                yield return list[i];
            }
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

            int newArrayLength = array.Length + Count;
            Array.Resize(ref array, newArrayLength);
            int index = arrayIndex;
            foreach (T element in list)
            {
                ShiftRight(index, array);
                array[index] = element;
                index++;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return list[i];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                list[i] = list[i + 1];
            }

            Array.Clear(list, Count - 1, 1);
        }

        private void ShiftRight(int index, T[] array)
        {
            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }

        private void ResizeIfNeeded()
        {
            if (list.Length == Count)
            {
                Array.Resize(ref list, Count * 2);
            }
        }
    }
}
