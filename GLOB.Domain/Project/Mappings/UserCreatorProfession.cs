using System.ComponentModel.DataAnnotations.Schema;

namespace GLOB.Domain.Entity;
public class Mapping_UserCreatorProfession
{
  // public int ID { get; set; }
  public int? UserCreatorID { get; set; }
  [NotMapped]
  public UserCreator? UserCreator { get; set; }

  public int? ProfessionID { get; set; }
  [NotMapped]
  public Profession? Profession { get; set; }
}
