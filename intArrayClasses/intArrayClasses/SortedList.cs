using System;
using System.Collections;

namespace intArrayClasses
{
    public class SortedList<T> : IEnumerable where T : IComparable<T>
    {
        public int Count { get; private set; } = 0;
        private T[] list;
        private const int Capacity = 4;
        public SortedList()
        {
            list = new T[Capacity];
        }

        public void Add(T element)
        {
            if (Count == 0)
            {
                list[0] = element;
                Count++;
                return;
            }

            ResizeIfNeeded();
            list[Count] = element;
            Count++;
            Sort();
        }

        public T this[int index]
        {
            get => list[index];
            set
            {
                if (index < 0 || index > Count - 1)
                {
                    return;
                }

                if (CanInsertElementAtIndex(index - 1, value) ||
                    CanInsertElementAtIndex(index + 1, value))
                {
                    list[index] = value;
                }
            }
        }

        public void Insert(int index, T element)
        {
            if (index < 0 || index > Count)
            {
                return;
            }

            ResizeIfNeeded();
            if (CanInsertElementAtIndex(index, element))
            {
                ShiftOneRightAndIncreaseCount(index);
                list[index] = element;
            }
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

        public void Clear()
        {
            Array.Clear(list, 0, list.Length);
            Count = 0;
        }

        public void Remove(T element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            ShiftLeftAndDecreaseCount(index);
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return list[i];
            }
        }

        private bool CanInsertElementAtIndex(int index, T element)
        {
            if (index < 0)//code reaches this point only in set case and only for list[0] = value
            {
                return element.CompareTo(list[0]) <= 0;
            }

            if (index == 0)
            {
                return element.CompareTo(list[0]) <= 0;
            }

            if (index == Count)
            {
                return element.CompareTo(list[Count - 1]) >= 0;
            }

            return element.CompareTo(list[index - 1]) >= 0 &&
                element.CompareTo(list[index]) <= 0;
        }

        private void ShiftOneRightAndIncreaseCount(int index)
        {
            for (int i = Count; i > index; i--)
            {
                list[i] = list[i - 1];
            }

            Count++;
        }

        private void ShiftLeftAndDecreaseCount(int index)
        {
            for (int i = index; i < Count; i++)
            {
                list[i] = list[i + 1];
            }

            Count--;
        }

        private void ResizeIfNeeded()
        {
            if (Count == list.Length)
            {
                Array.Resize(ref list, list.Length * 2);
            }
        }

        private void Sort()
        {
            int limit = Count - 1;
            bool swaped = true;
            while (swaped)
            {
                swaped = false;
                for (int j = 0; j < limit; j++)
                {
                    if (list[j].CompareTo(list[j + 1]) > 0)
                    {
                        T temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        swaped = true;
                    }
                }
            }
        }
    }
}
