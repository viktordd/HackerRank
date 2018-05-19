using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRankTest.DataStructures.Stacks
{
    [TestClass]
    public class SimpleTextEditor
    {
        [TestMethod]
        public void SimpleTextEditor_Solutions()
        {
            StringBuilder s = new StringBuilder();
            Stack<Operation> h = new Stack<Operation>();
            Assert.AreEqual(null, performOperation(s, h, new Operation("1 abc")));
            Assert.AreEqual("c", performOperation(s, h, new Operation("3 3")));
            Assert.AreEqual(null, performOperation(s, h, new Operation("2 3")));
            Assert.AreEqual(null, performOperation(s, h, new Operation("1 xy")));
            Assert.AreEqual("y", performOperation(s, h, new Operation("3 2")));
            Assert.AreEqual(null, performOperation(s, h, new Operation("4")));
            Assert.AreEqual(null, performOperation(s, h, new Operation("4")));
            Assert.AreEqual("a", performOperation(s, h, new Operation("3 1")));
        }

        static string performOperation(StringBuilder s, Stack<Operation> h, Operation op)
        {
            switch (op.Op)
            {
                case Op.Append:
                    s.Append(op.Arg);
                    h?.Push(new Operation {Op = Op.Delete, Arg = op.Arg.Length.ToString()});
                    break;

                case Op.Delete:
                    var len = Convert.ToInt32(op.Arg);
                    var startIndex = s.Length - len;
                    h?.Push(new Operation { Op = Op.Append, Arg = s.ToString().Substring(startIndex) });
                    s.Remove(startIndex, len);
                    break;

                case Op.Print:
                    var at = Convert.ToInt32(op.Arg) - 1;
                    return s[at].ToString();

                case Op.Undo:
                    if (h.Count > 0)
                        performOperation(s, null, h.Pop());
                    break;

            }
            return null;
        }

        enum Op
        {
            Append = 1,
            Delete = 2,
            Print = 3,
            Undo = 4
        }

        struct Operation
        {
            public Op Op { get; set; }
            public string Arg { get; set; }

            public Operation (string s)
            {
                string[] split = s.Split(' ');

                Op = (Op)Convert.ToInt32(split[0]);

                Arg = split.Length > 1 ? split[1] : null;
            }
        }
        
        static void Main(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            TextWriter textWriter = new StreamWriter(System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            
            StringBuilder s = new StringBuilder();
            Stack<Operation> h = new Stack<Operation>();

            int g = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < g; i++)
            {
                string result = performOperation(s, h, new Operation(Console.ReadLine()));

                if (result != null)
                    textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
