using System.ComponentModel.DataAnnotations.Schema;

namespace GLOB.Domain.Hierarchy;
public class Mapping_UserBusinessIndustry
{
  // public int ID { get; set; }
  public int? UserBusinessID { get; set; }
  [NotMapped]
  public UserBusiness? UserBusiness { get; set; }

  public int? IndustryID { get; set; }
  [NotMapped]
  public Industry? Industry { get; set; }
}
