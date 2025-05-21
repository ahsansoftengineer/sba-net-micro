## Dotnet Core CLI Commands
- Note: For Bash You can Revert BackSlash \ to ForwardSlash /
- Create a Folder for your project with that folder run the following commands

### SOLUTION COMMANDS
```bash
dotnet new sln -o SBA
```

### LOCAL LIBRARY
```bash
dotnet new classlib -o GLOB.Domain
dotnet new classlib -o GLOB.Infra
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
dotnet sln add GLOB.Domain/GLOB.Domain.csproj
dotnet sln add GLOB.Infra/GLOB.Infra.csproj
```

### LOCAL PROJECTS TO SOLUTION
```bash
dotnet sln add GLOB.API/GLOB.API.csproj
dotnet sln add GLOB.API.Config/GLOB.API.Config.csproj

dotnet sln add SBA.APIGateway/SBA.APIGateway.csproj
dotnet sln add SBA.Auth/SBA.Auth.csproj
dotnet sln add SBA.Hierarchy/SBA.Hierarchy.csproj
dotnet sln add SBA.Userz/SBA.Userz.csproj
dotnet sln add SBA.Orderz/SBA.Orderz.csproj
dotnet sln add SBA.Jobz/SBA.Jobz.csproj

# dotnet sln add PlatformService/PlatformService.csproj
# dotnet sln add CommandsService/CommandsService.csproj
```

### LOCAL CLASS LIBRARY RELATION
```bash
dotnet build
dotnet add ./GLOB.API/ reference ./GLOB.Infra/ # WEB API
```
### Web API PACKAGES
```bash
dotnet add ./GLOB.API/ reference ./GLOB.API.Config/ # WEB API
dotnet add ./GLOB.APIGateway/ reference ./GLOB.API.Config/ # WEB API
dotnet add ./SBA.Auth/ reference ./GLOB.API/ # WEB API
dotnet add ./SBA.Hierarchy/ reference ./GLOB.API/ # WEB API
# dotnet add ./SBA.Userz/ reference ./GLOB.API/ # WEB API
# dotnet add ./SBA.Orderz/ reference ./GLOB.API/ # WEB API

```

### Web API CONFIG PACKAGES
```bash
dotnet add ./GLOB.API/ reference ./GLOB.API.Config/ # WEB API
dotnet add ./GLOB.API/ reference ./GLOB.Infra/ # WEB API
```
### Local Packages
- Windows ||| C:\Users\Ahsan1008\.nuget\packages
- Ubuntu  ||| ~/.nuget/packages
- So, even if you use .NET 9, .NET 8, or .NET Core 3.1, all package versions are managed under:
```bash
# Create Dir
cd C:
mkdir Packages

# Create Source Dir

dotnet nuget add source 'C:\Packages\' --name Packages 
dotnet nuget list source


# Remove Source
dotnet nuget remove source Packages # Not Working

# Disable
dotnet nuget enable source nuget.org
dotnet nuget disable source nuget.org
dotnet nuget enable source "Microsoft Visual Studio Offline Packages"

```
### Using Local Package Source
```bash
dotnet add ./SBA.Auth/ package Microsoft.AspNetCore.Authentication.Google --version 8.0.7 --source "C:\Packages" # Worked
```

### Customize Package Location 

```bash
# Print File Location for Nuget Packges
dotnet nuget locals global-packages -l

# DEfault File Location for Nuget Packages
cd C:\Users\Ahsan1008\.nuget

# Custom File Location
setx NUGET_PACKAGES 'C:\Packages\'

```