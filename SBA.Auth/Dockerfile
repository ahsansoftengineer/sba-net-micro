# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy only .csproj files first (to enable Docker caching of restore)
COPY GLOB.Domain/*.csproj ./GLOB.Domain/
COPY GLOB.Infra/*.csproj ./GLOB.Infra/
COPY GLOB.API.Config/*.csproj ./GLOB.API.Config/
COPY GLOB.API/*.csproj ./GLOB.API/
COPY SBA.Auth/*.csproj ./SBA.Auth/

# Restore dependencies
RUN dotnet restore ./SBA.Auth/SBA.Auth.csproj

# Copy the rest of the source files
COPY GLOB.Domain/ ./GLOB.Domain/
COPY GLOB.Infra/ ./GLOB.Infra/
COPY GLOB.API.Config/ ./GLOB.API.Config/
COPY GLOB.API/ ./GLOB.API/
COPY SBA.Auth/ ./SBA.Auth/

# Build and publish
WORKDIR /app/SBA.Auth
RUN dotnet publish -c Release -o /app/out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app/SBA.Auth

# Copy the published app from build stage
COPY --from=build-env /app/out .

# Runtime environment variables (can be overridden at runtime via CLI, Docker Compose, etc.)
ENV ASPNETCORE_URLS=http://+:5802
ENV DOTNET_ENVIRONMENT=Development
ENV ConnectionStrings__SqlConnection="Server=host.docker.internal,1433;Initial Catalog=SBA_Auth;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"

EXPOSE 5802

ENTRYPOINT [ "dotnet", "SBA.Auth.dll" ]

# ===========================================================
# Build:
# docker build -t mansanhhub/srvc-sba-auth -f SBA.Hierarchy/Dockerfile .
# docker push mansanhhub/srvc-sba-auth
# docker run -d --name srvc-sba-auth -p 5802:5802 -e DOTNET_ENVIRONMENT=Docker mansanhhub/srvc-sba-auth
# docker rm -f srvc-sba-auth
# docker exec -it <container_id> /bin/bash

# http://localhost:5802/api/hierarchy/v1/swagger/index.html
# http://localhost:5802/api/hierarchy/v1/_projectz-lookup/gets-lookup
