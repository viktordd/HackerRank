using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HackerRank.DataStructures.Stacks
{
    [TestClass]
    public class PoisonousPlants
    {
        [TestMethod]
        public void PoisonousPlants_Solutions()
        {
            Assert.AreEqual(0, poisonousPlants(new int[0]));
            Assert.AreEqual(0, poisonousPlants(new[] {1}));
            Assert.AreEqual(0, poisonousPlants(new[] {1, 1, 1, 1, 1}));
            Assert.AreEqual(0, poisonousPlants(new[] {5, 4, 3, 2, 1}));
            Assert.AreEqual(2, poisonousPlants(new[] {6, 5, 8, 4, 7, 10, 9}));
        }

        // Complete the poisonousPlants function below.
        public static int poisonousPlants(int[] p)
        {
            if (p.Length == 0)
                return 0;

            var left = int.MinValue;
            var head = new List<Stack>();
            for (var i = 0; i < p.Length; i++)
            {
                var plant = p[i];
                if (plant > left)
                    head.Add(new Stack { Pos = i, Count = 0 });
                left = plant;
                head[head.Count - 1].Count++;
            }

            var day = 0;
            bool deadPlant;

            do
            {
                deadPlant = false;
                Stack prev = head[0];
                for (int i = 1; i < head.Count; i++)
                {
                    var curr = head[i];
                    if (curr.Count == 0)
                        continue;

                    if (curr.Peek(p) > prev.PeekLast(p))
                    {
                        deadPlant = true;
                        curr.Pop();
                    }
                    prev = curr;
                }

                if (deadPlant)
                    day++;
            } while (deadPlant);

            return day;
        }

        class Stack
        {
            public int Pos { get; set; }
            public int Count { get; set; }

            public int Peek(int[] p) => p[Pos];

            public int PeekLast(int[] p) => p[Pos + Count - 1];

            public void Pop()
            {
                if (Count <= 0) return;
                Pos++;
                Count--;
            }
        }
    }
}
