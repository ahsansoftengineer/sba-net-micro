### SQL Server
- Local Dev
```bash
docker build -t sql-image -f ./../SQL/Dockerfile ./../
docker run -p 1430:1433 --name sql-dockerfile -d sql-image
# docker run -p 1430:1430 --name sql-dockerfile -d -v D:/sql/_1430:/var/opt/mssql -d sql-image
```
### ENV
```json
"ConnectionStrings": {
  "PlatformConn": "Server=172.0.0.1,1430;Initial Catalog=platformsdb;User ID=sa;Password=Pa55w0rd!;TrustServerCertificate=true"
}
```

### Migration
```bash

```
