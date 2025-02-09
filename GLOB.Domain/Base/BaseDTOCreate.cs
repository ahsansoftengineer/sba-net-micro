using System.ComponentModel.DataAnnotations;

namespace GLOB.Domain.Base;
public class BaseDtoCreate
{
  [Required]
  [StringLength(maximumLength: 50, ErrorMessage = "Max Characters 50 Allowed")]
  public string Title { get; set; } = "";
  [StringLength(maximumLength: 100, ErrorMessage = "Max Characters 100 Allowed")]
  public string? Desc { get; set; }

}
public class BaseDtoFull : BaseDtoCreate
{
  public int? Id { get; set; } = null;
  public DateTime? CreatedAt { get; set; }
  public DateTime? UpdatedAt { get; set; }
}
public class BaseDtoRelation
{
  public int Id { get; set; }
  public string Title { get; set; } = "";
}
public class BaseDtoUpdateFull : BaseDtoCreate
{
  //public IList<CreateHotelDTO> Hotels { get; set; } //
}