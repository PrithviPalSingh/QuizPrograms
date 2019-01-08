using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using temp;
using Newtonsoft.Json;
using System.Collections;

namespace RandomPrograms
{
    class Program
    {
        public static IComparer<long> Y_ORDER = new CompareStrings();

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
            //Console.WriteLine(string.Join(" ", MinMaxRiddle.riddle(new long[] { 2, 6, 1, 12 })));
            #endregion

            #region poisonous plants            
            //Console.WriteLine(PoisonousPlants.poisonousPlants(new int[] { 6, 5, 8, 4, 7, 10, 9 }));

            #endregion

            //FindNegativeNumber(-1);
            //FindNegativeNumber(23);
            //FindNegativeNumber(-23);
            //FindNegativeNumber(0);

            //reductionCost(new List<int> { 4,3,2,1 });
            //getMovieTitles("spiderman");

            //KthDigit();
            TheGreatOne();

            //Console.Write(findgcd(new int[] { 19}, 1));
            Console.Read();

        }

        static string[] getMovieTitles(string substr)
        {

            var uri = new Uri("https://jsonmock.hackerrank.com/api/movies/search/?Title=" + substr);


            using (var w = new WebClient())
            {
                var json_data = string.Empty;

                try
                {
                    json_data = w.DownloadString(uri);
                }
                catch (Exception) { }

                System.Diagnostics.Debug.WriteLine(json_data);

                var ss = JsonConvert.DeserializeObject(json_data);

                //System.Diagnostics.Debug.WriteLine(ss.data[0].TITLE);
                return new string[2] { "a", "b" };
            }

        }

        public static int reductionCost(List<int> num)
        {
            MinIndexedPriorityQueue<int> minPQ = new MinIndexedPriorityQueue<int>(num.Count);
            for (int i = 0; i < num.Count; i++)
            {
                minPQ.Insert(num[i]);
            }

            List<int> list = new List<int>();
            while (minPQ.N != 1)
            {
                var one = minPQ.DeleteMin();
                var two = minPQ.DeleteMin();
                list.Add(one + two);
                minPQ.Insert(one + two);
            }

            //for (int i = num.Count - 1; i > 0; i--)
            //{
            //    //if (num[num.Count - 1 - i] == num[num.Count - i])
            //    //{
            //    //    continue;
            //    //}

            //    var sum = num[num.Count - 1 - i] + num[num.Count - i];
            //    num.RemoveAt(num.Count - 1 - i);
            //    num.RemoveAt(num.Count - i);
            //    num.Insert(0, sum);
            //    num.Sort();
            //    list.Add(sum);
            //}

            int sum1 = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum1 += list[i];
            }

            return sum1;
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

        static bool FindNegativeNumber(int i)
        {
            var n = -(i) >> 31;

            if (i != 0 && n == 0)
                return true;

            return false;
        }

