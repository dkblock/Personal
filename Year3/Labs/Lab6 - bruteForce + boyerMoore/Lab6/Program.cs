using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            var bruteForce = new BruteForce();
            var boyerMoore = new BoyerMoore();
            var text = ReadText("WarAndWorld.txt");

            Console.Write("Enter substring for search: ");
            var substring = Console.ReadLine();

            GetResult(bruteForce, substring, text);
            GetResult(boyerMoore, substring, text);
        }

        static void GetResult(ISearcher searcher, string substring, string text)
        {
            var t = new Stopwatch();
            t.Start();

            var entries = searcher.GetAllEntries(substring, text);
            t.Stop();

            Console.WriteLine($"\nAlgorithm: {searcher.GetType().Name}\nEntries: {entries.Count()}\nTime: {t.ElapsedMilliseconds} ms\n");
            t.Reset();
        }

        static string ReadText(string source)
        {
            using (var f = new StreamReader(source))
            {
                return f.ReadToEnd();
            }
        }
    }
}
