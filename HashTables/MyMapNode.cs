using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables
{
    class MyMapNode<K,V>
    {
        public struct KeyValue<K, V>
        {
            public K Key { get; set; }
            public V Value { get; set; }
        }
        private readonly int size;
        //int[] arr;
        private readonly LinkedList<KeyValue<K,V>>[] items;
        public MyMapNode(int size)// Creting a constructer to intilisize the values
        {
            this.size = size;
            //arr new int [size];
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        protected int GetArrayPosition(K key)
        {
            int hash=key.GetHashCode();
            int position=hash%size;
            return Math.Abs(position);
        }
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach(KeyValue<K, V> item in linkedList)
            {
                if(item.Key.Equals (key))
                    return item.Value;  
            }
            return default(V);
        }
        public void Add(K key,V value) //this method for adding the elements
        {
            int position=GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key=key,Value=value};
            linkedList.AddLast(item);
        }
        public bool Exists(K key) //this method for checking how many same elements in linked list
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K,V>> linkedList= GetLinkedList(position);
            foreach(KeyValue<K,V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }
        public void Remove(K key)
        {
            int position =GetArrayPosition(key);
            LinkedList<KeyValue<K,V>> linkedList=GetLinkedList(position);
            bool itemFound=false;
            KeyValue<K,V> foundItem=default(KeyValue<K,V>);
            foreach(KeyValue<K,V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound=true;
                    foundItem=item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
        protected LinkedList<KeyValue<K,V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K,V>> linkedList= items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        public void Display() // this method for displying the elements in linked list
        {
            foreach(var linkedList in items)
            {
                if (linkedList != null)
                {
                    foreach (var element in linkedList)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + " " + element.Value);
                    }
                }
            }
        }
    }
}
