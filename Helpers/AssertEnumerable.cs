using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Helpers
{
    public class AssertEnumerable
    {
        /// <summary>
        /// Tests whether the items in the specified enumerables are equal at each position and throws an exception
        /// if any of the items the enumerables are not equal, or the enumerables are different lengths.
        /// </summary>
        public static void AreEqual2DimArrays<T>(IEnumerable<IEnumerable<T>> expected, IEnumerable<IEnumerable<T>> actual, string errMsg = null)
        {
            using (var expectedEnum = expected.GetEnumerator())
            using (var actualEnum = actual.GetEnumerator())
            {
                int i = 0;
                bool expectedMoved, actualMoved;

                bool MoveNext()
                {
                    expectedMoved = expectedEnum.MoveNext();
                    actualMoved = actualEnum.MoveNext();
                    return expectedMoved && actualMoved;
                };

                while (MoveNext())
                    AreEqual(expectedEnum.Current, actualEnum.Current, $"{errMsg} Wrong item at position {i++}.");

                Assert.AreEqual(expectedMoved, actualMoved, actualMoved
                    ? "Less items than expected."
                    : "More items than expected.");
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
                int i = 0;
                bool expectedMoved, actualMoved;

                bool MoveNext()
                {
                    expectedMoved = expectedEnum.MoveNext();
                    actualMoved = actualEnum.MoveNext();
                    return expectedMoved && actualMoved;
                };

                while (MoveNext())
                    Assert.AreEqual(expectedEnum.Current, actualEnum.Current, $"{errMsg} Wrong item at position {i++}.");

                Assert.AreEqual(expectedMoved, actualMoved, actualMoved
                    ? "Less items than expected."
                    : "More items than expected.");
            }
        }
    }
}
