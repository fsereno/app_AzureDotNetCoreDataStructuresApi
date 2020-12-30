using System.Collections;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Interfaces;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Utils;
using Xunit;

namespace FabioSereno.App_AzureDotNetCoreDataStructuresApi.Test
{
    public class QueueHandlerTest
    {
        private readonly Queue _queue;
        private readonly ICollectionHandler<Queue> _queueHandler;

        public QueueHandlerTest()
        {
            _queueHandler = new QueueHandler();
            _queue = _queueHandler.Create();
        }

        [Fact]
        public void Add_ShouldAddItemToQueue()
        {
            _queueHandler.Add(_queue, "Item 1");

            var result = _queue.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_ShouldNotErrorWhenNullIsPassedForQueue()
        {
            _queueHandler.Add(null, "Item 1");

            var result = _queue.Count;
            Assert.Equal(0, result);
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
        public void Remove_ShouldNotRemoveIfQueueIsNull()
        {
            _queueHandler.Remove(null);

            var result = _queue.Count;
            Assert.Equal(0, result);
        }

        [Fact]
        public void Create_ShouldCreateQueueWhenCollectionPassedIsNull()
        {
            Assert.IsType<Queue>(_queue);
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