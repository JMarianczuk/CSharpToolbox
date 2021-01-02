using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSharpToolbox.Extensions
{
    public static class IEnumeratorExtensions
    {
        public static IEnumerator<TElement> Concat<TElement>(this IEnumerator<TElement> enumerator, IEnumerator<TElement> other)
        {
            return new ConcatenationEnumerator<TElement>(enumerator, other);
        }

        private class ConcatenationEnumerator<TElement> : IEnumerator<TElement>
        {
            private readonly IEnumerator<TElement> _first;
            private readonly IEnumerator<TElement> _second;

            private bool _firstEnumeratorActive = true;

            public ConcatenationEnumerator(IEnumerator<TElement> first, IEnumerator<TElement> second)
            {
                _first = first;
                _second = second;
            }

            public bool MoveNext()
            {
                if (_firstEnumeratorActive)
                {
                    if (_first.MoveNext())
                    {
                        return true;
                    }
                    _firstEnumeratorActive = false;
                }

                return _second.MoveNext();
            }

            public void Reset()
            {
                throw new System.NotImplementedException();
            }

            public TElement Current => _firstEnumeratorActive ? _first.Current : _second.Current;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                _first.Dispose();
                _second.Dispose();
            }
        }
    }
}