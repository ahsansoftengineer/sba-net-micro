### Configuration Presedence
- You can set Configuration 10 ways and the presedence from To Bottom to Top
-  Configuration Keys are Case Insensitives
0. User Secrets
1. Settings files, such as appsettings.json -> "MyKey": "From appsettings.json"
2. Settings files, such as appsettings.Development.json -> "MyKey": "From appsettings.Development.json"
3. Environment Variable OS System -> MyKey Environment Variable form System
4. Environment Variable OS Users -> MyKey This is from PC User Environment Variable
5. Azure Key Vault
6. Azure App Configuration
7. Command-line arguments -> dotnet run MyKey="Any Value of my choice"
8. Custom providers, installed or created
9. Directory files
10. In-memory .NET objects

### launchsettings.json
- By Default .Net Core Application uses Port from launchSettings.json
```json
{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "http://localhost:5000",
      "environmentVariables": {
      "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
      "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}

```
### Environment Variables (Windows, Ubuntu, Linux etc...)
- Supersede 
```bash
ASPNETCORE_URLS=http://localhost:5000/
```
### CMD
- Command Line Supersede Environment Variables
```bash
dotnet watch
dotnet run
dotnet run --urls=http://localhost:5000/ # Command Line URL

# Application will use Port of launchSettings.json

```
### Code Supersede Every thing
```c#
 public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.UseUrls("http://localhost:5000"); // Specify the desired port here
            });
```