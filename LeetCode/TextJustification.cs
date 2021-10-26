using System.Collections.Generic;
using System.Text;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class TextJustificationTest
    {
        [DataTestMethod]
        [DataRow(new[] { "This", "is", "an", "example", "of", "text", "justification." }, 16,
                 new[] { "This    is    an", "example  of text", "justification.  " })]
        [DataRow(new[] { "What", "must", "be", "acknowledgment", "shall", "be" }, 16,
                 new[] { "What   must   be", "acknowledgment  ", "shall be        " })]
        [DataRow(new[] { "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a", "computer.", "Art", "is", "everything", "else", "we", "do" }, 20,
                 new[] { "Science  is  what we", "understand      well", "enough to explain to", "a  computer.  Art is", "everything  else  we", "do                  " })]
        public void TextJustification_Solutions(string[] words, int maxWidth, string[] expected)
        {
            var solution = new TextJustificationClass();
            var result = solution.TextJustification(words, maxWidth);
            AssertEnumerable.AreEqual(expected, result);
        }
    }

    // https://leetcode.com/problems/text-justification/
    public class TextJustificationClass
    {
        public IList<string> TextJustification(string[] words, int maxWidth)
        {
            List<string> lines = new();
            List<string> lineWords = new();
            int currLength = 0;

            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (word.Length + lineWords.Count + currLength <= maxWidth)
                {
                    lineWords.Add(word);
                    currLength += word.Length;
                }
                else
                {
                    int wordBreaks = lineWords.Count == 1 ? 1 : lineWords.Count - 1;
                    int totalSpaces = maxWidth - currLength;
                    int eachSpace = totalSpaces / wordBreaks;
                    int extraSpaces = totalSpaces % wordBreaks;

                    lines.Add(ConcatWords(lineWords, eachSpace, extraSpaces, maxWidth));

                    lineWords = new();
                    currLength = 0;
                    i--;
                }
            }

            if (lineWords.Count > 0)
                lines.Add(ConcatWords(lineWords, 1, 0, maxWidth));

            return lines;
        }

        private string ConcatWords(List<string> words, int eachSpace, int extraSpaces, int maxWidth)
        {
            StringBuilder s = new();
            s.Append(words[0]);

            string extraSpace = new string(' ', eachSpace + 1);
            string space = new string(' ', eachSpace);
            for (int i = 1; i < words.Count; i++)
            {
                s.Append(extraSpaces-- > 0 ? extraSpace : space);
                s.Append(words[i]);
            }

            if (s.Length < maxWidth)
                s.Append(new string(' ', maxWidth - s.Length));

            return s.ToString();
        }
    }
}