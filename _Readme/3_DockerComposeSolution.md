### Dockerfile PlatformService
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
### PlatformService appsettings.DockerComposeSolution.json
```json
{
  "CommandService": "http://commandsservice:8301/api/c/platforms/"
}
```
### Dockerfile CommandsService
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

ENTRYPOINT [ "dotnet", "CommandsService.dll"]
```
### Docker Compose
```yml
version: "3.9"

services:
  platformservice:
    build:
      context: ./PlatformService/
      dockerfile: DockerfileCompose
    image: ahsansoftengineer/platformservice-c
    container_name: platformservice-c
    environment:
      - ASPNETCORE_URLS=http://+:5301
      - DOTNET_ENVIRONMENT=DockerComposeSolution
    ports:
      - "5301:5301" 
    networks:
      - app-network

  commandsservice:
    build:
      context: ./CommandsService/
      dockerfile: DockerfileCompose
    image: ahsansoftengineer/commandservice-c
    container_name: commandservice-c
    environment:
      - ASPNETCORE_URLS=http://+:8301
      - DOTNET_ENVIRONMENT=DockerComposeSolution
    ports:
      - "8301:8301"
    networks:
      - app-network

networks:
  app-network:
    driver: bridge

```

### Docker Compose CLI
```bash
docker-compose up -d --build
```