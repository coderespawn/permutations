using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinator
{
    class Program
    {
        static void PrintIndent(int TabCount)
        {
            for (int i = 0; i < TabCount; i++)
            {
                Console.Write("    ");
            }
        }
        static void PrintResult<T>(IEnumerable<T> result)
        {
            foreach (T number in result)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //TestCombination();
            //TestPermutation();

            TestSystem();
        }

        static void PrintSelectionConfig(int[] Doors, string[] Nodes)
        {
            for (int i = 0; i < Doors.Length; i++)
            {
                Console.Write("{0}[{1}] ", Nodes[i], Doors[i]);
            }
            Console.WriteLine();
        }

        static void TestSystem()
        {
            var DoorIndices = new int[] { 0, 1, 2, 3, 4 };
            var Outgoing = new string[] { "R", "R", "C" };

            var combinator = new Combination<int>(DoorIndices, Outgoing.Length);
            while (combinator.CanRun)
            {
                int[] selection = combinator.Execute();

                var permutation = new Permutation<string>(Outgoing);
                while (permutation.CanPermute)
                {
                    permutation.Permutate();
                    PrintSelectionConfig(selection, permutation.Data);
                }

                Console.WriteLine();
            }


        }

        static void TestCombination()
        {
            var data = new int[] { 1, 2, 3, 4, 5 };
            var combinator = new Combination<int>(data, 3);
            while (combinator.CanRun)
            {
                int[] selection = combinator.Execute();
                PrintResult(selection);
            }
        }

        static void TestPermutation()
        {
            //var data = new int[] { 1, 2, 3 };
            //var permutation = new Permutation<int>(data);

            var data = new string[] { "R", "R", "C" };
            var permutation = new Permutation<string>(data);

            while (permutation.CanPermute)
            {
                permutation.Permutate();
                PrintIndent(1);
                PrintResult(permutation.Data);
            }
        }
    }
}
