using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3
{
    internal class Item<TKey, TValue> where TKey : IComparable<TKey>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public Item(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

    public class HashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>> where TKey : IComparable<TKey>
    {
        private Item<TKey, TValue>[] _table;
        private bool[] _deleted;
        private int _size;
        private PrimeNumberSearcher _searcher;
        private const double _fillFactor = 0.85;

        public int Count { get; private set; }

        public HashTable()
        {
            _searcher = new PrimeNumberSearcher();
            _size = _searcher.GetNextPrime();
            _table = new Item<TKey, TValue>[_size];
            _deleted = new bool[_size];
            Count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            var firstHash = GetHash(key, _size);

            if (!IsAddingSuccessful(firstHash, key, value))
            {
                for (int i = 1; i < _size; i++)
                {
                    var secondHash = GetHash(key, _size - 1);
                    var index = GetHash(firstHash, secondHash, i);

                    if (IsAddingSuccessful(index, key, value))
                        break;
                }
            }

            if ((double)Count / _size >= _fillFactor)
                ResizeTable();
        }

        private bool IsAddingSuccessful(int index, TKey key, TValue value)
        {
            if (_table[index] == null || _deleted[index])
            {
                _table[index] = new Item<TKey, TValue>(key, value);
                Count++;
                return true;
            }

            if (_table[index].Key.Equals(key))
                throw new ArgumentException("Item with same key has already been added");

            return false;
        }

        private void ResizeTable()
        {
            var buffer = _table;

            _size = _searcher.GetNextPrime();
            _table = new Item<TKey, TValue>[_size];
            _deleted = new bool[_size];
            Count = 0;

            foreach (var item in buffer)
            {
                if (item != null)
                    Add(item.Key, item.Value);
            }
        }

        public bool Contains(TKey key)
        {
            var item = Find(key);

            if (item != null)
                return true;

            return false;
        }

        private Item<TKey, TValue> Find(TKey key)
        {
            var firstHash = GetHash(key, _size);

            if (_table[firstHash] == null)
                return null;

            if (!_deleted[firstHash] && _table[firstHash].Key.Equals(key))
                return _table[firstHash];

            for (int i = 1; i < _size; i++)
            {
                var secondHash = GetHash(key, _size - 1);
                var index = GetHash(firstHash, secondHash, i);

                if (_table[index] == null)
                    return null;

                if (!_deleted[index] && _table[index].Key.Equals(key))
                    return _table[index];
            }

            return null;
        }

        public bool Remove(TKey key)
        {
            var firstHash = GetHash(key, _size);

            if (_table[firstHash] != null && _table[firstHash].Key.Equals(key))
            {
                _deleted[firstHash] = true;
                Count--;
                return true;
            }

            for (int i = 1; i < _size; i++)
            {
                var secondHash = GetHash(key, _size - 1);
                var index = GetHash(firstHash, secondHash, i);

                if (_table[index] != null)
                {
                    if (_table[index].Key.Equals(key))
                    {
                        _deleted[index] = true;
                        Count--;
                        return true;
                    }
                }
                else
                    return false;
            }

            return false;
        }

        public TValue this[TKey key]
        {
            get
            {
                var item = Find(key);
                return item.Value;
            }
            set
            {
                var item = Find(key);
                item.Value = value;
            }
        }

        private int GetHash(TKey key, int divider)
        {
            return Math.Abs(key.GetHashCode()) % divider;
        }

        private int GetHash(int firstHash, int secondHash, int i)
        {
            return (firstHash + i * (1 + secondHash)) % _size;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var item in _table)
                if (item != null)
                    yield return new KeyValuePair<TKey, TValue>(item.Key, item.Value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class PrimeNumberSearcher
    {
        private int _currentNumber;
        private int _currentIndex;
        private readonly int[] _primes = { 11, 31, 61, 127, 263, 523, 1087, 2213, 4519, 9619, 19717, 40009, 80317, 151153 };

        public PrimeNumberSearcher()
        {
            _currentIndex = -1;
        }

        public int GetNextPrime()
        {
            if (_currentIndex < _primes.Length - 1)
            {
                _currentIndex++;
                _currentNumber = _primes[_currentIndex];
            }
            else
            {
                _currentNumber *= 2;

                while (!IsPrime(_currentNumber))
                    _currentNumber++;
            }

            return _currentNumber;
        }

        private bool IsPrime(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;

            return true;
        }
    }
}
