dotnet build
dotnet rebuild
dotnet watch
clear

dotnet ef migrations add Init -s SBA.Hierarchy --context DBCtxProjectz
dotnet ef database update -s SBA.Hierarchy --context DBCtxProjectz
dotnet ef migrations remove -s SBA.Hierarchy --context DBCtxProjectz
dotnet ef database drop --force -s SBA.Hierarchy --context DBCtxProjectz

dotnet sln add GLOB.API/GLOB.API.csproj
