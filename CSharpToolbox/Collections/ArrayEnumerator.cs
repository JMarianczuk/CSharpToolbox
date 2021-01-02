using System.Collections;
using System.Collections.Generic;

namespace CSharpToolbox.Collections
{
    public class ArrayEnumerator<TElement> : IEnumerator<TElement>
    {
        private TElement[] _array;
        private readonly int _endIndex;
        private int _currentIndex;
        public ArrayEnumerator(TElement[] array, int startIndex, int endIndex)
        {
            _array = array;
            _endIndex = endIndex;
            _currentIndex = startIndex - 1;
        }
        public bool MoveNext()
        {
            _currentIndex += 1;
            return _currentIndex <= _endIndex;
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public TElement Current => _array[_currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _array = null;
        }
    }
}