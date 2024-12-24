### Migration for Single Project
```bash
dotnet tool list --global
dotnet tool install --global dotnet-ef -v 9.0
Install-Package Microsoft.EntityFrameworkCore.Tools # Power Shell
dotnet ef migrations add NameOfMigration
dotnet ef database update 
detnet ef migrations remove
dotnet ef database drop --force
```

### Multi Projects
```bash
# NOTE: --connection is not the part of add migrations
dotnet run --project SB_Admin.Web
dotnet ef migrations add NameOfMigration -p SB_Admin.Infra -s SB_Admin.Web --context DBCntx
dotnet ef database update 
dotnet ef database update -p SB_Admin.Infra -s SB_Admin.Web --connection "Server=.;Database=SB_Admin;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=True;"
dotnet ef migrations remove  -p SB_Admin.Infra -s SB_Admin.Web
dotnet ef database drop --force  -p SB_Admin.Infra -s SB_Admin.Web
# Trusted_Connection=True;Integrated Security=False;
```
### PACKAGE MANAGER
```bash
UPDATE-DATABASE -Context DatabaseContext
Add-Migration NameOfMigration -Context DatabaseContextName
```