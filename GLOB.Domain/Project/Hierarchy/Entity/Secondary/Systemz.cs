using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Base;

namespace GLOB.Domain.Hierarchy;
public class Systemz : EntityBase
{
  [ForeignKey(nameof(Org))]
  public int OrgId { get; set; } // We Marked it as Nullable because of Dynamic Filtering
  // [Relate] // For Eager Loading
  public virtual Org? Org { get; set; }
}