using System;
using System.Collections;
using Xunit;

namespace Test
{
    public class DataStructuresUtilTest
    {
        private readonly Queue _queue;
        private readonly Stack _stack;

        public DataStructuresUtilTest()
        {
            _queue = new Queue();
            _stack = new Stack();
        }

        [Fact]
        public void AddShouldAddItemToQueue()
        {
            _queue.Enqueue("Item 1");

            var result = _queue.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void RemoveShouldRemoveItemFromQueue()
        {
            _queue.Enqueue("Item 1");
            _queue.Dequeue();

            var result = _queue.Count;
            Assert.Equal(0, result);
        }

        [Fact]
        public void AddShouldAddItemToStack()
        {
            _stack.Push("Item 1");

            var result = _stack.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void RemoveShouldRemoveItemFromStack()
        {
             _stack.Push("Item 1");
             _stack.Pop();

            var result = _stack.Count;
            Assert.Equal(0, result);
        }
    }
}
