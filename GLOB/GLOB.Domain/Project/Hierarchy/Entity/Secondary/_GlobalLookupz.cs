using System.ComponentModel.DataAnnotations.Schema;

namespace GLOB.Hierarchy.Global;

public class GlobalLookup : EntityBase
{
  // Generated by End User (PayStatus-Active, PayStatus-Deactive, Guids, 001-0002-0003)
  // Pregenerated Key Because of Applying Conditions on (Backend / FrontEnd)
  public string? Code { get; set; } = null;
  [ForeignKey(nameof(GlobalLookupBase))]
  public int? GlobalLookupBaseId { get; set; }
  [ForeignKey("GlobalLookupBaseId")]
  public virtual GlobalLookupBase? GlobalLookupBase { get; set; }
}

public class GlobalLookupDtoRead : DtoRead
{
  public string? Code { get; set; } = null;
  public int GlobalLookupBaseId { get; set; }
  public DtoSelect? GlobalLookupBase { get; set; }
}
public class GlobalLookupDtoCreate : DtoCreate
{
  public string? Code { get; set; } = null;
  public int GlobalLookupBaseId { get; set; }
}
public class GlobalLookupDtoSearch : DtoSearch
{
  public string? Code { get; set; } 
  public int? GlobalLookupBaseId { get; set; }
}