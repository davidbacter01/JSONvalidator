using System;

namespace intArrayClasses
{
    public class IntArray
    {
        private int[] arr;
        private const int StandardLength = 4;
        public IntArray()
        {
            arr = new int[StandardLength];
        }

        public void Add(int element)
        {
            Count++;
            ExpandIfNeeded();
            arr[Count - 1] = element;
        }

        public int Count { get; private set; } = 0;

        public int Element(int index) => arr[index];

        public void SetElement(int index, int element) => arr[index] = element;

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

        public void Insert(int index, int element)
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
