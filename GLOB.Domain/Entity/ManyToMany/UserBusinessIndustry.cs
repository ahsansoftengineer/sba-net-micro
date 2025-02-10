namespace GLOB.Domain.Entity;
public class UserBusinessIndustry
{
  // public int ID { get; set; }
  public int? UserBusinessID { get; set; }
  public UserBusiness? UserBusiness { get; set; }

  public int? IndustryID { get; set; }
  public Industry? Industry { get; set; }
}
