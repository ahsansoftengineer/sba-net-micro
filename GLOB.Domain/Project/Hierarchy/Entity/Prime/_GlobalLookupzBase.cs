using GLOB.Domain.Base;

namespace GLOB.Hierarchy.Global;

public class GlobalLookupzBase : EntityBase
{
  public virtual ICollection<GlobalLookupz>? GlobalLookupz { get; set; }
}