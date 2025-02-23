using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GLOB.Domain.Hierarchy;
public class TestApiUser : IdentityUser
{
  public string? FirstName { get; set; }
  public string? LastName { get; set; }

  [DataType(DataType.PhoneNumber)]
  public override string? PhoneNumber { get; set; }

  public List<IdentityRole>? Roles { get; set; }
}