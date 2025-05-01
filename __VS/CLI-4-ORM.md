### COMMON
```bash
dotnet ef database update -p GLOB.Infra -s SBA.Hierarchy --connection "Server=.;Database=Hierarchy;User Id=sa;Password=P@55w0rd!123;Encrypt=false;TrustServerCertificate=True;"

dotnet ef migrations add Init -p GLOB.Infra -s SBA.Hierarchy --context DBCtx
dotnet ef migrations remove  -p GLOB.Infra -s SBA.Hierarchz --context DBCtx
dotnet ef database drop --force -p GLOB.Infra -s SBA.Hierarchy --context DBCtx
dotnet run --project SBA.Api
```
### HIERARCHY
```bash
dotnet ef migrations add Init -s SBA.Hierarchy --context DBCtxProjectz
dotnet ef database update -s SBA.Hierarchy --context DBCtxProjectz
dotnet ef migrations remove -s SBA.Hierarchy --context DBCtxProjectz
dotnet ef database drop --force -s SBA.Hierarchy --context DBCtxProjectz
```
### AUTH
```bash
dotnet ef migrations add Init -s SBA.Auth --context DBCtxProjectz
dotnet ef database update -s SBA.Auth --context DBCtxProjectz
dotnet ef migrations remove -s SBA.Auth --context DBCtxProjectz
dotnet ef database drop --force -s SBA.Auth --context DBCtxProjectz
```

### USERSZ
```bash

```
### ORDERZ
```bash

```