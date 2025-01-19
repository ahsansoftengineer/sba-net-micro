using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs.Donation;
public class DonationSubTypeDto : BaseDtoFull
{
  //public int DonationCategoryId { get; set; }
  //public BaseDtoRelation? DonationCategory { get; set; }
  public int DonationTypeId { get; set; }
  public BaseDtoRelation? DonationType { get; set; }
}
public class DonationSubTypeDtoCreate : BaseDtoCreate
{
  //public int DonationCategoryId { get; set; }
  public int DonationTypeId { get; set; }
}
public class DonationSubTypeDtoSearch : BaseDtoSearchFull
{
  //public int? DonationCategoryId { get; set; }
  public int? DonationTypeId { get; set; }
}