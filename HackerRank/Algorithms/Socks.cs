using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    /// <summary>
    ///  Complete the sockMerchant function below.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="ar"></param>
    /// <returns></returns>
    static int sockMerchant(int n, int[] ar) {
        HashSet<int> single = new HashSet<int>();

        int pairs = 0;

        for (int i = 0; i < ar.Length; i++)
        {
            if (!single.Add(ar[i]))
            {
                single.Remove(ar[i]);
                pairs++;
            }
        }
        return pairs;
    }

    static void sockMerchant_Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] ar = Array.ConvertAll(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), arTemp => Convert.ToInt32(arTemp));

        int result = sockMerchant(n, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
