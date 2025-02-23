using GLOB.Domain.Base;

namespace GLOB.Domain.Entity;
public class State : BaseEntity
{
  public virtual ICollection<City>? Citys { get; set; }
}
