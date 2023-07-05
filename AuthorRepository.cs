using MongoDB.Bson;
using MongoDB.Driver;

namespace lingoSimApi;

public class AuthorRepository
{
    private readonly IMongoCollection<Author> _authorCollection;

    public AuthorRepository(IMongoDatabase database)
    {
        _authorCollection = database.GetCollection<Author>("authors");
    }

    public async Task<IEnumerable<Author>> GetAllAuthors()
    {
        return await _authorCollection.Find(_ => true).ToListAsync();
    }

    public async Task<Author> GetAuthorById(ObjectId id)
    {
        var filter = Builders<Author>.Filter.Eq(q => q.Id, id);
        return await _authorCollection.Find(filter).FirstOrDefaultAsync();
    }
    public async Task CreateAuthor(Author author)
    {
        await _authorCollection.InsertOneAsync(author);
    }

    public async Task UpdateAuthor(ObjectId id, Author updatedAuthor)
    {
        await _authorCollection.ReplaceOneAsync(author => author.Id == id, updatedAuthor);
    }

    public async Task DeleteAuthor(ObjectId id)
    {
        await _authorCollection.DeleteOneAsync(author => author.Id == id);
    }
}