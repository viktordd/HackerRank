using System;
using System.Collections.Generic;

namespace Algorithms
{
    //Considerations
    //Immutability of keys.
    //・Assumption: client does not change keys while they're on the PQ.
    //・Best practice: use immutable keys.
    //Underflow and overflow.
    //・Underflow: throw exception if deleting from empty PQ.
    //・Overflow: add no-arg constructor and use resizing array.
    //Minimum-oriented priority queue.
    //・Replace less() with greater().
    //・Implement greater().
    //Other operations.
    //・Remove an arbitrary item.
    //・Change the priority of an item.


    /// <summary>
    /// Max Priority Queue implemented with Binary heap
    /// </summary>
    public class MaxPQ<T> where T : IComparable<T>
    {
        private readonly List<T> pq;

        public MaxPQ()
        {
            pq = new List<T>();
        }
        public bool IsEmpty()
        {
            return pq.Count == 0;
        }

        public void Insert(T x)
        {
            pq.Add(x);
            Swim(pq.Count - 1);
        }

        public T DelMax()
        {
            T max = pq[0];
            Exchange(0, pq.Count - 1);
            pq.RemoveAt(pq.Count - 1);
            Sink(0);
            return max;
        }

        private void Swim(int k)
        {
            while (k > 0 && Less(Parent(k), k))
            {
                int parent = Parent(k);
                Exchange(k, parent);
                k = parent;
            }
        }

        private void Sink(int k)
        {
            while (LChild(k) < pq.Count)
            {
                int j = LChild(k);
                if (j + 1 < pq.Count && Less(j, j + 1)) j++;
                if (!Less(k, j)) break;
                Exchange(k, j);
                k = j;
            }
        }

        private int Parent(int k) => (k - 1) / 2;

        private int LChild(int k) => 2 * k + 1;

        private bool Less(int i, int j)
        {
            return pq[i].CompareTo(pq[j]) < 0;
        }

        private void Exchange(int i, int j)
        {
            T t = pq[i];
            pq[i] = pq[j];
            pq[j] = t;
        }
    }
}