        static public void KthDigit()
        {
            int n = 1;// Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double[] numA = Array.ConvertAll("4 4 2".Split(' '), double.Parse);

                double a = numA[0];
                double b = numA[1];
                double k = numA[2];
                double p = (long)Math.Pow(a, b);
                double count = 0;
                while (p > 0 && count < k)
                {
                    long rem = (long)p % 10;
                    count++;
                    if (count == k)
                    {
                        Console.WriteLine(rem);
                    }
                    p /= 10;
                }
            }
        }

        static public void TheGreatOne()
        {
            int n = 1;// Convert.ToInt32(Console.ReadLine());
                      // Dictionary<long, bool> dict = new Dictionary<long, bool>();

            for (int i = 0; i < n; i++)
            {
                int len = 6;// Convert.ToInt32(Console.ReadLine());
                long[] dict = Array.ConvertAll("4 9 16 25 49 121".Split(' '), long.Parse);
                List<long> list = new List<long>();

                string finalNum = string.Empty;
                for (int k = 0; k < len; k++)
                {
                    if (isPerfectSquare(dict[k]))
                    {
                        if (IsValid(dict[k]))
                        {
                            list.Add(dict[k]);
                        }
                    }
                }

                list.Sort(0, list.Count, Y_ORDER);
                //MaxBinaryHeap<long> list = new MaxBinaryHeap<long>(len);
                //for (int j = 0; j < len; j++)
                //{
                //    if (dict.ContainsKey(numA[j]))
                //    {
                //        list.Insert(numA[j]);
                //    }
                //}

                //string finalNum = string.Empty;

                //if (list.N == 0)
                //{
                //    finalNum = "-1";
                //}
                //else if (list.N == 1)
                //{
                //    finalNum = list.DeleteMax().ToString();
                //}
                //else
                //{
                //var lastNum = list.Count > 0 ? list[list.Count - 1].ToString() : "-1";
                //var secLastNum = list.Count > 1 ? list[list.Count - 2].ToString() : "";
                //var OnePoss = lastNum + "" + secLastNum;
                //var SecPoss = secLastNum + "" + lastNum;

                //if (Convert.ToInt64(OnePoss) > Convert.ToInt64(SecPoss))
                //    finalNum = OnePoss;
                //else
                //    finalNum = SecPoss;
                //}

                if (list.Count == 0)
                {
                    finalNum = "-1";
                }
                else
                {

                    for (int l = (list.Count - 1); l >= 0; l--)
                    {
                        finalNum += list[l].ToString();
                    }
                }

                Console.WriteLine(finalNum);

                //Console.WriteLine(finalNum.Trim());
            }
        }

        static bool isPerfectSquare(double x)
        {
            double sr = Math.Sqrt(x);
            return ((sr - Math.Floor(sr)) == 0);
        }

        private static bool IsValid(long num)
        {
            if (num <= 3)
                return false;

            if (num == 4)
                return true;

            if (num > 4 && num % 2 == 0)
                return false;

            int count = 2;
            for (int i = 3; i <= num / 2; i = i + 2)
            {
                if (num % i == 0)
                {
                    count++;
                }
            }

            if (count == 3)
            {
                return true;
            }

            return false;
        }

        static int gcd(int a, int b)
        {
            if (a == 0)
            {
                return b;
            }
            return gcd(b % a, a);
        }

        static int findgcd(int[] arr, int n)
        {
            if (n == 1)
                return arr[0];

            int result = gcd(arr[1], arr[0]);
            for (int i = 2; i < n; i++)
            {
                if (arr[i] % result != 0)
                {
                    result = 1;
                }
            }
            return result;
        }
    }

    public class CompareStrings : IComparer<long>
    {
        public int Compare(long x, long y)
        {
            // first append Y at the end of X 
            string XY = x.ToString() + y.ToString();

            // then append X at the end of Y 
            string YX = y.ToString() + x.ToString();

            //long a = Convert.ToInt64(XY);
            //long b = Convert.ToInt64(YX);

            // Now see which of the two formed numbers is greater 
            return XY.CompareTo(YX);
        }
    }

    class MaxBinaryHeap<T> where T : IComparable<T>
    {
        T[] Items = null;
        int n = 0;

        //public int N { get => n; set => n = value; }

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public MaxBinaryHeap(int capacity)
        {
            Items = new T[capacity];
        }

        public void Insert(T item)
        {
            ////Normal implementation;
            //Items[N++] = item;

            //BH implementation
            Items[N++] = item;
            Swim(N - 1);
        }

        public T DeleteMax()
        {
            ////Normal Implementation
            //int MaxIndex = 0;
            //for (int i = 1; i < N; i++)
            //{
            //    if (Less(Items[MaxIndex], Items[i]))
            //    {
            //        MaxIndex = i;
            //    }
            //}

            //Exchange(MaxIndex, N - 1);
            //return Items[--N];

            ////BH Implementation
            T max = Items[0];
            Exchange(0, --N);
            Sink(0);
            Items[N] = default(T);
            return max;
        }

        public T Max()
        {
            //int MaxIndex = 0;
            //for (int i = 1; i < N; i++)
            //{
            //    if (Less(Items[MaxIndex], Items[i]))
            //    {
            //        MaxIndex = i;
            //    }
            //}

            return Items[0];
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        /// <summary>
        /// Children's key is larger than parent's key
        ///   - Exchange key in child with key in parent
        ///   - Repeat uptil heap order restored
        /// </summary>
        /// <param name="k"></param>
        private void Swim(int k)
        {
            while (k > 0 && Less(Items[k / 2], Items[k]))
            {
                Exchange(k, k / 2);
                k = k / 2;
            }
        }

        private bool Less(int i, int j)
        {
            return Items[i].CompareTo(Items[j]) < 0;
        }

        /// <summary>
        /// Parent's key become smaller than one or both children's key
        ///   - Exchange key in parent with key in larger child
        ///   - Repeat uptil heap order is restored
        /// </summary>
        /// <param name="k"></param>
        private void Sink(int k)
        {
            while (2 * k < N)
            {
                int j = 2 * k;

                if (j < N - 1 && Less(j, j + 1))
                    j++;

                if (!Less(k, j))
                    break;

                Exchange(k, j);
                k = j;
            }
        }

        private bool Less(T a, T b)
        {
            return a.CompareTo(b) < 0;
        }

        private void Exchange(int i, int j)
        {
            var swap = Items[i];
            Items[i] = Items[j];
            Items[j] = swap;
        }
    }
}