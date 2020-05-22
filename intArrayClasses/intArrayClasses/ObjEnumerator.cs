using System;
using System.Collections;

namespace intArrayClasses
{
    public class ObjEnumerator : IEnumerator
    {
        private readonly ObjectArray objectArray;
        private int position = -1;

        public ObjEnumerator(ObjectArray list)
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
