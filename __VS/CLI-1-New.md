## Dotnet Core CLI Commands
- Note: For Bash You can Revert BackSlash \ to ForwardSlash /
- Create a Folder for your project with that folder run the following commands

### SOLUTION COMMANDS
```bash
dotnet new sln -o SBA
```

### LOCAL LIBRARY
```bash
dotnet new classlib -o GLOB.Package
dotnet new classlib -o GLOB.Domain
dotnet new classlib -o GLOB.Apps
dotnet new classlib -o GLOB.Infra
dotnet new classlib -o GLOB.Contracts
# dotnet new classlib -o GLOB.APIz
```

### LOCAL PROJECTS
```bash
dotnet new webapi -o GLOB.API
dotnet new webapi -o SBA.APIGateway
dotnet new webapi -o SBA.Hierarchy
dotnet new webapi -o SBA.Auth
dotnet new webapi -o SBA.Orderz
dotnet new webapi -o SBA.Userz
dotnet new webapi -o SBA.Jobz
# dotnet new webapi -o SBA.Notify
```


### LOCAL LIBRARY TO SOLUTION
```bash
dotnet sln add GLOB.Apps/GLOB.Apps.csproj
dotnet sln add GLOB.Domain/GLOB.Domain.csproj
dotnet sln add GLOB.Infra/GLOB.Infra.csproj
```

### LOCAL PROJECTS TO SOLUTION
```bash
dotnet sln add GLOB.API/GLOB.API.csproj

dotnet sln add SBA.APIGateway/SBA.APIGateway.csproj
dotnet sln add SBA.Auth/SBA.Auth.csproj
dotnet sln add SBA.Hierarchy/SBA.Hierarchy.csproj
dotnet sln add SBA.Userz/SBA.Userz.csproj
dotnet sln add SBA.Orderz/SBA.Orderz.csproj
dotnet sln add SBA.Jobz/SBA.Jobz.csproj

dotnet sln add PlatformService/PlatformService.csproj
dotnet sln add CommandsService/CommandsService.csproj
```

### LOCAL CLASS LIBRARY RELATION
```bash
dotnet build
dotnet add ./GLOB.Apps/ reference ./GLOB.Domain/
dotnet add ./GLOB.Infra/ reference ./GLOB.Apps/ # ./GLOB.Domain/
dotnet add ./GLOB.API/ reference ./GLOB.Infra/ # WEB API
dotnet add ./GLOB.Package/ reference ./GLOB.API/ # Common Packages
# dotnet add ./SBA.APIz/ reference ./GLOB.Infra/ # ClassLib
```
### Web API PACKAGES
```bash
dotnet add ./SBA.Auth/ reference ./GLOB.Package/ # WEB API
dotnet add ./SBA.Hierarchy/ reference ./GLOB.Package/ # WEB API
dotnet add ./SBA.Userz/ reference ./GLOB.Package/ # WEB API
dotnet add ./SBA.Orderz/ reference ./GLOB.Package/ # WEB API

```