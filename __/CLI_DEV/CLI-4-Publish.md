
### PUBLISH Class Library
- oy2admcfuhtm3ub5pnu5qghl2y6ykti2u5ovdy5dl55i66m

#### GLOB.API.Config
```bash
dotnet build ./GLOB/GLOB.API.Config/GLOB.API.Config.csproj -c Release
dotnet pack ./GLOB/GLOB.API.Config/GLOB.API.Config.csproj -c Release
dotnet nuget push ./GLOB/GLOB.API.Config/bin/Release/GLOB.API.Config.1.0.0.nupkg --api-key oy2abz6ry2ev5umiibufqs64izjruy5duppzurlosmyoxye --source https://api.nuget.org/v3/index.json

dotnet add ./Projects/SBA.Hierarchy/SBA.Hierarchy.csproj package GLOB.API.Config -v 1.0.0
```

#### GLOB.API.Config
```bash
dotnet build ./GLOB/GLOB.API/GLOB.API.csproj -c Release
dotnet pack ./GLOB/GLOB.API/GLOB.API.csproj -c Release
dotnet nuget push ./GLOB/GLOB.API/bin/Release/GLOB.API.1.0.0.nupkg --api-key oy2admcfuhtm3ub5pnu5qghl2y6ykti2u5ovdy5dl55i66m --source https://api.nuget.org/v3/index.json

dotnet add ./Projects/SBA.Hierarchy/SBA.Hierarchy.csproj package GLOB.API -v 1.0.0
```

