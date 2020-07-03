using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace intArrayClasses
{
    public class ReadonlyList<T> : List<T>
    {
        public ReadonlyList() : base() { }
        
        public override T this[int index]
        {
            get => base[index];
            set
            {
                if (IsReadOnly)
                {
                    throw new NotSupportedException("This list is readonly!");
                }

                base[index] = value;
            }
        }

        private bool AsReadonly { get; set; } = false;
        public override bool IsReadOnly { get => AsReadonly; }

        public override void Add(T element)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("This list is readonly!");
            }

            base.Add(element);
            AsReadonly = true;
        }

        public override void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("This list is readonly!");
            }

            base.Clear();
        }

        public override void Insert(int index, T element)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("List is readonly!");
            }

            base.Insert(index, element);
        }

        public override bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("List is readonly!");
            }

            return base.Remove(item);
        }

        public override void RemoveAt(int index)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("List is readonly!");
            }

            base.RemoveAt(index);
        }
    }
}
