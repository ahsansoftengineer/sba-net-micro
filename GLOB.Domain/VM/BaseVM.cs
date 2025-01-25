namespace GLOB.Domain.VM;
public class BaseVM<T>
where T : class
{
  public T? D {get; set;} = null;
}