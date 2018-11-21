using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinator
{
    class Combination
    {
        int[] data;
        int selectionCount;
        Stack<StackState> stack = new Stack<StackState>();

        public bool CanRun
        {
            get { return stack.Count > 0; }
        }


        public Combination(int[] data, int selectionCount)
        {
            this.data = data;
            this.selectionCount = selectionCount;

            stack.Push(new StackState
            {
                buffer = new int[0],
                startIndex = 0
            });
        }

        struct StackState
        {
            public int[] buffer;
            public int startIndex;
        }

        public int[] Execute()
        {
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                if (top.buffer.Length == selectionCount)
                {
                    return top.buffer;
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
            return null;
        }
    }
}
