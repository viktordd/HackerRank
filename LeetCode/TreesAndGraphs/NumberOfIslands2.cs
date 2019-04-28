using System.Collections.Generic;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.TreesAndGraphs
{
    [TestClass]
    public class NumberOfIslands2
    {
        #region Tests

        [TestMethod]
        public void NumberOfIslands2_Solutions()
        {
            AssertEnumerable.AreEqual(new[] {1, 1, 2, 3}, NumIslands2(3, 3, new[,] {{0, 0}, {0, 1}, {1, 2}, {2, 1}}));
        }

        #endregion


        public IList<int> NumIslands2(int rows, int cols, int[,] positions)
        {
            var dsu = new DSU(rows * cols);
            var result = new List<int>();

            int GetIndx(int r, int c) => r * cols + c;

            for (var i = 0; i < positions.GetLength(0); i++)
            {
                var r = positions[i, 0];
                var c = positions[i, 1];
                var indx = GetIndx(r, c);

                dsu.Set(indx);

                var up = GetIndx(r - 1, c);
                if (r - 1 >= 0 && dsu.IsSet(up)) { dsu.Union(indx, up); }

                var down = GetIndx(r + 1, c);
                if (r + 1 < rows && dsu.IsSet(down)) { dsu.Union(indx, down); }

                var left = GetIndx(r, c - 1);
                if (c - 1 >= 0 && dsu.IsSet(left)) { dsu.Union(indx, left); }

                var right = GetIndx(r, c + 1);
                if (c + 1 < cols && dsu.IsSet(right)) { dsu.Union(indx, right); }

                result.Add(dsu.GetCount());
            }

            return result;
        }

        public class DSU
        {
            private readonly int[] parent;
            private readonly int[] rank;
            private int count;

            public DSU(int size)
            {
                parent = new int[size];
                rank = new int[size];

                for (var i = 0; i < size; i++)
                    parent[i] = -1;
            }

            public int Find(int i)
            {
                if (parent[i] != i)
                    parent[i] = Find(parent[i]);
                return parent[i];
            }

            public bool Union(int a, int b)
            {
                var pA = Find(a);
                var pB = Find(b);

                if (pA == pB)
                    return false;

                if (rank[pA] < rank[pB])
                    parent[pA] = pB;

                else if (rank[pB] < rank[pA])
                    parent[pB] = pA;

                else
                {
                    parent[pB] = pA;
                    rank[pA]++;
                }

                count--;

                return true;
            }

            public void Set(int i)
            {
                count++;
                parent[i] = i;
            }

            public bool IsSet(int i)
            {
                return parent[i] > -1;
            }

            public int GetCount() => count;
        }
    }
}
