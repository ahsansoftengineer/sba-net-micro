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
ENTRYPOINT [ "dotnet", "PlatformService.dll"]
```
### Docker Compose
```yml
version: "3.9"

services:
  platformservice:
    build:
      context: .
      dockerfile: Dockerfile
    image: ahsansoftengineer/platformservice-b
    container_name: platformservice-b
    environment:
      - ASPNETCORE_URLS=http://+:5201
      - DOTNET_ENVIRONMENT=DockerCompose
    ports:
      - "5201:5201" # Map host port 5201 to container port 5201
```

### Docker Compose CLI
```bash
docker-compose up -d --build
docker-compose up -d --build -p 5201:5201 -e ASPNETCORE_URLS=http://+:5201  -e DOTNET_ENVIRONMENT=Development

```

### appsettings.DockerComposeSolution.json
```json
{
  "CommandService": "http://host.docker.internal:8201/api/c/platforms/"
}
```