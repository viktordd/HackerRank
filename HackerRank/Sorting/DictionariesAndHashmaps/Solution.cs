namespace HackerRank.Sorting.DictionariesAndHashmaps
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class MergeSortCountingInversionsTests
    {
        [DataTestMethod]
        [DataRow("[ [1, 5], [3, 2], [1, 5], [3, 2], [2, 5], [3, 1], [2, 5], [3, 1] ]", new[] { 0, 1, 1, 0 },
            DisplayName = "[ [1, 5], [3, 2], [1, 5], [3, 2], [2, 5], [3, 1], [2, 5], [3, 1] ], [0, 1, 1, 0]")]
        [DataRow("[ [1, 5], [1, 6], [3, 2], [1, 10], [1, 10], [1, 6], [2, 5], [3, 2] ]", new[] { 0, 1 },
            DisplayName = "[ [1, 5], [1, 6], [3, 2], [1, 10], [1, 10], [1, 6], [2, 5], [3, 2] ], [0, 1]")]
        [DataRow("[ [3, 4], [2, 1003], [1, 16], [3, 1] ]", new[] { 0, 1 },
            DisplayName = "[ [3, 4], [2, 1003], [1, 16], [3, 1] ], [ 0, 1 ]")]
        [DataRow("[ [1, 3], [2, 3], [3, 2], [1, 4], [1, 5], [1, 5], [1, 4], [3, 2], [2, 4], [3, 2] ]", new[] { 0, 1, 1 },
            DisplayName = "[ [1, 3], [2, 3], [3, 2], [1, 4], [1, 5], [1, 5], [1, 4], [3, 2], [2, 4], [3, 2] ], [ 0, 1, 1 ]")]
        public void MergeSortCountingInversionsTest(string input, int[] expected)
        {
            var list = JsonConvert.DeserializeObject<List<int[]>>(input);
            var result = Solution.freqQuery(list);

            Assert.AreEqual(expected.Length, result.Count);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }

    class Solution
    {

        // Complete the freqQuery function below.
        public static List<int> freqQuery(List<int[]> queries)
        {
            var result = new List<int>();

            var data = new Dictionary<int, int>();
            var freq = new Dictionary<int, int>();

            foreach (var query in queries)
            {
                var val = query[1];
                switch (query[0])
                {
                    case 1: Insert(data, freq, val); break;
                    case 2: Delete(data, freq, val); break;
                    case 3: //Check
                        result.Add(freq.TryGetValue(val, out int f) && f > 0 ? 1 : 0);
                        break;
                }
            }

            return result;
        }

        private static void Insert(Dictionary<int, int> data, Dictionary<int, int> freq, int val)
        {
            if (data.TryGetValue(val, out int count))
            {
                if (count > 0)
                    freq[count]--;
                data[val] = ++count;
                AddFrequency(freq, count);
            }
            else
            {
                data[val] = 1;
                AddFrequency(freq, 1);
            }
        }

        private static void Delete(Dictionary<int, int> data, Dictionary<int, int> freq, int val)
        {
            if (data.TryGetValue(val, out int ct) && ct > 0)
            {
                freq[ct]--;
                data[val] = --ct;
                if (ct > 0)
                    AddFrequency(freq, ct);
            }
        }

        private static void AddFrequency(Dictionary<int, int> freq, int f)
        {
            if (freq.ContainsKey(f))
                freq[f]++;
            else
                freq[f] = 1;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            List<int[]> queries = new List<int[]>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToArray());
            }

            List<int> ans = freqQuery(queries);

            textWriter.WriteLine(String.Join("\n", ans));

            textWriter.Flush();
            textWriter.Close();
        }
    }

}