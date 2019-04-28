using System.Collections.Generic;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class MinimumWindowSubstring
    {
        #region Tests

        [TestMethod]
        public void MinimumWindowSubstring_Solutions()
        {
            //Input: S = "ADOBECODEBANC", T = "ABC"
            //Output: "BANC"

            Assert.AreEqual("BANC", MinWindow("ADOBECODEBANC", "ABC"));
            Assert.AreEqual("a", MinWindow("a", "a"));
        }

        #endregion

        public string MinWindow(string s, string t)
        {
            if (string.IsNullOrEmpty(s) || s.Length < t.Length)
                return "";

            var map = new int[64];
            var tMap = new bool[64];

            foreach (var c in t)
            {
                tMap[c - 'A'] = true;
                map[c - 'A']++;
            }

            int left = 0, minLeft = 0, minLen = s.Length + 1, count = 0;

            for (int right = 0; right < s.Length; right++)
            {
                var rIndx = s[right] - 'A';
                if (!tMap[rIndx]) continue;

                map[rIndx]--;

                if (map[rIndx] >= 0)
                    count++;

                while (count == t.Length)
                {
                    if (right - left + 1 < minLen)
                    {
                        minLeft = left;
                        minLen = right - left + 1;
                    }

                    var lIndx = s[left] - 'A';
                    if (tMap[lIndx])
                    {
                        map[lIndx]++;
                        if (map[lIndx] > 0)
                        {
                            count--;
                        }
                    }

                    left++;
                }
            }

            return minLen > s.Length ? "" : s.Substring(minLeft, minLen);
        }
    }
}
