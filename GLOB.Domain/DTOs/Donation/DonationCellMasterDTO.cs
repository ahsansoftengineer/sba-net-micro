using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs.Donation;
public class DonationCellMasterDto : BaseDtoFull
{
  public string? Address { get; set; }
  public int LocationzId { get; set; }
  public BaseDtoSelect? Locationz { get; set; }
  public int MajlisId { get; set; }
  public BaseDtoSelect? Majlis { get; set; }
  //public int BGId { get; set; }
  //public BaseDtoSelect? BG { get; set; }
  //public int LEId { get; set; }
  //public BaseDtoSelect? LE { get; set; }
  //public int OUId { get; set; }
  //public BaseDtoSelect? OU { get; set; }
  public int SUId { get; set; }
  public BaseDtoSelect? SU { get; set; }
}
public class DonationCellMasterDtoCreate : BaseDtoCreate
{
  public string? Address { get; set; }
  public int LocationzId { get; set; }
  public int MajlisId { get; set; }
  //public int BGId { get; set; }
  //public int LEId { get; set; }
  //public int OUId { get; set; }
  public int SUId { get; set; }
}
public class DonationCellMasterDtoSearch : BaseDtoSearchFull
{
  public string? Address { get; set; }
  public int? LocationzId { get; set; }
  public int? MajlisId { get; set; }
  //public int? BGId { get; set; }
  //public int? LEId { get; set; }
  //public int? OUId { get; set; }
  public int? SUId { get; set; }
}