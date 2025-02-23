using GLOB.Domain.Base;

namespace GLOB.Domain.Hierarchy;
public class State : BaseEntity
{
  public virtual ICollection<City>? Citys { get; set; }
}
