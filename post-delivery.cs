using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace OSRSEats.functions
{
    public static class post_delivery
    {
        [FunctionName("post_delivery")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName: "OSRSDeliveryServiceDB", containerName: "Active", 
                Connection = "CosmosDbConnectionString")]
                out object postDelivery,
            ILogger log)
        {
            log.LogInformation("post-delivery function processed a request.");

            Guid id = Guid.NewGuid();
            string name = req.Query["name"];
            string location = req.Query["location"];
            string items = req.Query["items"];

            postDelivery = new {
                id,
                name,
                location,
                items
            };

            return new OkObjectResult("ok");
        }
    }
}