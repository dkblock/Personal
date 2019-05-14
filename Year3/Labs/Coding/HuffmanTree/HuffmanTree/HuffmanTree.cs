using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuffmanTree
{
    internal class Node
    {
        public string Key { get; set; }
        public double Period { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public string Code { get; set; }

        public Node(string symbol, double period)
        {
            Key = symbol;
            Period = period;
            Code = string.Empty;
        }

        public Node() { }
    }

    public class HuffmanTree
    {
        private Node _root;
        private List<Node> _nodes;
        private Dictionary<char, string> _codes;

        public HuffmanTree(Dictionary<char, double> periodDictionary)
        {
            _nodes = new List<Node>();
            _codes = new Dictionary<char, string>();

            BuildTree(periodDictionary);
        }

        public Dictionary<char, string> GetCode()
        {
            if (_root.Left == null && _root.Right == null)
            {
                _codes.Add(_root.Key[0], "0");
                return _codes;
            }

            var code = new Stack<byte>();
            var stNodes = new Stack<Node>();
            var visitedNodes = new HashSet<Node>();

            stNodes.Push(_root);
            visitedNodes.Add(stNodes.Peek());

            while (stNodes.Count > 0)
            {
                var first = stNodes.Peek();

                if (first.Left != null && !visitedNodes.Contains(first.Left))
                {
                    stNodes.Push(first.Left);
                    code.Push(0);
                    visitedNodes.Add(first.Left);
                }
                else
                {
                    if (first.Right != null && !visitedNodes.Contains(first.Right))
                    {
                        stNodes.Push(first.Right);
                        code.Push(1);
                        visitedNodes.Add(first.Right);
                    }
                    else
                    {
                        var nums = new List<byte>();

                        while (code.Count > 0)
                            nums.Add(code.Pop());

                        var answer = new StringBuilder();

                        for (int i = nums.Count - 1; i >= 0; i--)
                        {
                            answer.Append(nums[i]);
                            code.Push(nums[i]);
                        }

                        if (code.Count > 0)
                            code.Pop();

                        var item = stNodes.Pop();

                        if (first.Key.Length == 1)
                            _codes.Add(item.Key[0], answer.ToString());
                    }
                }
            }

            return _codes;
        }

        private void BuildTree(Dictionary<char, double> periodDictionary)
        {
            foreach (var item in periodDictionary)
                _nodes.Add(new Node(item.Key.ToString(), item.Value));

            while (_nodes.Count > 1)
            {
                var sortedNodes = _nodes.OrderBy(x => x.Period).ToList();

                if (sortedNodes.Count >= 2)
                {
                    var taken = sortedNodes.Take(2).ToList();

                    var parent = new Node()
                    {
                        Key = taken[0].Key + taken[1].Key,
                        Period = taken[0].Period + taken[1].Period,
                        Left = taken[0],
                        Right = taken[1]
                    };

                    _nodes.Remove(taken[0]);
                    _nodes.Remove(taken[1]);
                    _nodes.Add(parent);
                }
            }

            _root = _nodes.FirstOrDefault();
        }
    }
}
