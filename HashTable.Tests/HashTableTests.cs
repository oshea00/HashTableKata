using NUnit.Framework;
using System;

namespace HashTable.Tests
{
    public class HashTableTests : HashTable
    {
        [Test]
        public void CanSaveValueByKey()
        {
            var hash = new HashTable();
            hash.Add("Key1", "Value");
        }

        [Test]
        public void CanRetrieveValueByKey()
        {
            var hash = new HashTable();
            var key = "Key1";
            var value = "Value";
            hash.Add(key, value);

            var storedValue = hash.GetValue(key);

            Assert.AreEqual(value, storedValue);
        }

        [Test]
        public void CanCheckKeyExists()
        {
            var hash = new HashTable();
            var key = "Key1";
            var value = "Value";
            hash.Add(key, value);

            Assert.IsTrue(hash.ContainsKey(key));
        }

        [Test]
        public void CanDeleteItems()
        {
            var hash = new HashTable();
            var key = "Key1";
            var value = "Value";
            hash.Add(key, value);
            hash.Remove(key);

            Assert.IsFalse(hash.ContainsKey(key));
        }

        [Test]
        public void AddingDuplicateKeyThrowsExeception()
        {
            var hash = new HashTable();
            var key = "Key1";
            var value1 = "Value1";
            var value2 = "Value2";
            hash.Add(key, value1);

            Assert.Throws(typeof(Exception), () => { hash.Add(key, value2); });
        }

        [Test]
        public void CanHaveKeyCollisions()
        {
            var hash1 = HashString("01");
            var hash2 = HashString("a");
            Assert.AreEqual(hash1, hash2);
        }

        [Test]
        public void CanHandleKeyCollision()
        {
            var hash = new HashTable();
            var key1 = "01";
            var key2 = "a";
            var value1 = "Value1";
            var value2 = "Value2";
            hash.Add(key1, value1);

            hash.Add(key2, value2);

            Assert.AreEqual(hash.GetValue(key1), value1);

        }

        [Test]
        public void CanRemoveCorrectlyOnKeyCollision()
        {
            var hash = new HashTable();
            var key1 = "01";
            var key2 = "a";
            var value1 = "Value1";
            var value2 = "Value2";
            hash.Add(key1, value1);
            hash.Add(key2, value2);

            hash.Remove(key1);

            Assert.AreEqual(hash.GetValue(key2), value2);

        }

        [Test]
        public void GettingNonExistentKeyReturnsNullValue()
        {
            var hash = new HashTable();
            Assert.IsNull(hash.GetValue("nothere"));
        }

    }
}