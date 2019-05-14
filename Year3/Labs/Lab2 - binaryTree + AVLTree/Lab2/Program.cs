using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = GenerateArray(10000);
            var firstIndexToRemove = 1500;
            var lastIndexToRemove = 9700;
            var t = new Stopwatch();

            SortedDictionaryExample(array, firstIndexToRemove, lastIndexToRemove, t);
            BinaryTreeExample(array, firstIndexToRemove, lastIndexToRemove, t);
            AVLTreeExample(array, firstIndexToRemove, lastIndexToRemove, t);

            Console.ReadLine();
        }

        private static void SortedDictionaryExample(int[] array, int firstIndexToRemove, int lastIndexToRemove, Stopwatch t)
        {
            Console.WriteLine("Sorted Dictionary:\n");
            var dictionary = new SortedDictionary<int, int>();
            t.Start();

            for (int i = 0; i < array.Length; i++)
            {
                dictionary.Add(array[i], i);
            }

            Console.WriteLine($"Добавлено {array.Length} элементов");

            for (int i = firstIndexToRemove; i <= lastIndexToRemove; i++)
            {
                dictionary.Remove(array[i]);
            }

            Console.WriteLine($"Удалено {lastIndexToRemove - firstIndexToRemove + 1} элементов");
            Console.WriteLine($"Поиск всех элементов массива...");

            for (int i = 0; i < array.Length; i++)
            {
                var x = dictionary.ContainsKey(array[i]);
            }

            t.Stop();
            Console.WriteLine($"Время выполнения: {t.ElapsedMilliseconds} мс\n\n");
            t.Reset();
        }

        private static void BinaryTreeExample(int[] array, int firstIndexToRemove, int lastIndexToRemove, Stopwatch t)
        {
            Console.WriteLine("Binary Tree:\n");
            var tree = new BinaryTree<int, int>();
            t.Start();

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i], i);
            }

            Console.WriteLine($"Добавлено {array.Length} элементов");

            for (int i = firstIndexToRemove; i <= lastIndexToRemove; i++)
            {
                tree.Remove(array[i]);
            }

            Console.WriteLine($"Удалено {lastIndexToRemove - firstIndexToRemove + 1} элементов");
            Console.WriteLine($"Поиск всех элементов массива...");

            for (int i = 0; i < array.Length; i++)
            {
                var x = tree.Contains(array[i]);
            }

            t.Stop();
            Console.WriteLine($"Время выполнения: {t.ElapsedMilliseconds} мс\n\n");
            t.Reset();
        }

        private static void AVLTreeExample(int[] array, int firstIndexToRemove, int lastIndexToRemove, Stopwatch t)
        {
            Console.WriteLine("AVL Tree:\n");
            var tree = new AVLTree<int, int>();
            t.Start();

            for (int i = 0; i < array.Length; i++)
            {
                tree.Add(array[i], i);
            }

            Console.WriteLine($"Добавлено {array.Length} элементов");

            for (int i = firstIndexToRemove; i <= lastIndexToRemove; i++)
            {
                tree.Remove(array[i]);
            }

            Console.WriteLine($"Удалено {lastIndexToRemove - firstIndexToRemove + 1} элементов");
            Console.WriteLine($"Поиск всех элементов массива...");

            for (int i = 0; i < array.Length; i++)
            {
                var x = tree.Contains(array[i]);
            }

            t.Stop();
            Console.WriteLine($"Время выполнения: {t.ElapsedMilliseconds} мс\n\n");
            t.Reset();
        }

        private static int[] GenerateArray(int n)
        {
            var array = new int[n];
            var range = 100000;
            var unusedNumbers = Enumerable.Range(1, range).ToList();
            var rand = new Random();

            for (int i = 0; i < n; i++)
            {
                var pos = rand.Next(0, unusedNumbers.Count);
                array[i] = unusedNumbers[pos];
                unusedNumbers.RemoveAt(pos);
                array[i] = i;
            }

            Console.WriteLine($"Сгенерирован массив из {n} случайных чисел\n\n");

            //array = new int[] { 7, 15, 3, 371, 0, 228, 111, 100, 18, 27, 388, 1400, 1, 8, 36, 25, 5, 69, 158 };
            return array;
        }
    }
}
