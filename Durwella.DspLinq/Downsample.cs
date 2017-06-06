using System;
using System.Collections.Generic;

namespace Durwella.DspLinq
{
    public static partial class DspEnumerable
    {
        /// <summary>
        /// Keeps every Nth element.
        /// </summary>
        /// <param name="source">Source sequence.</param>
        /// <returns>A sequence with only the 1st element and every nth element thereafter.</returns>
        public static IEnumerable<T> Downsample<T>(this IEnumerable<T> source, int n)
        {
            if (source == null) 
                throw new ArgumentNullException(nameof(source));
            if (n <= 0)
                throw new ArgumentException("N must be a positive integer for downsampling.", nameof(n));
            // Ensure arg exceptions are thrown by nesting coroutine                
            return _(); IEnumerable<T> _()
            {
                using (var enumerator = source.GetEnumerator())
                {
                    int i = n;
                    while (enumerator.MoveNext())
                    {
                        if (i == n)
                        {
                            i = 0;
                            yield return enumerator.Current;
                        }
                        ++i;
                    }
                }
            }
        }
    }
}