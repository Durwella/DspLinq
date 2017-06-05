using System;
using System.Collections.Generic;

namespace Durwella.DspLinq
{
    public static partial class DspEnumerable
    {
        /// <summary>
        /// Skips every 10th element.
        /// </summary>
        /// <param name="source">Source sequence.</param>
        /// <returns>A sequence with every 10th element of the input sequence skipped.</returns>
        public static IEnumerable<T> Decimate<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            using (var enumerator = source.GetEnumerator())
            {
                int i = 0;
                while (enumerator.MoveNext())
                {
                    ++i;
                    if (i == 10)
                    {
                        i = 0;
                        continue;
                    }
                    yield return enumerator.Current;
                }
            }
        }
    }
}