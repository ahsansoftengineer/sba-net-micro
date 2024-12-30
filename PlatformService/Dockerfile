FROM mcr.microsoft.com/dotnet/sdk:9.0 AS base
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=base /app/out .

# OVERRIDE (PORT & ENV) THROUGH (CLI, DOCKER-COMPOSE, K8S)
ENV ASPNETCORE_URLS http://+:5101
ENV DOTNET_ENVIRONMENT Docker
ENV CommandService http://host.docker.internal:8101/api/c/platforms/
ENV ConnectionStrings__SbPlatform "Server=host.docker.internal,1433;Initial Catalog=PlatformDB;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"

# EXPOSE 5101
# # EXPOSE 5101 5102 5103 # Multiple Ports

ENTRYPOINT [ "dotnet", "PlatformService.dll"]

## SQL CONTAINER
# docker run -p 1431:1433 --name ms-sql-a -d mcr.microsoft.com/mssql/server:2022-latest

### Migration
# - Before Runing Container Run Sql Container & Migrations

## DOCKER RUNNING
# docker build -t ahsansoftengineer/platformservice-a -f ../PlatformService/Dockerfile ../PlatformService
# docker push ahsansoftengineer/platformservice-a
# --network network-docker-a 
# docker run -d --name platformservice-a -p 5101:5101 -e DOTNET_ENVIRONMENT=Docker ahsansoftengineer/platformservice-a

# docker rm -f platformservice-a
# docker exec -it d2d4 # Not Working Get Inside Container

# ### ROUTE (Docker Port Mapping)
# - http://localhost:5101/swagger/index.html
# - http://localhost:5101/api/platform
# - http://localhost:5101/api/platform/1

# ### InterService Comm (Docker Host IP Name)
# - http://host.docker.internal:8101/api/c/platforms/