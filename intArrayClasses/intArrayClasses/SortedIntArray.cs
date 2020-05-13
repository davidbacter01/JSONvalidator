using System;

namespace intArrayClasses
{
    public class SortedIntArray : IntArray
    {
        public SortedIntArray():base()
        {
        }

        public override void Add(int element)
        {
            base.Add(element);
            Sort();
        }

        public override void Insert(int index, int element)
        {
            if (base[index - 1] <= element && base[index] >= element)
            {
                base.Insert(index, element);
            }
            else if (index == 0 && base[0] >= element)
            {
                base.Insert(index, element);
            }
        }

        public override int this[int index] 
        {
            get => base[index];
            set 
            {
                if (CanBeInsertedAt(index, value))
                {
                    base[index] = value;
                }
            }    
        }

        private bool CanBeInsertedAt(int index, int value)
        {
            if (index == Count - 1 && base[index - 1] <= value)
            {
                return true;
            }
            else if (index == 0 && base[1] >= value)
            {
                return true;
            }
            else if (index > 0 && 
                index < Count - 1 &&
                value >= base[index - 1] &&
                value <= base[index + 1])
            {
                return true;
            }

            return false;
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
                    if (base[j] > base[j + 1])
                    {
                        int temp = base[j];
                        base[j] = base[j + 1];
                        base[j + 1] = temp;
                        swaped = true;
                    }
                }
            }                      
        }
    }
}
