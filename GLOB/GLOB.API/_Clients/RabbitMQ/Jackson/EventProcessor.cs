using AutoMapper;
using GLOB.API.Config.Extz;
using GLOB.Infra.Model.Base;
using GLOB.Infra.UOW;
using Newtonsoft.Json;

namespace GLOB.API.Clientz;

public class EventProcessor
{
  private readonly IServiceScopeFactory _scopeFactory;
  private readonly IMapper _mapper;

  public EventProcessor(IServiceProvider sp, IServiceScopeFactory scopeFactory)
  {
    _scopeFactory = scopeFactory;
    _mapper = sp.GetSrvc<IMapper>();
  }

  public void AddPlatform(string message)
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
          Console.WriteLine("ProjectzLookupz Created Successfully");
        }
        else
        {
          Console.WriteLine("ProjectzLookupBaseId Does not Exsist");
        }

      }
      catch (Exception ex)
      {
        Console.WriteLine("--> ProjectzLookup not Created");
      }
    }
  }
  public void ProcessEvent(string message)
  {

    var EventType = JsonConvert.DeserializeObject<GenericEventDto>(message);   
    switch (EventType?.Event)
    {
      case "ProjectzLookupz_create":
        Console.WriteLine($"Known Event {message}");
        AddPlatform(message);
        // TODO
        break;
      default:
        Console.WriteLine($"Unknown Event {message}");
        break;
    }
  }
}
class GenericEventDto
{
  public string? Event { get; set; }
}