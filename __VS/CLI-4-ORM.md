### COMMON
```bash
otnet ef migrations add Init -p GLOB.Infra -s SBA.Hierarchy --context DBCntx
dotnet ef database update -p GLOB.Infra -s SBA.Hierarchy --connection "Server=.;Database=Hierarchy;User Id=sa;Password=P@55w0rd!123;Encrypt=false;TrustServerCertificate=True;"
dotnet ef migrations remove  -p GLOB.Infra -s SBA.Hierarchz
dotnet ef database drop --force -p SBA.Infra -s GLOB.Hierarchy
dotnet run --project SBA.Api
```
### HIERARCHY
```bash
dotnet ef migrations add Init -s SBA.Hierarchy
dotnet ef database update -s SBA.Hierarchy
```

### AUTH
```bash

```

### USERSZ
```bash

```
### ORDERZ
```bash

```