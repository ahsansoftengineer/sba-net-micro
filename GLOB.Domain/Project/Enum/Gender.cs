using GLOB.Domain.Decorator;

namespace GLOB.Domain.Enum;

public enum GENDER
{
  [EnumAtr("None")]
  NONE = 0,
  [EnumAtr("Male")]
  MALE = 1,
  [EnumAtr("Female", "Icons")]
  FEMALE = 2,
  [EnumAtr("Other")]
  OTHER = 3,
}
