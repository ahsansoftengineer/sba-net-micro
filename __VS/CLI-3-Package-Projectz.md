### API GATEWAY
```bash
dotnet add ./SBA.APIGateway/ package Microsoft.AspNetCore.OpenApi -v 8.0.12
dotnet add ./SBA.APIGateway/ package MMLib.SwaggerForOcelot -v 8.0.0
dotnet add ./SBA.APIGateway/ package Swashbuckle.AspNetCore -v 6.6.2

```

### Auth
```bash
dotnet add ./SBA.Auth/ package Microsoft.AspNetCore.Authentication.Google
```

### Hierarchy
```bash
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.Design -v 9.0.4
```