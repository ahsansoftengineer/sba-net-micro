# ===========================================================
# Build:
# docker build -t mansanhhub/srvc-sba-hierarchy -f SBA.Hierarchy/Dockerfile .
# docker push mansanhhub/srvc-sba-hierarchy
# docker run -d --name srvc-sba-hierarchy -p 1106:1106 -e DOTNET_ENVIRONMENT=Docker mansanhhub/srvc-sba-hierarchy
# docker rm -f srvc-sba-hierarchy
# docker exec -it <container_id> /bin/bash

# http://localhost:1106/api/hierarchy/v1/swagger/index.html
# http://localhost:1106/api/hierarchy/v1/_projectz-lookup/gets-lookup

# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy only .csproj files first (to enable Docker caching of restore)
COPY GLOB.API.Config/*.csproj ./GLOB.API.Config/
COPY GLOB.Domain/*.csproj ./GLOB.Domain/
COPY GLOB.Infra/*.csproj ./GLOB.Infra/
COPY GLOB.API/*.csproj ./GLOB.API/
COPY SBA.Hierarchy/*.csproj ./SBA.Hierarchy/

# Restore dependencies
RUN dotnet restore ./SBA.Hierarchy/SBA.Hierarchy.csproj

# Copy the rest of the source files
COPY GLOB.API.Config/ ./GLOB.API.Config/
COPY GLOB.Domain/ ./GLOB.Domain/
COPY GLOB.Infra/ ./GLOB.Infra/
COPY GLOB.API/ ./GLOB.API/
COPY SBA.Hierarchy/ ./SBA.Hierarchy/

# Build and publish
WORKDIR /app/SBA.Hierarchy
RUN dotnet publish -c Release -o /app/out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app/SBA.Hierarchy

# Copy the published app from build stage
COPY --from=build-env /app/out .

# Runtime environment variables (can be overridden at runtime via CLI, Docker Compose, etc.)
ENV ASPNETCORE_URLS=http://+:1106
ENV DOTNET_ENVIRONMENT=Docker
ENV ConnectionStrings__SqlConnection="Server=host.docker.internal,1433;Initial Catalog=SBA_Hierarchy;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"

# Cannot do this
# Need Network for this
# ENV Httpz__Auth=http://srvc-auth:1102/api/auth/v1

EXPOSE 1106

ENTRYPOINT [ "dotnet", "SBA.Hierarchy.dll" ]


