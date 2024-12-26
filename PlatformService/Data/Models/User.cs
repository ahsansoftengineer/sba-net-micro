using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models;
public class Employee
{
  [Key]
  [Required]
  public int ID { get; set; }
  [Required]
  public string Name { get; set; }
  [Required]
  public string Gender { get; set; }
}