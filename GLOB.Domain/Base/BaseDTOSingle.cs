using System.Net;

namespace GLOB.Domain.Base;
public class BaseDtoSingle<T>
{
  public T? Record { get; set; }
  public HttpStatusCode Status { get; set; }
}