using System;
using System.Collections.Generic;
using Lab2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeUnitTests
{
    [TestClass]
    public class AVLTreeTests
    {
        [TestMethod]
        public void CountIncreasesAfterAdding()
        {
            var tree = new AVLTree<int, int>();
            var n = 10;

            for (int i = 0; i < n; i++)
                tree.Add(i, i);

            Assert.AreEqual(tree.Count, n);
        }

        [TestMethod]
        public void AllAddedPairsOutputed()
        {
            var tree = new AVLTree<int, int>();

            tree.Add(2, 2);
            tree.Add(4, 4);
            tree.Add(6, 6);

            var pairs = tree.GetPairs();
            var expected = new List<KeyValuePair<int, int>>();

            expected.AddRange(new[] { new KeyValuePair<int, int>(2, 2), new KeyValuePair<int, int>(4, 4), new KeyValuePair<int, int>(6, 6) });

            CollectionAssert.AreEqual(pairs, expected);
        }

        [TestMethod]
        public void ExceptionWhenAddingSameKeys()
        {
            var tree = new AVLTree<int, int>();
            tree.Add(2, 2);

            Assert.ThrowsException<ArgumentException>(() => tree.Add(2, 4));
        }

        [TestMethod]
        public void ExistedKeyFound()
        {
            var tree = new AVLTree<int, int>();
            var n = 10;

            for (int i = 0; i < n; i++)
                tree.Add(i, i);

            Assert.AreEqual(tree.Contains(5), true);
        }

        [TestMethod]
        public void NotExistedKeyNotFound()
        {
            var tree = new AVLTree<int, int>();
            var n = 10;

            for (int i = 0; i < n; i++)
                tree.Add(i, i);

            Assert.AreEqual(tree.Contains(9000), false);
        }

        [TestMethod]
        public void CountDecreasesAfterRemoving()
        {
            var tree = new AVLTree<int, int>();
            var n = 10;
            var m = 2;

            for (int i = 0; i < n; i++)
                tree.Add(i, i);

            for (int i = 0; i < m; i++)
                tree.Remove(i);

            var expected = n - m;

            Assert.AreEqual(tree.Count, expected);
        }
    }
}
