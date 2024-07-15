using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureApp.Models;

namespace AzureApp
{
    public static class OnSalesUploadWrtieToQueue
    {
        [FunctionName("OnSalesUploadWrtieToQueue")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Queue("SalseRequestInBound", Connection = "AzureWebJobsStorage")] IAsyncCollector<SalesRequest> salseRequestQueue,
            ILogger log)
        {
            log.LogInformation("Sales Request received by OnSalesUploadWrtieToQueue function");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            SalesRequest data = JsonConvert.DeserializeObject<SalesRequest>(requestBody);

            await salseRequestQueue.AddAsync(data);

            string responseMessage = "Sales Request has been received for : " + data.Name;

            return new OkObjectResult(responseMessage);
        }
    }
}
