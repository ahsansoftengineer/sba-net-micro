### SQL Server
- Local Dev
```bash
docker build -t sqlImage ./../SQL/Dockerfile
docker run -p 1430:1430 --name sqlserver -d sqlImage -v D:/sql/_1430:/var/opt/mssql -d custom-sqlserver
```
