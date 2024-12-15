### Dockerfile
- The Env Variable provided in Docker-Compose File
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
EXPOSE 5201

ENTRYPOINT [ "dotnet", "PlatformService.dll"]
```
### Docker Compose
```yml
version: '3.8'
services:
  webapp:
    image: ahsansoftengineer/platformservice-a
    build:
      context: .
      dockerfile: Dockerfile
    ports:
      - "5201:5201"  # Maps host port 9999 to container port 9999
    environment:
      - ASPNETCORE_URLS=http://+:5201  # Configures the app to listen on all network interfaces
      - DOTNET_ENVIRONMENT=Development  # Optional: Sets the environment for .NET Core
```

### Docker Compose CLI
```bash
docker-compose up -d --build
docker-compose up -p 5301:5301 -e ASPNETCORE_URLS=http://+:5301  -e DOTNET_ENVIRONMENT=Development -d --build

````