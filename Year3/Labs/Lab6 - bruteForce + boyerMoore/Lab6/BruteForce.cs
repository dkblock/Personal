using System.Collections.Generic;

namespace Lab6
{
    public class BruteForce : ISearcher
    {
        public IEnumerable<int> GetAllEntries(string substring, string text)
        {
            var entries = new List<int>();

            for (int i = 0; i < text.Length; i++)
            {
                var current = i;

                for (int j = 0; j < substring.Length; j++)
                {
                    if (current < text.Length && text[current] == substring[j])
                        current++;
                    else
                        break;
                }

                if (current - i == substring.Length)
                    entries.Add(i);
            }

            return entries;
        }
    }
}
