using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp
{
    class PoisonousPlants
    {
        //Dictionary way of doing
        public static int poisonousPlants1(int[] p)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int n = p.Length;
            for (int i = 0; i < p.Length; i++)
            {
                dict.Add(i, p[i]);
            }

            bool found = true;
            int loop = 0;
            while (found)
            {
                found = false;

                Dictionary<int, int> dict1 = new Dictionary<int, int>();
                var prevKey = -1;
                foreach (var item in dict)
                {
                    if (!dict.ContainsKey(prevKey))
                    {
                        prevKey = item.Key;
                        continue;
                    }

                    if (item.Value > dict[prevKey])
                    {
                        found = true;
                        dict1.Add(item.Key, item.Value);
                    }

                    prevKey = item.Key;
                }

                foreach (var item in dict1)
                {
                    if (dict.ContainsKey(item.Key))
                        dict.Remove(item.Key);

                }

                loop++;
            }

            return loop - 1;
        }

        public static int poisonousPlants2(int[] p)
        {
            Stack<int> st = new Stack<int>();
            Stack<int> st1 = new Stack<int>();
            int n = p.Length;
            int loop = 0;
            bool found = true;

            for (int i = 0; i < n; i++)
            {
                st.Push(i);
            }

            while (found)
            {
                found = false;
                st1 = new Stack<int>();

                var pop = st.Pop();
                while (st.Count != 0)
                {
                    if (p[pop] <= p[st.Peek()])
                    {
                        st1.Push(pop);
                    }
                    else
                    {
                        found = true;
                    }

                    pop = st.Pop();
                }

                st1.Push(pop);

                while (st1.Count != 0)
                {
                    var pop1 = st1.Pop();
                    st.Push(pop1);
                }

                if (found)
                    loop++;
            }

            return loop;
        }

        public static int poisonousPlants(int[] p)
        {
            List<List<int>> stackList = new List<List<int>>();
            List<int> st = new List<int>();
            st.Add(p[0]);
            for (int i = 1; i < p.Length; i++)
            {
                if (p[i] <= p[i - 1])
                {
                    st.Add(p[i]);
                }
                else
                {
                    stackList.Add(st);

                    st = new List<int>();
                    st.Add(p[i]);
                }

                if (i == p.Length - 1)
                    stackList.Add(st);
            }

            int dayCount = 0;

            while (stackList.Count != 1)
            {
                for (int i = stackList.Count - 1; i > 0; i--)
                {
                    if (stackList[i].Count > 0)
                    {
                        stackList[i].RemoveAt(0);
                    }

                    if (stackList[i].Count == 0)
                    {
                        stackList.Remove(stackList[i]);
                    }
                }

                for (int i = stackList.Count - 1; i > 0; i--)
                {
                    if (stackList[i][0] <= stackList[i - 1][stackList[i - 1].Count - 1])
                    {
                        stackList[i - 1].AddRange(stackList[i]);
                        stackList.Remove(stackList[i]);
                    }
                }

                dayCount++;
            }

            return dayCount;
        }
    }
}
