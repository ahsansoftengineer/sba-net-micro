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

public class BaseVMSelect<TKey>
{
  public List<IEntityAlpha<TKey>>? Records { get; set; }
  public HttpStatusCode Status { get; set; }
}

public class BaseVMSelect : BaseVMSelect<int>
{
}

public class BaseVMMulti<T>
{
  public IList<T>? Records { get; set; }
  public HttpStatusCode Status { get; set; }
}