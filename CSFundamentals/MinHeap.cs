using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals
{
    public class MinHeap<T> where T : IComparable
    {
        const int CAPACITY = 2;

        T[] data;
        int size;
        IComparer<T> comparer;

        // Helper functions
        private int getParentIndex(int k) { return k / 2;  }
        private T parentValue(int k) { return this.data[getParentIndex(k)]; }

        private int getLeftChildIndex(int k) { return 2 * k; }
        private T leftChild(int k) { return this.data[getLeftChildIndex(k)]; }

        private int getRightChildIndex(int k) { return 2 * k + 1; }
        private T rightChild(int k) { return this.data[getRightChildIndex(k)]; }

        public MinHeap()
            : this(Comparer<T>.Default)
        {
        }

        public MinHeap(IComparer<T> comparer)
        {
            this.size = 0;
            this.data = new T[CAPACITY];
            this.comparer = comparer;
        }

        private void Swap(int i, int j)
        {
            T temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }

        private void HeapifyUp()
        {
            int k = this.size;
            while (getParentIndex(k) != 0)
            {
                //if (parentValue(k).CompareTo(data[k]) > 0)
                if (comparer.Compare(parentValue(k), data[k]) > 0)
                {
                    Swap(getParentIndex(k), k);
                    k = getParentIndex(k);
                }
                else { break; }
            }

        }

        private void HeapifyDown()
        {
            if (size == 0) return;

            int pos = 1; 

            while (true)
            {
                int smallest = pos;
                int left = getLeftChildIndex(pos);
                int right = getRightChildIndex(pos);

                if (left <= size && comparer.Compare(data[smallest], data[left]) > 0)
                {
                    smallest = left;
                }
                if (right <= size && comparer.Compare(data[smallest], data[right]) > 0)
                {
                    smallest = right;
                }

                if (smallest != pos)
                {
                    Swap(pos, smallest);
                    pos = smallest;
                }
                else break;
            }
        }

        public void Push(T item)
        {
            if (this.size + 1 == this.data.Length)
            {
                T[] temp = new T[(this.size + 1) * 2];
                for (var i = 1; i <= this.size; i++)
                {
                    temp[i] = data[i];
                }
                this.data = temp;
            }
            this.size++;
            this.data[size] = item;
            HeapifyUp();
        }

        public T Pop()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException();
            }
            T min = data[1];
            Swap(1, this.size);
            this.size--;
            HeapifyDown();

            return min;
        }

        public T Peek()
        {
            return data[1];
        }

        public int Size()
        {
            return size;
        }

        public string Export()
        {
            StringBuilder sb = new StringBuilder(size);
            for (int i = 1; i <= size; i++)
            {
                sb.Append(data[i]);
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
