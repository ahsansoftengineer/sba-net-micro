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
ENV ASPNETCORE_URLS=http://+:8101
ENV DOTNET_ENVIRONMENT=Docker
ENV ConnectionStrings__SbPlatform=Server=127.0.0.1,1431;Initial Catalog=PlatformDB;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;

EXPOSE 8101

ENTRYPOINT [ "dotnet", "CommandsService.dll"]

## Docker Run Without Port & Env
# docker build -t ahsansoftengineer/commandservice-a -f ../CommandsService/Dockerfile ../CommandsService
# docker push ahsansoftengineer/commandservice-a
## docker run
# docker run -d --name commandservice-a -p 8101:8101 -e DOTNET_ENVIRONMENT=Docker ahsansoftengineer/commandservice-a
# docker rm -f commandservice-a
# # docker exec -it d2d4 # Not Working Get Inside Container

# ### ROUTE (Docker Port Mapping)
# - http://localhost:8101/swagger/index.html
# - http://localhost:8101/api/c/platforms POST