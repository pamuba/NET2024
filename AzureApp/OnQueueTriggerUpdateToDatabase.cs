using System;
using AzureApp.Data;
using AzureApp.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureApp
{
    public class OnQueueTriggerUpdateToDatabase
    {
        private readonly AzureDbContext _db;

        public OnQueueTriggerUpdateToDatabase(AzureDbContext db)
        {
            _db = db;
        }

        [FunctionName("OnQueueTriggerUpdateToDatabase")]
        public void Run([QueueTrigger("SalseRequestInBound", Connection = "AzureWebJobsStorage")]SalesRequest myQueueItem, ILogger log)
        {
            log.LogInformation("C# Queue trigger function processed");
            myQueueItem.Status = "Submitted";

            _db.SalesRequests.Add(myQueueItem);
            _db.SaveChanges();
        }
    }
}
