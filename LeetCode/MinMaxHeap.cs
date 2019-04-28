using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class MinMaxHeapTests
    {
        #region Tests

        [TestMethod]
        public void MinHeap_Solutions()
        {
            var minHeap = new MinHeap<int>();

            minHeap.Push(1);
            Assert.AreEqual(1, minHeap.Peek());

            minHeap.Push(2);
            Assert.AreEqual(1, minHeap.Peek());

            minHeap.Push(3);
            Assert.AreEqual(1, minHeap.Peek());

            minHeap.Push(4);
            Assert.AreEqual(1, minHeap.Peek());

            minHeap.Push(5);
            Assert.AreEqual(1, minHeap.Peek());
            
            Assert.AreEqual(1, minHeap.PopPush(6));
            Assert.AreEqual(2, minHeap.Peek());

            minHeap.Push(0);
            Assert.AreEqual(0, minHeap.Peek());

            Assert.AreEqual(0, minHeap.Pop());
            Assert.AreEqual(2, minHeap.Pop());
            Assert.AreEqual(3, minHeap.Pop());
            Assert.AreEqual(4, minHeap.Pop());
            Assert.AreEqual(5, minHeap.Pop());
            Assert.AreEqual(6, minHeap.Pop());

            Assert.AreEqual(0, minHeap.Count);
        }

        [TestMethod]
        public void MaxHeap_Solutions()
        {
            var maxHeap = new MaxHeap<int>();

            maxHeap.Push(6);
            Assert.AreEqual(6, maxHeap.Peek());

            maxHeap.Push(5);
            Assert.AreEqual(6, maxHeap.Peek());

            maxHeap.Push(4);
            Assert.AreEqual(6, maxHeap.Peek());

            maxHeap.Push(3);
            Assert.AreEqual(6, maxHeap.Peek());

            maxHeap.Push(2);
            Assert.AreEqual(6, maxHeap.Peek());
            
            Assert.AreEqual(6, maxHeap.PopPush(1));

            Assert.AreEqual(5, maxHeap.Peek());

            maxHeap.Push(7);
            Assert.AreEqual(7, maxHeap.Peek());

            Assert.AreEqual(7, maxHeap.Pop());
            Assert.AreEqual(5, maxHeap.Pop());
            Assert.AreEqual(4, maxHeap.Pop());
            Assert.AreEqual(3, maxHeap.Pop());
            Assert.AreEqual(2, maxHeap.Pop());
            Assert.AreEqual(1, maxHeap.Pop());

            Assert.AreEqual(0, maxHeap.Count);
        }

        #endregion
    }

    public class MinHeap<T> : MinMaxHeap<T>
    {
        protected override bool NeedToSwap(int pos, int parent)
        {
            return Comparer.Compare(Heap[pos], Heap[parent]) < 0;
        }
    }

    public class MaxHeap<T> : MinMaxHeap<T>
    {
        protected override bool NeedToSwap(int pos, int parent)
        {
            return Comparer.Compare(Heap[pos], Heap[parent]) > 0;
        }
    }

    public abstract class MinMaxHeap<T>
    {
        protected readonly List<T> Heap;

        protected readonly Comparer<T> Comparer;

        protected MinMaxHeap()
        {
            Heap = new List<T>();
            Comparer = Comparer<T>.Default;
        }

        public int Count => Heap.Count;
        
        public void Push(T item)
        {
            var pos = Heap.Count;

            Heap.Add(item);

            if (pos == 0) return;

            var parent = Parent(pos);
            while (pos != 0 && NeedToSwap(pos, parent))
            {
                Swap(pos, parent);
                pos = parent;
                parent = Parent(pos);
            }

            Heap[pos] = item;
        }

        public T Pop()
        {
            if (Heap.Count == 0)
                return default;
            
            var pop = Heap[0];

            if (Heap.Count == 1)
                Heap.RemoveAt(0);
            else
            {
                Heap[0] = Heap[Heap.Count - 1];
                Heap.RemoveAt(Heap.Count - 1);
                Heapify(0);
            }

            return pop;
        }

        public T PopPush(T item)
        {
            if (Heap.Count == 0)
            {
                Heap.Add(item);
                return default;
            }

            var pop = Heap[0];
            Heap[0] = item;

            if (Heap.Count > 1)
                Heapify(0);

            return pop;
        }

        public T Peek()
        {
            return Heap.Count > 0 ? Heap[0] : default;
        }

        private static int Parent(int i)
        {
            return (i - 1) / 2;
        }

        private static int Left(int i)
        {
            return 2 * i + 1;
        }

        private static int Right(int i)
        {
            return 2 * i + 2;
        }

        private void Heapify(int parent)
        {
            while (true)
            {
                var l = Left(parent);
                var r = Right(parent);
                var swap = parent;
                if (l < Heap.Count && NeedToSwap(l, parent)) swap = l;
                if (r < Heap.Count && NeedToSwap(r, swap)) swap = r;

                if (swap == parent) return;

                Swap(parent, swap);
                parent = swap;
            }
        }

        private void Swap(int i, int j)
        {
            var t = Heap[i];
            Heap[i] = Heap[j];
            Heap[j] = t;
        }

        protected abstract bool NeedToSwap(int pos, int parent);
    }
}

