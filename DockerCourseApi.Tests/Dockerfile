FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY DockerCourseApi.Tests/DockerCourseApi.Tests.csproj DockerCourseApi.Tests/
RUN dotnet restore DockerCourseApi.Tests/DockerCourseApi.Tests.csproj
COPY . .
RUN dotnet test DockerCourseApi.Tests/DockerCourseApi.Tests.csproj
