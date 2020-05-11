using System;

namespace intArrayClasses
{
    public class IntArray
    {
        private int[] arr;
        private int count = 0;
        private const int StandardLength = 4;
        public IntArray()
        {
            arr = new int[StandardLength];
        }

        public void Add(int element)
        {
            count++;
            ExpandIfNeeded();
            arr[count - 1] = element;
        }

        public int Count() => count;
        
        public int Element(int index) => arr[index];

        public void SetElement(int index, int element) => arr[index] = element;

        public bool Contains(int element) => IndexOf(element) > -1;

        public int IndexOf(int element)
        {
            for(int i = 0; i < count; i++)
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
            count++;
        }

        public void Clear() 
        {
            Array.Clear(arr, 0, arr.Length);
            count = 0;
        }

        public void Remove(int element) => RemoveAt(IndexOf(element));   
        
        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            count--;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < count - 1; i++)
            {
                arr[i] = arr[i + 1];
            }

            arr[count - 1] = 0;
        }

        private void ShiftRight(int index)
        {
            for (int i = count; i >= index; i--)
            {
                arr[i] = arr[i - 1];
            }
        }

        private void ExpandIfNeeded()
        {
            if (arr.Length == count)
            {
                Array.Resize(ref arr, arr.Length * 2);
            }
        }
    }
}
