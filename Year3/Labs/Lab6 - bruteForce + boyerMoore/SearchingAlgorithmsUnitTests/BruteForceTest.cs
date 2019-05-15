using System.Collections.Generic;
using System.Linq;
using Lab6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchingAlgorithmsUnitTests
{
    [TestClass]
    public class BruteForceTest
    {
        private BruteForce _bruteForce = new BruteForce();

        [TestMethod]
        public void FirstEntryIs2()
        {
            var text = "aabcabbcdbc";
            var substring = "bc";
            var entries = _bruteForce.GetAllEntries(substring, text).ToList();
            var first = entries[0];

            Assert.AreEqual(first, 2);
        }

        [TestMethod]
        public void AllEntriesFoundCorrect()
        {
            var text = "aabcabbcdbc";
            var substring = "bc";
            var entries = _bruteForce.GetAllEntries(substring, text).ToList();
            var expected = new List<int>() { 2, 6, 9 };

            CollectionAssert.AreEqual(entries, expected);
        }

        [TestMethod]
        public void CountOfEntriesIs3()
        {
            var text = "aabcabbcdbc";
            var substring = "bc";
            var entries = _bruteForce.GetAllEntries(substring, text).ToList();
            var count = entries.Count;

            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void CountOfEntriesIs0()
        {
            var text = "aabcabbcdbc";
            var substring = "bcc";
            var entries = _bruteForce.GetAllEntries(substring, text).ToList();
            var count = entries.Count;

            Assert.AreEqual(count, 0);
        }
    }
}
