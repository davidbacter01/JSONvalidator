using System;

namespace IntArray
{
    public class IntArray
    {
        private const int StandardSize = 4;
        private int[] array;

        public IntArray()
        {
            array = new int[StandardSize];
        }

        public void Add(int element)
        {
            if (array[array.Length - 1] == 0)
            {
                Array.Resize(ref array, array.Length + StandardSize);
            }

            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i - 1] != 0)
                {
                    array[i] = element;
                    break;
                }

                if (i == 1)
                {
                    array[0] = element;
                }
            }
        }

        public int Count()
        {
            bool notEmpty = false;
            int count = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] != 0)
                {
                    notEmpty = true;
                }

                if (notEmpty)
                {
                    count++;
                }
            }

            return count;
        }

        public int Element(int index) => array[index];

        public void SetElement(int index, int element) => array[index] = element;

        public bool Contains(int element)
        {
            foreach (int value in array)
            {
                if (value == element)
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            if (array[array.Length - 1] == 0)
            {
                Array.Resize(ref array, array.Length + StandardSize);
            }

            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }

            array[index] = element;
        }

        public void Clear() => Array.Clear(array, 0, array.Length);

        public void Remove(int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                {
                    Array.Clear(array, i, 1);
                    break;
                }
            }
        }

        public void RemoveAt(int index) => Array.Clear(array, index, 1);
    }
}