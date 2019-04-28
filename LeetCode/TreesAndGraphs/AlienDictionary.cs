using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.TreesAndGraphs
{
    [TestClass]
    public class AlienDictionary
    {
        [TestMethod]
        public void AlienDictionary_Solutions()
        {
            Assert.AreEqual("wertf", AlienOrder(new[] { "wrt", "wrf", "er", "ett", "rftt" }));

            Assert.AreEqual("z", AlienOrder(new[] { "z", "z" }));

            Assert.AreEqual("", AlienOrder(new[] { "bsusz", "rhn", "gfbrwec", "kuw", "qvpxbexnhx", "gnp", "laxutz", "qzxccww" }));

            Assert.AreEqual("abc", AlienOrder(new[] { "a", "b", "ca", "cc" }));
            //brglkqsuzhnfwecvpxat
        }

        public string AlienOrder(string[] words)
        {
            if (words.Length == 0)
                return string.Empty;
            if (words.Length == 1)
                return words[0];
            
            var chars = new HashSet<char>();
            var comparisons = new List<char>[26];

            add(chars, words[0]);

            for (int i = 1; i < words.Length; i++)
            {
                var diff = compare(words[i - 1], words[i]);
                if (diff != null)
                {
                    var (first, second) = diff.Value;

                    var indxFirst = first - 'a';
                    if (comparisons[indxFirst] == null)
                        comparisons[indxFirst] = new List<char> {second};
                    else
                        comparisons[indxFirst].Add(second);
                }

                add(chars, words[i]);
            }

            if (hasCycles(comparisons))
                return string.Empty;
            
            var alphabet = topologicalSort(comparisons);

            if (alphabet.Length < chars.Count)
            {
                chars.ExceptWith(alphabet);
                alphabet = alphabet.Concat(chars).ToArray();
            }

            return new string(alphabet);
        }

        private bool hasCycles(List<char>[] comparisons)
        {
            var visited = new bool[comparisons.Length];
            for (int i = 0; i < comparisons.Length; i++)
            {
                if (comparisons[i] != null && hasCycles(i, comparisons, visited))
                    return true;
            }

            return false;
        }
        private bool hasCycles(int curr, List<char>[] comparisons, bool[] visited)
        {
            visited[curr] = true;

            var adjasent = comparisons[curr];
            if (adjasent != null)
                for (int i = 0; i < adjasent.Count; i++)
                {
                    var next = adjasent[i] - 'a';
                    if (visited[next] || hasCycles(next, comparisons, visited))
                        return true;
                }

            visited[curr] = false;

            return false;
        }

        private char[] topologicalSort(List<char>[] comparisons)
        {
            var visited = new bool[comparisons.Length];

            var stack = new Stack<char>();
            for (int i = 0; i < comparisons.Length; i++)
            {
                if (!visited[i] && comparisons[i] != null)
                    topologicalSort(i, comparisons, visited, stack);
            }

            var alphabet = stack.ToArray();
            return alphabet;
        }

        private void topologicalSort(int curr, List<char>[] comparisons, bool[] visited, Stack<char> stack)
        {
            visited[curr] = true;

            var adjasent = comparisons[curr];
            if (adjasent != null)
                for (int i = 0; i < adjasent.Count; i++)
                {
                    var next = adjasent[i] - 'a';
                    if (!visited[next])
                        topologicalSort(next, comparisons, visited, stack);
                }

            stack.Push((char) ('a' + (uint) curr));
        }


        public void add(HashSet<char> chars, in string word)
        {
            for (int i = 0; i < word.Length; i++)
                chars.Add(word[i]);
        }

        public (char first, char second)? compare(in string first, in string second)
        {
            for (int i = 0; i < first.Length && i < second.Length; i++)
            {
                if (first[i] == second[i])
                    continue;
                return (first[i], second[i]);
            }

            return null;
        }
    }
}
