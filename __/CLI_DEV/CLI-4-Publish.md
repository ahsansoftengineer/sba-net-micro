## Nuget Time Frame
- It takes 15 Minutes to publish


### PUBLISH Class Library
- oy2admcfuhtm3ub5pnu5qghl2y6ykti2u5ovdy5dl55i66m

#### GLOB.API.Config
- oy2abz6ry2ev5umiibufqs64izjruy5duppzurlosmyoxye
```bash
dotnet build ./GLOB/GLOB.API.Config/GLOB.API.Config.csproj -c Release -p:PackageVersion=1.0.41
dotnet pack ./GLOB/GLOB.API.Config/GLOB.API.Config.csproj -c Release -p:PackageVersion=1.0.41
dotnet nuget push ./GLOB/GLOB.API.Config/bin/Release/GLOB.API.Config.1.0.41.nupkg --api-key oy2abz6ry2ev5umiibufqs64izjruy5duppzurlosmyoxye --source https://api.nuget.org/v3/index.json

```
#### GLOB.Infra
```bash
dotnet build ./GLOB/GLOB.Infra/GLOB.Infra.csproj -c Release -p:PackageVersion=1.0.41
dotnet pack ./GLOB/GLOB.Infra/GLOB.Infra.csproj -c Release -p:PackageVersion=1.0.41
dotnet nuget push ./GLOB/GLOB.Infra/bin/Release/GLOB.Infra.1.0.41.nupkg --api-key oy2abz6ry2ev5umiibufqs64izjruy5duppzurlosmyoxye --source https://api.nuget.org/v3/index.json

```
#### GLOB.API
```bash
dotnet build ./GLOB/GLOB.API/GLOB.API.csproj -c Release -p:PackageVersion=1.0.41 -p:UseProjectReferences=true
dotnet pack ./GLOB/GLOB.API/GLOB.API.csproj -c Release -p:PackageVersion=1.0.41 -p:UseProjectReferences=true
dotnet nuget push ./GLOB/GLOB.API/bin/Release/GLOB.API.1.0.41.nupkg --api-key oy2admcfuhtm3ub5pnu5qghl2y6ykti2u5ovdy5dl55i66m --source https://api.nuget.org/v3/index.json

```
### Adding the Packages to Class Library
```bash
dotnet add ./GLOB/GLOB.API/GLOB.API.csproj package GLOB.API.Config -v 1.0.41

dotnet add ./GLOB/GLOB.Domain/GLOB.Domain.csproj package GLOB.Infra -v 1.0.41
```


### Adding the Packages to Projects
```bash
dotnet add ./Projects/SBA.APIGateway/SBA.APIGateway.csproj package GLOB.API.Config -v 1.0.41
dotnet add ./Projects/SBA.Job/SBA.Job.csproj package GLOB.API -v 1.0.41
dotnet add ./Projects/SBA.Auth/SBA.Auth.csproj package GLOB.API -v 1.0.41
dotnet add ./Projects/SBA.Hierarchy/SBA.Hierarchy.csproj package GLOB.API -v 1.0.41
```