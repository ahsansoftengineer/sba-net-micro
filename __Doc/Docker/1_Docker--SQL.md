### Network
- Create Network
```bash
docker network create network-docker-a
docker network ls
docker network rm network-docker-a
```
### SQL Server
- Local Dev
```bash
docker build -t ahsansoftengineer/sql-image -f ../PlatformService/DockerfileSQL ../
docker push ahsansoftengineer/sql-image
docker run -p 1430:1433 --name docker-sql-z -d ahsansoftengineer/sql-image

docker run -p 1431:1433 --name docker-sql-a --network network-docker-a -d ahsansoftengineer/sql-image
# docker run -p 1433:1433 --name sql-dockerfile -d -v D:/sql/_1430:/var/opt/mssql -d sql-image
docker rm docker-sql-a -f
```
### ENV
```json
"ConnectionStrings": {
  "SbPlatform": "Server=127.0.0.1,1430;Initial Catalog=Platform;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"
}
```
### SSMS Connect
- 127.0.0.1,1430
- sa
- P@55w0rd!123

### Migration
```bash
dotnet ef migrations add Init_DB
dotnet ef database update 
dotnet ef migrations list
dotnet ef migrations remove
dotnet ef database drop --force
```
