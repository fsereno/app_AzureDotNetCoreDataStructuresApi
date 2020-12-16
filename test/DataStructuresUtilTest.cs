using System.Collections;
using Xunit;

namespace FS.Test.Utils.DataStructuresUtilTest
{
    public interface ICollectionsHandler<T>
    {
        void Add(T collection, string value);
        void Remove(T collection);
    }

    public class StackHandler<T> : ICollectionsHandler<T> where T : Stack
    {
        public void Add(T collection, string value)
        {
            collection.Push(value);
        }

        public void Remove(T collection)
        {
            collection.Pop();
        }
    }

    public class QueueHandler<T> : ICollectionsHandler<T> where T : Queue
    {
        public void Add(T collection, string value)
        {
            collection.Enqueue(value);
        }

        public void Remove(T collection)
        {
            collection.Dequeue();
        }
    }

    public class DataStructuresUtilTest
    {
        private readonly Queue _queue;
        private readonly Stack _stack;

        private readonly ICollectionsHandler<Queue> _queueHandler;

        private readonly ICollectionsHandler<Stack> _stackHandler;

        public DataStructuresUtilTest()
        {
            _queue = new Queue();
            _stack = new Stack();

            _queueHandler = new QueueHandler<Queue>();
            _stackHandler = new StackHandler<Stack>();
        }

        [Fact]
        public void AddShouldAddItemToQueue()
        {
            _queueHandler.Add(_queue, "Item 1");

            var result = _queue.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void RemoveShouldRemoveItemFromQueue()
        {
            _queueHandler.Add(_queue, "Item 1");
            _queueHandler.Remove(_queue);

            var result = _queue.Count;
            Assert.Equal(0, result);
        }

        [Fact]
        public void AddShouldAddItemToStack()
        {
            _stackHandler.Add(_stack, "Item 1");

            var result = _stack.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void RemoveShouldRemoveItemFromStack()
        {
            _stackHandler.Add(_stack, "Item 1");
            _stackHandler.Remove(_stack);

            var result = _stack.Count;
            Assert.Equal(0, result);
        }
    }
}