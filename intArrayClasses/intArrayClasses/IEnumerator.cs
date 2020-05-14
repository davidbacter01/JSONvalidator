using System;
using System.Text;

namespace intArrayClasses
{
    public interface IEnumerator
    {
        object Current { get; } // expune elementul curent din enumerare
        bool MoveNext(); // avansează la elementul următor
        void Reset(); // poziționează enumeratorul înaintea primului element
    }
}
