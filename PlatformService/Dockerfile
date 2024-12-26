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
ENV ASPNETCORE_URLS=http://+:5101
ENV DOTNET_ENVIRONMENT=Docker
ENV CommandService=http://host.docker.internal:8101/api/c/platforms/
ENV ConnectionStrings__PlatformConn="Server=127.0.0.1,1430;Initial Catalog=PlatformDB;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"

# EXPOSE 5101
# # EXPOSE 5101 5102 5103 # Multiple Ports

ENTRYPOINT [ "dotnet", "PlatformService.dll"]