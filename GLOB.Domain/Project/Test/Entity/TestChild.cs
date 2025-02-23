using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Base;

namespace GLOB.Domain.Projectz;
public class TestChild : BaseEntity
{
  [ForeignKey(nameof(TestParent))]
  public int TestParentId { get; set; }
  public virtual TestParent? TestParent { get; set; }

}