﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms
{
    [TestClass]
    public class BinarySearchTest
    {
        [DataTestMethod]
        [DataRow(new[] { 2, 4, 6, 10, 40 }, 6)]  // 2
        [DataRow(new int[0], 9)]                 // ~0
        [DataRow(new[] { 2, 4, 6, 10, 40 }, 1)]  // ~0
        [DataRow(new[] { 2, 4, 6, 10, 40 }, 3)]  // ~1
        [DataRow(new[] { 2, 4, 6, 10, 40 }, 5)]  // ~2
        [DataRow(new[] { 2, 4, 6, 10, 40 }, 7)]  // ~3
        [DataRow(new[] { 2, 4, 6, 10, 40 }, 11)] // ~4
        [DataRow(new[] { 2, 4, 6, 10, 40 }, 41)] // ~5
        [DataRow(new[] { 2, 4, 6, 10, 40, 45 }, 1)]  // ~0
        [DataRow(new[] { 2, 4, 6, 10, 40, 45 }, 3)]  // ~1
        [DataRow(new[] { 2, 4, 6, 10, 40, 45 }, 5)]  // ~2
        [DataRow(new[] { 2, 4, 6, 10, 40, 45 }, 7)]  // ~3
        [DataRow(new[] { 2, 4, 6, 10, 40, 45 }, 11)] // ~4
        [DataRow(new[] { 2, 4, 6, 10, 40, 45 }, 41)] // ~5
        [DataRow(new[] { 2, 4, 6, 10, 40, 45 }, 46)] // ~6
        public void Test(int[] arr, int x)
        {
            var expected = Array.BinarySearch(arr, x);

            var solution = new BinarySearchClass();
            var result = solution.BinarySearch(arr, x);
            Assert.AreEqual(expected, result);
        }
    }

    /// Implementation of the Array.BinarySearch algorithm
    public class BinarySearchClass
    {
        public int BinarySearch<T>(T[] arr, T x) where T : IComparable<T>
        {
            if (arr.Length == 0)
                return -1;

            int comp = 0;
            int l = 0;
            int r = arr.Length - 1;

            while (l < r)
            {
                int m = l + (r - l) / 2;

                comp = x.CompareTo(arr[m]);

                if (comp == 0) // x == m
                    return m;

                if (comp < 0) // x < m
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