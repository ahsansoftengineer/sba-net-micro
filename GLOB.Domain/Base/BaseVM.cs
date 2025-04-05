using System.Net;

namespace GLOB.Domain.Base;

public class BaseVM<T>
where T : class
{
  public T? D { get; set; } = null;
}
public class BaseVMSingle<T>
{
  public T? Record { get; set; }
  public HttpStatusCode Status { get; set; }
}
public class BaseVMSingle : BaseVMSingle<object>
{
}

public class BaseVMSelect
{
  public List<DtoSelect>? Records { get; set; }
  public HttpStatusCode Status { get; set; }
}
public class BaseVMMulti<T>
{
  public IList<T>? Records { get; set; }
  public HttpStatusCode Status { get; set; }
}
public class BaseVMMulti : BaseVMMulti<object>
{
}