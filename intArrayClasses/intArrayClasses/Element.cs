using System;
using System.Collections.Generic;
using System.Text;

namespace intArrayClasses
{
    public class Element<TKey,TValue>
    {
        public TKey key;
        public TValue value;
        public int next;
        
        public Element(TKey key, TValue value)
        {
            this.key = key;
            this.value = value;
            next = -1;
        }
    }
}
