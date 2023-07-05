using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace lingoSimApi.Controllers
{
    public class TestConnection : Controller
    {
        //private readonly CosmosClient _cosmosClient;
        //private readonly CosmosDbSettings _cosmosDbSettings;

        //public TestConnection(CosmosClient cosmosClient, IOptions<CosmosDbSettings> cosmosDbSettings)
        //{
        //    _cosmosClient = cosmosClient;
        //    _cosmosDbSettings = cosmosDbSettings.Value;
        //}


        //[HttpGet]
        //public async Task<IActionResult> GetData()
        //{
        //    var databaseId = _cosmosDbSettings.DatabaseId;
        //    var containerId = _cosmosDbSettings.ContainerId;
        //    var container = _cosmosClient.GetContainer(databaseId, containerId);

        //    var queryText = "SELECT * FROM c"; // Modify the query as per your data model
        //    var queryDefinition = new QueryDefinition(queryText);
        //    var queryResultSetIterator = container.GetItemQueryIterator<dynamic>(queryDefinition);

        //    var results = new List<dynamic>();
        //    while (queryResultSetIterator.HasMoreResults)
        //    {
        //        var response = await queryResultSetIterator.ReadNextAsync();
        //        results.AddRange(response.ToList());
        //    }

        //    return Ok(results);
        //}
    }
}
