using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs.Donation;
public class DonationTypeDto : BaseDtoFull
{
  public int SysmanAccountId { get; set; }
  public BaseDtoSelect? SysmanAccount { get; set; }

  public int COAId { get; set; }
  public BaseDtoSelect? COA { get; set; }

  public int DonationCategoryId { get; set; }
  public BaseDtoSelect? DonationCategory { get; set; }
}
public class DonationTypeDtoCreate : BaseDtoCreate
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