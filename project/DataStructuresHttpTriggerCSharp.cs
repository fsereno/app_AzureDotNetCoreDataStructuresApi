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

using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Interfaces;
using FabioSereno.App_AzureDotNetCoreDataStructuresApi.Models;

namespace FabioSereno.App_AzureDotNetCoreDataStructuresApi.Azure.Function
{
    public class DataStructuresHttpTriggerCSharp
    {
        private readonly ICollectionUtil<Queue> _queueUtil;
        private readonly ICollectionUtil<Stack> _stackUtil;
        public DataStructuresHttpTriggerCSharp(ICollectionUtil<Queue> queueUtil, ICollectionUtil<Stack> stackUtil)
        {
            _queueUtil = queueUtil;
            _stackUtil = stackUtil;
        }

        [FunctionName("AddQueueItemAsync")]
        public async Task<IActionResult> AddQueueItemAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("AddQueueItemAsync endpoint hit");

            AddRequestBody data;
            string result = string.Empty;

            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                var request = await streamReader.ReadToEndAsync();
                data = JsonConvert.DeserializeObject<AddRequestBody>(request);
            }

            if (data != null) {

                log.LogInformation("Adding item to the queue");

                var queue = _queueUtil.Create(data.Collection);
                _queueUtil.Add(queue, data.Item);

                result = JsonConvert.SerializeObject(queue);

                log.LogInformation("Added item to the queue");
            }

            return new OkObjectResult(result);
        }

        [FunctionName("RemoveQueueItemAsync")]
        public async Task<IActionResult> RemoveQueueItemAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("RemoveQueueItemAsync endpoint hit");

            AddRequestBody data;
            string result = string.Empty;

            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                var request = await streamReader.ReadToEndAsync();
                data = JsonConvert.DeserializeObject<AddRequestBody>(request);
            }

            if (data != null) {

                log.LogInformation("Removing item to the queue");

                var queue = _queueUtil.Create(data.Collection);
                _queueUtil.Remove(queue);

                result = JsonConvert.SerializeObject(queue);

                log.LogInformation("Removed item to the queue");
            }

            return new OkObjectResult(result);
        }

        [FunctionName("AddStackItemAsync")]
        public async Task<IActionResult> AddStackItemAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("AddStackItemAsync endpoint hit");

            AddRequestBody data;
            string result = string.Empty;

            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                var request = await streamReader.ReadToEndAsync();
                data = JsonConvert.DeserializeObject<AddRequestBody>(request);
            }

            if (data != null) {

                log.LogInformation("Adding item to the stack");

                var stack = _stackUtil.Create(data.Collection);
                _stackUtil.Add(stack, data.Item);

                result = JsonConvert.SerializeObject(stack);

                log.LogInformation("Added item to the stack");
            }

            return new OkObjectResult(result);
        }

        [FunctionName("RemoveStackItemAsync")]
        public async Task<IActionResult> RemoveStackItemAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("RemoveStackItemAsync endpoint hit");

            AddRequestBody data;
            string result = string.Empty;

            using (StreamReader streamReader = new StreamReader(req.Body))
            {
                var request = await streamReader.ReadToEndAsync();
                data = JsonConvert.DeserializeObject<AddRequestBody>(request);
            }

            if (data != null) {

                log.LogInformation("Removing item to the stack");

                var stack = _stackUtil.Create(data.Collection);
                _stackUtil.Remove(stack);

                result = JsonConvert.SerializeObject(stack);

                log.LogInformation("Removed item to the stack");
            }

            return new OkObjectResult(result);
        }
    }
}