using System.ComponentModel.DataAnnotations.Schema;

namespace GLOB.Domain.Entity;
public class Mapping_UserCreatorIndustry
{
  // public int ID { get; set; }
  public int? UserCreatorID { get; set; }
  [NotMapped]
  public UserCreator? UserCreator { get; set; }

  public int? IndustryID { get; set; }
  [NotMapped]
  public Industry? Industry { get; set; }
}
