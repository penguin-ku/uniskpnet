namespace System.Collections.Generic
{
    /// <summary>
    /// 链表扩展方法
    /// </summary>
    public static class LinkedListNodeExtensions
    {
        public static LinkedListNode<T> Append<T>(this LinkedList<T> p_ll, T p_value)
        {
            if (p_ll.Count == 0)
            {
                return p_ll.AddFirst(p_value);
            }
            return p_ll.AddAfter(p_ll.Last, p_value);
        }
    }
}
