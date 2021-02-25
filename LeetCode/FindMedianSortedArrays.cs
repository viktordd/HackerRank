using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class FindMedianSortedArraysTest
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 3 }, new int[] { 2 }, 2.00000)]
        [DataRow(new int[] { 1, 2 }, new int[] { 3, 4 }, 2.50000)]
        [DataRow(new int[] { 0, 0 }, new int[] { 0, 0 }, 0.00000)]
        [DataRow(new int[] { }, new int[] { 1 }, 1.00000)]
        [DataRow(new int[] { 2 }, new int[] { }, 2.00000)]
        public void Test(int[] A, int[] B, double expected)
        {
            var solution = new FindMedianSortedArraysClass();
            var result = solution.FindMedianSortedArrays(A, B);
            Assert.AreEqual(expected, result);
        }
    }

    public class FindMedianSortedArraysClass
    {
        public double FindMedianSortedArrays(int[] A, int[] B)
        {
            if (A == null || B == null)
            {
                throw new ArgumentNullException();
            }

            int aLen = A.Length;
            int bLen = B.Length;

            // Make sure we always search the shorter array.
            if (aLen > bLen)
            {
                Swap(ref A, ref B);
                Swap(ref aLen, ref bLen);
            }

            int leftHalfLen = (aLen + bLen + 1) / 2;

            // Since A is guaranteed to be either shorter or of
            // the same length as B, we know it can contribute
            // 0 or all of its values to the left half of A ∪ B.
            int aMinCount = 0;
            int aMaxCount = aLen;

            while (aMinCount <= aMaxCount)
            {
                int aCount = aMinCount + (aMaxCount - aMinCount) / 2;
                int bCount = leftHalfLen - aCount;

                // a can be null if A is not contributing any values to left half.
                // e.g. A = [10, 11], B = [3, 4]
                //  ⟹ left half = [3, 4], aCount = 0, bCount = 2.
                int? a = (aCount > 0) ? A[aCount - 1] : (int?)null;

                // b can be null if B is not contributing any values to left half.
                // e.g. A = [3, 4], B = [10, 11]
                //  ⟹ left half = [3, 4], aCount = 2, bCount = 0.
                int? b = (bCount > 0) ? B[bCount - 1] : (int?)null;

                // aNext can be null if A is contributing all of its values to left half,
                //  i.e. aCount = A.Length.
                // e.g. A = [3, 4], B = [10, 11]
                //  ⟹ left half = [3, 4], aCount = 2, bCount = 0.
                int? aNext = (aCount < aLen) ? A[aCount] : (int?)null;

                // bNext can be null if B is contributing all of its values to left half,
                // i.e. bCount = B.Length.
                // e.g. A = [10, 11], B = [3, 4]
                //  ⟹ left half = [3, 4], aCount = 0, bCount = 2.
                int? bNext = (bCount < bLen) ? B[bCount] : (int?)null;

                if (a > bNext)
                {
                    // Decrease A's contribution size; a lies in the right half.
                    aMaxCount = aCount - 1;
                }
                else if (b > aNext)
                {
                    // Decrease B's contribution size, i.e. increase A's contribution size;
                    // b lies in the right half.
                    aMinCount = aCount + 1;
                }
                else
                {
                    // Neither a nor b lie beyond the left half. We found the right aCount.
                    // We don't know how a and b compare to each other yet though.

                    // If aLen + bLen is odd, the median is the greater of a and b.
                    int leftHalfEnd = (a == null)
                                        ? b.Value
                                        : (b == null)
                                            ? a.Value
                                            : Math.Max(a.Value, b.Value);

                    if ((aLen + bLen) % 2 == 1)
                    {
                        return leftHalfEnd;
                    }

                    // aLen + bLen is even. To compute the median, we need to find
                    // the first element in the right half, which will be the smaller
                    // of aNext and bNext. Remember that either aNext or bNext can be null (if all
                    // the values of A or B are in the left half).
                    int rightHalfStart = (aNext == null)
                                            ? bNext.Value
                                            : (bNext == null)
                                                ? aNext.Value
                                                : Math.Min(aNext.Value, bNext.Value);
                    return (leftHalfEnd + rightHalfStart) / 2.0;
                }
            }

            throw new InvalidOperationException("Unexpected code path reached");
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}