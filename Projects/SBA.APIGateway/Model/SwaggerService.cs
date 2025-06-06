namespace SBA.APIGateway.Model;
public class SwaggerService
{
    public string Name { get; set; }
    public string Url { get; set; }
}
public class SwaggerServicesOptions
{
    public List<SwaggerService> Services { get; set; }
}
