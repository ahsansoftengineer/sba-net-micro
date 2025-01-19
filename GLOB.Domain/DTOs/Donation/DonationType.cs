using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs.Donation;
public class DonationTypeDto : BaseDtoFull
{
  public int SysmanAccountId { get; set; }
  public BaseDtoRelation? SysmanAccount { get; set; }

  public int COAId { get; set; }
  public BaseDtoRelation? COA { get; set; }

  public int DonationCategoryId { get; set; }
  public BaseDtoRelation? DonationCategory { get; set; }
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