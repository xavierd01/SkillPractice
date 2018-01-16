using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals;

namespace UnitTestCSFundamentals
{
    [TestClass]
    public class MyStackUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMyStack_empty_stack_pop_exception()
        {
            // Creating a new stack with nothing in it.
            var stack = new MyStack<int>();
            stack.pop();
        }

        [TestMethod]
        public void TestMyStack_new_stack_isEmpty_is_true()
        {
            // Creating a new stack with nothing in it.
            var stack = new MyStack<int>();
            Assert.IsTrue(stack.isEmpty());
        }

        [TestMethod]
        public void TestMyStack_push_isEmpty_is_false()
        {
            // Creating a new stack with nothing in it.
            var stack = new MyStack<int>();
            stack.push(1);
            Assert.IsFalse(stack.isEmpty());
        }

        [TestMethod]
        public void TestMyStack_new_stack_push_then_pop_isEmpty_is_true()
        {
            // Creating a new stack with nothing in it.
            var stack = new MyStack<int>();
            Assert.IsTrue(stack.isEmpty());
            stack.push(1);
            Assert.IsFalse(stack.isEmpty());
            stack.pop();
            Assert.IsTrue(stack.isEmpty());
        }

        [TestMethod]
        public void TestMyStack_stack_is_FILO()
        {
            int firstPushed = 0;
            int secondPushed = 1;
            // Creating a new stack with nothing in it.
            var stack = new MyStack<int>();
            Assert.IsTrue(stack.isEmpty());
            stack.push(firstPushed);
            stack.push(secondPushed);

            var actualFirstOut = stack.pop();
            var expectedFirstOut = secondPushed;
            Assert.AreEqual(expectedFirstOut, actualFirstOut);

            var actualLastOut = stack.pop();
            var expectedLastOut = firstPushed;
            Assert.AreEqual(expectedLastOut, actualLastOut);
        }
    }
}
