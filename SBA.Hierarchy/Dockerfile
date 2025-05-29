# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy only required projects
COPY GLOB.Domain/ ./GLOB.Domain/
COPY GLOB.Infra/ ./GLOB.Infra/
COPY GLOB.API.Config/ ./GLOB.API.Config/
COPY GLOB.API/ ./GLOB.API/
COPY SBA.Hierarchy/ ./SBA.Hierarchy/

# Set working directory to the main project
WORKDIR /app/SBA.Hierarchy

# Restore & publish
RUN dotnet restore
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app/SBA.Hierarchy
COPY --from=build-env /app/out .

# SETUP (PORT & ENV) THROUGH (CLI, DOCKER-COMPOSE, K8S)
ENV ASPNETCORE_URLS=http://+:5806
ENV DOTNET_ENVIRONMENT=Docker

EXPOSE 5806

ENTRYPOINT [ "dotnet", "SBA.Hierarchy.dll"]

## Docker Run Without Port & Env
# docker build -t ahsansoftengineer/srvc-sba-hierarchy -f SBA.Hierarchy/Dockerfile .
# docker push ahsansoftengineer/srvc-sba-hierarchy
## docker run
# docker run -d --name srvc-sba-hierarchy -p 5806:5806 -e DOTNET_ENVIRONMENT=Docker ahsansoftengineer/srvc-sba-hierarchy
# docker rm -f srvc-sba-hierarchy
# # docker exec -it bbf /bin/bash # CMD (Not Bash)

# ### ROUTE (Docker Port Mapping)
# - http://localhost:5806/api/hierarchy/v1/swagger/index.html
# - http://localhost:5806/api/hierarchy/v1/_global-lookup/gets-lookup