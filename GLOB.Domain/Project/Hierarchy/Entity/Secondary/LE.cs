using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Base;

namespace GLOB.Domain.Hierarchy;
public class LE : EntityBase
{
  [ForeignKey(nameof(BG))]
  public int BGId { get; set; }
  public virtual BG? BG { get; set; }
  public virtual ICollection<OU> OUs { get; set; }

}