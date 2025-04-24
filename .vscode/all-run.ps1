Start-Process powershell -ArgumentList 'dotnet watch run --project ../SBA.APIGateway/SBA.APIGateway.csproj'
Start-Process powershell -ArgumentList 'dotnet watch run --project ../SBA.Auth/SBA.Auth.csproj'
Start-Process powershell -ArgumentList 'dotnet watch run --project ../SBA.Hierarchy/SBA.Hierarchy.csproj'
