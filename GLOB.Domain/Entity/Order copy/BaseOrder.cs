using System.ComponentModel.DataAnnotations.Schema;
namespace GLOB.Domain.Entity;
public abstract class BaseOrder : BaseBaseEntity
{
  public required string Message { get; set; } // Business Iquriy, (Standard / Custom) Order Message
  // ID = InquiryID
  public UserCreator? UserCreator { get; set; }
  public int? UserCreatorID { get; set; }
  public SHOUTOUT_TYPE? ShoutoutType { get; set; }
  public DateTimeOffset DeliveryDate { get; set; }
  // Order when Complete
  public string? UrlVideo { get; set; }
  public string? UrlThumbnail { get; set; }
  public STATUS_ORDER? StatusOrder { get; set; }
  public string? OrderDeclinedReason { get; set; }


  // public int BusinessInquiryID { get; set;} // Delete
  // public string CreatorName { get; set;} // Delete
  // public string Reason { get; set;} // Desc
  // public string CreatedBy { get; set; }
  // public string ModifiedBy { get; set; }
}
