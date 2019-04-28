using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class PrefixTree
    {
        #region Tests

        [TestMethod]
        public void PrefixTree_Solutions()
        {
            var trie = new Trie();

            trie.Insert("apple");
            Assert.IsTrue(trie.Search("apple")); // returns true
            Assert.IsFalse(trie.Search("app")); // returns false
            Assert.IsTrue(trie.StartsWith("app")); // returns true
            trie.Insert("app");
            Assert.IsTrue(trie.Search("app")); // returns true
        }

        #endregion

        public class Trie
        {
            private readonly TrieNode root;

            /** Initialize your data structure here. */
            public Trie()
            {
                root = new TrieNode();
            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                var (curr, i, found) = InternalSearch(word);
                if (found && curr.IsEnd)
                    return;

                while (i < word.Length)
                {
                    var ch = word[i];
                    var t = new TrieNode();
                    curr.Put(ch, t);
                    curr = t;
                    i++;
                }
                
                curr.IsEnd = true;
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                var (last, _, found) = InternalSearch(word);

                return found && last.IsEnd;
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                return InternalSearch(prefix).found;
            }

            private (TrieNode last, int i, bool found) InternalSearch(string prefix)
            {
                int i;
                var curr = root;
                for (i = 0; i < prefix.Length; i++)
                {
                    var ch = prefix[i];
                    if (curr.ContainsKey(ch))
                        curr = curr.Get(ch);
                    else
                        return (curr, i, false);
                }

                return (curr, i, true);
            }

            public class TrieNode
            {
                private readonly TrieNode[] links;

                private const int Count = 26;

                public bool IsEnd { get; set; }

                public TrieNode()
                {
                    links = new TrieNode[Count];
                }

                public bool ContainsKey(char ch)
                {
                    return links[ch - 'a'] != null;
                }

                public TrieNode Get(char ch)
                {
                    return links[ch - 'a'];
                }

                public void Put(char ch, TrieNode node)
                {
                    links[ch - 'a'] = node;
                }
            }
        }
    }
}
