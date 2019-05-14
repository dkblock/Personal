using System;
using System.Collections.Generic;

namespace Lab5
{
    public class BinaryHeap<T> where T: IComparable<T>
    {
        private List<T> _data;

        public int Count
        {
            get { return _data.Count; }
        }

        public BinaryHeap()
        {
            _data = new List<T>();
        }

        public void Add(T item)
        {
            _data.Add(item);

            var i = Count - 1;
            var parent = Parent(i);

            while (i > 0 && _data[parent].CompareTo(_data[i]) < 0)
            {
                var temp = _data[i];
                _data[i] = _data[parent];
                _data[parent] = temp;

                i = parent;
                parent = Parent(i);
            }
        }

        public T ExtractMax()
        {
            var max = _data[0];
            _data[0] = _data[Count - 1];
            _data.RemoveAt(Count - 1);
            Heapify(0);

            return max;
        }

        public T Max()
        {
            return _data[0];
        }

        public List<T> GetAllItems()
        {
            return _data;
        }

        private void Heapify(int i)
        {
            var left = Left(i);
            var right = Right(i);
            var largest = i;

            if (left <= Count - 1 && _data[left].CompareTo(_data[i]) > 0)
                largest = left;

            if (right <= Count - 1 && _data[right].CompareTo(_data[largest]) > 0)
                largest = right;

            if (largest != i)
            {
                var temp = _data[i];
                _data[i] = _data[largest];
                _data[largest] = temp;

                Heapify(largest);
            }
        }

        private int Left(int i)
        {
            return 2 * i + 1;
        }

        private int Right(int i)
        {
            return 2 * i + 2;
        }

        private int Parent(int i)
        {
            return (i - 1) / 2;
        }
    }
}
