using System;

namespace Lab4
{
    internal class Node<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public bool IsEmpty { get; set; }
        public Node<TKey, TValue> Next, Up, Down;

        public Node()
        {
            IsEmpty = true;
        }

        public Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            IsEmpty = false; 
            Next = null;
            Up = null;
            Down = null;
        }

        public override string ToString()
        {
            if (IsEmpty)
                return "null";

            return $"{Key} {Value}";
        }
    }

    public class SkipList<TKey, TValue> where TKey : IComparable<TKey>
    {
        private int _maxLevel;
        private int _currentLevel;
        private double _probability;
        private Random _rd;
        private Node<TKey, TValue>[] _head;
        private Node<TKey, TValue> _tail;

        public int Count { get; private set; }

        public SkipList(int maxLevel = 10, double probability = 0.5)
        {
            _maxLevel = maxLevel;
            _probability = probability;
            _currentLevel = 0;
            _rd = new Random();
            _head = new Node<TKey, TValue>[_maxLevel];
            _tail = new Node<TKey, TValue>();

            for (int i = 0; i < _maxLevel; i++)
            {
                _head[i] = new Node<TKey, TValue>();
                _head[i].Next = _tail;

                if (i == 0)
                    continue;

                _head[i].Down = _head[i - 1];
                _head[i - 1].Up = _head[i];
            }
        }

        public void Add(TKey key, TValue value)
        {
            var previousItems = new Node<TKey, TValue>[_maxLevel];
            var current = _head[_currentLevel];

            for (int i = _currentLevel; i >= 0; i--)
            {
                while (current.Next != _tail && current.Next.Key.CompareTo(key) < 0)
                    current = current.Next;

                if (current.Next.Key.CompareTo(key) == 0 && !current.Next.IsEmpty)
                    throw new ArgumentException("Item with same key has already been added");

                previousItems[i] = current;
                current = current.Down;
            }
            
            var height = 0;

            while (_rd.NextDouble() < _probability && height < _maxLevel - 1)
                height++;
                        
            if (height > _currentLevel)
            {
                for (int i = _currentLevel + 1; i <= height; i++)
                    previousItems[i] = _head[i];

                _currentLevel = height;
            }
            
            for (int i = 0; i <= height; i++)
            {
                var newItem = new Node<TKey, TValue>(key, value);
                newItem.Next = previousItems[i].Next;
                previousItems[i].Next = newItem;

                if (i == 0)
                    continue;

                newItem.Down = previousItems[i - 1].Next;
                previousItems[i - 1].Next.Up = newItem;
            }

            Count++;
        }

        public bool Contains(TKey key)
        {
            var node = Find(_head[_currentLevel], key);

            if (node.Key.CompareTo(key) == 0)
                return true;

            return false;
        }

        private Node<TKey, TValue> Find(Node<TKey, TValue> node, TKey key)
        {
            var current = node;

            while (current.Next != _tail && current.Next.Key.CompareTo(key) <= 0)
                current = current.Next;

            if (current.Down == null || (current.Key.CompareTo(key) == 0 && !current.IsEmpty))
                return current;

            return Find(current.Down, key);
        }

        public void Remove(TKey key)
        {
            Remove(_head[_currentLevel], key);

            Count--;
        }

        private void Remove(Node<TKey, TValue> node, TKey key)
        {
            var current = node;

            while (current.Next != _tail && current.Next.Key.CompareTo(key) < 0)
                current = current.Next;

            if (current.Down != null)
                Remove(current.Down, key);

            if (current.Next != _tail && current.Next.Key.CompareTo(key) == 0)
                current.Next = current.Next.Next;
        }

        public void Print()
        {
            for (int i = _currentLevel; i >= 0; i--)
            {
                var current = _head[i].Next;

                while (current != _tail)
                {
                    Console.Write($"{current.Key} ");
                    current = current.Next;
                }

                Console.WriteLine();
            }
        }
    }
}