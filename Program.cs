using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinator
{
    class Program
    {
        public static void PrintResult(IEnumerable<int> result)
        {
            foreach (int number in result)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //TestCombination();
            TestPermutation();
        }

        static void TestCombination()
        {
            var data = new int[] { 1, 2, 3, 4, 5 };
            var combinator = new Combination(data, 3);
            while (combinator.CanRun)
            {
                int[] selection = combinator.Execute();
                PrintResult(selection);
            }
        }

        static void TestPermutation()
        {
            var data = new int[] { 1, 2, 3 };
            var permutation = new Permutation(data);
            while (permutation.CanPermute)
            {
                permutation.Permutate();
                PrintResult(permutation.Data);
            }
        }
    }
}
