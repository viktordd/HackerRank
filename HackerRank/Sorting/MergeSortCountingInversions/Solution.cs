namespace HackerRank.Sorting.MergeSortCountingInversions
{
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Collections;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Text.RegularExpressions;
    using System.Text;
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MergeSortCountingInversionsTests
    {
        [TestMethod]
        public void MergeSortCountingInversionsTest()
        {
            var input = new[] { 2, 1, 3, 1, 2 };
            var result = Solution.CountInversions(input);
            Assert.AreEqual(4, result);
        }
    }

    class Solution
    {
        // Complete the countInversions function below.
        public static long CountInversions(int[] arr)
        {
            return Mergesort(arr, new int[arr.Length], 0, arr.Length - 1);
        }

        private static long Mergesort(int[] arr, int[] temp, int leftStart, int rightEnd)
        {
            long swaps = 0;
            if (leftStart >= rightEnd)
                return swaps;

            int middle = (leftStart + rightEnd) / 2;
            swaps += Mergesort(arr, temp, leftStart, middle);
            swaps += Mergesort(arr, temp, middle + 1, rightEnd);
            swaps += MergeHalves(arr, temp, leftStart, rightEnd);
            return swaps;
        }

        private static long MergeHalves(int[] arr, int[] temp, int leftStart, int rightEnd)
        {
            long swaps = 0;
            int leftEnd = (leftStart + rightEnd) / 2;
            int rightStart = leftEnd + 1;
            int size = rightEnd - leftStart + 1;

            int left = leftStart;
            int right = rightStart;
            int i = leftStart;

            while (left <= leftEnd && right <= rightEnd)
            {
                if (arr[left] <= arr[right])
                {
                    temp[i] = arr[left];
                    left++;
                }
                else
                {
                    temp[i] = arr[right];
                    right++;
                    swaps += right - i;
                }
                i++;
            }

            Copy(arr, left, temp, i, leftEnd - left + 1);
            Copy(arr, right, temp, i, rightEnd - right + 1);
            Copy(temp, leftStart, arr, leftStart, size);

            return swaps;
        }

        private static void Copy(int[] source, int sStart, int[] dest, int dStart, int count)
        {
            for (int i = 0; i < count && sStart < source.Length && dStart < dest.Length; i++, sStart++, dStart++)
            {
                dest[dStart] = source[sStart];
            }
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine());

                int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
                long result = CountInversions(arr);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }

}