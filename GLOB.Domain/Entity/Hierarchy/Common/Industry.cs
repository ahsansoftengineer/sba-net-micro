using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Base;

namespace GLOB.Domain.Entity;
public class Industry : BaseEntity
{
  [NotMapped]
  public ICollection<UserBusinessIndustry>? UserBusinessIndustrys { get; set; } = new List<UserBusinessIndustry>();
  [NotMapped]
  public ICollection<UserCreatorIndustry>? UserCreatorIndustrys { get; set; } = new List<UserCreatorIndustry>();
  [NotMapped]
  public ICollection<UserCreatorProfession>? UserCreatorProfessions { get; set; } = new List<UserCreatorProfession>();

}
