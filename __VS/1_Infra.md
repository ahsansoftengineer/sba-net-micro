### Packages for Infra
```bash
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.Design
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.DynamicLinq
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.SqlServer
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.Tools

dotnet add ./GLOB.Infra/ package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add ./GLOB.Infra/ package Microsoft.AspNetCore.Authentication.OpenIdConnect

dotnet add ./GLOB.Infra/ package Microsoft.AspNetCore.Mvc.NewtonsoftJson
dotnet add ./GLOB.Infra/ package Microsoft.Extensions.Configuration
dotnet add ./GLOB.Infra/ package Microsoft.Extensions.Options.ConfigurationExtensions

dotnet add ./GLOB.Infra/ package DynamicExpressions.NET
dotnet add ./GLOB.Infra/ package LinqKit.Core
dotnet add ./GLOB.Infra/ package X.PagedList
dotnet add ./GLOB.Infra/ package X.PagedList.Mvc.Core

```


### DOCKER
```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker image ls
docker run -e 'HOMEBREW_NO_ENV_FILTERING=1' -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=asdf1234' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
docker container ls
docker ps
// Below Command Run After SQL Container Runs (Keys are Case Insensitive & their alternatives are available)


dotnet ef database update -p GLOB.Infrastructure -s SBA.Api --connection "server=localhost;Database=SBA;User Id=sa;password=asdf1234;TrustServerCertificate=true"
 // This Command won't work b/c of Certificate & Swagger (Run using f5)
```
### MIGRATION
```bash
dotnet tool install --global dotnet-ef
dotnet tool list --global


dotnet ef database add MigrationName --project GLOB.Infrastructure --startup-project SBA.Api --connection "SERVER=127.0.0.1,1433;DATABASE=SBA;USER=sa;PASSWORD=asdf1234;Encrypt=false"

# ADD
dotnet ef migrations add InitialCreate -p GLOB.Infrastructure -s SBA.Api
# REMOVE
dotnet ef migrations remove  -p GLOB.Infrastructure -s SBA.Api
# UPDATE
dotnet ef database update -p GLOB.Infrastructure -s SBA.Api --connection "Server=localhost;Database=SBA;User Id=sa;Password=asdf1234;Encrypt=false"
# RUN
dotnet run --project SBA.Api
```
### CURL COMMAND
- Undermentioned Commands only works with Bash
- Before Using that you have to Stop Https Middleware
- Running your app with http in Visual Studio
```bash
curl -X 'POST' 'http://localhost:5294/auth/register' -H 'accept: */*' -H 'Content-Type: Apps/json' -d '{   "firstName": "string", "lastName": "string", "email": "string", "password": "string" }'
curl -X 'POST' 'http://localhost:5294/auth/login' -H 'accept: */*' -H 'Content-Type: Apps/json' -d '{ "email": "string", "password": "string" }'
curl -X 'GET' 'http://localhost:5294/api/Dinners' -H 'accept: */*' -H 'Authorization: Bearer token.full.goeshere'
```