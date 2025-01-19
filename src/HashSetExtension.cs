using System.Collections.Generic;

namespace Soenneker.Extensions.HashSet;

/// <summary>
/// A collection of useful HashSet extension methods
/// </summary>
public static class HashSetExtension
{
    /// <summary>
    /// Iterates the <see cref="IEnumerable{T}"/> adds the items one by one to the hashset
    /// </summary>
    public static void AddRange<T>(this HashSet<T> set, IEnumerable<T> items)
    {
        // If items is a known-count collection, pre-grow the HashSet to minimize resizing.
        if (items is ICollection<T> collection)
        {
            int neededCapacity = set.Count + collection.Count;
            set.EnsureCapacity(neededCapacity);

            // Specialized path for T[] to avoid enumerator overhead.
            if (items is T[] array)
            {
                for (var i = 0; i < array.Length; i++)
                {
                    set.Add(array[i]);
                }
                return;
            }

            // Specialized path for List<T>.
            if (items is List<T> list)
            {
                int count = list.Count;
                for (var i = 0; i < count; i++)
                {
                    set.Add(list[i]);
                }
                return;
            }

            // Fallback for other ICollection<T> types.
            foreach (T item in collection)
            {
                set.Add(item);
            }
        }
        else
        {
            // Fallback if items is an enumerable without a known count.
            foreach (T item in items)
            {
                set.Add(item);
            }
        }
    }
}