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
    public static class get_all_deliveries
    {
        [FunctionName("get_all_deliveries")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            [CosmosDB(
                databaseName: Constants.COSMOS_DB_Database_Name,
                containerName: Constants.COSMOS_DB_CONTAINER_NAME,
                Connection = Constants.COSMOS_DB_CONNECTION_STRING,
                SqlQuery ="SELECT * FROM c ORDER BY c._ts DESC")] IEnumerable<Delivery> deliveries,
            ILogger log)
        {
            log.LogInformation("get-delivery function processed a request.");

           if (deliveries == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(deliveries);
        }
    }
}
