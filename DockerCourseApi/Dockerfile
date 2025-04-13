FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY DockerCourseApi/DockerCourseApi.csproj DockerCourseApi/
RUN dotnet restore DockerCourseApi/DockerCourseApi.csproj
COPY . .
WORKDIR /src/DockerCourseApi
RUN dotnet build DockerCourseApi.csproj --configuration Release --output /app/build

FROM build AS publish
WORKDIR /src/DockerCourseApi
RUN dotnet publish DockerCourseApi.csproj --configuration Release --output /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerCourseApi.dll"]
