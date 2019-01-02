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
        public static int poisonousPlants(int[] p)
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
    }
}
