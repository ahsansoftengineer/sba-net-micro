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
  commandservice-b:
    build:
      context: .
      dockerfile: Dockerfile
    image: ahsansoftengineer/commandservice-b
    container_name: commandservice-b
    environment:
      - ASPNETCORE_URLS=http://+:8201
      - DOTNET_ENVIRONMENT=DockerCompose
    ports:
      - "8201:8201" # Map host port 8201 to container port 8201
```

### Docker Compose CLI
```bash
docker-compose up -d --build
docker-compose down
```

### ROUTE (Docker Port Mapping)
- http://localhost:8201/swagger/index.html
- http://localhost:8201/api/c/platform POST

