using System;
using System.Collections;

namespace intArrayClasses
{
    public class SortedList<T> : List<T>, IEnumerable where T : IComparable<T>
    {
        public SortedList() : base()
        {
        }

        public override void Add(T element)
        {
            base.Add(element);
            Sort();
        }

        public override T this[int index]
        {
            set
            {
                if (ElementAt(index - 1, value).CompareTo(value) <= 0 &&
                    value.CompareTo(ElementAt(index + 1, value)) <= 0)
                {
                    base[index] = value;
                }
            }
        }

        public override void Insert(int index, T element)
        {
            if (ElementAt(index - 1, element).CompareTo(element) <= 0 &&
                element.CompareTo(ElementAt(index, element)) <= 0)
            {
                base.Insert(index, element);
            }
        }

        private T ElementAt(int index, T value)
        {
            return index >= 0 && index < Count ? base[index] : value;
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
                    if (base[j].CompareTo(base[j + 1]) > 0)
                    {
                        T temp = base[j];
                        base[j] = base[j + 1];
                        base[j + 1] = temp;
                        swaped = true;
                    }
                }
            }
        }
    }
}
