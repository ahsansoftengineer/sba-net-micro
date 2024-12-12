```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expose the port
# No Default Port for Expose
EXPOSE 5000

ENTRYPOINT [ "dotnet", "PlatformService.dll"]
```

```yml
version: '3.8'
services:
  webapp:
    image: your-image-name
    build:
      context: .
      dockerfile: Dockerfile
    ports:
      - "5000:5000"  # Maps host port 9999 to container port 9999
    environment:
      - ASPNETCORE_URLS=http://+:5000  # Configures the app to listen on all network interfaces
      - DOTNET_ENVIRONMENT=Development  # Optional: Sets the environment for .NET Core
```