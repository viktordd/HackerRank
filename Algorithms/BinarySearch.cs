using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms
{
    [TestClass]
    public class BinarySearchTest
    {
        [DataTestMethod]
        [DataRow(new[] { 2, 3, 4, 10, 40 }, 10)]
        [DataRow(new[] { 2, 3, 4, 10, 40 }, 9)]
        [DataRow(new[] { 2, 3, 4, 10, 40 }, 11)]
        [DataRow(new[] { 2, 3, 4, 10, 40 }, 1)]
        [DataRow(new[] { 2, 3, 4, 10, 40 }, 41)]
        public void Test(int[] arr, int x)
        {
            var solution = new BinarySearchClass();
            var result = solution.BinarySearch(arr, x);
            var expected = Array.BinarySearch(arr, x);
            Assert.AreEqual(expected, result);
        }
    }

    /// Implementation of the Array.BinarySearch algorithm
    public class BinarySearchClass
    {
        public int BinarySearch<T>(T[] arr, T x) where T : IComparable<T>
        {
            int comp = 0;
            int l = 0;
            int r = arr.Length - 1;
            while (l < r)
            {
                int m = l + (r - l) / 2;

                comp = x.CompareTo(arr[m]);

                if (comp == 0)
                    return m;

                if (comp < 0)
                    r = m - 1;

                else
                    l = m + 1;
            }

            comp = x.CompareTo(arr[l]);

            if (comp == 0)
                return l;

            if (comp < 0)
                return ~l;

            return ~(l + 1);
        }
    }
}