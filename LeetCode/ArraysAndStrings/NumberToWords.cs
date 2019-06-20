using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.ArraysAndStrings
{
    [TestClass]
    public class NumberToWordsSolutions
    {
        [TestMethod]
        public void NumberToWords_Solutions()
        {
            Assert.AreEqual("One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One", NumberToWords(1_234_567_891));
            Assert.AreEqual("One Billion Two Hundred Ten Million Five Hundred Fifteen Thousand Ninety One", NumberToWords(1_210_515_091));
            Assert.AreEqual("Zero", NumberToWords(0));
            Assert.AreEqual("One Million", NumberToWords(1_000_000));
        }

        //1 234 567 891
        //"One Billion    Two Hundred Thirty Four Million     Five Hundred Sixty Seven Thousand     Eight Hundred Ninety One"
        private static readonly string[] Ones = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        private static readonly string[] Teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        private static readonly string[] Tens = { string.Empty, string.Empty, "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        private static readonly string[] Big = { "Hundred", "Thousand", "Million", "Billion" };

        public string NumberToWords(int num)
        {
            var res = new Stack<string>();

            if (num == 0)
                return Ones[0];

            int bigNum = 0;
            while (num > 0 && bigNum < Big.Length)
            {
                int curr = num % 1000;
                if (curr > 0)
                {
                    if (bigNum > 0)
                        res.Push(Big[bigNum]);
                    NumberToWords(res, curr);
                }
                num /= 1000;
                bigNum++;
            }

            return string.Join(" ", res);
        }

        public void NumberToWords(Stack<string> res, int num)
        {
            int ones = num % 10;
            int tens = num / 10 % 10;
            int hundreds = num / 100 % 10;

            if (tens == 1)
                res.Push(Teens[ones]);
            else
            {
                if (ones > 0)
                    res.Push(Ones[ones]);
                if (tens > 1)
                    res.Push(Tens[tens]);
            }

            if (hundreds > 0)
            {
                res.Push(Big[0]);
                res.Push(Ones[hundreds]);
            }
        }
    }
}
