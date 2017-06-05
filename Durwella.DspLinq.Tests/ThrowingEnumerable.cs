using System;
using System.Collections;
using System.Collections.Generic;

namespace Durwella.DspLinq.Tests
{
    class ThrowingEnumerator : IEnumerator<int>
    {
        public int Current => throw new Exception("Should not access item in sequence.");
        object IEnumerator.Current => throw new Exception("Should not access item in sequence.");
        public void Dispose() => throw new Exception("Should not dispose enumerator.");
        public bool MoveNext() => throw new Exception("Should not enumerate sequence.");
        public void Reset() => throw new Exception("Should not reset enumerator.");
    }

    class ThrowingEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator() => new ThrowingEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => new ThrowingEnumerator();
    }
}
