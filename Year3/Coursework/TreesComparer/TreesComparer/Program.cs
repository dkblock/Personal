using System;
using System.Diagnostics;
using System.Linq;
using Trees;

namespace TreesComparer
{
    class Program
    {
        static Stopwatch _timer;
        static int[] _array;
        static int _arrayLength = 10000;
        static int _deleteFrom = 2500;
        static int _deleteTo = 7500;

        static void Main(string[] args)
        {
            var binaryTree = new BinaryTree<int, int>();
            var avlTree = new AVLTree<int, int>();
            var redBlackTree = new RedBlackTree<int, int>();
            var bTree = new BTree<int, int>(2000);
            _timer = new Stopwatch();

            GenerateArray(_arrayLength);

            Console.WriteLine("Добавление:\n");

            var binaryTime = GetAdditionTimeResult(binaryTree);
            var avlTime = GetAdditionTimeResult(avlTree);
            var redBlackTime = GetAdditionTimeResult(redBlackTree);
            //var bTime = GetAdditionTimeResult(bTree);

            Console.WriteLine("\nПоиск:\n");

            binaryTime += GetSearchingTimeResult(binaryTree);
            avlTime += GetSearchingTimeResult(avlTree);
            redBlackTime += GetSearchingTimeResult(redBlackTree);
            //bTime += GetSearchingTimeResult(bTree);

            Console.WriteLine("\nУдаление:\n");

            binaryTime += GetRemovingTimeResult(binaryTree);
            avlTime += GetRemovingTimeResult(avlTree);
            redBlackTime += GetRemovingTimeResult(redBlackTree);
            //bTime += GetRemovingTimeResult(bTree);

            Console.WriteLine("\nОбщее время:\n");

            GetTotalTime(binaryTree, binaryTime);
            GetTotalTime(avlTree, avlTime);
            GetTotalTime(redBlackTree, redBlackTime);
            //GetTotalTime(bTree, bTime);
        }

        static long GetAdditionTimeResult(ITree<int, int> tree)
        {
            _timer.Start();

            for (int i = 0; i < _array.Length; i++)
                tree.Add(_array[i], i);

            _timer.Stop();
            var time = _timer.ElapsedMilliseconds;
            _timer.Reset();

            Console.WriteLine($"Добавлено {_array.Length} элементов в {GetTreeType(tree)}");
            Console.WriteLine($"Время выполнения: {time} мс\n");

            return time;
        }

        static long GetRemovingTimeResult(ITree<int, int> tree)
        {
            _timer.Start();

            for (int i = _deleteFrom; i <= _deleteTo; i++)
                tree.Remove(_array[i]);

            _timer.Stop();
            var time = _timer.ElapsedMilliseconds;
            _timer.Reset();

            Console.WriteLine($"Удалены элементы с {_deleteFrom}-го по {_deleteTo}-ый из {GetTreeType(tree)}");
            Console.WriteLine($"Время выполнения: {time} мс\n");

            return time;
        }

        static long GetSearchingTimeResult(ITree<int, int> tree)
        {
            _timer.Start();

            for (int i = 0; i < _array.Length; i++)
                tree.Contains(_array[i]);

            _timer.Stop();
            var time = _timer.ElapsedMilliseconds;
            _timer.Reset();

            Console.WriteLine($"Поиск элементов в {GetTreeType(tree)}");
            Console.WriteLine($"Время выполнения: {time} мс\n");

            return time;
        }

        static void GetTotalTime(ITree<int, int> tree, long time)
        {
            Console.WriteLine($"{GetTreeType(tree)} : {time} мс");
        }

        static string GetTreeType(ITree<int, int> tree)
        {
            if (tree is BinaryTree<int, int>)
                return "Binary Tree";

            if (tree is AVLTree<int, int>)
                return "AVL-Tree";

            if (tree is RedBlackTree<int, int>)
                return "Red-Black Tree";

            if (tree is BTree<int, int>)
                return "B-Tree";

            return "";
        }

        static void GenerateArray(int length)
        {
            _array = new int[length];

            var unusedNumbers = Enumerable.Range(1, length).ToList();
            var rand = new Random();

            for (int i = 0; i < length; i++)
            {
                var pos = rand.Next(0, unusedNumbers.Count);
                _array[i] = unusedNumbers[pos];
                unusedNumbers.RemoveAt(pos);
                _array[i] = i;
            }

            Console.WriteLine($"Сгенерирован массив из {length} случайных чисел\n\n");
        }
    }
}
