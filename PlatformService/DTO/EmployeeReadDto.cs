using System.ComponentModel.DataAnnotations;

namespace PlatformService.DTO;
public class EmployeeReadDto
{
  public int ID { get; set; }
  public string Name { get; set; }
  public string Gender { get; set; }
}