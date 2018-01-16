using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals
{
    public class StackQueue<T>
    {
        Stack<T> newStack;
        Stack<T> oldStack;

        public StackQueue()
        {
            newStack = new Stack<T>();
            oldStack = new Stack<T>();
        }

        public void Enqueue(T data)
        {
            if (oldStack.Count == 0)
            {
                oldStack.Push(data);
            }
            else
            {
                newStack.Push(data);
            }
        }

        public T Dequeue()
        {
            if (oldStack.Count == 0 && newStack.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T output = oldStack.Pop();

            if (oldStack.Count == 0)
            {
                while (newStack.Count > 0)
                {
                    oldStack.Push(newStack.Pop());
                }
            }
            return output;
        }

        public T Peek()
        {
            if (oldStack.Count == 0 && newStack.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return oldStack.Peek();
        }

    }
}
