namespace Algorithms
{
    /// <summary>
    /// Weighted Quick-union Union Find with Path compression
    /// algorithm worst-case time
    /// -quick-find: M N
    /// -quick-union: M N
    /// -weighted QU: N + M log N
    /// -QU + path compression: N + M log N
    /// -weighted QU + path compression: N + M lg* N
    /// *M union-ﬁnd operations on a set of N objects
    /// </summary>
    class QuickUnionUF
    {
        private readonly int[] parent;
        private readonly int[] rank;

        public QuickUnionUF(int count)
        {
            parent = new int[count];
            rank = new int[count];
            for (int i = 0; i < count; i++)
            {
                parent[i] = i;
                rank = 1;
            }
        }

        private int FindParent(int node)
        {
            while (node != parent[node])
            {
                //path compression
                parent[node] = parent[parent[node]];
                node = parent[node];
            }
            return node;
        }

        public bool Connected(int p, int q)
        {
            return FindParent(p) == FindParent(q);
        }

        public void Union(int p, int q)
        {
            int parentP = FindParent(p);
            int parentQ = FindParent(q);

            if (parentP == parentQ)
                return;

            if (rank[parentP] < rank[parentQ])
            {
                parent[parentP] = parentQ;
                rank[parentQ] += rank[parentP];
            }
            else
            {
                parent[parentQ] = parentP;
                rank[parentP] += rank[parentQ];
            }
        }
    }
}
