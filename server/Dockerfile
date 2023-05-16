# Dockerfile for backend service
# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /src

# Copy and restore project files
COPY src/TradieApp.Api/*.csproj TradieApp.Api/
COPY src/TradieApp.Application/*.csproj TradieApp.Application/
COPY src/TradieApp.Domain/*.csproj TradieApp.Domain/
COPY src/TradieApp.Infrastructure/*.csproj TradieApp.Infrastructure/
COPY src/TradieApp.Presentation/*.csproj TradieApp.Presentation/
RUN dotnet restore "TradieApp.Api/TradieApp.Api.csproj"

# Copy the rest of the source code and build
COPY src/ ./
RUN dotnet publish -c Release -o /publish TradieApp.Api/TradieApp.Api.csproj

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build-env /publish .

# Start the application
ENTRYPOINT ["dotnet", "TradieApp.Api.dll"]
