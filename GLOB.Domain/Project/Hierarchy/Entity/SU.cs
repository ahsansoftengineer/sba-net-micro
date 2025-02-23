using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Base;

namespace GLOB.Domain.Hierarchy;
public class SU : BaseEntity
{
  [ForeignKey(nameof(OU))]
  public int OUId { get; set; }
  public virtual OU? OU { get; set; }

}