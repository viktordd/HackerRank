namespace HackerRank.Sorting.FraudulentActivityNotifications
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Solution
    {
        // Complete the activityNotifications function below.
        public static int activityNotifications(int[] expenditure, int d)
        {
            var ct = new CountSort(expenditure.Take(d));

            var notifications = 0;
            for (int i = d; i < expenditure.Length; i++)
            {
                var median = ct.GetMedian();

                if (expenditure[i] >= 2 * median)
                    notifications++;

                ct.Update(expenditure[i - d], expenditure[i]);
            }
            return notifications;
        }

        class CountSort
        {
            private readonly List<int> ct;
            private int sortedCount;
            private int medCountSum;
            private int medPos;

            public CountSort(IEnumerable<int> collection)
            {
                ct = new List<int>();
                foreach (var val in collection)
                    Add(val);

                medCountSum = 0;
                medPos = -1;
            }

            public void Add(int add)
            {
                if (ct.Count <= add)
                {
                    ct.AddRange(Enumerable.Repeat(0, add + 1 - ct.Count));
                }
                ct[add]++;
                sortedCount++;

                if (add <= medPos)
                    medCountSum++;
            }

            public void Remove(int remove)
            {
                if (ct[remove] == 0)
                    throw new ArgumentOutOfRangeException(nameof(remove));

                ct[remove]--;
                sortedCount--;

                if (remove <= medPos)
                    medCountSum--;
            }

            public void Update(int remove, int add)
            {
                Remove(remove);

                Add(add);
            }
            //public double GetMedian()
            //{
            //    var _medCountSum = medCountSum;
            //    var _medPos = medPos;

            //    var old = GetMedianOld();
            //    var @new = GetMedianNew();

            //    if (old != @new)
            //    {
            //        medCountSum = _medCountSum;
            //        medPos = _medPos;
            //        @new = GetMedianNew();
            //    }

            //    return @new;
            //}

            private double GetMedianOld()
            {
                int sum = 0;
                for (int i = 0; i < ct.Count; i++)
                {
                    sum += ct[i];
                    if (2 * sum < sortedCount)
                        continue;
                    else
                        return GetMedian(i, sum);
                }

                return -1.0;
            }

            public double GetMedian()
            {
                if (2 * medCountSum > sortedCount)
                {
                    for (; medPos >= 0; medPos--)
                    {
                        medCountSum -= ct[medPos];
                        if (2 * medCountSum > sortedCount)
                            continue;
                        else if (2 * medCountSum == sortedCount)
                            return GetMedianEven(--medPos);
                        else
                            break;
                    }
                }
                else if (2 * medCountSum == sortedCount)
                    return GetMedianEven(medPos);
                else
                    medPos++;

                for (; medPos < ct.Count; medPos++)
                {
                    medCountSum += ct[medPos];
                    if (2 * medCountSum < sortedCount)
                        continue;
                    else
                        return GetMedian(medPos, medCountSum);
                }

                return -1.0;
            }

            private double GetMedian(int i, int sum)
            {
                if (2 * sum == sortedCount)
                    return GetMedianEven(i);
                else
                    return i * 1.0;
            }
            private double GetMedianEven(int i)
            {
                for (int j = i + 1; j < ct.Count; j++)
                {
                    if (ct[j] == 0)
                        continue;

                    return (j + i) / 2.0;
                }
                return -1.0;
            }
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] expenditure = Array.ConvertAll(Console.ReadLine().Split(' '), expenditureTemp => Convert.ToInt32(expenditureTemp));

            int result = activityNotifications(expenditure, d);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }

}