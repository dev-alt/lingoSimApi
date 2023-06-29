# lingoSimApi

Cosmos DB Connected ASP.NET Core API

This API is built using ASP.NET Core and connects to an Azure Cosmos DB MongoDB API to store and serve data.
Features

    Built using ASP.NET Core
    Securely connects to Cosmos DB MongoDB API
    Exposes HTTP API endpoints to serve Cosmos DB data
    Uses best practices for scalability, security and performance
    Utilizes Entity Framework Core to map to Cosmos DB collections
    Automated deployment via Azure Pipelines
    Monitored for issues and load tested before release

Technology Stack

    ASP.NET Core
    Entity Framework Core
    MongoDB Driver
    Cosmos DB
    Azure App Service
    Azure DevOps

Usage

Clone or fork this repo. Update the appsettings.json with your Cosmos DB and Azure App Service configuration.

Build and run the API locally:

dotnet build
dotnet run

Publish to Azure App Service:

dotnet publish

Trigger the Azure Pipelines release to deploy to Azure.
Architecture

The API project connects to Cosmos DB MongoDB API to store and retrieve data. It exposes HTTP API endpoints using ASP.NET Core Controllers. Before publishing, environment variables are used for secrets and the firewall is restricted. Azure Pipelines is used for automated deployments to Azure App Service.
TODO

    Add more API endpoints
    Implement additional features
    Refactor for improved design
