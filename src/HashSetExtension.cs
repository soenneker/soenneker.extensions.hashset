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
    public static void AddRange<T>(this HashSet<T> value, IEnumerable<T> enumerable)
    {
        foreach (T item in enumerable)
        {
            value.Add(item);
        }
    }
}