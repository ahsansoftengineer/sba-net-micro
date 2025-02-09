### COMMON
```bash
dotnet ef database update -p GLOB.Infra -s SBA.Hierarchy --connection "Server=.;Database=Hierarchy;User Id=sa;Password=P@55w0rd!123;Encrypt=false;TrustServerCertificate=True;"

dotnet ef migrations add Init -p GLOB.Infra -s SBA.Hierarchy --context AppDBContextz
dotnet ef migrations remove  -p GLOB.Infra -s SBA.Hierarchz --context AppDBContextz
dotnet ef database drop --force -p GLOB.Infra -s SBA.Hierarchy --context AppDBContextz
dotnet run --project SBA.Api
```
### HIERARCHY
```bash
dotnet ef migrations add Init -s SBA.Hierarchy --context AppDBContextProj
dotnet ef database update -s SBA.Hierarchy --context AppDBContextProj
dotnet ef migrations remove -s SBA.Hierarchy --context AppDBContextProj
dotnet ef database drop --force -s SBA.Hierarchy --context AppDBContextProj
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