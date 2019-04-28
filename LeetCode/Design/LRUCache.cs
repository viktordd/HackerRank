using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Design
{
    [TestClass]
    public class LruCache
    {
        #region Tests

        [TestMethod]
        public void LRUCache_Solutions()
        {
            LRUCache cache = new LRUCache(2 /* capacity */);

            cache.Put(1, 10);
            cache.Put(2, 20);
            Assert.AreEqual(10, cache.Get(1)); // returns 10
            cache.Put(3, 30);                  // evicts key 2
            Assert.AreEqual(-1, cache.Get(2)); // returns -1 (not found)
            cache.Put(4, 40);                  // evicts key 1
            Assert.AreEqual(-1, cache.Get(1)); // returns -1 (not found)
            Assert.AreEqual(30, cache.Get(3)); // returns 30
            Assert.AreEqual(40, cache.Get(4)); // returns 40
            cache.Put(4, 44);
            Assert.AreEqual(44, cache.Get(4)); // returns 44
        }

        #endregion
    }

    public class LRUCache
    {
        public class Node
        {
            public Node(int key = 0, int value = 0)
            {
                Key = key;
                Value = value;
            }
            public int Key { get; set; }
            public int Value { get; set; }
            public Node Prev { get; set; }
            public Node Next { get; set; }
        }

        private readonly int capacity;
        private readonly Dictionary<int, Node> cache;
        private readonly Node head;
        private readonly Node tail;


        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            cache = new Dictionary<int, Node>(capacity);

            head = new Node();
            tail = new Node();
            head.Next = tail;
            tail.Prev = head;
        }

        public int Get(int key)
        {
            if (!cache.TryGetValue(key, out var node))
                return -1;

            MoveToHead(node);
            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (cache.TryGetValue(key, out var node))
            {
                MoveToHead(node);
                node.Value = value;
                return;
            }

            if (cache.Count == capacity)
                InvalidateOldest();

            node = new Node(key, value);
            AddNode(node);
            cache.Add(key, node);
        }

        private void MoveToHead(Node node)
        {
            RemoveNode(node);
            AddNode(node);
        }

        private void InvalidateOldest()
        {
            cache.Remove(tail.Prev.Key);
            RemoveNode(tail.Prev);
        }

        private void AddNode(Node node)
        {
            node.Next = head.Next;
            node.Next.Prev = node;

            node.Prev = head;
            head.Next = node;
        }

        private void RemoveNode(Node node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }
    }
}
