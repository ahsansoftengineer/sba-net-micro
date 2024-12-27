using System.ComponentModel.DataAnnotations;

namespace PlatformService.DTO;
public class EmployeeCreateDto
{
  [Required]
  public string Name { get; set; }
  [Required]
  public string Gender { get; set; }
}