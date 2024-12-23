### SQL Server
- Local Dev
```bash
docker build -t sql-image -f ./../SQL/Dockerfile ./../
docker push sql-image
docker run -p 1433:1433 --name sql-dockerfile -d sql-image
# docker run -p 1430:1430 --name sql-dockerfile -d -v D:/sql/_1430:/var/opt/mssql -d sql-image
docker stop sql-dockerfile
docker rm sql-dockerfile
```
### ENV
```json
"ConnectionStrings": {
  "PlatformConn": "Server=127.0.0.1,1430;Initial Catalog=platformsdb;User ID=sa;Password=Pa55w0rd!;TrustServerCertificate=true"
}
```
### SSMS Connect
- 127.0.0.1,1430
- sa
- Pa55w0rd!

### Migration
```bash

```
