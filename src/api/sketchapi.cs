using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
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
            string queryString = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, TagEntry.PartitionTitle);
            var fluentQuery = new TableQuery<TagEntry>().Where(queryString);
            var result = await table.ExecuteQuerySegmentedAsync(fluentQuery, continuationToken);

            return new OkObjectResult(result.Select(x=>x.Title));

        }
    }


    public class ImageEntry:TableEntity
    {
        public const string PartitionTitle = "Entry";
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Tags { get;set; }

    }

    public class TagEntry : TableEntity
    {
        public const string PartitionTitle = "Tag";
        public string Title { get; set; }
    }
}
