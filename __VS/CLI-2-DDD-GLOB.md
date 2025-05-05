### EXTERNAL PACKAGES DOMAIN
- Adding Packages to Specific Project
```bash
dotnet add ./GLOB.Domain/ package Microsoft.AspNetCore.Mvc.NewtonsoftJson
dotnet add ./GLOB.Domain/ package ErrorOr # Recommended and Final Approach

```
### EXTERNAL PACKAGES INFRA
```bash
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore -v 8.0.7
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.Design -v 8.0.7
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.DynamicLinq -v 8.0.7
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.SqlServer -v 8.0.7
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.Tools -v 8.0.7

dotnet add ./GLOB.Infra/ package Microsoft.AspNetCore.Authentication.JwtBearer -v 8.0.7
dotnet add ./GLOB.Infra/ package Microsoft.AspNetCore.Authentication.OpenIdConnect -v 8.0.7
dotnet add ./GLOB.Infra/ package Microsoft.Extensions.Options.ConfigurationExtensions -v 8.0.7
dotnet add ./GLOB.Infra/ package Microsoft.Extensions.Configuration -v 8.0.7 

dotnet add ./GLOB.Infra/ package Microsoft.AspNetCore.Mvc.NewtonsoftJson

dotnet add ./GLOB.Infra/ package DynamicExpressions.NET -v 1.1.0
dotnet add ./GLOB.Infra/ package LinqKit.Core

```
### EXTERNAL PACKAGES API.CONFIG
```bash
dotnet add ./GLOB.API.Config/ package AspNetCoreRateLimit
dotnet add ./GLOB.API.Config/ package AutoMapper.Extensions.Microsoft.DependencyInjection8
dotnet add ./GLOB.API.Config/ package Marvin.Cache.Headers
dotnet add ./GLOB.API.Config/ package Microsoft.AspNetCore.Mvc.Versioning
dotnet add ./GLOB.API.Config/ package Microsoft.AspNetCore.OpenApi
dotnet add ./GLOB.API.Config/ package Microsoft.AspNetCore.StaticFiles
dotnet add ./GLOB.API.Config/ package Microsoft.Extensions.Configuration -v 8.0.7
dotnet add ./GLOB.API.Config/ package Microsoft.Extensions.Options.ConfigurationExtensions -v 8.0.7
dotnet add ./GLOB.API.Config/ package Swashbuckle.AspNetCore

dotnet add ./GLOB.API.Config/ package Microsoft.AspNetCore.Authentication.JwtBearer -v 8.0.7
dotnet add ./GLOB.API.Config/ package Microsoft.AspNetCore.Authentication.OpenIdConnect -v 8.0.7
dotnet add ./GLOB.API.Config/ package Microsoft.Extensions.Options.ConfigurationExtensions -v 8.0.7
```

### EXTERNAL PACKAGES API
```bash
```
