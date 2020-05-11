using System;

namespace intArrayClasses
{
    public class IntArray
    {
        private int[] arr;
        private int count = 0;
        private const int StandardLength = 4;
        private readonly string Left = "left";
        private readonly string Right = "right";
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

        public bool Contains(int element) => Array.IndexOf(GetActualArray(), element) != -1;
 

        public int IndexOf(int element) => Array.IndexOf(GetActualArray(), element);

        public void Insert(int index, int element)
        {
            ExpandIfNeeded();
            Shift(Right, index);
            arr[index] = element;
        }

        public void Clear() 
        {
            Array.Clear(arr, 0, arr.Length);
            count = 0;
        }

        public void Remove(int element)
        {
            for(int i = 0; i < count; i++)
            {
                if (arr[i] == element)
                {
                    Shift(Left, i);
                    break;
                }
            }

            count--;
        }

        public void RemoveAt(int index)
        {
            Shift(Left, index);
            count--;
        }

        private void Shift(string direction, int index)
        {
            if (direction == Left)
            {
                for (int i = index; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[count - 1] = 0;
            }
            else
            {
                for (int i = arr.Length - 1; i >= index; i--)
                {
                    arr[i] = arr[i - 1];
                }
            }
        }

        private void ExpandIfNeeded()
        {
            if (arr.Length == count)
            {
                Array.Resize(ref arr, arr.Length * 2);
            }
        }

        private int[] GetActualArray()
        {
            int[] actualArray = new int[count];
            for(int i = 0; i < count; i++)
            {
                actualArray[i] = arr[i];
            }

            return actualArray;
        }
    }
}
