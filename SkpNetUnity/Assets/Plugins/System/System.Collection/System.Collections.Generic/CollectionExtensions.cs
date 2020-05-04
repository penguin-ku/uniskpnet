namespace System.Collections.Generic
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T1>(ICollection<T1> p_collection)
        {
            return p_collection == null || p_collection.Count == 0;
        }
    }
}
