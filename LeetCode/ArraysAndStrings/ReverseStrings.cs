using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.ArraysAndStrings
{
    [TestClass]
    public class ReverseWordsSolution
    {
        [TestMethod]
        public void ReverseWords_Solutions()
        {
            var str = new[] {'t', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e'};
            ReverseWords(str);
            AssertEnumerable.AreEqual(new[] {'b', 'l', 'u', 'e', ' ', 'i', 's', ' ', 's', 'k', 'y', ' ', 't', 'h', 'e'},
                str);
        }


        public void ReverseWords(char[] str)
        {
            int start = 0;
            for (int end = 0; end < str.Length; end++)
            {
                while (end < str.Length && str[end] != ' ')
                    end++;
                Reverse(str, start, end - 1);
                start = end + 1;
            }

            Reverse(str, 0, str.Length - 1);
        }

        static void Reverse(char[] str, int start, int end)
        {
            while (start < end)
            {
                char temp = str[start];
                str[start] = str[end];
                str[end] = temp;
                start++;
                end--;
            }

        }
    }
}
