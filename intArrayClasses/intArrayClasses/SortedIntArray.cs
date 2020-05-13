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
            base.Insert(index, element);
            Sort();
        }

        public override int this[int index] 
        {
            get => base[index];
            set 
            {
                base[index] = value;
                Sort();
            }    
        }


        private void Sort()
        {
            int limit = Count - 1;           
            for (int i = 0; i < limit; i++)
            {
                bool swaped = false;
                for (int j = 0; j < limit - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swaped = true;
                    }
                }

                if (!swaped)
                    break;
            }                      
        }
    }
}
