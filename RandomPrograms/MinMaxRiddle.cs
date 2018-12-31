using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using temp;

namespace RandomPrograms
{
    class MinMaxRiddle
    {
        public static long[] riddle1(long[] arr)
        {
            List<long> finalList = new List<long>();
            for (int i = 1; i <= arr.Length; i++)
            {
                List<long> max = new List<long>();
                for (int j = 0; j < arr.Length; j++)
                {
                    List<long> min = new List<long>();
                    for (int k = j; k < j + i && k < arr.Length; k++)
                    {
                        min.Add(arr[k]);
                    }

                    if (min.Count == i)
                    {
                        min.Sort();
                        max.Add(min[0]);
                    }
                }

                max.Sort();
                finalList.Add(max[max.Count - 1]);
            }

            return finalList.ToArray();
        }

        public static long[] riddle2(long[] arr)
        {
            MinIndexedPriorityQueue<long>[] aggregatedList = new MinIndexedPriorityQueue<long>[arr.Length];
            List<long> max = new List<long>();
            var maxVal = arr.Max();
            for (int i = 0; i < arr.Length; i++)
            {
                aggregatedList[i] = new MinIndexedPriorityQueue<long>(arr.Length);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                MaxPriorityQueue<long> min = new MaxPriorityQueue<long>(arr.Length);

                for (int j = 0; j < arr.Length && j + i < arr.Length; j++)
                {
                    aggregatedList[j].Insert(arr[j + i]);
                    min.Insert(aggregatedList[j].Min());
                }

                max.Add(min.Max());
            }

            return max.ToArray();
        }

        public static int[] riddle(long[] a)
        {
            int i;
            int n = a.Length;
            Stack<int> s = new Stack<int>();
            int[] left = new int[n];
            int[] right = new int[n];
            int[] ans = new int[n + 1];
            int len = 0;

            for (i = 0; i < n; ++i)
            {
                left[i] = -1;
                right[i] = n;
            }

            for (i = 0; i < n; ++i)
            {
                while (s.Count != 0 && a[s.Peek()] >= a[i])
                {
                    s.Pop();
                }
                if (s.Count != 0)
                {
                    left[i] = s.Peek();
                }
                s.Push(i);
            }

            while (s.Count != 0)
            {
                s.Pop();
            }

            for (i = n - 1; i >= 0; --i)
            {
                while (s.Count != 0 && a[s.Peek()] >= a[i])
                {
                    s.Pop();
                }
                if (s.Count != 0)
                {
                    right[i] = s.Peek();
                }

                s.Push(i);
            }

            //memset(ans, 0, sizeof ans);

            for (i = 0; i < n; ++i)
            {
                len = right[i] - left[i] - 1;
                ans[len] = (int)Math.Max(ans[len], a[i]);
            }

            for (i = n - 1; i >= 1; --i)
            {
                ans[i] = (int)Math.Max(ans[i], ans[i + 1]);
            }


            return ans.Where(k => k != 0).ToArray<int>();
        }
    }
}
