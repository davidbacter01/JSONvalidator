using System;
using System.Collections;

namespace intArrayClasses
{
    public class List<T> : IEnumerable
    {
        private T[] array;
        private const int Size = 4;
        public List()
        {
            array = new T[Size];
        }

        public int Count { get; private set; } = 0;

        public virtual T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public virtual void Add(T element)
        {
            ResizeIfNeeded();
            Count++;
            array[Count - 1] = element;
        }

        public bool Contains(T element) => IndexOf(element) > -1;

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, T element)
        {
            ResizeIfNeeded();
            ShiftRight(index);
            array[index] = element;
            Count++;
        }

        public void Clear()
        {
            Array.Clear(array, 0, array.Length);
            Count = 0;
        }

        public void Remove(T element) => RemoveAt(IndexOf(element));

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }

            Array.Clear(array, Count - 1, 1);
        }

        private void ShiftRight(int index)
        {
            for (int i = Count; i >= index; i--)
            {
                array[i] = array[i - 1];
            }
        }

        private void ResizeIfNeeded()
        {
            if (array.Length == Count)
            {
                Array.Resize(ref array, Count * 2);
            }
        }
    }
}
