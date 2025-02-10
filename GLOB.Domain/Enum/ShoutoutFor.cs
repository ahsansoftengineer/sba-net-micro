using GLOB.Domain.Decorator;

namespace GLOB.Domain.Enum;

public enum SHOUTOUT_FOR
{
  [EnumAtr("None")]
  NONE = 0,
  [EnumAtr("For Me")]
  FOR_ME = 1,
  [EnumAtr("For Someone Else")]
  FOR_ELSE = 2,
}
