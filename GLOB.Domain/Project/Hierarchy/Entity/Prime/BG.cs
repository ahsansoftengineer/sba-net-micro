using GLOB.Domain.Base;

namespace GLOB.Domain.Hierarchy;
public class BG : BaseEntity
{
  public virtual IList<LE>? LEs { get; set; }
}