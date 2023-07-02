using MongoDB.Bson;
using MongoDB.Driver;

namespace lingoSimApi;

public class QuoteRepository
{
    private readonly IMongoCollection<Quote> _quoteCollection;

    public QuoteRepository(IMongoDatabase database)
    {
        _quoteCollection = database.GetCollection<Quote>("quote");
    }

    public List<Quote> GetQuotes()
    {
        return _quoteCollection.Find(_ => true).ToList();
    }
    public async Task<IEnumerable<Quote>> GetAllQuotes()
    {
        return await _quoteCollection.Find(_ => true).ToListAsync();
    }
    public async Task<Quote> GetQuoteById(ObjectId id)
    {
        var filter = Builders<Quote>.Filter.Eq(q => q.Id, id);
        return await _quoteCollection.Find(filter).FirstOrDefaultAsync();
    }


    public async Task<long> GetQuotesCount()
    {
        var count = await _quoteCollection.CountDocumentsAsync(_ => true);
        return count;
    }
    
    public async Task<Quote> GetQuoteByIndex(int index)
    {
        var quotes = await _quoteCollection.Find(_ => true).Skip(index).Limit(1).ToListAsync();
        return quotes.FirstOrDefault();
    }
}