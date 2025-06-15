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

  private void AddPlatform(string message)
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
    var eventType = DetermineEvent(message);
    switch (eventType)
    {
      case EventType.ProjectzLookup_Create:
        // TODO
        break;
      default:
        break;
    }
  }
  private EventType DetermineEvent(string notificationMessage)
  {
    Console.WriteLine("--> Determining Event");
    var eventType = JsonConvert.DeserializeObject<GenericEventDto>(notificationMessage);

    switch (eventType.Event)
    {
      case "ProjectzLookup_Create":
        Console.WriteLine("Platform Published Event Detected");
        return EventType.ProjectzLookup_Create;
      default:
        Console.WriteLine("--> Could not Determine the Event Type");
        return EventType.Undetermined;
    }
  }
}

enum EventType
{
  ProjectzLookup_Create,
  Undetermined,
}
class GenericEventDto
{
  public string Event { get; set; }
}