using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals;

namespace UnitTestCSFundamentals
{
    [TestClass]
    public class MinHeapUnitTests
    {
        [TestMethod]
        public void DefaultConstructorMinHeap()
        {
            var min = new MinHeap<int>();
            min.Push(1);
            min.Push(2);
            min.Push(3);
            min.Push(4);
            min.Push(5);
            
            Assert.IsTrue(min.Peek() == 1);
            var val = min.Pop();
            Assert.IsTrue(val == 1);
            Assert.IsTrue(min.Peek() == 2);
        }

        [TestMethod]
        public void MaxHeap()
        {
            var sortDesc = Comparer<int>.Create((a, b) => b - a);

            var max = new MinHeap<int>(sortDesc);
            max.Push(1);
            max.Push(2);
            max.Push(3);
            max.Push(4);
            max.Push(5);
            Assert.IsTrue(max.Peek() == 5);
            var val = max.Pop();
            Assert.IsTrue(val == 5);
            Assert.IsTrue(max.Peek() == 4);
        }
    }
}
