namespace System.Collections.Generic
{
    public static partial class Extension
    {
        public static ICollection<T> Clear<T>(this ICollection<T> collection)
        {
            collection.Clear();
            return collection;
        }
        public static ICollection<T> OnlyOne<T>(this ICollection<T> collection, T item)
        {
            collection.Clear();
            collection.Add(item);
            return collection;
        }
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (TSource item in source)
            {
                action(item);
            }
        }
        public static IList<T> NullToEmpty<T>(this IList<T> list)
        {
            return list ?? new List<T>();
        }
        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count == 0;
        }
        public static bool IsNullOrEmpty<T1, T2>(this IDictionary<T1, T2> dictionary)
        {
            return dictionary == null || dictionary.Count == 0;
        }
    }
}
