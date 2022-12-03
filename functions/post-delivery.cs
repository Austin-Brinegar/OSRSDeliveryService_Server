using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OSRSEats.util;

namespace OSRSEats.functions
{
    public static class post_delivery
    {
        [FunctionName("post_delivery")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName: Constants.COSMOS_DB_Database_Name, 
                containerName: Constants.COSMOS_DB_CONTAINER_NAME, 
                Connection = Constants.COSMOS_DB_CONNECTION_STRING)]
                out Delivery postDelivery,
            ILogger log)
        {
            log.LogInformation("post-delivery function processed a request.");

            string name = req.Query["name"];
            string location = req.Query["location"];
            string items = req.Query["items"];

            postDelivery = new Delivery("trdy", location, items);

            return new OkObjectResult("ok");
        }
    }
}