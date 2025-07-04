using AutoMapper;
using GLOB.API.Clientz;
using GLOB.Infra.UOW;
using Newtonsoft.Json;

namespace SBA.Projectz.Clientz;

public class EventProjectzLookupCreate
{
  private readonly IServiceScopeFactory _scopeFactory;

  public EventProjectzLookupCreate(IServiceScopeFactory scopeFactory)
  {
    _scopeFactory = scopeFactory;
  }


  public void ProcessEvent(string message)
  {
     using (var scope = _scopeFactory.CreateScope())
    {
      var uow = scope.ServiceProvider.GetRequiredService<IUOW_Infra>();
      Console.WriteLine(message);
      var model = JsonConvert.DeserializeObject<RabbitMQPayload<ProjectzLookup>>(message);

      try
      {
        if (uow.ProjectzLookupBases.AnyId(model.Body?.ProjectzLookupBaseId ?? 0))
        {
          uow.ProjectzLookups.Insert(model.Body);
          uow.Save();
          Console.WriteLine("ProjectzLookup Created Successfully");
        }
        else
        {
          Console.WriteLine("ProjectzLookupBaseId Does not Exsist");
        }

      }
      catch (Exception ex)
      {
        Console.WriteLine($"--> ProjectzLookup not Created {ex.Message}");
      }
    }
  }
}