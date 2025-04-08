using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs.Donation;
public class DonationSubTypeDto : DtoRead
{
  //public int DonationCategoryId { get; set; }
  //public DtoSelect? DonationCategory { get; set; }
  public int DonationTypeId { get; set; }
  public DtoSelect? DonationType { get; set; }
}
public class DonationSubTypeDtoCreate : DtoCreate
{
  //public int DonationCategoryId { get; set; }
  public int DonationTypeId { get; set; }
}
public class DonationSubTypeDtoSearch : DtoSearch
{
  //public int? DonationCategoryId { get; set; }
  public int? DonationTypeId { get; set; }
}