
### EXTERNAL PACKAGES DOMAIN
- Adding Packages to Specific Project
```bash
dotnet add ./GLOB.Domain/ package Microsoft.AspNetCore.Mvc.NewtonsoftJson
dotnet add ./GLOB.Domain/ package ErrorOr # Recommended and Final Approach
```

### EXTERNAL PACKAGES APPS
```bash
# Apps
dotnet add ./GLOB.Apps/ package OneOf
dotnet add ./GLOB.Apps/ package FluentResults
dotnet add ./GLOB.Apps/ package MediatR
dotnet add ./GLOB.Apps/ package MediatR.Extension.Microsoft.DependencyInjection
dotnet add ./GLOB.Apps/ package Mapster
dotnet add ./GLOB.Apps/ package FluentValidation
dotnet add ./GLOB.Apps/ package FluentValidation.AspNetCore

```

### EXTERNAL PACKAGES API
```bash

dotnet add ./SBA.____/ package AspNetCoreRateLimit
dotnet add ./SBA.____/ package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add ./SBA.____/ package DynamicExpressions.NET
dotnet add ./SBA.____/ package LinqKit.Core
dotnet add ./SBA.____/ package Marvin.Cache.Headers
dotnet add ./SBA.____/ package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add ./SBA.____/ package Microsoft.AspNetCore.Authentication.OpenIdConnect
dotnet add ./SBA.____/ package Microsoft.AspNetCore.Mvc.NewtonsoftJson
dotnet add ./SBA.____/ package Microsoft.AspNetCore.Mvc.Versioning
dotnet add ./SBA.____/ package Microsoft.AspNetCore.StaticFiles
dotnet add ./SBA.____/ package Microsoft.EntityFrameworkCore
dotnet add ./SBA.____/ package Microsoft.EntityFrameworkCore.Design
dotnet add ./SBA.____/ package Microsoft.EntityFrameworkCore.DynamicLinq
dotnet add ./SBA.____/ package Microsoft.EntityFrameworkCore.SqlServer
dotnet add ./SBA.____/ package Microsoft.EntityFrameworkCore.Tools
dotnet add ./SBA.____/ package Microsoft.Extensions.Configuration
dotnet add ./SBA.____/ package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add ./SBA.____/ package Swashbuckle.AspNetCore
dotnet add ./SBA.____/ package X.PagedList
dotnet add ./SBA.____/ package X.PagedList.Mvc.Core
```

### LOCAL PACKAGES API
```bash

```