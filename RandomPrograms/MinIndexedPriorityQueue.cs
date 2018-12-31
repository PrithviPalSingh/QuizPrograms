using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp
{
    class MinIndexedPriorityQueue<T> where T : IComparable<T>
    {
        private T[] Items;

        private long n;

        public long N { get => n; set => n = value; }

        public MinIndexedPriorityQueue(long n)
        {
            Items = new T[n + 1];
        }

        public void Insert(T a)
        {
            Items[++N] = a;
            Swim(N);
        }

        private void Swim(long k)
        {
            while (k > 1 && greater(k / 2, k))
            {
                Exchange(k, k / 2);
                k = k / 2;
            }
        }

        private void Sink(long k)
        {
            while (2 * k <= N)
            {
                long j = 2 * k;
                if (j < N && greater(j, j + 1))
                {
                    j++;
                }

                if (greater(j, k))
                { break; }

                Exchange(k, j);
                k = j;
            }
        }

        public T DeleteMin()
        {
            T min = Items[1];
            Exchange(1, N--);
            Sink(1);
            Items[N + 1] = default(T);
            return min;
        }

        public T Min()
        {
            //long MinIndex = 1;
            //for (long i = 1; i < N; i++)
            //{
            //    if (greater(MinIndex, i))
            //    {
            //        MinIndex = i;
            //    }
            //}

            return Items[1];
        }

        private bool greater(long i, long j)
        {
            return Items[i].CompareTo(Items[j]) > 0;
        }

        private void Exchange(long i, long j)
        {
            var swap = Items[i];
            Items[i] = Items[j];
            Items[j] = swap;
        }
    }
}
