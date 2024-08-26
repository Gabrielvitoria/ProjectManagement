# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 44367
ENV ASPNETCORE_URLS=http://*:44367
ENV ASPNETCORE_ENVIRONMENT="Development"

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
COPY . ./src
WORKDIR /src
COPY ["ProjectManagement/ProjectManagement.csproj", "ProjectManagement"]
COPY ["ProjectManagement.Common/ProjectManagement.Common.csproj", "ProjectManagement.Common"]
COPY ["ProjectManagement.Domain/ProjectManagement.Domain.csproj", "ProjectManagement.Domain"]
COPY ["ProjectManagement.Infra/ProjectManagement.Infra.csproj", "ProjectManagement.Infra"]
COPY ["ProjectManagement.Services/ProjectManagement.Services.csproj", "ProjectManagement.Services"]
COPY ["ProjectManagement.Tests/ProjectManagement.Tests.csproj", "ProjectManagement.Tests"]

RUN dotnet restore "ProjectManagement/ProjectManagement.csproj"
COPY . .
WORKDIR "/src/ProjectManagement"
RUN dotnet build "ProjectManagement.csproj" -c Release -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
RUN dotnet publish "ProjectManagement.csproj" -c Release -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectManagement.dll"]