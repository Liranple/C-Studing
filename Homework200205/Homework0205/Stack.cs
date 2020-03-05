using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework0205
{
    class Stack<T>
    {
        List<T> stack = new List<T>();

        public void Push(T i)
        {
            stack.Add(i);
        }
        public T Pop()
        {
            var output = stack[stack.Count - 1];

            stack.RemoveAt(stack.Count - 1);

            return output;
        }
        public T Peek()
        {
            var output = stack[stack.Count - 1];

            return output;
        }
    }
}
