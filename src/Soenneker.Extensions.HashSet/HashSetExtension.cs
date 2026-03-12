using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Soenneker.Extensions.HashSet;

/// <summary>
/// A collection of useful HashSet extension methods
/// </summary>
public static class HashSetExtension
{
    /// <summary>
    /// Adds all items from <paramref name="items"/> into <paramref name="set"/>.
    /// Uses fast paths for common collection types and pre-grows capacity when the item count is known.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddRange<T>(this HashSet<T> set, IEnumerable<T> items)
    {
        ArgumentNullException.ThrowIfNull(set);
        ArgumentNullException.ThrowIfNull(items);

        // Avoid "Collection was modified" if someone passes the same set instance.
        if (ReferenceEquals(set, items))
            return;

        // Fast paths first (also lets us avoid enumerator allocations on older runtimes)
        if (items is T[] array)
        {
            if (array.Length == 0)
                return;

            set.EnsureCapacity(set.Count + array.Length);

            for (int i = 0; i < array.Length; i++)
                set.Add(array[i]);

            return;
        }

        if (items is List<T> list)
        {
            int count = list.Count;
            if (count == 0)
                return;

            set.EnsureCapacity(set.Count + count);

            for (int i = 0; i < count; i++)
                set.Add(list[i]);

            return;
        }

        // Pre-grow if we can get a count without enumerating
        if (items.TryGetNonEnumeratedCount(out int addCount) && addCount > 0)
            set.EnsureCapacity(set.Count + addCount);

        foreach (T item in items)
            set.Add(item);
    }
}