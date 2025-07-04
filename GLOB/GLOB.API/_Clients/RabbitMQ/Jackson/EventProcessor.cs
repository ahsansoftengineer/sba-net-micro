using AutoMapper;
using GLOB.Infra.UOW;
using Newtonsoft.Json;

namespace GLOB.API.Clientz;

public class EventProcessor
{
  private readonly IServiceScopeFactory _scopeFactory;

  public EventProcessor(IServiceScopeFactory scopeFactory)
  {
    _scopeFactory = scopeFactory;
  }
  public void ProcessEvent(string message)
  {
    using (var scope = _scopeFactory.CreateScope())
    {
      var uow = scope.ServiceProvider.GetRequiredService<IUOW_Infra>();
      var model = JsonConvert.DeserializeObject<ProjectzLookup>(message);

      try
      {
        if (uow.ProjectzLookupBases.AnyId(model?.ProjectzLookupBaseId ?? 0))
        {
          uow.ProjectzLookups.Insert(model);
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