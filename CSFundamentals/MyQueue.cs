using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals
{
    public class MyQueue<T>
    {
        LinkedList<T> data;

        public MyQueue()
        {
            this.data = new LinkedList<T>();
        }

        public void add(T item)
        {
            this.data.AddFirst(item);
        }

        public T remove()
        {
            if (this.isEmpty()) throw new InvalidOperationException();
            var temp = this.data.Last.Value;
            this.data.RemoveLast();
            return temp;
        }

        public T peek()
        {
            if (this.isEmpty()) throw new InvalidOperationException();
            return this.data.Last();
        }

        public bool isEmpty()
        {
            return this.data.First == null;
        }
    }
}
