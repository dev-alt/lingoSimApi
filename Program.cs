using lingoSimApi;
using MongoDB.Driver;
using System.Configuration;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.DependencyInjection;
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

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
