namespace intArrayClasses
{
    public sealed class LinkedListNode<T>
    {
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previous { get; set; }
        public LinkedList<T> ParentList { get; set; }
    }
}