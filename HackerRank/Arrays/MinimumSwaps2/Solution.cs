namespace HackerRank.Arrays.MinimumSwaps2
{
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MinimumSwaps2Tests
    {
        [DataTestMethod]
        [DataRow(new[] { 8, 45, 35, 84, 79, 12, 74, 92, 81, 82, 61, 32, 36, 1, 65, 44, 89, 40, 28, 20, 97, 90, 22, 87, 48, 26, 56, 18, 49, 71, 23, 34, 59, 54, 14, 16, 19, 76, 83, 95, 31, 30, 69, 7, 9, 60, 66, 25, 52, 5, 37, 27, 63, 80, 24, 42, 3, 50, 6, 11, 64, 10, 96, 47, 38, 57, 2, 88, 100, 4, 78, 85, 21, 29, 75, 94, 43, 77, 33, 86, 98, 68, 73, 72, 13, 91, 70, 41, 17, 15, 67, 93, 62, 39, 53, 51, 55, 58, 99, 46 }, 91,
            DisplayName = "large 100, 91")]
        [DataRow(new[] { 3, 2, 1, 5, 4, 8, 6, 7 }, 4, DisplayName = "[ 3, 2, 1, 5, 4, 8, 6, 7 ], 4")]
        [DataRow(new[] { 7, 1, 3, 2, 4, 5, 6 }, 5, DisplayName = "[ 7, 1, 3, 2, 4, 5, 6 ], 5")]
        [DataRow(new[] { 4, 3, 1, 2 }, 3, DisplayName = "[ 4, 3, 1, 2 ], 3")]
        [DataRow(new[] { 2, 3, 4, 1, 5 }, 3, DisplayName = "[ 2, 3, 4, 1, 5 ], 3")]
        [DataRow(new[] { 1, 3, 5, 2, 4, 6, 7 }, 3, DisplayName = "[ 1, 3, 5, 2, 4, 6, 7 ], 3")]
        public void MergeSortCountingInversionsTest(int[] input, int expected)
        {
            var result = Solution.minimumSwaps(input);
            Assert.AreEqual(expected, result);
        }
    }

    class Solution
    {
        // Complete the minimumSwaps function below.
        public static int minimumSwaps(int[] arr)
        {
            var numberSwaps = 0;
            var i = 0;

            while (i < arr.Length)
            {
                int finalPosition = arr[i] - 1;

                if (finalPosition != i)
                {
                    int buffer = arr[i];
                    arr[i] = arr[finalPosition];
                    arr[finalPosition] = buffer;
                    numberSwaps++;
                }
                else
                {
                    i++;
                }
            }

            return numberSwaps;
        }

        static void minimumSwaps_Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            int res = minimumSwaps(arr);

            textWriter.WriteLine(res);

            textWriter.Flush();
            textWriter.Close();
        }
    }


}