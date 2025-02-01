### EXTERNAL PACKAGES DOMAIN
- Adding Packages to Specific Project
```bash
dotnet add ./GLOB.Domain/ package Microsoft.AspNetCore.Mvc.NewtonsoftJson
dotnet add ./GLOB.Domain/ package ErrorOr # Recommended and Final Approach

```

### EXTERNAL PACKAGES APPS
```bash
dotnet add ./GLOB.Apps/ package X.PagedList.Mvc.Core

# dotnet add ./GLOB.Apps/ package OneOf # Drawback of Scalability used in Apps Layer
# dotnet add ./GLOB.Apps/ package FluentResults # It has Lack Some Ability of OneOf used in Apps Layer
# dotnet add ./GLOB.Apps/ package MediatR
# dotnet add ./GLOB.Apps/ package MediatR.Extension.Microsoft.DependencyInjection
# dotnet add ./GLOB.Apps/ package Mapster
# dotnet add ./GLOB.Apps/ package FluentValidation
# dotnet add ./GLOB.Apps/ package FluentValidation.AspNetCore

```

### EXTERNAL PACKAGES INFRA
```bash
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.Design
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.DynamicLinq
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.SqlServer
dotnet add ./GLOB.Infra/ package Microsoft.EntityFrameworkCore.Tools

dotnet add ./GLOB.Infra/ package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add ./GLOB.Infra/ package Microsoft.AspNetCore.Authentication.OpenIdConnect

dotnet add ./GLOB.Infra/ package Microsoft.AspNetCore.Mvc.NewtonsoftJson
dotnet add ./GLOB.Infra/ package Microsoft.Extensions.Configuration
dotnet add ./GLOB.Infra/ package Microsoft.Extensions.Options.ConfigurationExtensions

dotnet add ./GLOB.Infra/ package DynamicExpressions.NET
dotnet add ./GLOB.Infra/ package LinqKit.Core
dotnet add ./GLOB.Infra/ package X.PagedList
dotnet add ./GLOB.Infra/ package X.PagedList.Mvc.Core

```
### EXTERNAL PACKAGES API
```bash
dotnet add ./GLOB.API/ package AspNetCoreRateLimit
dotnet add ./GLOB.API/ package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add ./GLOB.API/ package Marvin.Cache.Headers
dotnet add ./GLOB.API/ package Microsoft.AspNetCore.Mvc.Versioning
dotnet add ./GLOB.API/ package Microsoft.AspNetCore.OpenApi
dotnet add ./GLOB.API/ package Microsoft.AspNetCore.StaticFiles
dotnet add ./GLOB.API/ package Microsoft.Extensions.Configuration
dotnet add ./GLOB.API/ package Microsoft.Extensions.Options.ConfigurationExtensions
dotnet add ./GLOB.API/ package Swashbuckle.AspNetCore
```

