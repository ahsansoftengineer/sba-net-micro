namespace GLOB.API.Config.Optionz;

public class SrvcHttp
{
  public static string SectionName = "SrvcHttp";
  public string? Gateway { get; set; }
  public string? Auth { get; set; }
  public string? Hierarchy { get; set; }
}

public class SrvcGRPC
{
  public static string SectionName = "SrvcGRPC";
  public string? Gateway { get; set; }
  public string? Auth { get; set; }
  public string? Hierarchy { get; set; }
}

public class SrvcRabbitMQ
{
  public static string SectionName = "SrvcRabbitMQ";
  public string? Gateway { get; set; }
  public string? Auth { get; set; }
  public string? Hierarchy { get; set; }
}
