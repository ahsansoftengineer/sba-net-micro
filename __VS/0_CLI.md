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
dotnet new webapi -o SBA.Order
dotnet new webapi -o SBA.Userz
dotnet new webapi -o SBA.Notify
dotnet new webapi -o SBA.Jobz
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
dotnet sln add SBA.Orderz/SBA.Orderz.csproj
dotnet sln add SBA.Userz/SBA.Userz.csproj

```
### ADD / REMOVE PROJECTS
```bash
dotnet sln add (ls -r **\*.csproj) # Powershell Command
dotnet sln remove .\Donation.Contacts\Donation.Contacts.csproj # cmd
dotnet format ./solution.sln # ??
more.\SBA.sln # ??
```
### ADDING LOCAL PROJECTS
```bash
dotnet build
dotnet add .\Donation.Api\ reference .\Donation.Contracts\ .\Donation.Application\
dotnet add .\Donation.Infrastructure\ reference .\Donation.Application\
dotnet add .\Donation.Application\ reference .\Donation.Domain\
dotnet add .\Donation.Api\ reference .\Donation.Infrastructure\
```
### RUNNING PROJECTS
```bash
dotnet run --project .\Donation.Api\
dotnet watch run --project .\Donation.Api\
```

#### USER SECRETS
```bash 
dotnet user-secrets init --project .\Donation.Api\
dotnet user-secrets set --project .\Donation.Api\ "JwtSettings:Secret" "super-secret-key-from-user-secrets"
dotnet user-secrets list --project .\Donation.Api\
```
### EXTERNAL PACKAGES
- Adding Packages to Specific Project
```bash
dotnet add .\Donation.Infrastructure\ package Microsoft.Extensions.Configuration
dotnet add .\Donation.Infrastructure\ package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add .\Donation.Infrastructure\ package Microsoft.AspNetCore.Authentication.JwtBearer

dotnet add .\Donation.Application\ package OneOf // Drawback of Scalability used in Application Layer
dotnet add .\Donation.Application\ package FluentResults // It has Lack Some Ability of OneOf used in Application Layer
dotnet add .\Donation.Domain\ package ErrorOr // Recommended and Final Approach
dotnet add .\Donation.Application\ package MediatR
dotnet add .\Donation.Application\ package MediatR.Extension.Microsoft.DependencyInjection
dotnet add .\Donation.Application\ package Mapster
dotnet add .\Donation.Application\ package FluentValidation
dotnet add .\Donation.Application\ package FluentValidation.AspNetCore

dotnet add Donation.Infrastructure package Microsoft.EntityFrameworkCore 
dotnet add Donation.Infrastructure package Microsoft.EntityFrameworkCore.SqlServer
dotnet add Donation.Infrastructure package Microsoft.EntityFrameworkCore.Design
dotnet add Donation.Api package Microsoft.EntityFrameworkCore.Design
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

### DOCKER
```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker image ls
docker run -e 'HOMEBREW_NO_ENV_FILTERING=1' -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=asdf1234' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
docker container ls
docker ps
// Below Command Run After SQL Container Runs (Keys are Case Insensitive & their alternatives are available)


dotnet ef database update -p Donation.Infrastructure -s Donation.Api --connection "server=localhost;Database=Donation;User Id=sa;password=asdf1234;TrustServerCertificate=true"
 // This Command won't work b/c of Certificate & Swagger (Run using f5)
```
### MIGRATION
```bash
dotnet tool install --global dotnet-ef
dotnet tool list --global


dotnet ef database add MigrationName --project Donation.Infrastructure --startup-project Donation.Api --connection "SERVER=127.0.0.1,1433;DATABASE=Donation;USER=sa;PASSWORD=asdf1234;Encrypt=false"

# ADD
dotnet ef migrations add InitialCreate -p Donation.Infrastructure -s Donation.Api
# REMOVE
dotnet ef migrations remove  -p Donation.Infrastructure -s Donation.Api
# UPDATE
dotnet ef database update -p Donation.Infrastructure -s Donation.Api --connection "Server=localhost;Database=Donation;User Id=sa;Password=asdf1234;Encrypt=false"
# RUN
dotnet run --project Donation.Api
```
### CURL COMMAND
- Undermentioned Commands only works with Bash
- Before Using that you have to Stop Https Middleware
- Running your app with http in Visual Studio
```bash
curl -X 'POST' 'http://localhost:5294/auth/register' -H 'accept: */*' -H 'Content-Type: application/json' -d '{   "firstName": "string", "lastName": "string", "email": "string", "password": "string" }'
curl -X 'POST' 'http://localhost:5294/auth/login' -H 'accept: */*' -H 'Content-Type: application/json' -d '{ "email": "string", "password": "string" }'
curl -X 'GET' 'http://localhost:5294/api/Dinners' -H 'accept: */*' -H 'Authorization: Bearer token.full.goeshere'
```