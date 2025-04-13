FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY DockerCourseFrontend/DockerCourseFrontend.csproj DockerCourseFrontend/
RUN dotnet restore DockerCourseFrontend/DockerCourseFrontend.csproj
COPY . .
WORKDIR /src/DockerCourseFrontend
RUN dotnet build DockerCourseFrontend.csproj --configuration Release --output /app/build

FROM build AS publish
RUN dotnet publish DockerCourseFrontend.csproj --configuration Release --output /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerCourseFrontend.dll"]
