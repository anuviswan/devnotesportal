using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Azure.Cosmos.Table;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace api
{
    public static class SketchApi
    {
        [FunctionName("getTags")]
        public static async Task<IActionResult> GetTags(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [Table("devsketches")] CloudTable table,
            ILogger log)
        {
            TableContinuationToken continuationToken = null;
            var fluentQuery = new TableQuery<ImageEntry>();
            var result = await table.ExecuteQuerySegmentedAsync(fluentQuery, continuationToken);

            return new OkObjectResult(result);

        }
    }


    public class ImageEntry:TableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Tags { get;set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string ETag { get; set; }

    }
}
