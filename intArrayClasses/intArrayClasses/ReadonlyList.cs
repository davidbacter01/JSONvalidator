using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace intArrayClasses
{
    public class ReadonlyList<T> : List<T>
    {
        public ReadonlyList(T[] readOnlyList) 
        {
            base.list = readOnlyList;
        }
        
        public override T this[int index]
        {
            get => base[index];
            set => throw new NotSupportedException("This list is readonly!");
        }

        public override bool IsReadOnly => true;

        public override void Add(T element) => throw new NotSupportedException("This list is readonly!");

        public override void Clear() => throw new NotSupportedException("This list is readonly!");

        public override void Insert(int index, T element) => throw new NotSupportedException("This list is readonly!");

        public override bool Remove(T item) => throw new NotSupportedException("This list is readonly!");

        public override void RemoveAt(int index) => throw new NotSupportedException("This list is readonly!");
    }
}
