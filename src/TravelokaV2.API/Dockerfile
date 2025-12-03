# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/TravelokaV2.API/TravelokaV2.API.csproj", "src/TravelokaV2.API/"]
COPY ["src/TravelokaV2.Application/TravelokaV2.Application.csproj", "src/TravelokaV2.Application/"]
COPY ["src/TravelokaV2.Domain/TravelokaV2.Domain.csproj", "src/TravelokaV2.Domain/"]
COPY ["src/TravelokaV2.Infrastructure/TravelokaV2.Infrastructure.csproj", "src/TravelokaV2.Infrastructure/"]
RUN dotnet restore "./src/TravelokaV2.API/TravelokaV2.API.csproj"
COPY . .
WORKDIR "/src/src/TravelokaV2.API"
RUN dotnet build "./TravelokaV2.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TravelokaV2.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelokaV2.API.dll"]