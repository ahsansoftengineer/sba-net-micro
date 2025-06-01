namespace GLOB.API.Config.Configz;

public class SrvcHttp
{
    public string Gateway { get; set; }
    public string Auth { get; set; }
    public string Hierarchy { get; set; }
}

public class SrvcGRPC
{
    public string Gateway { get; set; }
    public string Auth { get; set; }
    public string Hierarchy { get; set; }
}

public class SrvcRabbitMQ
{
    public string Gateway { get; set; }
    public string Auth { get; set; }
    public string Hierarchy { get; set; }
}
