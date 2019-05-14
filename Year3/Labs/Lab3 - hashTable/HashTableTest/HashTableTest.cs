using System;
using Lab3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTableTest
{
    [TestClass]
    public class HashTableTest
    {
        [TestMethod]
        public void CountIncreasesAfterAdding()
        {
            var hashTable = new HashTable<int, int>();
            var n = 10;

            for (int i = 0; i < n; i++)
                hashTable.Add(i, i);

            Assert.AreEqual(hashTable.Count, n);
        }

        [TestMethod]
        public void CountDecreasesAfterRemoving()
        {
            var hashTable = new HashTable<int, int>();
            var n = 10;

            for (int i = 0; i < n; i++)
                hashTable.Add(i, i);

            var m = 4;

            for (int i = 0; i < m; i++)
                hashTable.Remove(i);

            Assert.AreEqual(hashTable.Count, n - m);
        }

        [TestMethod]
        public void ContainsExistedItem()
        {
            var hashTable = new HashTable<int, int>();
            var n = 10;

            for (int i = 0; i < n; i++)
                hashTable.Add(i, i);

            var flag = hashTable.Contains(5);

            Assert.AreEqual(flag, true);
        }

        [TestMethod]
        public void NotContainsNotExistedItem()
        {
            var hashTable = new HashTable<int, int>();
            var n = 10;

            for (int i = 0; i < n; i++)
                hashTable.Add(i, i);

            var flag = hashTable.Contains(99);

            Assert.AreEqual(flag, false);
        }

        [TestMethod]
        public void NotContainsRemovedItem()
        {
            var hashTable = new HashTable<int, int>();
            var n = 10;

            for (int i = 0; i < n; i++)
                hashTable.Add(i, i);

            hashTable.Remove(5);

            var flag = hashTable.Contains(5);

            Assert.AreEqual(flag, false);
        }

        [TestMethod]
        public void RemoveExistedItemIsTrue()
        {
            var hashTable = new HashTable<int, int>();
            var n = 10;

            for (int i = 0; i < n; i++)
                hashTable.Add(i, i);

            var flag = hashTable.Remove(5);

            Assert.AreEqual(flag, true);
        }

        [TestMethod]
        public void RemoveNotExistedItemIsFalse()
        {
            var hashTable = new HashTable<int, int>();
            var n = 10;

            for (int i = 0; i < n; i++)
                hashTable.Add(i, i);

            var flag = hashTable.Remove(99);

            Assert.AreEqual(flag, false);
        }

        [TestMethod]
        public void IndexatorReturnsCorrectValue()
        {
            var hashTable = new HashTable<int, int>();
            var n = 10;

            for (int i = 0; i < n; i++)
                hashTable.Add(i, i*2);

            var value = hashTable[5];

            Assert.AreEqual(value, 10);
        }

        [TestMethod]
        public void SetValueByIndexChangesValueAtThisIndex()
        {
            var hashTable = new HashTable<int, int>();
            var n = 10;

            for (int i = 0; i < n; i++)
                hashTable.Add(i, i);

            var lastValue = hashTable[5];
            hashTable[5] = 100;
            var newValue = hashTable[5];

            Assert.AreNotEqual(lastValue, newValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Item with same key has already been added")]
        public void ExceptionWhileAddingExistedKey()
        {
            var hashTable = new HashTable<int, int>();
            var n = 10;

            for (int i = 0; i < n; i++)
                hashTable.Add(i, i);

            hashTable.Add(5, 0);
        }
    }
}
