using MongoDB.Bson;
using MongoDB.Driver;

namespace lingoSimApi;

public class QuoteRepository
{
    private readonly IMongoCollection<Quote> _quoteCollection;
    private readonly IMongoCollection<Author> _authorCollection;

    public QuoteRepository(IMongoDatabase database)
    {
        _quoteCollection = database.GetCollection<Quote>("quote");
        _authorCollection = database.GetCollection<Author>("author");

    }

    public List<Quote> GetQuotes()
    {
        var lookupPipeline = new BsonDocument("$lookup",
            new BsonDocument
            {
                { "from", "author" },
                { "localField", "authorId" },
                { "foreignField", "_id" },
                { "as", "author" }
            });

        var unwindPipeline = new BsonDocument("$unwind", "$author");

        var projectionPipeline = new BsonDocument("$project",
            new BsonDocument
            {
                { "_id", 1 },
                { "text", 1 },
                { "meaning", 1 },
                { "explanation", 1 },
                { "language", 1 },
                { "author._id", 1 },
                { "author.name", 1 }
            });

        var aggregatePipeline = new[] { lookupPipeline, unwindPipeline, projectionPipeline };

        return _quoteCollection.Aggregate<Quote>(aggregatePipeline).ToList();
    }

    public List<Quote> GetAllPhrases()
    {
        return _quoteCollection.Find(_ => true).ToList();
    }
    public Quote GetPhraseById(string id)
    {
        return _quoteCollection.Find(p => p.Id == id).FirstOrDefault();
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