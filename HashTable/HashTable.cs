using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public class HashTable
    {
        class HashTableItem 
        {
            public string Key;
            public string Value;
        }

        LinkedList<HashTableItem>[] _items;
        int _slotCount = 1000;

        public HashTable()
        {
            _items = new LinkedList<HashTableItem>[_slotCount];
        }

        public void Add(string key, string val)
        {
            if (ContainsKey(key))
                throw new Exception("Key Exists");

            var slotNum = HashString(key);

            if (_items[slotNum] == null)
            {
                _items[slotNum] = new LinkedList<HashTableItem>();
            }

            _items[slotNum].AddLast(new HashTableItem { Key = key, Value = val });
        }

        public string GetValue(string key)
        {
            var slotNum = HashString(key);
            var list = _items[slotNum];

            if (list == null)
                return null;

            foreach (var item in list)
            {
                if (item.Key == key)
                {
                    return item.Value;
                }
            }
            return null;
        }

        public bool ContainsKey(string key)
        {
            var slotNum = HashString(key);
            var list = _items[slotNum];

            if (list == null)
                return false;

            foreach (var item in list)
            {
                if (item.Key == key)
                {
                    return true;
                }
            }
            return false;
        }

        public void Remove(string key)
        {
            var slotNum = HashString(key);
            var list = _items[slotNum];
            HashTableItem found = null;

            if (list == null)
                return;

            foreach (var item in list)
            {
                if (item.Key == key)
                {
                    found = item;
                    break;
                }
            }

            if (found != null)
                list.Remove(found);
        }

        protected int HashString(string val)
        {
            int sum = 0;
            foreach (var c in val)
            {
                sum += c;
            }
            return sum % _slotCount;
        }

    }
}
