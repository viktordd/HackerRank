using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class SimplifyPath
    {
        #region Tests
        [DataTestMethod]
        [DataRow("/home/", "/home")]
        [DataRow("/../", "/")]
        [DataRow("/home//foo/", "/home/foo")]
        [DataRow("/a/./b/../../c/", "/c")]
        [DataRow("/a/../../b/../c//.//", "/c")]
        [DataRow("/a//b////c/d//././/..", "/a/b/c")]
        public void SimplifyPath_Solutions(string path, string expected)
        {
            var solution = new Solution();

            var result = solution.SimplifyPath(path);

            Assert.AreEqual(expected, result);
        }
        #endregion

        public class Solution
        {
            public string SimplifyPath(string path)
            {
                var folders = path.Split('/', StringSplitOptions.RemoveEmptyEntries);

                var res = new Stack<string>();

                foreach (var folder in folders)
                {
                    if (folder == ".") continue;
                    else if (folder == "..")
                    {
                        if (res.Count > 0)
                            res.Pop();
                    }
                    else
                        res.Push(folder);
                }

                return $"/{string.Join('/', res.Reverse())}";
            }
        }
    }
}