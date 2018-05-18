using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest.DataStructures.Stacks
{
    [TestClass]
    public class BalancedBrackets
    {
        [TestMethod]
        public void BalancedBrackets_Solutions()
        {
            Assert.AreEqual("YES", isBalanced("{[()]}"));
            Assert.AreEqual("NO", isBalanced("{[(])}"));
            Assert.AreEqual("YES", isBalanced("{{[[(())]]}}"));
        }

        // Complete the isBalanced function below.
        public static string isBalanced(string s)
        {
            const string no = "NO";
            const string yes = "YES";

            var stack = new Stack<char>();

            foreach (var c in s)
            {
                //(, ), {, }, [, or ].
                switch (c)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(c);
                        break;

                    case ')':
                    case '}':
                    case ']':
                        if (stack.Count == 0)
                            return no;
                        var open = stack.Pop();
                        if (c != getClosing(open))
                            return no;
                        break;

                    default:
                        return no;
                }
            }

            return stack.Count == 0 ? yes : no;
        }

        private static char getClosing(char open)
        {
            switch (open)
            {

                case '(': return ')';
                case '{': return '}';
                case '[': return ']';
                default: return '\0';
            }
        }
    }
}
