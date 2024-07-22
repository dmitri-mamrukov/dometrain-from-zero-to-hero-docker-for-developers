using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace DockerCourseApi.Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    // To find the database container's IP address.
    //
    // docker ps --all (get ContainerID or ContainerName)
    // docker inspect --format "{{range.NetworkSettings.Networks}}{{.IPAddress}}{{end}}" <ContainerID | ContainerName>
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(configBuilder =>
        {
            configBuilder.AddInMemoryCollection(new[]
            {
                new KeyValuePair<string, string?>(
                    "ConnectionString",
                    "Server=172.18.0.1;Initial Catalog=podcasts;Persist Security Info=False;User ID=sa;Password=Dometrain#123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=10;"),
            });
        });
    }
}
