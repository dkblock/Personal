using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arithmetic
{
    public class Segment
    {
        private Dictionary<char, KeyValuePair<double, double>> _dictionary;
        private double _countLetters;

        public double Start, Finish, Code;
        public StringBuilder Answer = new StringBuilder("");
        public StringBuilder Text = new StringBuilder("");
        public StringBuilder CodeSB = new StringBuilder("");

        public Segment(IOrderedEnumerable<KeyValuePair<char, double>> dictionary, double count)
        {
            _dictionary = new Dictionary<char, KeyValuePair<double, double>>();
            Answer = new StringBuilder("");
            _countLetters = count;
            Start = 0;
            Finish = 1;            

            var line = new List<double>();
            var i = 0;

            line.Add(0);

            foreach (var letters in dictionary)
            {
                line.Add(line[i] + letters.Value);
                i++;
                _dictionary.Add(letters.Key, new KeyValuePair<double, double>(line[i - 1], line[i]));
            }
        }

        public void GenerateNewLine(char letter)
        {
            CorrectingBorder();

            double HighRange = _dictionary[letter].Value,
                   LowRange = _dictionary[letter].Key,
                   OldLow = Start,
                   OldHigh = Finish;

            Start = OldLow + (OldHigh - OldLow) * LowRange;
            Finish = OldLow + (OldHigh - OldLow) * HighRange;
        }

        public void GenerateNewLine(IOrderedEnumerable<KeyValuePair<char, double>> dictionary)
        {
            var i = 0;
            Code = Convert.ToDouble(CodeSB.ToString());

            while (i < _countLetters)
            {
                double length = Finish - Start;
                double low = Start, high;

                foreach (var letter in dictionary)
                {
                    high = low + letter.Value * length;
                    
                    if (Code >= low && Code <= high)
                    {
                        GenerateNewLine(letter.Key);
                        Text.Append(letter.Key);
                        break;
                    }

                    low = high;
                }

                i++;
            }
        }

        private void CorrectingBorder()
        {
            double newStart = Start, newFinish = Finish;

            while (true)
            {
                double a = Math.Truncate(newStart * 10);
                double b = Math.Truncate(newFinish * 10);

                if (a == b)
                {
                    Answer.Append(a);

                    if (CodeSB.Length > 2)
                    {
                        CodeSB.Remove(2, 1);
                        Code = Convert.ToDouble(CodeSB.ToString());
                    }

                    newStart = newStart * 10 - a;
                    newFinish = newFinish * 10 - b;
                }
                else
                    break;
            }

            Start = newStart;
            Finish = newFinish;
        }

        public string GetAnswer()
        {
            double mid = Math.Round(Start + (Finish - Start) / 2, 2);
            var m = Convert.ToString(mid).Remove(0, 2);

            return Answer + m;
        }
    }

    public class Arithmetic
    {
        private Segment _segment;
        private double _count;
        private IOrderedEnumerable<KeyValuePair<char, double>> _frequencyDictionary;

        public string Encode(string text)
        {
            var dictionary = new Dictionary<char, double>();
            _count = text.Length;

            foreach (var letter in text)
                if (dictionary.ContainsKey(letter))
                    dictionary[letter] += (double)1 / _count;
                else
                    dictionary.Add(letter, (double)1 / _count);

            _frequencyDictionary = dictionary.OrderByDescending(s => s.Value);
            _segment = new Segment(_frequencyDictionary, _count);

            for (int i = 0; i < _count; i++)
                _segment.GenerateNewLine(text[i]);

            return GetAnswer();
        }

        public string Decode(string number)
        {
            _segment = new Segment(_frequencyDictionary, _count);
            _segment.CodeSB = new StringBuilder("0," + number);
            _segment.GenerateNewLine(_frequencyDictionary);

            return _segment.Text.ToString();
        }

        public string GetAnswer()
        {
            return _segment.GetAnswer();
        }
    }
}
