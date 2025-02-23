using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs.Donation;
public class DonationTypeDto : DtoRead
{
  public int SysmanAccountId { get; set; }
  public DtoSelect? SysmanAccount { get; set; }

  public int COAId { get; set; }
  public DtoSelect? COA { get; set; }

  public int DonationCategoryId { get; set; }
  public DtoSelect? DonationCategory { get; set; }
}
public class DonationTypeDtoCreate : DtoCreate
{
  public int SysmanAccountId { get; set; }
  public int COAId { get; set; }
  public int DonationCategoryId { get; set; }
}
public class DonationTypeDtoSearch : BaseDtoSearchFull
{
  public int? SysmanAccountId { get; set; }
  public int? COAId { get; set; }
  public int? DonationCategoryId { get; set; }
}