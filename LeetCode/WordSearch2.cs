using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

namespace Algorithms
{
    [TestClass]
    public class WordSearch2Test
    {
        [DataTestMethod]
        [DataRow("[['o','a','a','n'],['e','t','a','e'],['i','h','k','r'],['i','f','l','v']]", "[\"oath\",\"pea\",\"eat\",\"rain\"]", "[\"oath\",\"eat\"]")]
        [DataRow("[['a','b'],['c','d']]", "[\"abcb\"]", "[]")]
        [DataRow("[['o','a','a','n'],['e','t','a','s'],['t','d','o','g'],['i','f','s','s']]", "[\"oath\",\"dig\",\"dog\",\"dogs\"]", "[\"dog\",\"dogs\"]")]
        public void Test(string boardJson, string wordsJson, string expectedJson)
        {
            char[][] board = JsonConvert.DeserializeObject<char[][]>(boardJson);
            string[] words = JsonConvert.DeserializeObject<string[]>(wordsJson);

            var solution = new WordSearch2Class();
            var result = solution.FindWords(board, words);

            string resultJson = JsonConvert.SerializeObject(result);
            Assert.AreEqual(expectedJson, resultJson);
        }
    }

    class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public string word = null;

        public TrieNode() { }
    }

    class WordSearch2Class
    {
        public IList<string> FindWords(char[][] board, string[] words)
        {
            var result = new List<string>();

            if (words.Length == 0)
            {
                return result;
            }

            TrieNode root = BuildTrie(words);

            for (int r = 0; r < board.Length; r++)
            {
                for (int c = 0; c < board[r].Length; c++)
                {
                    if (root.children.ContainsKey(board[r][c]))
                    {
                        backtracking(result, board, r, c, root);
                    }
                }
            }

            return result;
        }

        private TrieNode BuildTrie(string[] words)
        {
            TrieNode root = new TrieNode();

            foreach (string word in words)
            {
                TrieNode node = root;

                foreach (char c in word)
                {
                    if (node.children.ContainsKey(c))
                    {
                        node = node.children[c];
                    }
                    else
                    {
                        TrieNode newNode = new TrieNode();
                        node.children.Add(c, newNode);
                        node = newNode;
                    }
                }

                node.word = word;
            }

            return root;
        }

        private void backtracking(IList<string> result, char[][] board, int r, int c, TrieNode parent)
        {
            char letter = board[r][c];
            TrieNode currNode = parent.children[letter];

            // check if there is any match
            if (currNode.word != null)
            {
                result.Add(currNode.word);
                currNode.word = null;
            }

            board[r][c] = '#';


            (int r, int c)[] offset = { (-1, 0), (0, 1), (1, 0), (0, -1) };

            for (int i = 0; i < offset.Length; ++i)
            {
                int newRow = r + offset[i].r;
                int newCol = c + offset[i].c;
                if (newRow < 0 || newRow >= board.Length ||
                    newCol < 0 || newCol >= board[newRow].Length)
                {
                    continue;
                }
                if (currNode.children.ContainsKey(board[newRow][newCol]))
                {
                    backtracking(result, board, newRow, newCol, currNode);
                }
            }

            board[r][c] = letter;

            // Optimization: incrementally remove the leaf nodes
            if (currNode.children.Count == 0)
            {
                parent.children.Remove(letter);
            }
        }
    }
}