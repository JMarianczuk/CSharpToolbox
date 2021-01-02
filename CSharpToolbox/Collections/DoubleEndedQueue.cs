using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CSharpToolbox.Extensions;

namespace CSharpToolbox.Collections
{
    public class DoubleEndedQueue<TElement> : IEnumerable<TElement>, ICollection
    {
        public const int DefaultInitialCapacity = 0;
        public const int DefaultInitialNonZeroCapacity = 4;
        public const double TrimExcessPercentage = 0.9;
        public const double AutoShrinkPercentage = 0.25;
        public const int SizeChangeFactor = 2;

        private TElement[] _array;
        private int _head = 0;
        private int _tail = 0;
        private readonly bool _autoShrink;

        public DoubleEndedQueue(bool autoShrink = false) : this(DefaultInitialCapacity, autoShrink)
        {

        }

        public DoubleEndedQueue(IEnumerable<TElement> elements, bool autoShrink = false)
        {
            _array = elements.ToArray();
            Count = _array.Length;
            _autoShrink = autoShrink;
        }

        public DoubleEndedQueue(int initialCapacity, bool autoShrink = false)
        {
            _array = new TElement[initialCapacity];
            Count = 0;
            _autoShrink = autoShrink;
        }

        public void PushFront(TElement element)
        {
            if (Count == _array.Length)
            {
                DuplicateArray();
            }
            _head -= 1;
            if (_head < 0)
            {
                _head = _array.Length - 1;
            }
            _array[_head] = element;
            Count += 1;
        }
        public void PushBack(TElement element)
        {
            if (Count == _array.Length)
            {
                DuplicateArray();
            }
            _array[_tail] = element;
            _tail += 1;
            if (_tail == _array.Length)
            {
                _tail = 0;
            }
            Count += 1;
        }

        private void DuplicateArray()
        {
            int newSize = _array.Length * SizeChangeFactor;
            if (newSize == 0)
            {
                newSize = DefaultInitialNonZeroCapacity;
            }
            var newArray = new TElement[newSize];
            CopyTo(newArray, 0);
            _head = 0;
            _tail = Count;
            _array = newArray;
        }

        private void ShrinkArrayTo(int size)
        {
            if (size < Count)
            {
                throw new Exception("Invalid state. Tried Shrinking to smaller than Count");
            }
            if (size < DefaultInitialNonZeroCapacity)
            {
                size = DefaultInitialNonZeroCapacity;
            }
            var newArray = new TElement[size];
            CopyTo(newArray, 0);
            _head = 0;
            _tail = Count < size ? Count : 0;
            _array = newArray;
        }

        public TElement PopFront()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The DoubleEndedQueue<> is empty");
            }
            var first = _array[_head];
            _array[_head] = default;
            _head += 1;
            if (_head == _array.Length)
            {
                _head = 0;
            }
            Count -= 1;
            if (_autoShrink && Count < _array.Length * AutoShrinkPercentage)
            {
                ShrinkArrayTo(Count * SizeChangeFactor);
            }
            return first;
        }

        public TElement PopBack()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The DoubleEndedQueue<> is empty");
            }
            _tail -= 1;
            if (_tail < 0)
            {
                _tail = _array.Length - 1;
            }
            var last = _array[_tail];
            _array[_tail] = default;
            Count -= 1;
            if (_autoShrink && Count < _array.Length * AutoShrinkPercentage)
            {
                ShrinkArrayTo(Count * SizeChangeFactor);
            }
            return last;
        }

        public TElement PeekFront()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The DoubleEndedQueue<> is empty");
            }
            return _array[_head];
        }

        public TElement PeekBack()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The DoubleEndedQueue<> is empty");
            }
            var tailPeek = _tail - 1;
            if (tailPeek < 0)
            {
                tailPeek = _array.Length - 1;
            }
            return _array[tailPeek];
        }

        public bool TryPopFront(out TElement element)
        {
            if (Count == 0)
            {
                element = default;
                return false;
            }
            element = PopFront();
            return true;
        }

        public bool TryPopBack(out TElement element)
        {
            if (Count == 0)
            {
                element = default;
                return false;
            }
            element = PopBack();
            return true;
        }

        public bool TryPeekFront(out TElement element)
        {
            if (Count == 0)
            {
                element = default;
                return false;
            }
            element = PeekFront();
            return true;
        }

        public bool TryPeekBack(out TElement element)
        {
            if (Count == 0)
            {
                element = default;
                return false;
            }
            element = PeekBack();
            return true;
        }

        public void TrimExcess()
        {
            if (Count < _array.Length * 0.9)
            {
                ShrinkArrayTo(Count);
            }
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            if (Count == 0)
            {
                return Enumerable.Empty<TElement>().GetEnumerator();
            }
            if (_tail == 0)
            {
                return new ArrayEnumerator<TElement>(_array, _head, _array.Length - 1);
            }
            if (_head < _tail)
            {
                return new ArrayEnumerator<TElement>(_array, _head, _tail - 1);
            }
            else
            {
                return new ArrayEnumerator<TElement>(_array, _head, _array.Length - 1)
                    .Concat(new ArrayEnumerator<TElement>(_array, 0, _tail - 1));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            if (Count == 0)
            {
                return;
            }
            if (_head < _tail)
            {
                Array.Copy(_array, _head, array, index, _tail - _head);
            }
            else
            {
                var headToLooparound = _array.Length - _head;
                Array.Copy(_array, _head, array, index, headToLooparound);
                Array.Copy(_array, 0, array, index + headToLooparound, _tail);
            }
        }

        public int Count { get; private set; }
        public int Capacity => _array.Length;

        public bool IsSynchronized => false;
        public object SyncRoot { get; } = new object();
    }
}