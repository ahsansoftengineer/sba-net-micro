namespace GLOB.Domain.Entity;
public class UserCreatorIndustry
{
  // public int ID { get; set; }
  public int? UserCreatorID { get; set; }
  public UserCreator? UserCreator { get; set; }

  public int? IndustryID { get; set; }
  public Industry? Industry { get; set; }
}
