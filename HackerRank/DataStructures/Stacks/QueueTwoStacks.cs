using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank.DataStructures.Stacks
{
    [TestClass]
    public class QueueTwoStacks
    {
        [TestMethod]
        public void QueueTwoStacks_Solutions()
        {
            StacksQueue<int> queue = new StacksQueue<int>();

            queue.Enqueue(1);
            Assert.AreEqual(1, queue.Peek());
            Assert.AreEqual(1, queue.Dequeue());

            queue.Enqueue(2);
            Assert.AreEqual(2, queue.Peek());
            queue.Enqueue(3);
            Assert.AreEqual(2, queue.Peek());

            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());

            try
            {
                queue.Peek();
                Assert.Fail("Should throw InvalidOperationException");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Empty queue", e.Message);
            }

            try
            {
                queue.Dequeue();
                Assert.Fail("Should throw InvalidOperationException");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Empty queue", e.Message);
            }
        }

        public class StacksQueue<T>
        {
            private readonly Stack<T> remove = new Stack<T>();
            private readonly Stack<T> add = new Stack<T>();

            public void Enqueue(T item)
            {
                add.Push(item);
            }

            public T Dequeue()
            {
                MoveAndCheck();
                return remove.Pop();

            }

            public T Peek()
            {
                MoveAndCheck();
                return remove.Peek();
            }

            private void MoveAndCheck()
            {
                if (remove.Count > 0)
                    return;

                while (add.Count > 0)
                    remove.Push(add.Pop());

                if (remove.Count == 0)
                    throw new InvalidOperationException("Empty queue");
            }
        }

        static void StacksQueue_Main(String[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
            TextWriter textWriter = new StreamWriter(System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            StacksQueue<int> queue = new StacksQueue<int>();

            int g = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < g; i++)
            {
                string[] split = Console.ReadLine().Split(' ');

                switch (split[0])
                {
                    case "1": //Enqueue
                        queue.Enqueue(int.Parse(split[1]));
                        break;

                    case "2": //Dequeue:
                        queue.Dequeue();
                        break;

                    case "3": //Print:
                        textWriter.WriteLine(queue.Peek());
                        break;
                }
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
