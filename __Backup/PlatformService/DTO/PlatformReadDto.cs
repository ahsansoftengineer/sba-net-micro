using System.ComponentModel.DataAnnotations;

namespace PlatformService.DTO;
public class PlatformReadDto
{
  public int ID { get; set; }
  public string Name { get; set; }
  public string Publisher { get; set; }
  public string Cost { get; set; }
}