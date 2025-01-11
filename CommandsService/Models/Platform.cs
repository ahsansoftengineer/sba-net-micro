namespace CommandsService.Models;
public class Platform
{
  public int Id { get; set; }
  public int ExternalID { get; set; }
  public string Name { get; set; }
  public ICollection<Command> Commands { get; set; }
}