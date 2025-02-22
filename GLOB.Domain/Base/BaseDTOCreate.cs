using System.ComponentModel.DataAnnotations;
using GLOB.Domain.Enums;

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
  public DateTimeOffset? CreatedAt { get; set; }
  public DateTimeOffset? UpdatedAt { get; set; }
  public Status? Status { get; set; } // = Status.None;

}
public class BaseDtoSelect
{
  public int Id { get; set; }
  public string Title { get; set; } = "";
}
public class BaseDtoUpdateFull : BaseDtoCreate
{
  //public IList<CreateHotelDTO> Hotels { get; set; } //
}