using GLOB.Domain.Base;

namespace GLOB.Domain.Entity;
public class Profession : BaseEntity
{
  public ICollection<UserCreatorProfession>? UserCreatorProfessions { get; set; } = new List<UserCreatorProfession>();

}
