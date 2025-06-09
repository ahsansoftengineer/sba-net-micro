### REDIS DOCS
- appsettings.json
```json
{
  "ASPNETCORE_ROUTE_PREFIX": "api/Auth/v1",
  "ConnectionStrings": {
    "Redis": "localhost:6379,password=P@55w0rd!123",
  },
}
  
```
- Add Following Srvc
```c#
    srvc.Add_API_Controller_Srvc_Extend(config);
    srvc.Add_Infra_Cache_Redis(config);
```