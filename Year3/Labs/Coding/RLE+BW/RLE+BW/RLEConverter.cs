using System.Collections.Generic;
using System.Text;

namespace RLE_BW
{
    public class RLEConverter
    {
        public string Encode(string text)
        {
            var code = new List<KeyValuePair<char, int>>();
            var i = 0;
            var current = text[i];
            var count = 0;

            while (i < text.Length)
            {
                if (text[i] == current)
                    count++;
                else
                {
                    code.Add(new KeyValuePair<char, int>(current, count));
                    current = text[i];
                    count = 1;
                }

                i++;
            }

            code.Add(new KeyValuePair<char, int>(current, count));

            var answer = new StringBuilder();

            foreach (var item in code)
                answer.Append($"{item.Key}{item.Value}");

            return answer.ToString();
        }

        public string Decode(string text)
        {
            var dict = GetSymbolsPeriod(text);
            var answer = new StringBuilder();

            foreach (var item in dict)
                for (int i = 0; i < item.Value; i++)
                    answer.Append(item.Key);

            return answer.ToString();
        }

        public List<KeyValuePair<char, int>> GetSymbolsPeriod(string text)
        {
            var dict = new List<KeyValuePair<char, int>>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsDigit(text[i]))
                {
                    var j = i + 1;
                    var sb = new StringBuilder();

                    while (j < text.Length && char.IsDigit(text[j]))
                    {
                        sb.Append(text[j]);
                        j++;
                    }

                    dict.Add(new KeyValuePair<char, int>(text[i], int.Parse(sb.ToString())));
                }
            }

            return dict;
        }
    }
}
