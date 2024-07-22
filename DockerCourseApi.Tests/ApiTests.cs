using System.Net;
using FluentAssertions;

namespace DockerCourseApi.Tests;

public class ApiTests
{
    [Fact]
    public async Task GetRequestToPodcatsSimpleEndpointShouldReturnOk()
    {
        var httpClient = new CustomWebApplicationFactory().CreateClient();

        var response = await httpClient.GetAsync("/podcasts-simple");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task GetRequestToPodcatsEndpointShouldReturnOk()
    {
        var httpClient = new CustomWebApplicationFactory().CreateClient();

        var response = await httpClient.GetAsync("/podcasts");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
