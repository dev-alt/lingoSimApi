using lingoSimApi;
using MongoDB.Driver;
using Azure.Security.KeyVault.Secrets;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string keyVaultURL = "https://lingosimsecrets.vault.azure.net/";
string keyVaultSecretName = "MongoString";

var client = new SecretClient(new Uri(keyVaultURL),
    new DefaultAzureCredential());

var secret = await client.GetSecretAsync(keyVaultSecretName);

builder.Services.AddControllers();

string connectionString = secret.Value.Value; // Get the secret value

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = MongoClientSettings.FromConnectionString(connectionString);
    return new MongoClient(settings);
});


builder.Services.AddScoped<IMongoDatabase>(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase("Quotes");
});

builder.Services.AddScoped<QuoteRepository, QuoteRepository>();
builder.Services.AddScoped<AuthorRepository, AuthorRepository>();



var app = builder.Build();

// Enable CORS
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();