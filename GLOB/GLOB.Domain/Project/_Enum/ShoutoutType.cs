using GLOB.Infra.Decorator;

namespace GLOB.Domain.Enumz;

public enum SHOUTOUT_TYPE : int
{
  [EnumAtr("None")]
  NONE = 0,
  [EnumAtr("Standard Order")]
  STANDARD = 1,
  [EnumAtr("Custom Order")]
  CUSTOM = 2,
  [EnumAtr("Business Order")]
  BUSINESS = 3,
  [EnumAtr("Business Multi Order")]
  BUSINESS_MULTI = 4,
}
//  Console.WriteLine(GetEnumDescription(OrderStatus.Shipped));
