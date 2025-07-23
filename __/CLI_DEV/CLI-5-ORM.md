### COMMON
```bash
dotnet ef database update -p ./GLOB/GLOB.Infra -s SBA.Hierarchy --connection "Server=.;Database=Hierarchy;User Id=sa;Password=P@55w0rd!123;Encrypt=false;TrustServerCertificate=True;"

dotnet ef migrations add Init -p ./GLOB/GLOB.Infra -s SBA.Hierarchy --context DBCtxInfra
dotnet ef migrations remove  -p ./GLOB/GLOB.Infra -s SBA.Hierarchz --context DBCtxInfra
dotnet ef database drop --force -p ./GLOB/GLOB.Infra -s SBA.Hierarchy --context DBCtxInfra
dotnet run --project SBA.Api
```
### JOB
```bash
dotnet ef migrations add Init -s ./Projects/SBA.Job --context DBCtxProjectz
dotnet ef database update -s ./Projects/SBA.Job --context DBCtxProjectz
dotnet ef migrations remove -s ./Projects/SBA.Job --context DBCtxProjectz
dotnet ef database drop --force -s ./Projects/SBA.Job --context DBCtxProjectz
```
### HIERARCHY
```bash
dotnet ef migrations add Init -s ./Projects/SBA.Hierarchy --context DBCtxProjectz
dotnet ef database update -s ./Projects/SBA.Hierarchy --context DBCtxProjectz
dotnet ef migrations remove -s ./Projects/SBA.Hierarcy --context DBCtxProjectz
dotnet ef database drop --force -s ./Projects/SBA.Hierarchy --context DBCtxProjectz
```
### AUTH
```bash
dotnet ef migrations add Init -s ./Projects/SBA.Auth --context DBCtxProjectz
dotnet ef database update -s ./Projects/SBA.Auth --context DBCtxProjectz
dotnet ef migrations remove -s ./Projects/SBA.Auth --context DBCtxProjectz
dotnet ef database drop --force -s ./Projects/SBA.Auth --context DBCtxProjectz
```

### USERSZ
```bash

```
### ORDERZ
```bash

```