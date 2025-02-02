
### Other Commands
```bash
dotnet ef database update -p GLOB.Infra -s SBA.Hierarchy --connection "Server=localhost;Database=SBA;User Id=sa;Password=asdf1234;Encrypt=false"

```
### Migration Auth
### Migration Hierarchy
```bash
dotnet ef migrations add Init -s SBA.Hierarchy --context AppDBContextProj
dotnet ef migrations remove -s SBA.Hierarchy
dotnet ef database update -s SBA.Hierarchy
dotnet run --project SBA.Hierarchy
```
### Migration Userz
### Migration Orderz
