using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab4
{
    class Program
    {
        private const int _firstIndexToRemove = 5000;
        private const int _lastIndexToRemove = 7000;
        private static int[] _array;

        static void Main(string[] args)
        {
            GenerateArray(10000);

            var skipListTime = UseSkipList();
            var sortedListTime = UseSortedList();
            var difference = sortedListTime / skipListTime;

            Console.WriteLine($"\nSkipList работает быстрее SortedList'a в {string.Format("{0:0.00}", difference)} раз\n");
        }

        private static double UseSkipList()
        {
            var timer = new Stopwatch();
            var skipList = new SkipList<int, int>();

            timer.Start();

            for (int i = 0; i < _array.Length; i++)
                skipList.Add(_array[i],i);

            for (int i = _firstIndexToRemove; i < _lastIndexToRemove; i++)
                skipList.Remove(_array[i]);

            for (int i = 0; i < _array.Length; i++)
                skipList.Contains(_array[i]);

            timer.Stop();
            var result = timer.ElapsedMilliseconds;

            Console.WriteLine($"SkipList: {result} ms");

            return result;
        }

        private static double UseSortedList()
        {
            var timer = new Stopwatch();
            var sortedList = new SortedList<int, int>();

            timer.Start();

            for (int i = 0; i < _array.Length; i++)
                sortedList.Add(_array[i], i);

            for (int i = _firstIndexToRemove; i < _lastIndexToRemove; i++)
                sortedList.Remove(_array[i]);

            for (int i = 0; i < _array.Length; i++)
                sortedList.ContainsKey(_array[i]);

            timer.Stop();
            var result = timer.ElapsedMilliseconds;

            Console.WriteLine($"SortedList: {result} ms");

            return result;
        }

        private static void GenerateArray(int n)
        {
            _array = new int[n];
            var range = 100000;
            var unusedNumbers = Enumerable.Range(0, range).ToList();
            var rand = new Random();

            for (int i = 0; i < n; i++)
            {
                //var pos = rand.Next(0, unusedNumbers.Count);
                //_array[i] = unusedNumbers[pos];
                //unusedNumbers.RemoveAt(pos);
                _array[i] = i;
            }

            Console.WriteLine($"Сгенерирован массив из {n} случайных чисел\n\n");
        }
    }
}
