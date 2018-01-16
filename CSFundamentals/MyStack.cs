using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals
{
    public class MyStack<T>
    {
        LinkedList<T> data;

        public MyStack()
        {
            this.data = new LinkedList<T>();
        }

        /// <summary>
        /// Remove the top item from the stack.
        /// </summary>
        /// <returns>Top item from the stack.</returns>
        /// <exception cref="InvalidOperationException">stack is empty</exception>
        public T pop()
        {
            if (isEmpty()) throw new InvalidOperationException("stack is empty");
            T temp = this.data.First.Value;
            this.data.RemoveFirst();
            return temp;
        }

        /// <summary>
        /// Add an item to the top of the stack.
        /// </summary>
        /// <param name="item">Value to add to the top of the stack.</param>
        public void push (T item)
        {
            this.data.AddFirst(item);
        }

        /// <summary>
        /// Retun the top of the stack.
        /// </summary>
        /// <returns>Top item from the stack.</returns>
        /// /// <exception cref="InvalidOperationException">stack is empty</exception>
        public T peek()
        {
            if (isEmpty()) throw new InvalidOperationException("stack is empty");
            return this.data.First.Value;
        }

        /// <summary>
        /// Return true if and only if the stack is empty.
        /// </summary>
        /// <returns>True if stack is empty. False otherwise.</returns>
        public bool isEmpty()
        {
            return this.data.First == null;
        }
    }
}
