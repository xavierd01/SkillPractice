using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals
{
    class Program
    {
        static BigInteger factorial(int n)
        {
            Func<BigInteger, BigInteger, BigInteger> fact = null;
            fact = (BigInteger x, BigInteger acc) =>
            {
                if (x <= 1) return acc;
                return fact(x - 1, x * acc);
            };
            return fact(n, 1);
        }

        static void TrieTest()
        {
            Tuple<string, string>[] commands =
            {
                Tuple.Create("add", "s"),
                Tuple.Create("add", "ss"),
                Tuple.Create("add", "sss"),
                Tuple.Create("add", "ssss"),
                Tuple.Create("add", "sssss"),
                Tuple.Create("find", "s"),
                Tuple.Create("find", "ss"),
                Tuple.Create("find", "sss"),
                Tuple.Create("find", "ssss"),
                Tuple.Create("find", "sssss"),
                Tuple.Create("find", "ssssss")
            };

            ContactTrie trie = new ContactTrie();
            foreach (var cmd in commands)
            {
                switch (cmd.Item1)
                {
                    case "add":
                        trie.AddContact(cmd.Item2);
                        break;

                    case "find":
                        Console.WriteLine(trie.CountPartial(cmd.Item2));
                        break;

                    default:
                        Console.WriteLine("Invalid Command: {0}", cmd.Item1);
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            
            var min = new MinHeap<int>(Comparer<int>.Create((x, y) => x - y));
            var max = new MinHeap<int>(Comparer<int>.Create((x, y) => y - x));
            int n = 10;
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int a_i = 0; a_i < n; a_i++)
            {
                //a[a_i] = Convert.ToInt32(Console.ReadLine());
                var next = a[a_i];
                //int newLen = a_i + 1;

                if (max.Size() == 0 || next < max.Peek())
                {
                    max.Push(next);
                }
                else
                {
                    min.Push(next);
                }

                var diff = max.Size() - min.Size();
                if (diff > 1)
                {
                    min.Push(max.Pop());
                }
                else if (diff < -1)
                {
                    max.Push(min.Pop());
                }

                var mid = -1.0;
                if (max.Size() > min.Size())
                {
                    mid = max.Peek();
                }
                else if (max.Size() < min.Size())
                {
                    mid = min.Peek();
                }
                else
                { // equal size
                    mid = ((double)max.Peek() + min.Peek()) / 2;
                }

                Console.WriteLine("{0:0.0}", mid);
            }


        }
    }
}
