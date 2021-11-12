using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace LeetCode
{
    [TestClass]
    public class ScrambleString_Test
    {
        [DataTestMethod]
        [DataRow("great", "rgeat", true)]
        [DataRow("abcde", "caebd", false)]
        [DataRow("a", "a", true)]
        [DataRow("abcdbdacbdac", "bdacabcdbdac", true)]
        public void ScrambleString_Solutions(string s1, string s2, bool expected)
        {
            var solution = new ScrambleString();
            var result = solution.IsScramble(s1, s2);
            Assert.AreEqual(expected, result);
        }
    }

    // https://leetcode.com/problems/scramble-string/
    public class ScrambleString
    {
        Dictionary<string, bool> map = new();
        public bool IsScramble(string s1, string s2)
        {
            var key = s1 + '-' + s2;

            if (map.ContainsKey(key))
            {
                return map[key];
            }

            if (s1 == s2)
            {
                map[key] = true;
                return true;
            }

            if (s1.Length != s2.Length || !hasAllLetters(s1, s2))
            {
                map[key] = false;
                return false;
            }

            for (int i = 1; i < s1.Length; i++)
            {
                var s1Left = s1.Substring(0, i);
                var s1Right = s1.Substring(i);

                if ((IsScramble(s1Left, s2.Substring(0, i)) && IsScramble(s1Right, s2.Substring(i))) ||
                   (IsScramble(s1Left, s2.Substring(s1.Length - i)) && IsScramble(s1Right, s2.Substring(0, s1.Length - i))))
                {
                    map[key] = true;
                    return true;
                }
            }

            map[key] = false;
            return false;
        }

        private bool hasAllLetters(string s1, string s2)
        {
            int[] letters = new int[26];
            for (int i = 0; i < s1.Length; i++)
            {
                letters[s1[i] - 'a']++;
                letters[s2[i] - 'a']--;
            }
            for (int i = 0; i < 26; i++)
            {
                if (letters[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }


        public bool IsScrambleBruteForce(string s1, string s2)
        {
            if (s1.Length == 1)
                return s1 == s2;

            Dictionary<string, List<string>> mem = new();

            foreach (var s in ScrambleRec(s1, mem))
            {
                // Console.WriteLine(s);
                if (s == s2)
                    return true;
            }

            return false;
        }

        private IEnumerable<string> ScrambleRec(string curr, Dictionary<string, List<string>> mem)
        {
            if (curr.Length == 1)
            {
                return new[] { curr };
            }

            if (mem.ContainsKey(curr))
            {
                return mem[curr];
            }

            var list = ScrambleRecIterator(curr, mem);

            mem[curr] = list.ToList();

            return list;
        }

        private IEnumerable<string> ScrambleRecIterator(string curr, Dictionary<string, List<string>> mem)
        {
            for (int i = 1; i <= curr.Length - 1; i++)
            {
                var left = curr.Substring(0, i);
                var right = curr.Substring(i);

                IEnumerable<string> rs = ScrambleRec(right, mem).ToList();
                foreach (var l in ScrambleRec(left, mem))
                {
                    foreach (var r in rs)
                    {
                        yield return l + r;
                        yield return r + l;
                    }
                }
            }
        }
    }
}