using MongoDB.Driver;

namespace lingoSimApi;

public class MongoDbService : ICosmosDbService
{
    private readonly IMongoClient _client;
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<Quote> _collection;

    public MongoDbService(MongoClient client)
    {
        _client = client;
        _database = _client.GetDatabase("Quotes");
        _collection = _database.GetCollection<Quote>("quote");
    }

    public async Task<IReadOnlyList<Quote>> GetQuotes()
    {
        var collection = _database.GetCollection<Quote>("quote");

        var quotes = await collection.Find(_ => true).ToListAsync();

        return quotes;
    }

    public Task<Quote> GetQuote(string id)
    {
        throw new NotImplementedException();
    }

    public Task AddQuote(Quote quote)
    {
        throw new NotImplementedException();
    }

    public Task UpdateQuote(Quote quote)
    {
        throw new NotImplementedException();
    }

    public Task DeleteQuote(string id)
    {
        throw new NotImplementedException();
    }
}