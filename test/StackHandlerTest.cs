using System.Collections;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Interfaces;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Utils;
using Xunit;

namespace FabioSereno.App_AzureDotNetCoreDataStructuresApi.Test
{
    public class StackHandlerTest
    {
        private readonly Stack _stack;
        private readonly ICollectionHandler<Stack> _stackHandler;

        public StackHandlerTest()
        {
            _stackHandler = new StackHandler();
            _stack = _stackHandler.Create();
        }

        [Fact]
        public void Add_ShouldAddItemToStack()
        {
            _stackHandler.Add(_stack, "Item 1");

            var result = _stack.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_ShouldNotErrorWhenNullIsPassedForStack()
        {
            _stackHandler.Add(null, "Item 1");

            var result = _stack.Count;
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_ShouldAddItemToStackInCorrectOrder()
        {
            var stack = new Stack(new string[] { "1", "2" });

            _stackHandler.Add(stack, "3"); // this results in 321

            var result = stack.Peek();
            Assert.Equal("3", result);
        }

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
        public void Remove_ShouldNotRemoveIfStackIsNull()
        {
            _stackHandler.Remove(null);

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
        public void Create_ShouldCreateStackWhenCollectionPassedIsNull()
        {
            Assert.IsType<Stack>(_stack);
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
    }
}