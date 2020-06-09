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
                if (ElementAt(index - 1, value, index < 0 || index > Count - 1) ||
                    ElementAt(index + 1, value, index < 0 || index > Count - 1))
                {
                    base[index] = value;
                }
            }
        }

        public override void Insert(int index, T element)
        {
            if (ElementAt(index, element, index < 0 || index > Count))
            {
                base.Insert(index, element);
            }
        }

        private bool ElementAt(int index, T element, bool inBounds)
        {
            if (!inBounds)
                return false;

            if (index < 0)//code reaches this point only in set case and only for list[0] = value
            {
                return element.CompareTo(base[0]) <= 0;
            }

            if (index == 0)
            {
                return element.CompareTo(base[0]) <= 0;
            }

            if (index == Count)
            {
                return element.CompareTo(base[Count - 1]) >= 0;
            }

            return element.CompareTo(base[index - 1]) >= 0 &&
                element.CompareTo(base[index]) <= 0;
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
