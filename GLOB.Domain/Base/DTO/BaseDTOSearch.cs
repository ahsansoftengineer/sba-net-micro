namespace GLOB.Domain.Base;
public class BaseDtoSearchFull
{
  public int? Id { get; set; } = null;
  public string? Title { get; set; }
  public string? Desc { get; set; }
  public DateTime? DateFrom { get; set; }
  public DateTime? DateTo { get; set; }
}