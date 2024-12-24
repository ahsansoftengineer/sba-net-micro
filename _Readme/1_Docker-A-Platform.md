### Dockerfile
- Env, Port & Expose can also be supplied using CLI
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

# SETUP (PORT & ENV) THROUGH (CLI, DOCKER-COMPOSE, K8S)
# ENV ASPNETCORE_URLS=http://+:5101
# ENV DOTNET_ENVIRONMENT=Docker
# ENV CommandService=http://host.docker.internal:8101/api/c/platforms/

# EXPOSE 5101
# # EXPOSE 5101 5102 5103 # Multiple Ports

ENTRYPOINT [ "dotnet", "PlatformService.dll"]
```



### appsettings.Docker.json
- YOU can use local host when both app inside same container
- YOU have to create docker network TO NOT USE http://host.docker.internal
- YOU cannot use localhost:8101
```json
{
  "CommandService": "http://host.docker.internal:8101/api/c/platforms/"
}
```
### Migration
- Before Runing Container Run Sql Container & Migrations

### Docker run
```bash
docker build -t ahsansoftengineer/platformservice-a -f ./../PlatformService/Dockerfile ./../PlatformService
docker push ahsansoftengineer/platformservice-a
# docker run
docker run -d --name platformservice-a -p 5101:5101  --network network-docker-a -e ASPNETCORE_URLS=http://+:5101  -e DOTNET_ENVIRONMENT=Docker -e ConnectionStrings__PlatformConn="Server=docker-sql-a,1433;Initial Catalog=PlatformA;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;" ahsansoftengineer/platformservice-a

docker rm -f platformservice-a
# docker exec -it d2d4 # Not Working Get Inside Container
```

### ROUTE (Docker Port Mapping)
- http://localhost:5101/swagger/index.html
- http://localhost:5101/api/platform
- http://localhost:5101/api/platform/1

### InterService Comm (Docker Host IP Name)
- http://host.docker.internal:8101/api/c/platforms/
