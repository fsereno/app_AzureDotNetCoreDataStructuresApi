using System.Collections;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Interfaces;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Utils;
using Xunit;

namespace FS.Test
{
    public class DataStructuresUtilTest
    {
        private readonly Queue _queue;
        private readonly Stack _stack;
        private readonly ICollectionHandler<Queue> _queueHandler;
        private readonly ICollectionHandler<Stack> _stackHandler;

        public DataStructuresUtilTest()
        {
            _queue = new Queue();
            _stack = new Stack();

            _queueHandler = new QueueHandler<Queue>();
            _stackHandler = new StackHandler<Stack>();
        }

        [Fact]
        public void Add_ShouldAddItemToQueue()
        {
            _queueHandler.Add(_queue, "Item 1");

            var result = _queue.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void Remove_ShouldRemoveItemFromQueue()
        {
            _queueHandler.Add(_queue, "Item 1");
            _queueHandler.Remove(_queue);

            var result = _queue.Count;
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_ShouldAddItemToStack()
        {
            _stackHandler.Add(_stack, "Item 1");

            var result = _stack.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_ShouldAddItemToStackInCorrectOrder()
        {
            var stack = new Stack(new string[] { "1", "2" });

            _stackHandler.Add(stack, "3"); // this results in 321

            var result = stack.Peek();
            Assert.Equal("3", result);
        }

        // this may be invalid test
        [Fact]
        public void Add_ShouldAddItemToStackInCorrectOrderWhenOrderIsReversedAlready()
        {
            var stack = new Stack(new string[] { "2", "1" });

            _stackHandler.Add(stack, "3");

            var result = stack.Peek();
            Assert.Equal("3", result);
        }

        [Fact]
        public void Remove_ShouldRemoveItemFromStack()
        {
            _stackHandler.Add(_stack, "Item 1");
            _stackHandler.Remove(_stack);

            var result = _stack.Count;
            Assert.Equal(0, result);
        }

        [Fact]
        public void Remove_ShouldRemoveItemFromStackInCorrectOrder()
        {
            var stack = new Stack(new string[] { "1", "2", "3" });
            _stackHandler.Remove(stack);

            var result = stack.Peek();
            Assert.Equal("2", result);
        }

        [Fact]
        public void Create_ShouldCreateAStackAndRemoveInCorrectOrderIfInitialOrderIsReversed_LIFO()
        {
            var array = new string[] { "2", "1" };
            var stack = _stackHandler.Create(array);

            _stackHandler.Add(stack, "3");
            _stackHandler.Remove(stack);

            var result = stack.Peek();
            Assert.Equal("2", result);
        }

        [Fact]
        public void Create_ShouldCreateAQueueAndRemoveInTheCorrectOrder_FIFO()
        {
            var array = new string[] { "1", "2" };
            var queue = _queueHandler.Create(array);

            _queueHandler.Add(queue, "3");
            _queueHandler.Remove(queue);

            var result = queue.Peek();
            Assert.Equal("2", result);
        }
    }
}