using GLOB.Domain.Base;

namespace GLOB.Domain.Entity;
public class City : BaseEntity
{
  public int? StateId { get; set; }
  public State? State { get; set; }
  // [NotMapped]
  // public ICollection<UserCreator>? UserCreators { get; set; }
}
