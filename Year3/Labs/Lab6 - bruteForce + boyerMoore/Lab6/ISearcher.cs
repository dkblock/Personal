using System.Collections.Generic;

namespace Lab6
{
    public interface ISearcher
    {
        IEnumerable<int> GetAllEntries(string substring, string text);
    }
}
