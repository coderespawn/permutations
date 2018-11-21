using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinator
{
    class Permutation
    {
        int[] data;
        int K = -1;
        int L = -1;
        bool first = true;

        public bool CanPermute
        {
            get { return first || K >= 0; }
        }

        public int[] Data
        {
            get { return data; }
        }

        public Permutation(int[] data)
        {
            this.data = data;
            Array.Sort(this.data);
        }

        void FindIndices()
        {
            K = -1;
            for (int k = 0; k + 1 < data.Length; k++)
            {
                if (data[k] < data[k + 1])
                {
                    K = k;
                }
            }

            if (K >= 0)
            {
                for (int l = K + 1; l < data.Length; l++)
                {
                    if (data[K] < data[l])
                    {
                        L = l;
                    }
                }
            }
        }

        void Reverse(int a, int b)
        {
            while (a < b)
            {
                Swap(a, b);
                a++;
                b--;
            }
        }

        void Swap(int a, int b)
        {
            int t = data[a];
            data[a] = data[b];
            data[b] = t;
        }        

        public void Permutate()
        {
            if (first)
            {
                first = false;
                FindIndices();
                return;
            }

            if (!CanPermute)
            {
                return;
            }

            Swap(K, L);
            Reverse(K + 1, data.Length - 1);
            FindIndices();
        }
    }
}
