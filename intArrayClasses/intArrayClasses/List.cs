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

        public T this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }

        public void Add(T element)
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

        public void Insert(int index, T element)
        {
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
            for (int i = 0; i < Count; i++)
            {
                if (list[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void RemoveAt(int index)
        {
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
            for (int i = array.Length - 1; i >= index; i--)
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
