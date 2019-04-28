using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank.DataStructures.Arrays
{
    [TestClass]
    public class ArrayManipulation
    {
        [TestMethod]
        public void ArrayManipulation_Solutions()
        {
            int n = 5;

            long[][] queries = {
                new long[] {1, 2, 100},
                new long[] {2, 5, 100},
                new long[] {3, 4, 100}
            };

            var result = arrayManipulation(n, queries);

            Assert.AreEqual(200, result);
        }

        /*
         * Complete the arrayManipulation function below.
         */
        public static long arrayManipulation(int n, long[][] queries)
        {
            long[] array = new long[n];

            for (int i = 0; i < queries.Length; i++)
            {
                long[] query = queries[i];
                long a = query[0] - 1;
                long b = query[1] - 1;
                long k = query[2];


                array[a] += k;
                if (b + 1 < n) array[b + 1] -= k;
            }

            long curr = 0;
            long max = 0;
            for (int i = 0; i < n; i++)
            {
                curr += array[i];
                if (curr > max)
                    max = curr;
            }

            return max;
        }
    }
}
