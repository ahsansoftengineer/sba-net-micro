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

# ENV ASPNETCORE_URLS=http://+:8101
# ENV DOTNET_ENVIRONMENT=Docker
# EXPOSE 8101

ENTRYPOINT [ "dotnet", "CommandsService.dll"]
```
### Docker Run Without Port & Env
```bash
docker build -t ahsansoftengineer/commandservice-a -f ./../CommandsService/Dockerfile ./../CommandsService
docker push ahsansoftengineer/commandservice-a
docker run
docker run -d --name commandsservice -p 8101:8101 -e ASPNETCORE_URLS=http://+:8101  -e DOTNET_ENVIRONMENT=Docker ahsansoftengineer/commandservice-a

docker exec -it d2d4
```
### appsettings.json
```json
{
  "No JSON":""
}
```