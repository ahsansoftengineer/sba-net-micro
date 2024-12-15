
### 1. Way 
- launchsettings.json
- By Default .Net Core Application uses Port from launchSettings.json when runing in Dev Mode
```json
{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "http://localhost:8000",
      "environmentVariables": {
      "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "https://localhost:8001;http://localhost:8000",
      "environmentVariables": {
      "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}

```
- Command Line Supersede Environment Variables
```bash
dotnet watch
dotnet run
dotnet run --urls=http://localhost:8000/ 
```
### 2. Way 
Programmitically Setting up Port
- Code Supersede Every thing
```c#
public static IHostBuilder CreateHostBuilder(string[] args) =>
Host.CreateDefaultBuilder(args)
  .ConfigureWebHostDefaults(webBuilder =>
  {
    webBuilder.UseStartup<Startup>();
    webBuilder.UseUrls("http://localhost:8000"); // Specify the desired port here
  });
```
```bash
dotnet run
```