using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Helpers
{
    public class AssertEnumerable
    {
        private static string RNT = "\r\n\t";

        /// <summary>
        /// Tests whether the items in the specified enumerables are equal at each position and throws an exception
        /// if any of the items the enumerables are not equal, or the enumerables are different lengths.
        /// </summary>
        public static void AreEqual2DimArrays<T>(IEnumerable<IEnumerable<T>> expected, IEnumerable<IEnumerable<T>> actual, string errMsg = null)
        {
            using (var expectedEnum = expected.GetEnumerator())
            using (var actualEnum = actual.GetEnumerator())
            {
                int i = -1;
                bool expectedMoved, actualMoved;

                bool MoveNext()
                {
                    expectedMoved = expectedEnum.MoveNext();
                    actualMoved = actualEnum.MoveNext();
                    i++;
                    return expectedMoved && actualMoved;
                };

                while (MoveNext())
                    AreEqual(expectedEnum.Current, actualEnum.Current, $"{errMsg}{RNT}Items at position {i} not equal.{RNT}{ToString2DimArrays(expected, actual)}");

                Assert.AreEqual(expectedMoved, actualMoved, actualMoved
                    ? $"{errMsg}{RNT}Less items than expected.{RNT}{ToString2DimArrays(expected, actual)}"
                    : $"{errMsg}{RNT}More items than expected.{RNT}{ToString2DimArrays(expected, actual)}");
            }
        }

        /// <summary>
        /// Tests whether the items in the specified enumerables are equal at each position and throws an exception
        /// if any of the items the enumerables are not equal, or the enumerables are different lengths.
        /// </summary>
        public static void AreEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual, string errMsg = null)
        {
            using (var expectedEnum = expected.GetEnumerator())
            using (var actualEnum = actual.GetEnumerator())
            {
                int i = -1;
                bool expectedMoved, actualMoved;

                bool MoveNext()
                {
                    expectedMoved = expectedEnum.MoveNext();
                    actualMoved = actualEnum.MoveNext();
                    i++;
                    return expectedMoved && actualMoved;
                };

                while (MoveNext())
                    Assert.AreEqual(expectedEnum.Current, actualEnum.Current, $"{errMsg}{RNT}Items at position {i} not equal.{RNT}{ToString(expected, actual)}");

                Assert.AreEqual(expectedMoved, actualMoved, actualMoved
                    ? $"{errMsg}{RNT}Less items than expected.{RNT}{ToString(expected, actual)}"
                    : $"{errMsg}{RNT}More items than expected.{RNT}{ToString(expected, actual)}");
            }
        }


        public static string ToString2DimArrays<T>(IEnumerable<IEnumerable<T>> expected, IEnumerable<IEnumerable<T>> actual)
        {
            return $"Expected: {ToString2DimArray(expected)}{RNT}  Actual: {ToString2DimArray(actual)}";
        }

        public static string ToString<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            return $"Expected: {ToString(expected)}{RNT}  Actual: {ToString(actual)}";
        }

        public static string ToString2DimArray<T>(IEnumerable<IEnumerable<T>> list)
        {
            string joined = string.Join(", ", list.Select(ToString));
            return $"[{joined}]";
        }

        public static string ToString<T>(IEnumerable<T> list)
        {
            string joined = string.Join(", ", list);
            return $"[{joined}]";
        }
    }
}
