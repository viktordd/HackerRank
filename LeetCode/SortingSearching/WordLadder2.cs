using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.SortingSearching
{
    [TestClass]
    public class WordLadder2
    {
        #region Tests
        [TestMethod]
        public void WordLadder2_Solutions()
        {
            var expected = new[]
            {
                new[] {"hit", "hot", "dot", "dog", "cog"},
                new[] {"hit", "hot", "lot", "log", "cog"}
            };
            var actual = FindLadders("hit", "cog", new List<string> {"hot", "dot", "dog", "lot", "log", "cog"});

            Assert.AreEqual(Print(expected), Print(actual));
        }

        [TestMethod]
        public void WordLadder2_Solutions_2()
        {
            var expected = new[]
            {
                new[] {"a", "c"}
            };
            var actual = FindLadders("a", "c", new List<string> {"a", "b", "c"});

            Assert.AreEqual(Print(expected), Print(actual));
        }

        [TestMethod]
        public void WordLadder2_Solutions_3()
        {
            var expected = new[]
            {
                new[] {"red", "ted", "tex", "tax"},
                new[] {"red", "ted", "tad", "tax"},
                new[] {"red", "rex", "tex", "tax"}
            };
            var actual = FindLadders("red", "tax",
                new List<string> {"ted", "tex", "red", "tax", "tad", "den", "rex", "pee"});

            Assert.AreEqual(Print(expected), Print(actual));
        }

        [TestMethod]
        public void WordLadder2_Solutions_4()
        {
            var expected = new[]
            {
                new[] {"cet", "cot", "con", "ion", "inn", "ins", "its", "ito", "ibo", "ibm", "ism"},
                new[] {"cet", "cat", "can", "ian", "inn", "ins", "its", "ito", "ibo", "ibm", "ism"},
                new[] {"cet", "get", "gee", "gte", "ate", "ats", "its", "ito", "ibo", "ibm", "ism"}
            };
            var actual = FindLadders("cet", "ism",
                new List<string> { "kid", "tag", "pup", "ail", "tun", "woo", "erg", "luz", "brr", "gay", "sip", "kay", "per", "val", "mes", "ohs", "now", "boa", "cet", "pal", "bar", "die", "war", "hay", "eco", "pub", "lob", "rue", "fry", "lit", "rex", "jan", "cot", "bid", "ali", "pay", "col", "gum", "ger", "row", "won", "dan", "rum", "fad", "tut", "sag", "yip", "sui", "ark", "has", "zip", "fez", "own", "ump", "dis", "ads", "max", "jaw", "out", "btu", "ana", "gap", "cry", "led", "abe", "box", "ore", "pig", "fie", "toy", "fat", "cal", "lie", "noh", "sew", "ono", "tam", "flu", "mgm", "ply", "awe", "pry", "tit", "tie", "yet", "too", "tax", "jim", "san", "pan", "map", "ski", "ova", "wed", "non", "wac", "nut", "why", "bye", "lye", "oct", "old", "fin", "feb", "chi", "sap", "owl", "log", "tod", "dot", "bow", "fob", "for", "joe", "ivy", "fan", "age", "fax", "hip", "jib", "mel", "hus", "sob", "ifs", "tab", "ara", "dab", "jag", "jar", "arm", "lot", "tom", "sax", "tex", "yum", "pei", "wen", "wry", "ire", "irk", "far", "mew", "wit", "doe", "gas", "rte", "ian", "pot", "ask", "wag", "hag", "amy", "nag", "ron", "soy", "gin", "don", "tug", "fay", "vic", "boo", "nam", "ave", "buy", "sop", "but", "orb", "fen", "paw", "his", "sub", "bob", "yea", "oft", "inn", "rod", "yam", "pew", "web", "hod", "hun", "gyp", "wei", "wis", "rob", "gad", "pie", "mon", "dog", "bib", "rub", "ere", "dig", "era", "cat", "fox", "bee", "mod", "day", "apr", "vie", "nev", "jam", "pam", "new", "aye", "ani", "and", "ibm", "yap", "can", "pyx", "tar", "kin", "fog", "hum", "pip", "cup", "dye", "lyx", "jog", "nun", "par", "wan", "fey", "bus", "oak", "bad", "ats", "set", "qom", "vat", "eat", "pus", "rev", "axe", "ion", "six", "ila", "lao", "mom", "mas", "pro", "few", "opt", "poe", "art", "ash", "oar", "cap", "lop", "may", "shy", "rid", "bat", "sum", "rim", "fee", "bmw", "sky", "maj", "hue", "thy", "ava", "rap", "den", "fla", "auk", "cox", "ibo", "hey", "saw", "vim", "sec", "ltd", "you", "its", "tat", "dew", "eva", "tog", "ram", "let", "see", "zit", "maw", "nix", "ate", "gig", "rep", "owe", "ind", "hog", "eve", "sam", "zoo", "any", "dow", "cod", "bed", "vet", "ham", "sis", "hex", "via", "fir", "nod", "mao", "aug", "mum", "hoe", "bah", "hal", "keg", "hew", "zed", "tow", "gog", "ass", "dem", "who", "bet", "gos", "son", "ear", "spy", "kit", "boy", "due", "sen", "oaf", "mix", "hep", "fur", "ada", "bin", "nil", "mia", "ewe", "hit", "fix", "sad", "rib", "eye", "hop", "haw", "wax", "mid", "tad", "ken", "wad", "rye", "pap", "bog", "gut", "ito", "woe", "our", "ado", "sin", "mad", "ray", "hon", "roy", "dip", "hen", "iva", "lug", "asp", "hui", "yak", "bay", "poi", "yep", "bun", "try", "lad", "elm", "nat", "wyo", "gym", "dug", "toe", "dee", "wig", "sly", "rip", "geo", "cog", "pas", "zen", "odd", "nan", "lay", "pod", "fit", "hem", "joy", "bum", "rio", "yon", "dec", "leg", "put", "sue", "dim", "pet", "yaw", "nub", "bit", "bur", "sid", "sun", "oil", "red", "doc", "moe", "caw", "eel", "dix", "cub", "end", "gem", "off", "yew", "hug", "pop", "tub", "sgt", "lid", "pun", "ton", "sol", "din", "yup", "jab", "pea", "bug", "gag", "mil", "jig", "hub", "low", "did", "tin", "get", "gte", "sox", "lei", "mig", "fig", "lon", "use", "ban", "flo", "nov", "jut", "bag", "mir", "sty", "lap", "two", "ins", "con", "ant", "net", "tux", "ode", "stu", "mug", "cad", "nap", "gun", "fop", "tot", "sow", "sal", "sic", "ted", "wot", "del", "imp", "cob", "way", "ann", "tan", "mci", "job", "wet", "ism", "err", "him", "all", "pad", "hah", "hie", "aim", "ike", "jed", "ego", "mac", "baa", "min", "com", "ill", "was", "cab", "ago", "ina", "big", "ilk", "gal", "tap", "duh", "ola", "ran", "lab", "top", "gob", "hot", "ora", "tia", "kip", "han", "met", "hut", "she", "sac", "fed", "goo", "tee", "ell", "not", "act", "gil", "rut", "ala", "ape", "rig", "cid", "god", "duo", "lin", "aid", "gel", "awl", "lag", "elf", "liz", "ref", "aha", "fib", "oho", "tho", "her", "nor", "ace", "adz", "fun", "ned", "coo", "win", "tao", "coy", "van", "man", "pit", "guy", "foe", "hid", "mai", "sup", "jay", "hob", "mow", "jot", "are", "pol", "arc", "lax", "aft", "alb", "len", "air", "pug", "pox", "vow", "got", "meg", "zoe", "amp", "ale", "bud", "gee", "pin", "dun", "pat", "ten", "mob" });

            Assert.AreEqual(Print(expected), Print(actual));
        }

        [TestMethod]
        public void WordLadder2_Solutions_none()
        {
            var res = FindLadders("hit", "cog", new List<string> {"hot", "dot", "dog", "lot", "log"});
            Assert.AreEqual(0, res.Count);
        }

        public string Print(IEnumerable<IEnumerable<string>> arrays)
        {
            var strArrays = arrays.Select(arr => $"[{string.Join(", ", arr.Select(s => $"\"{s}\""))}]");
            return $"[{string.Join(", ", strArrays)}]";
        }
        #endregion

        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var result = new List<IList<string>>();
            var graph = new List<List<int>>(wordList.Count + 1);

            int beginWordPos = -1;
            int endWordPos = -1;
            for (var i = 0; i < wordList.Count; i++)
            {
                graph.Add(new List<int>());
                
                if (wordList[i] == beginWord)
                    beginWordPos = i;

                if (wordList[i] == endWord)
                    endWordPos = i;
            }

            if (endWordPos == -1)
                return result;

            if (beginWordPos == -1)
            {
                beginWordPos = wordList.Count;
                wordList.Add(beginWord);
                graph.Add(new List<int>());
            }

            for (int i = 0; i < wordList.Count; i++)
            for (int j = i + 1; j < wordList.Count; j++)
            {
                if (!isOneDiff(wordList[i], wordList[j])) continue;
                graph[i].Add(j);
                graph[j].Add(i);
            }

            int[] dist = Bfs(beginWordPos, endWordPos, wordList, graph);
            
            Dfs(beginWordPos, endWordPos, wordList, graph, dist, new List<int>(), result);

            return result;
        }

        private static int[] Bfs(int start, int end, IList<string> wordList, List<List<int>> graph)
        {
            var q = new Queue<int>();
            var dist = new int[wordList.Count];
            
            for (int i = 0; i < wordList.Count; i++)
                dist[i] = -1;

            q.Enqueue(start);
            dist[start] = 0;
            int maxDistance = int.MaxValue;

            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                
                for (int i = 0; i < graph[curr].Count; i++)
                {
                    var next = graph[curr][i];
                    if (dist[next] != -1) continue;

                    dist[next] = dist[curr] + 1;

                    if (next == end)
                        maxDistance = maxDistance == int.MaxValue ? dist[next] : maxDistance;
                    else if (dist[next] <= maxDistance)
                        q.Enqueue(next);
                }
            }

            return dist;
        }


        private static void Dfs(int curr, int end, IList<string> wordList, List<List<int>> graph, int[] dist, List<int> path, List<IList<string>> result)
        {
            path.Add(curr);

            if (curr == end)
                result.Add(GetWordPath(wordList, path));
            else
                for (int i = 0; i < graph[curr].Count; i++)
                {
                    var next = graph[curr][i];
                    if (dist[next] > dist[curr])
                        Dfs(next, end, wordList, graph, dist, path, result);
                }

            path.RemoveAt(path.Count - 1);
        }

        private static List<string> GetWordPath(IList<string> wordList, List<int> path)
        {
            var wordPath = new List<string>();
            foreach (var i in path)
                wordPath.Add(wordList[i]);
            
            return wordPath;
        }

        private bool isOneDiff(in string w1, in string w2)
        {
            //assumed words with same lenght
            var diff = 0;
            for (int i = 0; i < w1.Length; i++)
            {
                if (w1[i] != w2[i])
                    diff++;

                if (diff > 1)
                    break;
            }

            return diff == 1;
        }
    }
}
