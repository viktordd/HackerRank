using System.Collections.Generic;
using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode;

[TestClass]
public class GraphValidTree_Test
{
    [DataTestMethod]
    [DataRow(5, "[[0, 1], [0, 2], [0, 3], [1, 4]]", true)]
    [DataRow(5, "[[0, 1], [1, 2], [2, 3], [1, 3], [1, 4]]", false)]
    public void GraphValidTree_Solutions(int n, string edgesJson, bool expected)
    {
        var edges = JsonSerializer.Deserialize<int[][]>(edgesJson);
        var solution = new GraphValidTree();
        var result = solution.ValidTree(n, edges);
        Assert.AreEqual(expected, result);
    }
}

// https://leetcode.com/problems/graph-valid-tree/
public class GraphValidTree
{
    /**
    * @param n: An integer
    * @param edges: a list of undirected edges
    * @return: true if it's a valid tree, or false
    */
    public bool ValidTree(int n, int[][] edges)
    {
        List<int>[] adj = new List<int>[n];

        for (int i = 0; i < n; i++)
        {
            adj[i] = new();
        }

        for (int i = 0; i < edges.Length; i++)
        {
            int l = edges[i][0];
            int r = edges[i][1];

            adj[l].Add(r);
            adj[r].Add(l);
        }

        HashSet<int> visited = new();
        return dfs(0, -1) && visited.Count == n;

        bool dfs(int node, int parent)
        {
            if (visited.Contains(node))
                return false;

            visited.Add(node);

            var currAdj = adj[node];

            for (int i = 0; i < currAdj.Count; i++)
            {
                if (currAdj[i] == parent)
                    continue;

                if (!dfs(currAdj[i], node))
                    return false;
            }

            return true;
        }
    }
}