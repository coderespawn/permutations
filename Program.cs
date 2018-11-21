using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combination
{
    class Combinator
    {
        int[] data;
        int selectionCount;

        public Combinator(int[] data, int selectionCount)
        {
            this.data = data;
            this.selectionCount = selectionCount;
        }

        void PrintResult(IEnumerable<int> result)
        {
            foreach (int number in result)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        public void PrintRecursive(Stack<int> buffer, int startIndex)
        {
            if (buffer.Count == selectionCount)
            {
                // Print and return
                var result = buffer.ToArray().Reverse();
                PrintResult(result);
                return;
            }


            int bufferLength = buffer.Count;
            int itemsLeft = selectionCount - bufferLength - 1;
            int endIndex = data.Length - itemsLeft;
            for (int i = startIndex; i < endIndex; i++)
            {
                buffer.Push(data[i]);
                PrintRecursive(buffer, i + 1);
                buffer.Pop();
            }
        }

        public void Print()
        {
            PrintRecursive(new Stack<int>(), 0);

        }

        struct StackState
        {
            public int[] buffer;
            public int startIndex;
        }

        public void PrintStack()
        {
            var stack = new Stack<StackState>();

            stack.Push(new StackState
            {
                buffer = new int[0],
                startIndex = 0
            });

            while (stack.Count > 0)
            {
                var top = stack.Pop();
                if (top.buffer.Length == selectionCount)
                {
                    PrintResult(top.buffer);
                }
                else
                {
                    int bufferLength = top.buffer.Length;
                    int itemsLeft = selectionCount - bufferLength - 1;
                    int endIndex = data.Length - itemsLeft;
                    for (int i = top.startIndex; i < endIndex; i++)
                    {
                        var nextBuffer = new List<int>(top.buffer);
                        nextBuffer.Add(data[i]);
                        var nextState = new StackState
                        {
                            buffer = nextBuffer.ToArray(),
                            startIndex = i + 1
                        };
                        stack.Push(nextState);
                    }
                }
            }
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            var combinator = new Combinator(new int[] { 1, 2, 3, 4, 5 }, 1);
            combinator.PrintStack();
        }
    }
}
