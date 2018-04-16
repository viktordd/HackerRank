using System;
using System.Linq;

namespace HackerRank
{
    public class ArithmeticExpressions
    {
        public static void Solve(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */

            int count = Convert.ToInt32(Console.ReadLine());
            var list = Console.ReadLine()?.Split(' ').Select(i => Convert.ToInt64(i)).ToArray();

            Console.WriteLine(GetExpression(list));
        }

        public static string GetExpression(long[] list)
        {
            return list[0] + Check(list, 1, list[0]);
        }

        static string Check(Int64[] list, int index, long current)
        {
            current %= 101;

            if (index == list.Length)
                return current == 0 ? "" : null;

            if (current == 0)
                return "*" + string.Join("*", list.Skip(index));

            var result = Check(list, index + 1, current + list[index]);
            if (result != null)
                return "+" + list[index] + result;

            result = Check(list, index + 1, current * list[index]);
            if (result != null)
                return "*" + list[index] + result;

            result = Check(list, index + 1, current - list[index]);
            if (result != null)
                return "-" + list[index] + result;

            return null;
        }
    }
}
