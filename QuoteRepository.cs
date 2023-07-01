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

    public List<Quote> GetAllPhrases()
    {
        return _quoteCollection.Find(_ => true).ToList();
    }


    public List<Quote> SearchPhrasesByText(string searchText)
    {
        var filter = Builders<Quote>.Filter.Regex("text", new BsonRegularExpression(searchText, "i"));
        return _quoteCollection.Find(filter).ToList();
    }
    public Quote GetRandomPhrase(string language)
    {
        var random = new Random();
        var filter = Builders<Quote>.Filter.Eq("Language", language);
        var count = _quoteCollection.CountDocuments(filter);
        var randomIndex = random.Next(0, (int)count);
        return _quoteCollection.Find(filter).Skip(randomIndex).Limit(1).FirstOrDefault();
    }
}