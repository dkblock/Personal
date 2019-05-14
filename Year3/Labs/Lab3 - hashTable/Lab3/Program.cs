using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = ReadText();

            var dict = (double)UseDictionary(words);
            var hashTable = (double)UseHashTable(words);
            var difference = hashTable / dict;

            Console.WriteLine($"Хеш-таблица работает медленнее словаря в {string.Format("{0:0.00}", difference)} раз");
            Console.ReadLine();
        }

        private static long UseDictionary(string[] words)
        {
            Console.WriteLine(" Dictionary:\n");

            var dict = new Dictionary<string, int>();
            var t = new Stopwatch();
            t.Start();

            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                    dict[word]++;
                else
                    dict.Add(word, word.Length);
            }

            Console.WriteLine($"Добавлено {dict.Count} слов");

            var length = 7;
            var wordsToDelete = (from word in dict where word.Key.Length == length select word.Key).ToList();

            foreach (var word in wordsToDelete)
                dict.Remove(word);

            t.Stop();
            Console.WriteLine($"Удалено {wordsToDelete.Count} слов длины {length}. В словаре {dict.Count} слов");
            Console.WriteLine($"Время выполнения: {t.ElapsedMilliseconds} мс\n\n");

            return t.ElapsedMilliseconds;
        }

        private static long UseHashTable(string[] words)
        {
            Console.WriteLine(" HashTable:\n");

            var hashTable = new HashTable<string, int>();
            var t = new Stopwatch();
            t.Start();

            foreach (var word in words)
            {
                if (hashTable.Contains(word))
                    hashTable[word]++;
                else
                    hashTable.Add(word, 1);
            }

            Console.WriteLine($"Добавлено {hashTable.Count} слов");

            var length = 7;
            var wordsToDelete = (from word in hashTable where word.Key.Length == length select word.Key).ToList();

            foreach (var word in wordsToDelete)
                hashTable.Remove(word);

            t.Stop();
            Console.WriteLine($"Удалено {wordsToDelete.Count} слов длины {length}. В хеш-таблице {hashTable.Count} слов");
            Console.WriteLine($"Время выполнения: {t.ElapsedMilliseconds} мс\n\n");

            return t.ElapsedMilliseconds;
        }

        private static string[] ReadText()
        {
            using (var f = new StreamReader("WarAndWorld.txt", Encoding.Default))
            {
                var text = f.ReadToEnd().ToLower();
                var regex = new Regex(@"[a-zA-Zа-яА-Я]+");
                var matches = regex.Matches(text);
                var words = new string[matches.Count];

                for (int i = 0; i < words.Length; i++)
                    words[i] = matches[i].ToString();

                return words;
            }
        }
    }
}
