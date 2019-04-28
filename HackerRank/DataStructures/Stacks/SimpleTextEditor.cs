using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank.DataStructures.Stacks
{
    [TestClass]
    public class SimpleTextEditor
    {
        [TestMethod]
        public void SimpleTextEditor_Solutions()
        {
            TextEditor editor = new TextEditor();
            Assert.AreEqual(null, editor.PerformOperation("1 abc"));
            Assert.AreEqual("c",  editor.PerformOperation("3 3"));
            Assert.AreEqual(null, editor.PerformOperation("2 3"));
            Assert.AreEqual(null, editor.PerformOperation("1 xy"));
            Assert.AreEqual("y",  editor.PerformOperation("3 2"));
            Assert.AreEqual(null, editor.PerformOperation("4"));
            Assert.AreEqual(null, editor.PerformOperation("4"));
            Assert.AreEqual("a",  editor.PerformOperation("3 1"));
        }

        public class TextEditor
        {
            private readonly StringBuilder str = new StringBuilder();
            private readonly Stack<Operation> history = new Stack<Operation>();

            public string PerformOperation(string op)
            {
                return PerformOperation(new Operation(op));
            }

            public string PerformOperation(Operation op)
            {
                return PerformOperation(op, true);
            }

            private string PerformOperation(Operation op, bool addToHistory)
            {
                switch (op.Op)
                {
                    case Op.Append:
                        Append(op.ArgStr, addToHistory);
                        break;

                    case Op.Delete:
                        Delete(op.ArgInt, addToHistory);
                        break;

                    case Op.Print:
                        return Print(op.ArgInt - 1).ToString();

                    case Op.Undo:
                        Undo();
                        break;

                }
                return null;
            }

            private void Append(string value, bool addToHistory)
            {
                str.Append(value);
                if (addToHistory)
                    history.Push(new Operation { Op = Op.Delete, ArgInt = value.Length });
            }

            private void Delete(int length, bool addToHistory)
            {
                var startIndex = str.Length - length;
                if (addToHistory)
                {
                    StringBuilder s = new StringBuilder();
                    for (int i = startIndex; i < str.Length; i++)
                        s.Append(str[i]);
                    history.Push(new Operation { Op = Op.Append, ArgStr = s.ToString() });
                }
                str.Remove(startIndex, length);
            }

            private char Print(int at)
            {
                return str[at];
            }
            
            private void Undo()
            {
                if (history.Count > 0)
                {
                    var op = history.Pop();
                    switch (op.Op)
                    {
                        case Op.Append:
                            Append(op.ArgStr, false);
                            break;

                        case Op.Delete:
                            Delete(op.ArgInt, false);
                            break;

                    }
                }
            }


            public enum Op
            {
                Append = 1,
                Delete = 2,
                Print = 3,
                Undo = 4
            }

            public struct Operation
            {
                public Op Op { get; set; }
                public string ArgStr { get; set; }
                public int ArgInt { get; set; }

                public Operation(string s)
                {
                    string[] split = s.Split(' ');

                    Op = (Op)Convert.ToInt32(split[0]);

                    ArgStr = null;
                    ArgInt = 0;

                    switch (Op)
                    {
                        case Op.Append:
                            ArgStr = split[1];
                            break;

                        case Op.Delete:
                        case Op.Print:
                            ArgInt = Convert.ToInt32(split[1]);
                            break;
                    }
                }
            }
        }


        
        static void Main(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            TextWriter textWriter = new StreamWriter(System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            TextEditor editor = new TextEditor();

            int g = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < g; i++)
            {
                string result = editor.PerformOperation(Console.ReadLine());

                if (result != null)
                    textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
