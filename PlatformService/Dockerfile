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