using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

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
            string queryString = TableQuery.GenerateFilterCondition(nameof(TableEntity.PartitionKey), QueryComparisons.Equal, TagEntry.PartitionTitle);
            var fluentQuery = new TableQuery<TagEntry>().Where(queryString);
            var result = await table.ExecuteQuerySegmentedAsync(fluentQuery, continuationToken);

            return new OkObjectResult(result.Select(x=>new
            {
                Title = x.Title,
                Id = x.RowKey
            }));

        }

        [FunctionName("getEntries")]
        public static async Task<IActionResult> GetEntriesFor(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [Table("devsketches")] CloudTable table,
            ILogger log)
        {
            var id = req.Query["id"];

            TableContinuationToken continuationToken = null;
            var partionKeyQuery = TableQuery.GenerateFilterCondition(nameof(ImageEntry.PartitionKey), QueryComparisons.Equal, id);
                
            var fluentQuery = new TableQuery<ImageEntry>().Where(partionKeyQuery);
            var result = await table.ExecuteQuerySegmentedAsync(fluentQuery, continuationToken);

            return new OkObjectResult(result.Select(x => new
            {
                Title = x.Title,
                Description= x.Description,
                Url = x.Url
            }));

        }
    }


    public class ImageEntry:TableEntity
    {
        public const string PartitionTitle = "Entry";
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int Tag { get;set; }

    }

    public class TagEntry : TableEntity
    {
        public const string PartitionTitle = "Tag";
        public string Title { get; set; }
    }
}
