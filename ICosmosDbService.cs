namespace lingoSimApi;

public interface ICosmosDbService
{
    Task<IReadOnlyList<Quote>> GetQuotes();
    Task<Quote> GetQuote(string id);
    Task AddQuote(Quote quote);
    Task UpdateQuote(Quote quote);
    Task DeleteQuote(string id);
}