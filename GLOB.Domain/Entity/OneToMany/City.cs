using GLOB.Domain.Base;

namespace GLOB.Domain.Entity;
public class City : BaseEntity
{
  public int? StateID { get; set; }
  public State? State { get; set; }
  public ICollection<UserCreator>? UserCreators { get; set; }
}
