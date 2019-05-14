namespace HackerRank.StringManipulation.CommonChild
{
    using System;
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommonChildTests
    {
        [DataTestMethod]
        [DataRow("HARRY", "SALLY", 2, DisplayName = "HARRY, SALLY, 2")]
        [DataRow("AA", "BB", 0, DisplayName = "AA, BB, 0")]
        [DataRow("SHINCHAN", "NOHARAAA", 3, DisplayName = "SHINCHAN, NOHARAAA, 3")]
        [DataRow("ABCDEF", "FBDAMN", 2, DisplayName = "ABCDEF, FBDAMN, 2")]
        [DataRow("ABZZEF", "ABZZEF", 6, DisplayName = "ABZZEF, ABZZEF, 6")]
        [DataRow("ABZZEF", "ABXXXEF", 4, DisplayName = "ABZZEF, ABXXXEF, 4")]
        [DataRow("1ABZZEF2", "3ABXXXEF4", 4, DisplayName = "1ABZZEF2, 3ABXXXEF4, 4")]
        public void CommonChildTest(string s1, string s2, int expected)
        {
            var result = Solution.commonChild(s1, s2);

            Assert.AreEqual(expected, result);
        }
    }

    class Solution
    {

        // Complete the commonChild function below.
        public static int commonChild(string s1, string s2)
        {
            int start = 0;
            int end1 = s1.Length - 1;
            int end2 = s2.Length - 1;

            // trim off matchin items at the beginning
            while (start <= end1 && start <= end2 && s1[start] == s2[start]) start++;

            // if equal strings return string length
            if (start == s1.Length)
                return start;

            // trim off matchin items at the end
            while (start <= end1 && start <= end2 && s1[end1] == s2[end2]) { end1--; end2--; }

            string s1s = s1.Substring(start, end1 - start + 1);
            string s2s = s2.Substring(start, end2 - start + 1);

            if (s1s.Length < s2s.Length)
            {
                return LCSLength(s2s, s1s) + start + (s1.Length - 1 - end1);
            }

            return LCSLength(s1s, s2s) + start + (s1.Length - 1 - end1);
        }

        private static int LCSLength(string s1, string s2)
        {
            int[,] c = new int[2, s2.Length + 1];

            for (int i = 0; i < s1.Length; i++)
            {
                int ci = (i + 1) % 2;
                int ciPrev = i % 2;
                for (int j = 0; j < s2.Length; j++)
                {
                    int cj = j + 1;
                    int cjPrev = j;
                    if (s1[i] == s2[j])
                        c[ci, cj] = c[ciPrev, cjPrev] + 1;
                    else
                        c[ci, cj] = Math.Max(c[ci, cjPrev], c[ciPrev, cj]);
                }
            }

            return c[1, s2.Length];
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            int result = commonChild(s1, s2);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }

}