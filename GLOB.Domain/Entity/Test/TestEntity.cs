using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GLOB.Domain.Entity;
public class TestEntity
{
  public int ID {get; set;}
  [MaxLength(50)]
  public required string Name {get; set;}
  public string? Desc {get; set;}
  [Display(Name="Price per Night")]
  [Range(10, 10000)]
  public double Price {get; set;}
  public int Sqft {get; set;}
  [Range(1,10)]
  public int Occupancy {get; set;}
  [Display(Name="Image Url")]
  public string? ImageUrl {get; set;}
  [Column("Created_Date")]
  public DateTime? CreatedDate {get; set;}
  [Column("Updated_Date")]
  public DateTime? UpdatedDate {get; set;}
}