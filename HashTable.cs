using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odev23
{
    public class HashEntry<K, V>
    {
        public K Key { get; private set; }
        public V Value { get; set; }

        public HashEntry(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }


    public class HashTable<K, V> : IEnumerable<HashEntry<K, V>>
    {
        private HashEntry<K, V>[] data;
        public int Capacity { get; private set; }
        public int Size { get; private set; }

        public HashTable( int capacity)
        {
            data = new HashEntry<K, V>[capacity];
            Capacity = capacity;
        }

        public HashTable() : this(100)
        {
                
        }

        public V GetValue(K key)
        {
            int hash = CalculateHash(key);
            if (data[hash] != null)
            {
                return data[hash].Value;
            }
            return default(V);
        }

        public void Put(K key, V value)
        {
            if (Size == Capacity)
            {
                throw new InvalidOperationException("HashTable dolu");
            }
            int hash = CalculateHash(key);
            if (data[hash] != null)
            {
                throw new InvalidOperationException($"Verilen değer hahs tablosubda bulunmakta");
            }
            data[hash] = new HashEntry<K, V>(key, value);
            Size++;
        }

        public void Remove(K key)
        {
            int hash = CalculateHash(key);
            if (data[hash] != null)
            {
                data[hash] = null;
                Size--;
            }
            else
            {
                throw new ArgumentException($"verieln değer hash tablosunda bulunmuuyor: (key)");

            }
        }

        public bool ContainKey(K key)
        {
            int hash = CalculateHash(key);
            return data[hash] != null;
        }

        public bool ContainValue(V value)
        {
            foreach (var entry in data)
            {
                if (entry.Value.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
        private int CalculateHash(K key)
        {
            int hash = Math.Abs(key, GetHashCode() % Capacity);
            if (data[hash] != null && !data[hash].Key.Equals(key))
                {
               hash = (hash - 1) % Capacity;
                }
            return hash;
        }

        public IEnumerator<HashEntry<K, V>> GetEnumerator()
        {
            foreach (var entry in data)
            {
                if (entry != null)
                {
                    yield return entry;

                }
            }
        }

  

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public V this[K key]
        {
            get
            {
                int hash = CalculateHash(key);
                return data[hash].Value;
            }
            set
            {
                int hash = CalculateHash(key);
                if (data[hash] != null)
                {
                    data[hash].Value = value;
                }
                else
                {
                    data[hash] = new HashEntry<K, V>(key, value);
                    Size++;
                }
            }
        }
    }

  
}
