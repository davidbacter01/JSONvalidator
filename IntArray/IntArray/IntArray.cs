using System;

namespace IntArray
{
    public class IntArray
    {
        private int[] array;

        public IntArray()
        {
            array = new int[4];
        }

		public void Add(int element)
		{
			// adaugă un nou element la sfârșitul șirului 
			if (array[array.Length - 1] == 0)
			{
				Array.Resize(ref array, array.Length + 4);
			}

			for (int i = array.Length - 1; i >= 0; i--)
			{
				if (array[i - 1] != 0)
				{
					array[i] = element;
					break;
				}
			}
		}

		public int Count()
		{
			return array.Length;
		}

		public int Element(int index)
		{
			return array[index];
		}

		public void SetElement(int index, int element)
		{
			array[index] = element;
		}

		public bool Contains(int element)
		{
			foreach (int value in array)
			{
				if (value == element)
					return true;
			}

			return false;
		}

		public int IndexOf(int element)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == element)
					return i;
			}

			return -1;
		}

		public void Insert(int index, int element)
		{
			if (array[array.Length - 1] == 0)
			{
				Array.Resize(ref array, array.Length + 4);
			}

			for (int i = array.Length - 1; i > index; i--)
			{
				array[i] = array[i - 1];
			}

			array[index] = element;
		}

		public void Clear()
		{
			// șterge toate elementele din șir
			Array.Clear(array, 0, array.Length);
		}

		public void Remove(int element)
		{
			// șterge prima apariție a elementului din șir
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == element)
				{
					Array.Clear(array, i, 1);
					break;
				}

			}
		}

		public void RemoveAt(int index)
		{
			// șterge elementul de pe poziția dată
			Array.Clear(array, index, 1);
		}

	}
}

