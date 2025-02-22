using System.Net;

namespace GLOB.Domain.Base;
public class BaseDtoSingleRes<T>
{
  public T? Record { get; set; }
  public HttpStatusCode Status { get; set; }
}

public class BaseDtoMultiRes<T>
{
  public List<T>? Records { get; set; }
  public HttpStatusCode Status { get; set; }
}