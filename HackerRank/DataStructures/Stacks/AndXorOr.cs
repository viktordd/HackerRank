using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest.DataStructures.Stacks
{
    [TestClass]
    public class AndXorOr
    {
        [TestMethod]
        public void AndXorOr_Solutions()
        {
            Assert.AreEqual(15, andXorOr(new[] {9, 6, 3, 5, 2}));
            Assert.AreEqual(11, andXorOr(new[] {9, 8, 3, 5, 7}));
            Assert.AreEqual(114613468,
                andXorOr(new[]
                {
                    76969694, 71698884, 32888447, 31877010, 65564584, 87864180, 7850891, 1505323, 17879621, 15722446
                }));
            Assert.AreEqual(112066588,
                andXorOr(new[]
                {
                    30301275, 19973434, 63004643, 54007648, 93722492, 91677384, 58694045, 41546981, 15552151, 5811338
                }));
        }

        public static int andXorOr(int[] a)
        {
            Stack<int> s = new Stack<int>();
            int max = 0;

            for (int i = 0; i < a.Length; i++)
            {
                while (s.Any())
                {
                    int c = s.Peek() ^ a[i];

                    if (c > max)
                        max = c;

                    if (a[i] < s.Peek())
                        s.Pop();
                    else
                        break;
                }

                s.Push(a[i]);
            }

            if (s.Count == 2)
            {
                max = Math.Max(max, s.Pop() ^ s.Pop());
            }

            return max;
        }
    }
}
