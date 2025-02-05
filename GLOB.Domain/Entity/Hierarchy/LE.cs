using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Base;

namespace GLOB.Domain.Entity;
public class LE : BaseEntity
{
  [ForeignKey(nameof(BG))]
  public int BGId { get; set; }
  public virtual BG? BG { get; set; }

}