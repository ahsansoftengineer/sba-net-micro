namespace GLOB.Domain.Enums;
public enum DonationOption
{
  OptionGSB,
  OptionSelf,
  OptionMarhoom
}
public enum Gender
{
  None,
  Male,
  Female
}
public enum Status
{
  None,
  Active,
  DeActive,
  Delete
}
public enum YesNo
{
  No,
  Yes,
}
//public class Status
//{
//  private Status(string value) { Value = value; }

//  public string Value { get; private set; }

//  public static Status None { get { return new Status("None"); } }
//  public static Status Activate { get { return new Status("Activate"); } }
//  public static Status DeActivate { get { return new Status("De-Activate"); } }
//  public override string ToString()
//  {
//  return Value;
//  }
//}