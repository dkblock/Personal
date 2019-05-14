using System;
using System.Diagnostics;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            var worker = new Worker();
            worker.Read();

            Console.WriteLine("SortedList:\n");
            stopwatch.Start();
            worker.RunSortedListExample();
            GetTimerResults(stopwatch);

            Console.WriteLine("SortedDictionary:\n");
            stopwatch.Start();
            worker.RunSortedDictionaryExample();
            GetTimerResults(stopwatch);

            Console.WriteLine("Dictionary:\n");
            stopwatch.Start();
            worker.RunDictionaryExample();
            GetTimerResults(stopwatch);

            Console.WriteLine("List:\n");
            stopwatch.Start();
            worker.RunListExample();
            GetTimerResults(stopwatch);

            Console.ReadLine();
        }

        static void GetTimerResults(Stopwatch stopwatch)
        {
            stopwatch.Stop();
            Console.WriteLine($"\nTime: {stopwatch.ElapsedMilliseconds} ms\n\n");
            stopwatch.Reset();
        }
    }
}
