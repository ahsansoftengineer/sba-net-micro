using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Base;

namespace GLOB.Domain.Entity;
public class Profession : BaseEntity
{
  [NotMapped]
  public ICollection<UserCreatorProfession>? UserCreatorProfessions { get; set; } = new List<UserCreatorProfession>();

}
