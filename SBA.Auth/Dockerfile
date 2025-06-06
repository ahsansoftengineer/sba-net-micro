# ===========================================================
# Build:
# docker build -t mansanhhub/srvc-sba-auth -f SBA.Hierarchy/Dockerfile .
# docker push mansanhhub/srvc-sba-auth
# docker run -d --name srvc-sba-auth -p 1102:1102 -e DOTNET_ENVIRONMENT=Docker mansanhhub/srvc-sba-auth
# docker rm -f srvc-sba-auth
# docker exec -it <container_id> /bin/bash

# http://localhost:1102/api/hierarchy/v1/swagger/index.html
# http://localhost:1102/api/hierarchy/v1/_projectz-lookup/gets-lookup


# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy only .csproj files first (to enable Docker caching of restore)
COPY GLOB/GLOB.API.Config/*.csproj ./GLOB/GLOB.API.Config/
COPY GLOB/GLOB.Domain/*.csproj ./GLOB/GLOB.Domain/
COPY GLOB/GLOB.Infra/*.csproj ./GLOB/GLOB.Infra/
COPY GLOB/GLOB.API/*.csproj ./GLOB/GLOB.API/
COPY SBA.Auth/*.csproj ./SBA.Auth/

# Restore dependencies
RUN dotnet restore ./SBA.Auth/SBA.Auth.csproj

# Copy the rest of the source files
COPY GLOB/GLOB.API.Config/ ./GLOB/GLOB.API.Config/
COPY GLOB/GLOB.Domain/ ./GLOB/GLOB.Domain/
COPY GLOB/GLOB.Infra/ ./GLOB/GLOB.Infra/
COPY GLOB/GLOB.API/ ./GLOB/GLOB.API/
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
ENV ASPNETCORE_URLS=http://+:1102
ENV DOTNET_ENVIRONMENT=Docker
ENV ConnectionStrings__SqlConnection="Server=host.docker.internal,1433;Initial Catalog=SBA_Auth;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"

EXPOSE 1102

ENTRYPOINT [ "dotnet", "SBA.Auth.dll" ]