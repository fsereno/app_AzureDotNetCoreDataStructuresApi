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