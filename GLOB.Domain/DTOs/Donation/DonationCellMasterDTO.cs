using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs.Donation;
public class DonationCellMasterDto : DtoRead
{
  public string? Address { get; set; }
  public int LocationzId { get; set; }
  public DtoSelect? Locationz { get; set; }
  public int MajlisId { get; set; }
  public DtoSelect? Majlis { get; set; }
  //public int BGId { get; set; }
  //public DtoSelect? BG { get; set; }
  //public int LEId { get; set; }
  //public DtoSelect? LE { get; set; }
  //public int OUId { get; set; }
  //public DtoSelect? OU { get; set; }
  public int SUId { get; set; }
  public DtoSelect? SU { get; set; }
}
public class DonationCellMasterDtoCreate : DtoCreate
{
  public string? Address { get; set; }
  public int LocationzId { get; set; }
  public int MajlisId { get; set; }
  //public int BGId { get; set; }
  //public int LEId { get; set; }
  //public int OUId { get; set; }
  public int SUId { get; set; }
}
public class DonationCellMasterDtoSearch : DtoSearch
{
  public string? Address { get; set; }
  public int? LocationzId { get; set; }
  public int? MajlisId { get; set; }
  //public int? BGId { get; set; }
  //public int? LEId { get; set; }
  //public int? OUId { get; set; }
  public int? SUId { get; set; }
}