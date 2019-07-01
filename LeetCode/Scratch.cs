using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    //[TestClass]
    public class Scratch
    {
        //[TestMethod]
        public void Scratch_Solutions()
        {

        }

    }

    // IMPORT LIBRARY PACKAGES NEEDED BY YOUR PROGRAM
    // SOME CLASSES WITHIN A PACKAGE MAY BE RESTRICTED
    // DEFINE ANY CLASS AND METHOD NEEDED
    // CLASS BEGINS, THIS CLASS IS REQUIRED
    public class GCD
    {
        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public int generalizedGCD(int num, int[] arr)
        {
            // WRITE YOUR CODE HERE
            int min = arr.Min();

            for (int divisor = min; divisor > 1; divisor--)
            {
                bool isDivisor = true;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % divisor != 0)
                    {
                        isDivisor = false;
                        break;
                    }
                }

                if (isDivisor == true)
                    return divisor;
            }

            return 1;
        }
        // METHOD SIGNATURE ENDS
    }

    // IMPORT LIBRARY PACKAGES NEEDED BY YOUR PROGRAM
    // SOME CLASSES WITHIN A PACKAGE MAY BE RESTRICTED
    // DEFINE ANY CLASS AND METHOD NEEDED
    // CLASS BEGINS, THIS CLASS IS REQUIRED
    public class Solution
    {
        //METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public int[] cellCompete(int[] states, int days)
        {
            // INSERT YOUR CODE HERE
            int[] newStates = new int[states.Length];

            for (int day = 0; day < days; day++)
            {
                newStates[0] = 0 == states[1] ? 0 : 1;
                newStates[states.Length - 1] = states[states.Length - 2] == 0 ? 0 : 1;
                for (int i = 1; i < states.Length - 1; i++)
                {
                    newStates[i] = states[i - 1] == states[i + 1] ? 0 : 1;
                }

                var t = states;
                states = newStates;
                newStates = t;
            }

            return states;
        }
        // METHOD SIGNATURE ENDS
    }
}
