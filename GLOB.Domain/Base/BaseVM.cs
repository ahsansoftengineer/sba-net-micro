namespace GLOB.Domain.Base;
public class BaseVM<T>
where T : class
{
  public T? D {get; set;} = null;
}