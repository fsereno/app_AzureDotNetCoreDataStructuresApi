using System;
using System.IO;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using FS.Interfaces;
using FS.Models;

namespace FS.Azure.Function
{
    public class DataStructuresHttpTriggerCSharp
    {
        private readonly ICollectionHandler<Queue> _queueHandler;
        private readonly ICollectionHandler<Stack> _stackHandler;
        public DataStructuresHttpTriggerCSharp(ICollectionHandler<Queue> queueHandler, ICollectionHandler<Stack> stackHandler)
        {
            _queueHandler = queueHandler;
            _stackHandler = stackHandler;
        }

        [FunctionName("DataStructuresHttpTriggerCSharp")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            var array = new string[] { "1", "2", "3"};
            var queue = new Queue(array);
            var stack = new Stack(array);

            _queueHandler.Add(queue, "4");
            _stackHandler.Add(stack, "4");

            return new OkObjectResult(responseMessage);
        }

        [FunctionName("AddQueueItem")]
        public async Task<IActionResult> AddQueueItem([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Adding an item to the queue");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject<AddRequestBody>(requestBody);

            var queue = new Queue(data.Collection);
            _queueHandler.Add(queue, data.Item);

            var result = JsonConvert.SerializeObject(queue);

            log.LogInformation("Added item to the queue");

            return new OkObjectResult(result);
        }

        [FunctionName("RemoveQueueItem")]
        public async Task<IActionResult> RemoveQueueItem([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Remove the next item from the queue");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject<RemoveRequestBody>(requestBody);

            var queue = new Queue(data.Collection);

            _queueHandler.Remove(queue);

            var result = JsonConvert.SerializeObject(queue);

            log.LogInformation("Removed item from the queue");

            return new OkObjectResult(result);
        }

        [FunctionName("AddStackItem")]
        public async Task<IActionResult> AddStackItem([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Adding an item to the stack");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject<AddRequestBody>(requestBody);

            var stack = new Stack(data.Collection);

            _stackHandler.Add(stack, data.Item);

            var result = JsonConvert.SerializeObject(stack);

            log.LogInformation("Added item to the stack");

            return new OkObjectResult(result);
        }

        [FunctionName("RemoveStackItem")]
        public async Task<IActionResult> RemoveStackItem([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Remove the next item from the stack");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject<RemoveRequestBody>(requestBody);

            var stack = new Stack(data.Collection);

            _stackHandler.Remove(stack);

            var result = JsonConvert.SerializeObject(stack);

            log.LogInformation("Removed item from the stack");

            return new OkObjectResult(result);
        }
    }
}
