using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Lab1
{
    public class Worker
    {
        private string[] _words;

        public Worker() { }

        public void Read()
        {
            using (StreamReader f = new StreamReader("WarAndWorld.txt"))
            {
                var text = f.ReadToEnd().ToLower();
                var regex = new Regex(@"[a-zA-Zа-яА-Я]+");
                var matches = regex.Matches(text);

                _words = new string[matches.Count];

                for (int i = 0; i < _words.Length; i++)
                    _words[i] = matches[i].ToString();
            }
        }

        public void RunSortedListExample()
        {
            var dictionary = new SortedList<string, int>();

            foreach (var word in _words)
            {
                if (dictionary.ContainsKey(word))
                    dictionary[word]++;
                else
                    dictionary.Add(word, 1);
            }

            var uniqueWords = dictionary.OrderByDescending(x => x.Value).ToList();
            CountUniqueWords(uniqueWords);
        }

        public void RunSortedDictionaryExample()
        {
            var dictionary = new SortedDictionary<string, int>();

            foreach (var word in _words)
            {
                if (dictionary.ContainsKey(word))
                    dictionary[word]++;
                else
                    dictionary.Add(word, 1);
            }

            var uniqueWords = dictionary.OrderByDescending(x => x.Value).ToList();
            CountUniqueWords(uniqueWords);
        }

        public void RunDictionaryExample()
        {
            var dictionary = new Dictionary<string, int>();

            foreach (var word in _words)
            {
                if (dictionary.ContainsKey(word))
                    dictionary[word]++;
                else
                    dictionary.Add(word, 1);
            }

            var uniqueWords = dictionary.OrderByDescending(x => x.Value).ToList();
            CountUniqueWords(uniqueWords);
        }

        public void RunListExample()
        {
            var dictionary = new List<string>();

            foreach (var word in _words)
                dictionary.Add(word);

            var uniqueWords = dictionary.GroupBy(x => x).Select(x => new KeyValuePair<string, int>(x.ElementAt(0), x.Count()))
                .OrderByDescending(x => x.Value).ToList();
            CountUniqueWords(uniqueWords);
        }

        private void CountUniqueWords(List<KeyValuePair<string, int>> uniqueWords)
        {
            Console.WriteLine($"Текст содержит {uniqueWords.Count} уникальных слов:");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i + 1}. {uniqueWords.ElementAt(i).Key} - {uniqueWords.ElementAt(i).Value} раз");
            }
        }
    }
}
