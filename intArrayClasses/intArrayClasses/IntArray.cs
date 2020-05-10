using System;

namespace intArrayClasses
{
    public class IntArray
    {
        private int[] arr;
        private int zerosCount = 0;
        private const int StandardLength = 4;
        private readonly string Left = "left";
        private readonly string Right = "right";
        public IntArray()
        {
            arr = new int[StandardLength];
        }

        public void Add(int element)
        {
            if (element == 0)
            {
                zerosCount++;
            }
            else
            {
                zerosCount = 0;
            }

            ExpandIfNeeded();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] != 0)
                {
                    arr[i + 1 + zerosCount] = element;
                    break;
                }

                if (i == 0)
                {
                    arr[0] = element;
                }
            }
        }

        public int Count()
        {
            int counter = 0;
            bool onEmptyPosition = true; 
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] != 0)
                {
                    onEmptyPosition = false;
                }

                if (!onEmptyPosition)
                {
                    counter++;
                }
            }

            return counter + zerosCount;
        }
        
        public int Element(int index) => arr[index];

        public void SetElement(int index, int element) => arr[index] = element;

        public bool Contains(int element) => Array.IndexOf(arr, element) != -1;
 

        public int IndexOf(int element) => Array.IndexOf(arr, element);

        public void Insert(int index, int element)
        {
            ExpandIfNeeded();
            Shift(Right, index);
            arr[index] = element;
        }

        public void Clear() => Array.Clear(arr, 0, arr.Length);

        public void Remove(int element)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == element)
                {
                    Shift(Left, i);
                    break;
                }
            }
        }

        public void RemoveAt(int index) => Shift(Left, index);

        private void Shift(string direction, int index)
        {
            if (direction == Left)
            {
                for (int i = index; i < arr.Length - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }

                arr[arr.Length - 1] = 0;
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
            if (arr[Count() - 1] != 0 || zerosCount > 0)
            {
                Array.Resize(ref arr, arr.Length + StandardLength);
            }
        }
    }
}
