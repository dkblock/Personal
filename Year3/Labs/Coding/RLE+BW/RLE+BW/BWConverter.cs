using System.Collections.Generic;
using System.Text;

namespace RLE_BW
{
    public class BWConverter
    {
        public KeyValuePair<string, int> Encode(string text)
        {
            var codes = new List<string>();
            var sb = new StringBuilder(text);
            var num = 0;

            for (int i = 0; i < text.Length; i++)
            {
                codes.Add(sb.ToString());

                var first = sb[0];
                sb.Remove(0, 1);
                sb.Append(first);
            }

            codes.Sort();
            sb.Clear();

            for (int i = 0; i < codes.Count; i++)
            {
                sb.Append(codes[i][codes[i].Length - 1]);

                if (codes[i] == text)
                    num = i + 1;
            }

            return new KeyValuePair<string, int>(sb.ToString(), num);
        }

        public string Decode(string text, int num)
        {
            var codes = new List<string>();

            for (int i = 0; i < text.Length; i++)
                codes.Add(text[i].ToString());

            codes.Sort();

            while (codes[0].Length < text.Length)
            {
                for (int i = 0; i < codes.Count; i++)
                {
                    var sb = new StringBuilder(codes[i]);
                    sb.Insert(0, text[i]);
                    codes[i] = sb.ToString();
                }

                codes.Sort();
            }

            return codes[num - 1].ToString();
        }
    }
}
