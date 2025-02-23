using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs.Donation;
public class TargetAssignmentDto : DtoRead
{
  public DateTime TargetFrom { get; set; }
  public DateTime TargetFor { get; set; }
  public int IncreasePercentage { get; set; }

  public int SystemzId { get; set; }
  public DtoSelect? Systemz { get; set; }

  public int MajlisId { get; set; }
  public DtoSelect? Majlis { get; set; }

  public int SUId { get; set; }
  public DtoSelect? SU { get; set; }
}
public class TargetAssignmentDtoCreate : DtoCreate
{
  public DateTime TargetFrom { get; set; }
  public DateTime TargetFor { get; set; }
  public int IncreasePercentage { get; set; }
  public int SystemzId { get; set; }
  public int MajlisId { get; set; }
  public int SUId { get; set; }
}
public class TargetAssignmenteDtoSearch : BaseDtoSearchFull
{
  public DateTime? TargetFrom { get; set; }
  public DateTime? TargetFor { get; set; }
  public int? IncreasePercentage { get; set; }
  public int? SystemzId { get; set; }
  public int? MajlisId { get; set; }
  public int? SUId { get; set; }
}