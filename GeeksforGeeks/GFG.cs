using System;
using System.Collections.Generic;
using System.Linq;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class GFG
{
    [TestMethod]
    public void GFG_Solutions()
    {
        AssertEnumerable.AreEqual(new List<int> {787, 23}, kLargest(new List<int> {12, 5, 787, 1, 23}, 2));
        AssertEnumerable.AreEqual(new List<int> {50, 30, 23}, kLargest(new List<int> {1, 23, 12, 9, 30, 2, 50}, 3));
    }


    public static void Main()
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            var kStr = Console.ReadLine().Trim();
            var cStr = Console.ReadLine().Trim();

            try
            {
                int k = Convert.ToInt32(kStr.Split(' ').Last());
                var c = cStr.Split(' ').Select(s => Convert.ToInt32(s)).ToList();

                Console.WriteLine(string.Join(" ", kLargest(c, k)));
            }
            catch (Exception e)
            {
                throw new Exception($"k: '{kStr}', c: '{cStr}'", e);
            }
        }
    }

    private static List<int> kLargest(List<int> c, int k)
    {
        if (k > c.Count)
            k = c.Count;

        c.Sort((i, i1) => i1.CompareTo(i));

        return c.Take(k).ToList();
    }
}