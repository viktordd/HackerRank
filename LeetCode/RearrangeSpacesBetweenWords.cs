using System;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode
{
    [TestClass]
    public class RearrangeSpacesBetweenWordsTest
    {
        [DataTestMethod]
        [DataRow("  this   is  a sentence ", "this   is   a   sentence")]
        [DataRow(" practice   makes   perfect", "practice   makes   perfect ")]
        [DataRow("hello   world", "hello   world")]
        [DataRow("  walks  udp package   into  bar a", "walks  udp  package  into  bar  a ")]
        [DataRow("a  ", "a  ")]
        [DataRow("a", "a")]
        public void RearrangeSpacesBetweenWords_Solutions(string text, string expected)
        {
            var solution = new RearrangeSpacesBetweenWordsClass();
            var result = solution.ReorderSpaces(text);
            Assert.AreEqual(expected, result);
        }
    }

    // https://leetcode.com/problems/rearrange-spaces-between-words/
    public class RearrangeSpacesBetweenWordsClass
    {
        public string ReorderSpaces(string text)
        {
            string[] words = text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            int spaces = text.Length - words.Sum(word => word.Length);
            int breaks = words.Length == 1 ? 1 : words.Length - 1;
            var space = new string(' ', spaces / breaks);
            var leftOver = new string(' ', spaces % breaks);

            StringBuilder sb = new(words[0]);

            for (int i = 1; i < words.Length; i++)
            {
                sb.Append(space);
                sb.Append(words[i]);
            }

            sb.Append(words.Length == 1 ? space : leftOver);

            return sb.ToString();
        }
    }
}