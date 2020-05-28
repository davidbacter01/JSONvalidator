using System;
using System.Collections;

namespace intArrayClasses
{
    public class ObjEnumerator<T> : IEnumerator
    {
        private readonly List<T> objectArray;
        private int position = -1;

        public ObjEnumerator(List<T> list)
        {
            objectArray = list;
        }

        public bool MoveNext()
        {
            position++;
            return position < objectArray.Count;
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get { return objectArray[position]; }
        }

    }
}
