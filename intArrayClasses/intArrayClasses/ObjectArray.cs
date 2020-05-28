using System;
using System.Collections;

namespace intArrayClasses
{
    public class ObjectArray : IEnumerable
    {
        private object[] array;
        private const int Size = 4;
        public ObjectArray()
        {
            array = new object[Size];
        }

        public int Count { get; private set; } = 0;

        public virtual object this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public void Add(object element)
        {
            ResizeIfNeeded();
            Count++;
            array[Count - 1] = element;
        }

        public bool Contains(object element) => IndexOf(element) > -1;

        public int IndexOf(object element)
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

        public void Insert(int index, object element)
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

        public void Remove(object element) => RemoveAt(IndexOf(element));

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        public IEnumerator GetEnumerator()
        {
            return new ObjEnumerator(this);
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                array[i] = array[i + 1];
            }

            array[Count - 1] = 0;
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
