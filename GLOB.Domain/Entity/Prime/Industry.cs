namespace GLOB.Domain.Entity;
public class Industry : BaseEntity
{
  public ICollection<UserBusinessIndustry>? UserBusinessIndustrys { get; set; } = new List<UserBusinessIndustry>();
  public ICollection<UserCreatorIndustry>? UserCreatorIndustrys { get; set; } = new List<UserCreatorIndustry>();
  public ICollection<UserCreatorProfession>? UserCreatorProfessions { get; set; } = new List<UserCreatorProfession>();

}
