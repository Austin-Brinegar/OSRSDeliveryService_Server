using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Cosmos;
using OSRSEats.util;
using System.Collections.Generic;

namespace OSRSEats.functions
{
    public static class get_delivery
    {
        [FunctionName("get_delivery")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "ReadDelivery/{id}")] HttpRequest req,
            [CosmosDB(
                databaseName: Constants.COSMOS_DB_Database_Name,
                containerName: Constants.COSMOS_DB_CONTAINER_NAME,
                Connection = Constants.COSMOS_DB_CONNECTION_STRING,
                SqlQuery ="SELECT * FROM c WHERE c.id={id} ORDER BY c._ts DESC")] IEnumerable<Delivery> delivery,
            string id,
            ILogger log)
        {
            log.LogInformation("get-delivery function processed a request.");

           if (delivery == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(delivery);
        }
    }
}
