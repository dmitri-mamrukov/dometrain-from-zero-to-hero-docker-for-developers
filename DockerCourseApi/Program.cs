using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.Configure<Settings>(builder.Configuration);

var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin());

app.MapGet("/podcasts-simple", () => new List<string>
{
    "Unhandled Exception Podcast",
    "Developer Weekly Podcast",
    "The Stack Overflow Podcast",
    "The Hanselminutes Podcast",
    "The .NET Rocks Podcast",
    "The Azure Podcast",
    "The AWS Podcast",
    "The Rabbit Hole Podcast",
    "The .NET Core Podcast"
});

app.MapGet("/podcasts", async (IOptions<Settings> settings) =>
{
    var connString = settings.Value.ConnectionString;
    System.Console.WriteLine("Connecting DB: {0}", connString);
    var connection = new SqlConnection(connString);

    return (await connection.QueryAsync<Podcast>("SELECT * FROM Podcasts")).Select(x => x.Title);
});

app.Run();

record Podcast(Guid Id, string Title);

public partial class Program
{
}
