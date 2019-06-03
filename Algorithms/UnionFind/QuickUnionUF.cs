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
        private readonly int[] id;
        private readonly int[] size;

        public QuickUnionUF(int n)
        {
            id = new int[n];
            size = new int[n];
            for (int i = 0; i < n; i++)
                id[i] = i;
        }

        private int Root(int i)
        {
            while (i != id[i])
            {
                id[i] = id[id[i]];
                i = id[i];
            }
            return i;
        }

        public bool Connected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        public void Union(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);
            if (i == j) return;
            if (size[i] < size[j])
            {
                id[i] = j;
                size[j] += size[i];
            }
            else
            {
                id[j] = i;
                size[i] += size[j];
            }
        }
    }
}
