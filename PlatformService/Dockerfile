FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build-env /app/out .

# Set the environment variable for ASP.NET Core
# Default Port of .Net Core is 5000 not 80
ENV ASPNETCORE_URLS=http://+:5101

# Set Env for Swagger & Developer Exception
ENV DOTNET_ENVIRONMENT=Docker

# No Default Port for Expose
EXPOSE 5101

ENTRYPOINT [ "dotnet", "PlatformService.dll"]

