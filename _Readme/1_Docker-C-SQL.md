### SQL Server
- Local Dev
```bash
docker build -t sql-image -f ./../PlatformService/DockerfileSQL ./../
docker push sql-image
docker run -p 1430:1433 --name sql-dockerfile -d sql-image
# docker run -p 1433:1433 --name sql-dockerfile -d -v D:/sql/_1430:/var/opt/mssql -d sql-image
docker stop sql-dockerfile
docker rm sql-dockerfile
```
### ENV
```json
"ConnectionStrings": {
  "PlatformConn": "Server=127.0.0.1,1430;Initial Catalog=platformsdb;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"
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
