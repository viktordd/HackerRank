
namespace HackerRank.DataStructures.Arrays
{
    public class ArrayManipulationClass
    {
        /*
         * Complete the arrayManipulation function below.
         */
        public static long ArrayManipulation(int n, long[][] queries)
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
