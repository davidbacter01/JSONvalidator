namespace intArrayClasses
{
    class ObjectArray
    {
        object[] array;
        private const int Size = 4;
        public ObjectArray()
        {
            array = new object[Size];
        }

        public int Count { get; private set; } = 0;
    }
}
