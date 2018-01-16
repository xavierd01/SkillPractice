using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals;

namespace UnitTestCSFundamentals
{
    [TestClass]
    public class MyQueueUnitTests
    {
        [TestMethod]
        public void TestMyQueue_new_queue_isEmpty_is_true()
        {
            // Creating a new stack with nothing in it.
            var queue = new MyQueue<int>();
            Assert.IsTrue(queue.isEmpty());
        }

        [TestMethod]
        public void TestMyQueue_after_add_isEmpty_is_false()
        {
            // Creating a new stack with nothing in it.
            var queue = new MyQueue<int>();
            Assert.IsTrue(queue.isEmpty());
            queue.add(1);
            Assert.IsFalse(queue.isEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMyQueue_empty_queue_peak_fails()
        {
            // Creating a new stack with nothing in it.
            var queue = new MyQueue<int>();
            queue.peek();
        }

        [TestMethod]
        public void TestMyQueue_peak_returns_first_in()
        {
            int firstIn = 1;
            int secondIn = 2;
            // Creating a new stack with nothing in it.
            var queue = new MyQueue<int>();
            queue.add(firstIn);
            int expectedPeek = firstIn;
            int actualFirstPeek = queue.peek();
            Assert.AreEqual(expectedPeek, actualFirstPeek);

            queue.add(secondIn);
            int actualSecondPeek = queue.peek();
            Assert.AreEqual(expectedPeek, actualSecondPeek);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMyQueue_empty_queue_remove_fails()
        {
            // Creating a new stack with nothing in it.
            var queue = new MyQueue<int>();
            queue.remove();
        }

        [TestMethod]
        public void TestMyQueue_remove_returns_first_in_and_removes()
        {
            int firstAdded = 1;
            int secondAdded = 2;
            // Creating a new stack with nothing in it.
            var queue = new MyQueue<int>();
            queue.add(firstAdded);
            queue.add(secondAdded);

            var expectedFirstRemoved = firstAdded;
            var actualFirstRemoved = queue.remove();
            Assert.AreEqual(expectedFirstRemoved, actualFirstRemoved);
            Assert.IsFalse(queue.isEmpty());

            var expectedSecondRemoved = secondAdded;
            var actualSecondRemoved = queue.remove();
            Assert.AreEqual(expectedSecondRemoved, actualSecondRemoved);
            Assert.IsTrue(queue.isEmpty());
        }
    }
}
