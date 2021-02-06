using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class ThreeSum1
    {
        [DataTestMethod]
        [DataRow(4, new[] { 20, 4, 8, 2 }, 54)]
        public void ThreeSum_Solutions(int numOfSubFiles, int[] input, int expected)
        {
            var result = minimumTime(numOfSubFiles, input);

            Assert.AreEqual(expected, result);
        }


        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public int minimumTime(int numOfSubFiles, int[] files)
        {
            // WRITE YOUR CODE HERE
            // to get minimun time the algorithm will recursively merge
            // the two files with the lowest time
            // use min heap to hold all values,
            // pop two values merge them and add the result back in the heap.

            var heap = new MinHeap();

            for (int i = 0; i < numOfSubFiles; i++)
            {
                heap.Insert(files[i]);
            }

            var elapsedTime = 0;

            while (heap.Count > 1)
            {
                var a = heap.DelMin();
                var b = heap.DelMin();

                elapsedTime += a + b;

                heap.Insert(a + b);
            }

            return elapsedTime;
        }
        // METHOD SIGNATURE ENDS

    }

    //Create min heap to hold
    public class MinHeap
    {
        private List<int> heap;

        public MinHeap()
        {
            heap = new List<int>();
        }

        public int Count
        {
            get
            {
                return heap.Count;
            }
        }

        // insert by adding at the end
        // then calling swim on the last element.
        public void Insert(int x)
        {
            heap.Add(x);
            Swim(heap.Count - 1);
        }

        // delete minimum by storing it in temp variable,
        // then put the last element in it's place and sink it.
        public int DelMin()
        {
            int min = heap[0];
            Exchange(0, heap.Count - 1);
            heap.RemoveAt(heap.Count - 1);
            Sink(0);
            return min;
        }

        // swim exchanges an element with it's parent
        // as long as it's smaller than it.
        private void Swim(int k)
        {
            while (k > 0 && heap[Parent(k)] > heap[k])
            {
                int parent = Parent(k);
                Exchange(k, parent);
                k = parent;
            }
        }

        // sink exchanges the parent element with the bigger of its children
        // as long as it's bigger than it's children
        private void Sink(int k)
        {
            while (LChild(k) < heap.Count)
            {
                // choose witch child to swap
                int j = LChild(k);
                if (j + 1 < heap.Count && heap[j] > heap[j + 1]) j++;
                // break of current is less thatn the smaller child
                if (heap[k] < heap[j]) break;
                Exchange(k, j);
                k = j;
            }
        }

        private int Parent(int k)
        {
            return (k - 1) / 2;
        }

        private int LChild(int k)
        {
            return 2 * k + 1;
        }

        private void Exchange(int i, int j)
        {
            int t = heap[i];
            heap[i] = heap[j];
            heap[j] = t;
        }
    }
}
