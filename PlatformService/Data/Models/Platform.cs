using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models;
public class Platform
{
  [Key]
  [Required]
  public int ID { get; set; }
  [Required]
  public string Name { get; set; }
  [Required]
  public string Publisher { get; set; }
  [Required]
  public string Cost { get; set; }
}