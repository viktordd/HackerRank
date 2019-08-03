using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace LeetCode
{
    [TestClass]
    public class WordSearch
    {
        #region Tests
        [DataTestMethod]
        [DataRow("[['A','B','C','E'],['S','F','C','S'],['A','D','E','E']]", "ABCCED", true)]
        [DataRow("[['A','B','C','E'],['S','F','C','S'],['A','D','E','E']]", "SEE", true)]
        [DataRow("[['A','B','C','E'],['S','F','C','S'],['A','D','E','E']]", "ABCB", false)]
        public void WordSearch_Solutions(string boardJson, string word, bool expected)
        {
            char[][] board = JsonConvert.DeserializeObject<char[][]>(boardJson);

            var solution = new Solution();

            var result = solution.Exist(board, word);

            Assert.AreEqual(expected, result);
        }
        #endregion

        public class Solution
        {
            public bool Exist(char[][] board, string word)
            {
                var R = board.Length;
                if (R == 0) return false;
                var C = board[0].Length;
                if (C == 0) return false;

                for (int r = 0; r < R; r++)
                    for (int c = 0; c < C; c++)
                        if (Dfs(board, r, c, word, 0))
                            return true;
                return false;
            }

            (int r, int c)[] adjacent = new[]
            {
                (-1, 0),
                (0, 1),
                (1, 0),
                (0, -1)
            };

            public bool Dfs(char[][] board, int r, int c, string word, int ch)
            {
                var curr = board[r][c];

                if (curr != word[ch])
                    return false;

                if (ch == word.Length - 1)
                    return true;

                board[r][c] = '\0';
                var R = board.Length;
                var C = board[0].Length;

                foreach (var adj in adjacent)
                {
                    var newR = r + adj.r;
                    var newC = c + adj.c;

                    if (newR >= 0 && newR < R &&
                        newC >= 0 && newC < C &&
                        Dfs(board, newR, newC, word, ch + 1))
                        return true;
                }

                board[r][c] = curr;

                return false;
            }
        }

        public class Solution1
        {
            public void Merge(int[] nums1, int m, int[] nums2, int n)
            {
                int i = m + n - 1;
                m--;
                n--;

                while (m >= 0 && n >= 0)
                    nums1[i--] = nums1[m] >= nums2[n]
                        ? nums1[m--]
                        : nums2[n--];

                while (n >= 0) nums1[i--] = nums2[n--];
            }
        }
    }
}