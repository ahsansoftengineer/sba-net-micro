namespace GLOB.Domain.Entity;
public class UserCreatorProfession
{
  // public int ID { get; set; }
  public int? UserCreatorID { get; set; }
  public UserCreator? UserCreator { get; set; }

  public int? ProfessionID { get; set; }
  public Profession? Profession { get; set; }
}
