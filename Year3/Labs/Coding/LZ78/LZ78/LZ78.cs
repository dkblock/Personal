using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZ78
{
    public class Item
    {
        public int Index { get; set; }
        public int Pointer { get; set; }
        public string Text { get; set; }
        public string Code { get; set; }

        public Item(int index, int pointer, string text, string kode)
        {
            Index = index;
            Pointer = pointer;
            Text = text;
            Code = kode;
        }
    }

    public class LZ78
    {
        private List<KeyValuePair<int, string>[]> _codeList;
        private List<int> _dictionarySizes = new List<int>();
        private List<Dictionary<string, List<Item>>> _dictionaryList;
        private StringBuilder _text = new StringBuilder();

        public double Size { get; private set; }

        public List<KeyValuePair<int, string>[]> Encode(string text)
        {
            _dictionaryList = new List<Dictionary<string, List<Item>>>();
            _dictionaryList.Add(new Dictionary<string, List<Item>>());
            int i = 0, dictionaryIndex = 0, dictionaryLetterIndex = 1;
            StringBuilder current;

            while (i <= text.Length - 1)
            {
                current = new StringBuilder("");
                current.Append(text[i]);

                if (_dictionaryList[dictionaryIndex].ContainsKey(current.ToString()))
                {
                    i++;
                    var key = current.ToString();

                    if (i > text.Length - 1)
                    {
                        _dictionaryList[dictionaryIndex][key].Add(new Item(dictionaryLetterIndex, _dictionaryList[dictionaryIndex][key][0].Index, current.ToString(), current.ToString()));
                        break;
                    }

                    current.Append(text[i]);

                    Item item = _dictionaryList[dictionaryIndex][key].FirstOrDefault(x => x.Text.Equals(current.ToString()));
                    Item oldItem = item;

                    while (item != null)
                    {
                        i++;

                        if (i > text.Length - 1)
                        {
                            i--;
                            break;
                        }

                        current.Append(text[i]);
                        oldItem = item;
                        item = _dictionaryList[dictionaryIndex][key].FirstOrDefault(x => x.Text.Equals(current.ToString()));
                    }

                    var lastLetter = current[current.Length - 1];
                    current.Remove(current.Length - 1, 1);

                    var pointer = oldItem != null ? oldItem.Index : _dictionaryList[dictionaryIndex][key][0].Index;
                    _dictionaryList[dictionaryIndex][key].Add(new Item(dictionaryLetterIndex, pointer, current.Append(text[i]).ToString(), lastLetter.ToString()));
                    dictionaryLetterIndex++;
                }
                else
                {
                    _dictionaryList[dictionaryIndex].Add(current.ToString(), new List<Item> { new Item(dictionaryLetterIndex, 0, current.ToString(), current.ToString()) });
                    dictionaryLetterIndex++;
                }

                i++;

                if (dictionaryLetterIndex == 1000)
                {
                    dictionaryIndex++;
                    _dictionaryList.Add(new Dictionary<string, List<Item>>());
                    _dictionarySizes.Add(dictionaryLetterIndex);
                    dictionaryLetterIndex = 1;
                }
            }

            _dictionarySizes.Add(dictionaryLetterIndex);

            Size = 0;
            _codeList = new List<KeyValuePair<int, string>[]>();

            for (int k = 0; k < _dictionaryList.Count; k++)
            {
                int maxIndex = 0;
                _codeList.Add(new KeyValuePair<int, string>[_dictionarySizes[k] + 1]);

                foreach (var item in _dictionaryList[k])
                {
                    foreach (var piece in item.Value)
                    {
                        maxIndex = Math.Max(maxIndex, piece.Pointer);
                        _codeList[k][piece.Index] = new KeyValuePair<int, string>(piece.Pointer, piece.Code);
                    }
                }

                var binMaxIndex = Convert.ToString(maxIndex, 2).Length;
                Size += (binMaxIndex + 8) * _codeList[k].Length - 1;                
            }

            return _codeList;
        }

        public string Decode()
        {
            _text = new StringBuilder();

            for (int i = 0; i < _codeList.Count; i++)
            {
                for (int j = 0; j < _codeList[i].Length; j++)
                {
                    int k = j;
                    StringBuilder code = new StringBuilder(_codeList[i][k].Value);

                    while (_codeList[i][k].Key != 0)
                    {
                        k = _codeList[i][k].Key;
                        code.Insert(0, _codeList[i][k].Value);
                    }

                    _text.Append(code);
                }
            }

            return _text.ToString();
        }        
    }
}
