using System;

namespace intArrayClasses
{
    public class IntArray
    {
        protected int[] arr;
        private const int StandardLength = 4;
        public IntArray()
        {
            arr = new int[StandardLength];
        }

        public virtual void Add(int element)
        {
            Count++;
            ExpandIfNeeded();
            arr[Count - 1] = element;
        }

        public int Count { get; private set; } = 0;

        public virtual int this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }

        public bool Contains(int element) => IndexOf(element) > -1;

        public int IndexOf(int element)
        {
            for(int i = 0; i < Count; i++)
            {
                if (arr[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, int element)
        {
            ExpandIfNeeded();
            ShiftRight(index);
            arr[index] = element;
            Count++;
        }

        public void Clear() 
        {
            Array.Clear(arr, 0, arr.Length);
            Count = 0;
        }

        public void Remove(int element) => RemoveAt(IndexOf(element));   
        
        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                arr[i] = arr[i + 1];
            }

            arr[Count - 1] = 0;
        }

        private void ShiftRight(int index)
        {
            for (int i = Count; i >= index; i--)
            {
                arr[i] = arr[i - 1];
            }
        }

        private void ExpandIfNeeded()
        {
            if (arr.Length == Count)
            {
                Array.Resize(ref arr, arr.Length * 2);
            }
        }
    }
}
