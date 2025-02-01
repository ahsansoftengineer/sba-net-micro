## Dotnet Core CLI Commands
- Note: For Bash You can Revert BackSlash \ to ForwardSlash /
- Create a Folder for your project with that folder run the following commands

### SOLUTION COMMANDS
```bash
dotnet new sln -o SBA
```

### CLASS LIBRARY
```bash
dotnet new classlib -o GLOB.Package
dotnet new classlib -o GLOB.Domain
dotnet new classlib -o GLOB.Apps
dotnet new classlib -o GLOB.Infra
dotnet new classlib -o GLOB.Contracts
dotnet new classlib -o GLOB.APIz
```

### PROJECTS
```bash
dotnet new webapi -o SBA.APIGateway
dotnet new webapi -o GLOB.API
dotnet new webapi -o SBA.Hierarchy
dotnet new webapi -o SBA.Auth
dotnet new webapi -o SBA.Orderz
dotnet new webapi -o SBA.Userz
dotnet new webapi -o SBA.Jobz
# dotnet new webapi -o SBA.Notify
```


### Adding Projects to Solution
```bash
dotnet sln add GLOB.Apps/GLOB.Apps.csproj
dotnet sln add GLOB.Contracts/GLOB.Contracts.csproj
dotnet sln add GLOB.Domain/GLOB.Domain.csproj
dotnet sln add GLOB.Infra/GLOB.Infra.csproj
dotnet sln add GLOB.API/GLOB.API.csproj
dotnet sln add GLOB.APIz/GLOB.APIz.csproj

dotnet sln add PlatformService/PlatformService.csproj
dotnet sln add CommandsService/CommandsService.csproj

dotnet sln add SBA.APIGateway/SBA.APIGateway.csproj
dotnet sln add SBA.Jobz/SBA.Jobz.csproj
dotnet sln add SBA.Hierarchy/SBA.Hierarchy.csproj
dotnet sln add SBA.Auth/SBA.Auth.csproj
dotnet sln add SBA.Userz/SBA.Userz.csproj
dotnet sln add SBA.Orderz/SBA.Orderz.csproj

```

### ADDING LOCAL CLASS LIBRARY
```bash
dotnet build
dotnet add ./GLOB.Apps/ reference ./GLOB.Domain/
dotnet add ./GLOB.Infra/ reference ./GLOB.Apps/ # ./GLOB.Domain/
dotnet add ./SBA.API/ reference ./GLOB.Infra/ # CLASS LIB
dotnet add ./SBA.APIz/ reference ./GLOB.Infra/ # WEB API
```
### EXTERNAL PACKAGES TO API
```bash

```

