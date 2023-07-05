using MongoDB.Bson;
using MongoDB.Driver;

namespace lingoSimApi;

public class PhraseRepository
{
    private readonly IMongoCollection<Phrase> _phraseCollection;

    public PhraseRepository(IMongoDatabase database)
    {
        _phraseCollection = database.GetCollection<Phrase>("quote");
    }

    public List<Phrase> GetAllPhrases()
    {
        return _phraseCollection.Find(_ => true).ToList();
    }
    public Phrase GetPhraseById(string id)
    {
        return _phraseCollection.Find(p => p.Id == id).FirstOrDefault();
    }

    public List<Phrase> SearchPhrasesByText(string searchText)
    {
        var filter = Builders<Phrase>.Filter.Regex("text", new BsonRegularExpression(searchText, "i"));
        return _phraseCollection.Find(filter).ToList();
    }
    public Phrase GetRandomPhrase(string language)
    {
        var random = new Random();
        var filter = Builders<Phrase>.Filter.Eq("Language", language);
        var count = _phraseCollection.CountDocuments(filter);
        var randomIndex = random.Next(0, (int)count);
        return _phraseCollection.Find(filter).Skip(randomIndex).Limit(1).FirstOrDefault();
    }
}