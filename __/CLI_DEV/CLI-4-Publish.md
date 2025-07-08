
### PUBLISH Class Library
- oy2admcfuhtm3ub5pnu5qghl2y6ykti2u5ovdy5dl55i66m

#### GLOB.API.Config
- oy2abz6ry2ev5umiibufqs64izjruy5duppzurlosmyoxye
```bash
dotnet build ./GLOB/GLOB.API.Config/GLOB.API.Config.csproj -c Release
dotnet pack ./GLOB/GLOB.API.Config/GLOB.API.Config.csproj -c Release
dotnet nuget push ./GLOB/GLOB.API.Config/bin/Release/GLOB.API.Config.1.0.0.nupkg --api-key oy2abz6ry2ev5umiibufqs64izjruy5duppzurlosmyoxye --source https://api.nuget.org/v3/index.json

```
#### GLOB.API
```bash
dotnet build ./GLOB/GLOB.Infra/GLOB.Infra.csproj -c Release
dotnet pack ./GLOB/GLOB.Infra/GLOB.Infra.csproj -c Release
dotnet nuget push ./GLOB/GLOB.Infra/bin/Release/GLOB.Infra.1.0.0.nupkg --api-key oy2admcfuhtm3ub5pnu5qghl2y6ykti2u5ovdy5dl55i66m --source https://api.nuget.org/v3/index.json

```

#### GLOB.API
```bash
dotnet build ./GLOB/GLOB.API/GLOB.API.csproj -c Release
dotnet pack ./GLOB/GLOB.API/GLOB.API.csproj -c Release
dotnet nuget push ./GLOB/GLOB.API/bin/Release/GLOB.API.1.0.0.nupkg --api-key oy2admcfuhtm3ub5pnu5qghl2y6ykti2u5ovdy5dl55i66m --source https://api.nuget.org/v3/index.json

```
### Adding the Packages
```bash
dotnet add ./Projects/SBA.APIGateway/SBA.APIGateway.csproj package GLOB.API.Config

dotnet add ./Projects/SBA.Job/SBA.Job.csproj package GLOB.API.Config
dotnet add ./Projects/SBA.Job/SBA.Job.csproj package GLOB.API
dotnet add ./Projects/SBA.Job/SBA.Job.csproj package GLOB.Infra

dotnet add ./Projects/SBA.Auth/SBA.Auth.csproj package GLOB.API.Config
dotnet add ./Projects/SBA.Auth/SBA.Auth.csproj package GLOB.API
dotnet add ./Projects/SBA.Auth/SBA.Auth.csproj package GLOB.Infra

dotnet add ./Projects/SBA.Hierarchy/SBA.Hierarchy.csproj package GLOB.API.Config
dotnet add ./Projects/SBA.Hierarchy/SBA.Hierarchy.csproj package GLOB.API
dotnet add ./Projects/SBA.Hierarchy/SBA.Hierarchy.csproj package GLOB.Infra




```