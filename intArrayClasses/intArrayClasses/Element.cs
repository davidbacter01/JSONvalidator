using System;
using System.Collections.Generic;
using System.Text;

namespace intArrayClasses
{
    public class Element<TKey,TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public int Next { get; set; } = -1;
    }
}
