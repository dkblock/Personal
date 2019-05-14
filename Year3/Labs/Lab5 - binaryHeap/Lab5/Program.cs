using System;
using System.Collections.Generic;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var heap = new BinaryHeap<double>();
            var items = new double[] { 0.5, 0.8, 0.1, 0.4, 0.9, 0.3, 0.1, 0.28, 0.41, 0.56, 0.98, 0.12, 0.3, 0.03, 0.03 };//{ 0.2, 0.2, 0.2, 0.2, 0.2, 0.2 };//;

            FillHeap(heap, items);
            GetResult(heap, items);
        }

        private static void FillHeap(BinaryHeap<double> heap, double[] items)
        {
            foreach (var item in items)
            {
                var extracted = new List<double>();
                var needToAddNew = true;

                while (heap.Count > 0)
                {
                    var max = heap.ExtractMax();

                    if (max + item > 1)
                        extracted.Add(max);
                    else
                    {
                        extracted.Add(max + item);
                        needToAddNew = false;
                        break;
                    }
                }

                foreach (var e in extracted)
                    heap.Add(e);

                if (needToAddNew)
                    heap.Add(item);
            }
        }

        private static void GetResult(BinaryHeap<double> heap, double[] items)
        {
            Console.Write("In: ");

            foreach (var item in items)
                Console.Write($"{item} | ");

            Console.Write("\nOut: ");

            foreach (var item in heap.GetAllItems())
                Console.Write($"{item} | ");

            Console.WriteLine($"\nUsed {heap.Count} containers");
        }
    }
}
