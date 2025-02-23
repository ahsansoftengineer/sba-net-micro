using GLOB.Domain.Base;

namespace GLOB.Domain.Hierarchy;
public class City : BaseEntity
{
  public int? StateId { get; set; }
  public virtual State? State { get; set; }
  // [NotMapped]
  // public ICollection<UserCreator>? UserCreators { get; set; }
}
