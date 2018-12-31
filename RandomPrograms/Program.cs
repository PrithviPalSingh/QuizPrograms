using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RandomPrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(func(2));
            //StirngMan();
            //var x = braces(new string[] { "({}([][]))[]()" });
            //var r = delta_encode(new int[] {12, 24, 32, 1222, 11111 });
            //Regex reg = new Regex("^[a-z]{1,6}[_][0-9]{0,4}@hackerrank.com$");
            //var c = getOneBits(161);

            //Console.WriteLine(findSimilar("1100", "1001"));

            //string str = "aaasss";
            //var x = str.Reverse();
            // Console.WriteLine(str.Reverse());

            //WorkWithShift();

            //Console.WriteLine(findMatchingPair("YVvyGSAJjJjjaWwsg"));
            //Console.WriteLine(MaxFligts(new int[] { 900, 940, 950, 1100, 1500, 1800 },
            //    new int[] { 910, 1200, 1120, 1130, 1900, 2000 }, 6));

            #region 1's in binary
            //int count = 0;
            //int num = 8;
            //while (num != 0)
            //{
            //    if ((num & 1) == 1)
            //    {
            //        count++;
            //    }

            //    num = num >> 1;
            //}

            //Console.WriteLine(count);
            #endregion

            #region missing alphabet
            //char[] str = new char[] { 'Q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n' };
            //bool[] present = new bool[26];
            //for (int i = 0; i < str.Length; i++)
            //{
            //    if (str[i] >= 'a' && str[i] <= 'z')
            //        present[str[i] - 'a'] = true;
            //    else if (str[i] >= 'A' && str[i] <= 'Z')
            //        present[str[i] - 'A'] = true;
            //}

            //for (int i = 0; i < present.Length; i++)
            //{
            //    if (present[i] == false)
            //    {
            //        char c = Convert.ToChar('a' + i);
            //        Console.WriteLine(c);
            //        break;
            //    }
            //}
            //Console.WriteLine();
            #endregion

            #region Min Max Riddle
            Console.WriteLine(string.Join(" ", MinMaxRiddle.riddle(new long[] { 1, 2, 3, 5, 1, 13, 3 })));
            #endregion

            Console.Read();

        }

        static int MaxFligts(int[] arr1, int[] arr2, int flights)
        {
            int maxGates = 0;

            Array.Sort(arr2);

            for (int i = 0; i < flights; i++)
            {
                int gates = 0;
                int outerloop = i;
                for (int j = i; j < flights && outerloop < flights; j++)
                {
                    if (arr1[outerloop] < arr2[j])
                    {
                        j--;
                        outerloop++;
                    }
                    else
                    {
                        gates = outerloop - i;
                        break;
                    }
                }

                maxGates = maxGates < gates ? gates : maxGates;
            }

            return maxGates;
        }

        static int findMatchingPair(String input)
        {
            /*
             * Write your code here.
             */

            Stack<char> stack = new Stack<char>();
            int lastindex = -1;
            int i = 0;
            foreach (char ch in input.ToCharArray())
            {
                if (IsUpperCase(ch))
                {
                    stack.Push(ch);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return lastindex;
                    }

                    char a = stack.Peek();
                    if (a.ToString() == ch.ToString().ToUpper())
                    {
                        lastindex = i;
                        stack.Pop();
                    }
                    else
                    {
                        //stack.Push(ch);
                        return lastindex;
                    }
                }

                i++;
            }

            return lastindex;
        }

        private static Boolean IsUpperCase(char c)
        {
            if (c >= 65 && c <= 91)
            {
                return true;
            }

            return false;
        }
        private static void WorkWithShift()
        {
            var a = 3 >> 1;
            Console.WriteLine(a);
        }

        public static long findSimilar(string a, string b)
        {
            a = a.TrimStart('0');
            b = b.TrimStart('0');

            char[] arr = a.ToCharArray();
            char[] brr = b.ToCharArray();
            Array.Sort(arr);
            Array.Sort(brr);

            bool Matched = true;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != brr[i])
                {
                    Matched = false;
                }
            }

            int total = brr.Length;
            int common = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < total; i++)
            {
                if (!dict.ContainsKey(brr[i]))
                {
                    dict.Add(brr[i], 1);
                }
                else
                {
                    dict[brr[i]] += 1;
                }
            }

            foreach (var item in dict)
            {
                if (item.Value > 1)
                    common++;
            }

            return common == 0 ? Factorial(total) : Factorial(total) / (Factorial(common) * Factorial(total - common));

        }

        private static int Factorial(int n)
        {
            if (n == 1)
                return 1;

            return n * Factorial(n - 1);
        }

        public static List<int> getOneBits(int n)
        {
            int i = 0;
            int max = 0;
            List<int> list = new List<int>();
            while (i < 32)
            {
                var temp = n & (1 << i);
                if (temp != 0)
                {
                    list.Add(i);
                    max = i + 1;
                }

                i++;
            }

            for (int j = 0; j < list.Count; j++)
            {
                list[j] = max - list[j];
            }

            list.Insert(0, list.Count);

            return list;
        }


        static void StirngMan()
        {

            var abc = "i am a man's. man.. ten".Replace("'", "").Replace(".", "").Split(' ');
            //var def = abc.Split(' ');
        }


        static int func(int n)
        {
            if (n == 4)
                return 2;
            else
                return 2 * func(n + 1);
        }

        static int[] delta_encode(int[] array)
        {

            if (array == null || array.Length == 0)
            {
                return null;
            }

            List<int> list = new List<int>();
            list.Add(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                var temp = array[i] - array[i - 1];
                if (temp > 127 || temp < -127)
                {
                    list.Add(-128);
                }

                list.Add(array[i]);
            }

            return list.ToArray();
        }
    }
}
