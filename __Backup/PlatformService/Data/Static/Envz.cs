namespace PlatformService.Static; 
public static class Envz
{
  public static readonly string Development = "Development";
  public static readonly string Production = "Production";
  public static readonly string Dev = "Dev";
  public static readonly string Prod = "Prod";
  public static readonly string Docker = "Docker";
  public static readonly string DockerCompose = "DockerCompose";
  public static readonly string DockerComposeSolution = "DockerComposeSolution";
  public static readonly string DockerK8S = "DockerK8S";

  public static bool IsDev(this IHostEnvironment env)
  {
    return env.IsEnvironment(Dev);
  }
  public static bool IsProd(this IHostEnvironment env)
  {
    return env.IsEnvironment(Prod);
  }
  public static bool IsDocker(this IHostEnvironment env)
  {
    return env.IsEnvironment(Docker);
  }
  public static bool IsDockerCompose(this IHostEnvironment env)
  {
    return env.IsEnvironment(DockerCompose);
  }
  public static bool IsDockerComposeSolution(this IHostEnvironment env)
  {
    return env.IsEnvironment(DockerComposeSolution);
  }
  public static bool IsDockerK8S(this IHostEnvironment env)
  {
    return env.IsEnvironment(DockerK8S);
  }
}