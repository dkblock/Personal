using System;
using System.Collections.Generic;

namespace Lab6
{
    public class BoyerMoore : ISearcher
    {
        public IEnumerable<int> GetAllEntries(string substring, string text)
        {
            var entries = new List<int>();
            var offsetTable = GetOffsetTable(substring);
            var suffixTable = GetSuffixTable(substring);
            var stop = text.Length - substring.Length + 1;
            var current = 0;

            while (current < stop)
            {
                var i = substring.Length - 1;

                while ((i > -1) && (substring[i] == text[current + i]))
                    i--;
                
                if (i == -1)
                {
                    entries.Add(current);
                    current += suffixTable[0];
                }
                else
                {
                    var position = offsetTable.ContainsKey(text[current + i]) ? offsetTable[text[current + i]] : -1;
                    current += Math.Max(suffixTable[i + 1], i - position);
                }
            }

            return entries;
        }

        private Dictionary<char, int> GetOffsetTable(string str)
        {
            var table = new Dictionary<char, int>();

            for (int i = 0; i < str.Length - 1; i++)
            {
                var symbol = str[i];

                if (table.ContainsKey(symbol))
                    table[symbol] = i;
                else
                    table.Add(symbol, i);
            }

            return table;
        }

        private int[] GetSuffixTable(string str)
        {
            var prefixFunc = GetPrefixFunction(str);
            var prefixFuncReversed = GetPrefixFunction(ReverseString(str));
            var table = new int[str.Length + 1];

            for (int i = 0; i < table.Length; i++)
                table[i] = str.Length - prefixFunc[str.Length - 1];

            for (int i = 1; i < table.Length; i++)
            {
                var j = str.Length - prefixFuncReversed[i - 1];

                if (table[j] > i - prefixFuncReversed[i - 1])
                    table[j] = i - prefixFuncReversed[i - 1];
            }

            return table;
        }

        private int[] GetPrefixFunction(string str)
        {
            var prefixFunc = new int[str.Length];
            var k = 0;
            prefixFunc[0] = 0;

            for (int i = 1; i < str.Length; i++)
            {
                while ((k > 0) && (str[k] != str[i]))
                    k = prefixFunc[k - 1];

                if (str[k] == str[i])
                    k++;

                prefixFunc[i] = k;
            }

            return prefixFunc;
        }

        private string ReverseString(string str)
        {
            var array = str.ToCharArray();
            Array.Reverse(array);

            return new string(array);
        }
    }
}
