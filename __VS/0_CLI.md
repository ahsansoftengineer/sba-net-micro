## Dotnet Core CLI Commands
- Note: For Bash You can Revert BackSlash \ to ForwardSlash /
- Create a Folder for your project with that folder run the following commands

### SOLUTION COMMANDS
```bash
dotnet new sln -o SBA
```
### PROJECTS
```bash
dotnet new webapi -o SBA.APIGateway
dotnet new webapi -o SBA.Auth
dotnet new webapi -o SBA.Orderz
dotnet new webapi -o SBA.Userz
dotnet new webapi -o SBA.Jobz
# dotnet new webapi -o SBA.Notify
```

### CLASS LIBRARY
```bash
dotnet new classlib -o GLOB.Domain
dotnet new classlib -o GLOB.Apps
dotnet new classlib -o GLOB.Infra
dotnet new classlib -o GLOB.Contracts
```
### Adding Projects to Commands Line
```bash
dotnet sln add GLOB.Apps/GLOB.Apps.csproj
dotnet sln add GLOB.Domain/GLOB.Domain.csproj
dotnet sln add GLOB.Infra/GLOB.Infra.csproj
dotnet sln add GLOB.Contracts/GLOB.Contracts.csproj

dotnet sln add PlatformService/PlatformService.csproj
dotnet sln add CommandsService/CommandsService.csproj

dotnet sln add SBA.APIGateway/SBA.APIGateway.csproj
dotnet sln add SBA.Auth/SBA.Auth.csproj
dotnet sln add SBA.Jobz/SBA.Jobz.csproj
dotnet sln add SBA.Orderz/SBA.Orderz.csproj
dotnet sln add SBA.Userz/SBA.Userz.csproj

```
### ADDING LOCAL CLASS LIBRARY
```bash
dotnet build
dotnet add ./GLOB.Infra/ reference ./GLOB.Apps/ ./GLOB.Domain/
dotnet add ./GLOB.Apps/ reference ./GLOB.Domain/
```

### ADDING LOCAL PROJECTS
```bash
dotnet build
dotnet add ./SBA.Auth/ reference ./GLOB.Contracts/ ./GLOB.Apps/
dotnet add ./SBA.Auth/ reference ./GLOB.Infra/
```

### EXTERNAL PACKAGES
- Adding Packages to Specific Project
```bash
dotnet add ./GLOB.Infra/ package Microsoft.Extensions.Configuration
dotnet add ./GLOB.Infra/ package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add ./GLOB.Infra/ package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore 
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.SqlServer
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.Design

dotnet add ./GLOB.Apps/ package OneOf # Drawback of Scalability used in Apps Layer
dotnet add ./GLOB.Apps/ package FluentResults # It has Lack Some Ability of OneOf used in Apps Layer
dotnet add ./GLOB.Apps/ package MediatR
dotnet add ./GLOB.Apps/ package MediatR.Extension.Microsoft.DependencyInjection
dotnet add ./GLOB.Apps/ package Mapster
dotnet add ./GLOB.Apps/ package FluentValidation
dotnet add ./GLOB.Apps/ package FluentValidation.AspNetCore

dotnet add ./GLOB.Domain/ package ErrorOr # Recommended and Final Approach


dotnet add SBA.Api package Microsoft.EntityFrameworkCore.Design
```


### SETTING UP STARTUP PROJECTS
```bash

```

### RUNNING PROJECTS
```bash
dotnet run --project ./SBA.Api/
dotnet watch run --project ./SBA.Api/
```

#### USER SECRETS
```bash 
dotnet user-secrets init --project ./SBA.Api/
dotnet user-secrets set --project ./SBA.Api/ "JwtSettings:Secret" "super-secret-key-from-user-secrets"
dotnet user-secrets list --project ./SBA.Api/
```

### GIT
```bash
start . # OPENING FOLDER EXPLORER USING CLI

dotnet new gitignore
git init
git push --set-upstream origin BranchNameHere
git remote set-url stream https://gitlab.com/starbazaar/admin-panel.git
git remote add stream https://gitlab.com/starbazaar/webapp.git
git remote -v
origin  https://gitlab.com/m.ahsan.saifi/webapp.git (fetch)
origin  https://gitlab.com/m.ahsan.saifi/webapp.git (push)
stream  https://gitlab.com/starbazaar/webapp.git (fetch)
stream  https://gitlab.com/starbazaar/webapp.git (push)
dotnet new editorconfig
```
