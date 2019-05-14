using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Trees;

namespace TreesComparerGUI
{
    public partial class Form1 : Form
    {
        private Stopwatch _timer;
        private int[] _array;
        private int _removeFrom;
        private int _removeTo;
        private int _counfOfTests;

        public Form1()
        {
            InitializeComponent();
        }

        private void test_BTN_Click(object sender, EventArgs e)
        {
            info_RTB.Clear();

            _removeFrom = int.Parse(removeFrom_TB.Text);
            _removeTo = int.Parse(removeTo_TB.Text);
            _counfOfTests = int.Parse(countOfTests_TB.Text);
            _timer = new Stopwatch();

            if (random_RB.Checked)
                _array = GenerateRandomArray(int.Parse(countOfElements_TB.Text));
            else
                _array = GenerateSortedArray(int.Parse(countOfElements_TB.Text));

            if (binary_CB.Checked)
                GetAverageResult(new BinaryTree<int, int>());

            if (avl_CB.Checked)
                GetAverageResult(new AVLTree<int, int>());

            if (rb_CB.Checked)
                GetAverageResult(new RedBlackTree<int, int>());

            if (b_CB.Checked)
                GetAverageResult(new BTree<int, int>(200));
        }

        private void GetAverageResult(ITree<int, int> tree)
        {
            var timesOfAddition = new List<long>();
            var timesOfSearching = new List<long>();
            var timesOfRemoving = new List<long>();
            var totalTimes = new List<long>();

            for (int i = 0; i < _counfOfTests; i++)
            {
                timesOfAddition.Add(GetAdditionTimeResult(tree));
                timesOfSearching.Add(GetSearchingTimeResult(tree));
                timesOfRemoving.Add(GetRemovingTimeResult(tree));

                var total = timesOfAddition[i] + timesOfSearching[i] + timesOfRemoving[i];
                totalTimes.Add(total);

                tree.Clear();
            }

            var averageAdditionTime = timesOfAddition.Sum() / _counfOfTests;
            var averageSearchingTime = timesOfSearching.Sum() / _counfOfTests;
            var averageRemovingTime = timesOfRemoving.Sum() / _counfOfTests;
            var averageTotalTime = totalTimes.Sum() / _counfOfTests;

            info_RTB.AppendText($"Average time of {GetTreeType(tree)}:\n");
            info_RTB.AppendText($"\tAddition: {averageAdditionTime} ms\n");
            info_RTB.AppendText($"\tSearching: {averageSearchingTime} ms\n");
            info_RTB.AppendText($"\tRemoving: {averageRemovingTime} ms\n");
            info_RTB.AppendText($"\tTotal: {averageTotalTime} ms\n\n");
        }

        private long GetAdditionTimeResult(ITree<int, int> tree)
        {
            _timer.Start();

            for (int i = 0; i < _array.Length; i++)
                tree.Add(_array[i], i);

            _timer.Stop();
            var time = _timer.ElapsedMilliseconds;
            _timer.Reset();

            return time;
        }

        private long GetRemovingTimeResult(ITree<int, int> tree)
        {
            _timer.Start();

            for (int i = _removeFrom; i <= _removeTo; i++)
                tree.Remove(_array[i]);

            _timer.Stop();
            var time = _timer.ElapsedMilliseconds;
            _timer.Reset();

            return time;
        }

        private long GetSearchingTimeResult(ITree<int, int> tree)
        {
            _timer.Start();

            for (int i = 0; i < _array.Length; i++)
                tree.Contains(_array[i]);

            _timer.Stop();
            var time = _timer.ElapsedMilliseconds;
            _timer.Reset();

            return time;
        }

        private string GetTreeType(ITree<int, int> tree)
        {
            if (tree is BinaryTree<int, int>)
                return "Binary Tree";

            if (tree is AVLTree<int, int>)
                return "AVL-Tree";

            if (tree is RedBlackTree<int, int>)
                return "Red-Black Tree";

            if (tree is BTree<int, int>)
                return "B-Tree";

            return "";
        }

        private int[] GenerateRandomArray(int length)
        {
            var array = new int[length];
            var unusedNumbers = Enumerable.Range(1, length).ToList();
            var rand = new Random();

            for (int i = 0; i < length; i++)
            {
                var pos = rand.Next(0, unusedNumbers.Count);
                array[i] = unusedNumbers[pos];
                unusedNumbers.RemoveAt(pos);
            }

            info_RTB.AppendText($"Generated array of {length} random values\n\n");

            return array;
        }

        private int[] GenerateSortedArray(int length)
        {
            var array = new int[length];

            for (int i = 0; i < length; i++)
                array[i] = i;

            info_RTB.AppendText($"Generated array of {length} sorted values\n\n");

            return array;
        }
    }
}
