using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class GroupAnagrams
    {
        #region Tests
        [DataTestMethod]
        [DataRow(new[] { "eat", "tea", "tan", "ate", "nat", "bat" }, "[[\"ate\",\"eat\",\"tea\"],[\"nat\",\"tan\"],[\"bat\"]]")]
        [DataRow(new[] { "ray", "cod", "abe", "ned", "arc", "jar", "owl", "pop", "paw", "sky", "yup", "fed", "jul", "woo", "ado", "why", "ben", "mys", "den", "dem", "fat", "you", "eon", "sui", "oct", "asp", "ago", "lea", "sow", "hus", "fee", "yup", "eve", "red", "flo", "ids", "tic", "pup", "hag", "ito", "zoo" },
            "[[\"hag\"],[\"pup\"],[\"ids\"],[\"ito\"],[\"flo\"],[\"red\"],[\"hus\"],[\"sow\"],[\"asp\"],[\"oct\"],[\"sui\"],[\"fee\"],[\"eon\"],[\"tic\"],[\"sky\"],[\"ago\"],[\"paw\"],[\"jul\"],[\"pop\"],[\"jar\"],[\"den\",\"ned\"],[\"owl\"],[\"eve\"],[\"mys\"],[\"abe\"],[\"zoo\"],[\"ado\"],[\"ray\"],[\"cod\"],[\"lea\"],[\"arc\"],[\"dem\"],[\"fat\"],[\"yup\",\"yup\"],[\"woo\"],[\"fed\"],[\"why\"],[\"ben\"],[\"you\"]]")]
        public void GroupAnagrams_Solutions(string[] strs, string expectedJson)
        {
            var solution = new Solution2();

            var result = solution.GroupAnagrams(strs);

            var expected = (IList<IList<string>>)JsonSerializer.Deserialize<List<IList<string>>>(expectedJson);

            result.Should().BeEquivalentTo(expected);
        }
        #endregion

        public class Solution
        {
            public IList<IList<string>> GroupAnagrams(string[] strs)
            {
                var result = new List<IList<string>>();

                var sorted = strs
                    .Select(str => (sorted: string.Join("", str.OrderBy(ch => ch)), str))
                    .OrderBy(s => s.sorted);

                List<string> curr = null;
                string currSorted = null;

                foreach (var str in sorted)
                {
                    if (curr == null || currSorted != str.sorted)
                    {
                        curr = new List<string>();
                        result.Add(curr);

                        curr.Add(str.str);
                        currSorted = str.sorted;
                    }
                    else
                    {
                        curr.Add(str.str);
                    }
                }

                return result;
            }
        }

        public class Solution2
        {
            public IList<IList<string>> GroupAnagrams(string[] strs)
            {
                var result = new Dictionary<string, IList<string>>();

                foreach (var str in strs)
                {
                    var key = GetKey(str);
                    if (!result.TryGetValue(key, out IList<string> list))
                    {
                        list = [];
                        result.Add(key, list);
                    }
                    list.Add(str);
                }

                return [.. result.Values];
            }

            private static string GetKey(string str)
            {
                var count = new int[26];
                foreach (var ch in str)
                    count[ch - 'a']++;

                return string.Join(",", count);
            }
        }
    }
}